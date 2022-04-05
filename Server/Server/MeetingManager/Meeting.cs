using System;
using System.Collections.Generic;
using System.Net;

namespace Server
{
    public class Meeting
    {
        public bool m_locked { get; set; }
        public Dictionary<string, int> m_waitingList { get; private set; }
        private string m_hostToken { get; set; }
        private int m_hostID { get; set; }
        private int m_idCounter { get; set; }
        private string m_subject { get; set; }
        private DateTime m_startTime { get; }
        private Streamer m_streamer { get; }
        public Hospitality m_hospitality { get; private set; }
        private Dictionary<int, Participant> m_participants { get; set; }
        private HashSet<string> m_nicknames { get; set; }

        public Meeting(string hostToken, Participation p, Trio<IPEndPoint, IPEndPoint, IPEndPoint> udps, Trio<int, int, int> ports, string username, string subject = "No subject")
        {
            m_hostID = 0;
            m_idCounter = 0;
            m_locked = false;
            m_subject = subject;
            m_hostToken = hostToken;
            m_startTime = DateTime.Now;
            m_nicknames = new HashSet<string>();
            m_waitingList = new Dictionary<string, int>();
            m_participants = new Dictionary<int, Participant>();
            m_participants.Add(0, new Participant(hostToken, 0, p));
            m_streamer = new Streamer(ports);
            m_streamer.AddUser(m_idCounter, udps);
            m_nicknames.Add(username);
        }

        public int AddUser(string token, Participation p, Trio<IPEndPoint, IPEndPoint, IPEndPoint> udps, string username)
        {
            try
            {
                m_idCounter++;
                m_participants.Add(m_idCounter, new Participant(token, m_idCounter, p));
                m_streamer.AddUser(m_idCounter, udps);
                m_nicknames.Add(username);

                return m_idCounter;
            }
            catch (Exception)
            {
                Console.WriteLine("meeting line 38 error");
                throw;
            }
        }

        public void RemoveUser(int id)
        {
            m_streamer.RemoveUser(id);
            if (!m_participants.Remove(id))
                Console.WriteLine("meeting line 46");
        }

        public int SwichHost(int id = 0)
        {
            if (id == 0)
            {
                if (m_participants.Count > 1)
                    foreach (var item in m_participants)
                    {
                        if (CheckHost(item.Value.m_token))
                            continue;
                        m_hostToken = item.Value.m_token;
                        m_hostID = item.Key;
                        Console.WriteLine("the meeting has new host named " + item.Value.m_participation.nickname);
                        return item.Key;
                    }
                return 0;
            }
            else
            {
                if (m_participants.ContainsKey(id))
                {
                    m_hostToken = m_participants[id].m_token;
                    m_hostID = id;
                }
                else
                    throw new NoSuchIdExpection();
                return id;
            }
        }

        public MeetingData Close()
        {
            MeetingData data = new MeetingData(m_startTime, DateTime.Now, GetNicknames());
            if (m_participants.Count != 0)
            {
                foreach (var v in m_participants)
                {
                    v.Value.AddUpdate(new Update(UpdatesCodes.END, null, m_hostID));
                    m_participants.Remove(v.Key);
                }
            }
            m_streamer.Close();

            return data;
        }

        public void SetHospitality(Hospitality hospitality)
        {
            m_hospitality = hospitality;
        }
        public void Rename(int id, string newName)
        {
            m_participants[id].Rename(newName);
        }
        public void UpdateCam(int id, bool open)
        {
            m_participants[id].UpdateCam(open);
        }
        public HashSet<string> GetNicknames()
        {
            return m_nicknames;
        }
        public void UpdateMic(int id, bool open)
        {
            m_participants[id].UpdateMic(open);
        }

        public void UpdateAllw(string code, bool open)
        {
            switch (code)
            {
                case MeetingCodes.ALLOW_CHAT:
                    m_hospitality.chat = open;
                    break;
                case MeetingCodes.ALLOW_SHOW:
                    m_hospitality.start_video = open;
                    break;

                case MeetingCodes.ALLOW_SHARE:
                    m_hospitality.share_screen = open;
                    break;

                case MeetingCodes.ALLOW_UNMUTE:
                    m_hospitality.unmute = open;
                    break;

                case MeetingCodes.ALLOW_RENAME:
                    m_hospitality.rename = open;
                    break;

                default:
                    throw new NoSuchAllowenceExpection();

            }
        }

        public void ChangeAll(bool trueIsVideo)
        {
            if (trueIsVideo)
            {
                foreach (var item in m_participants.Values)
                {
                    if (item.m_token != m_hostToken)
                    {
                        item.UpdateCam(false);
                    }
                }
            }
            else
            {
                foreach (var item in m_participants)
                {
                    if (item.Value.m_token != m_hostToken)
                    {
                        item.Value.UpdateMic(false);
                    }
                }
            }
        }
        public void ShereScreen(int id, bool open)
        {
            m_participants[id].UpdateShereScreen(open);
        }

        public void ChangeBackground(int id, byte[] background)
        {
            m_participants[id].m_participation.background = background;
        }

        public List<Update> GetUpdates(int id)
        {
            var a = m_participants[id].GetUpdates();
            m_participants[id].CleanUpdates();
            return a;
        }

        public void UpdateAll(Update update, int id)
        {
            foreach (var p in m_participants)
            {
                if (p.Key != id)
                    p.Value.AddUpdate(update);
            }
        }

        public void UpdateOne(Update update, int id)
        {

            m_participants[id].AddUpdate(update);
        }

        public void UpdateHost(Update update)
        {
              m_participants[m_hostID].AddUpdate(update);
        }

        public Dictionary<int, Participation> GetParticipants()
        {
            var p = new Dictionary<int, Participation>();
            foreach (var key in m_participants.Keys)
            {
                p[key] = m_participants[key].m_participation;
            }
            return p;
        }

        public int GetIdByToken(string token)
        {
            foreach (var item in m_participants)
            {
                if (item.Value.CheckToken(token))
                    return item.Key;
            }
            throw new NotImplementedException();
        }

        public Trio<int, int, int> GetPorts() { return m_streamer.GetPorts(); }
        public string GetSubject() { return m_subject; }
        public int GetHostID() { return m_hostID; }
        public bool Empty() { return m_participants.Count == 0; }
        public DateTime GetTime() { return m_startTime; }
        public bool CheckHost(string token) { return m_hostToken == token; }
        public bool CheckParticipant(string token, int id) { return m_participants[id].CheckToken(token); } 
        public bool FindParticipant(int id) { return m_participants.ContainsKey(id); } 
    }
}