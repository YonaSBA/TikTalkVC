using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Server
{
    public class MeetingManager
    {
        ClientsManager m_cliensManager;
        IMeetingsQueries m_meetingsQueries;
        Dictionary<string, Meeting> m_meetings;
        private RequestHandlerFactory m_requestHandlerFactory;

        public MeetingManager(ref IMeetingsQueries meetingsQweries, ref ClientsManager clientsManager)
        {
            m_cliensManager = clientsManager;
            m_meetingsQueries = meetingsQweries;
            m_meetings = new Dictionary<string, Meeting>();
        }

        public string CreateMeeting(string token, Participation p, Trio<int, int, int> streamerPorts, Trio<int, int, int> ports, string username)
        {
            string id = GenerateId();

            Console.WriteLine("New meeting id is: "+ id);
            m_cliensManager.GetClient(token).SetUDPEndPoints(ports);
            m_meetings.Add(id, new Meeting(token, p, m_cliensManager.GetClient(token).GetUDPEndPoints(), streamerPorts, username));
            return id;
        }

        public Tuple<int, Dictionary<int, Participation>, int> JoinMeeting(string meetingID, string token, Participation p, Trio<int, int, int> ports, string username)
        {
            try
            {
                var a = m_meetings[meetingID].GetParticipants();
                m_cliensManager.GetClient(token).SetUDPEndPoints(ports);
                int participantID = m_meetings[meetingID].AddUser(token, p, m_cliensManager.GetClient(token).GetUDPEndPoints(), username);
                
                m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.ADD, JsonSerializer.Serialize(p), participantID), participantID);
                return new Tuple<int, Dictionary<int, Participation>, int>(participantID, a, m_meetings[meetingID].GetHostID());
            }
            catch (KeyNotFoundException)
            {
                throw new NotExistingMeetingExpection();
            }
        }
        public void LeaveMeeting(string meetingID, string token, int participantID)
        {
            if (!m_meetings[meetingID].CheckParticipant(token, participantID))
                if (!m_meetings[meetingID].CheckHost(token))
                    throw new NoPermissionException();

            if (participantID == m_meetings[meetingID].GetHostID())
            {
                SwichHost(meetingID, token, 0);
            }
            m_meetings[meetingID].RemoveUser(participantID);
            m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.REMOVE, null, participantID), -1);

            if (m_meetings[meetingID].Empty())
            {
                m_meetingsQueries.AddNewMeeting(m_meetings[meetingID].Close());
                if (!m_meetings.Remove(meetingID))
                    Console.WriteLine("meeting manager line 55");
            
            }
        }

        public void LeaveMeeting(string meetingID, int participantID)
        {
            if (participantID == m_meetings[meetingID].GetHostID())
            {
                SwichHost(meetingID, "hosttoken",  0);
            }
            m_meetings[meetingID].RemoveUser(participantID);
            m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.REMOVE, null, participantID), -1);


            if (m_meetings[meetingID].Empty())
            {
                m_meetingsQueries.AddNewMeeting(m_meetings[meetingID].Close());
                if (!m_meetings.Remove(meetingID))
                    Console.WriteLine("meeting manager line 68");
            }
            Console.WriteLine("client " + participantID.ToString() +  " crushed out of meeting: " + meetingID);
        }

        public void CloseMeeting(string meetingID, string token)
        {
            if (!m_meetings[meetingID].CheckHost(token))
                throw new NoPermissionException();

            m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.END, null, 0), 0);

            m_meetingsQueries.AddNewMeeting(m_meetings[meetingID].Close());

            if (!m_meetings.Remove(meetingID))
                Console.WriteLine("meeting manager line 61");
        }

        public void Rename(string meetingID, string token, int participantID, string newName)
        {
            bool isHost = m_meetings[meetingID].CheckHost(token);
            if ((!m_meetings[meetingID].CheckParticipant(token, participantID) ||
                !m_meetings[meetingID].m_hospitality.rename) &&
                !isHost)
                throw new NoPermissionException();

            m_meetings[meetingID].Rename(participantID, newName);

            m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.RENAME, newName, participantID), -1);
        }

        public void Kick(string meetingID, string token, int participantID)
        {
            bool isHost = m_meetings[meetingID].CheckHost(token);
            if (!isHost)
                throw new NoPermissionException();
            if (participantID == m_meetings[meetingID].GetHostID())
                throw new CantKickYourselfExpection();

            m_meetings[meetingID].RemoveUser(participantID);

            m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.REMOVE, null, participantID),
                -1);
                //isHost ? m_meetings[meetingID].GetHostID() : participantID);
        }

        public void UpdateCam(string meetingID, string token, int participantID, bool open)
        {
            bool isHost = m_meetings[meetingID].CheckHost(token);
            if ((!m_meetings[meetingID].CheckParticipant(token, participantID) ||
                (!m_meetings[meetingID].m_hospitality.start_video && open)) &&
                !isHost)
                throw new NoPermissionException();

            m_meetings[meetingID].UpdateCam(participantID, open);

            m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.VIDEO, open.ToString(), participantID),
                isHost ? m_meetings[meetingID].GetHostID() : participantID);
        }

        public void UpdateMic(string meetingID, string token, int participantID, bool open)
        { 
            bool isHost = m_meetings[meetingID].CheckHost(token);
            if ((!m_meetings[meetingID].CheckParticipant(token, participantID) ||
                (!m_meetings[meetingID].m_hospitality.unmute && open)) &&
                !isHost)
                throw new NoPermissionException();

            m_meetings[meetingID].UpdateMic(participantID, open);

            m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.AUDIO, open.ToString(), participantID), 
                isHost ? m_meetings[meetingID].GetHostID() : participantID);
        }

        public void UpdateAllowence(string meetingID, string token, int participantID, string code,  bool open)
        { 
            bool isHost = m_meetings[meetingID].CheckHost(token);
            if (!isHost)
                throw new NoPermissionException();
            m_meetings[meetingID].UpdateAllw(code, open);
        }
        public void ShereScreen(string meetingID, string token, int participantID, bool open)
        {
            bool isHost = m_meetings[meetingID].CheckHost(token);
            if ((!m_meetings[meetingID].CheckParticipant(token, participantID) ||
                (!m_meetings[meetingID].m_hospitality.share_screen && open)) &&
                !isHost)
                throw new NoPermissionException();

            m_meetings[meetingID].ShereScreen(participantID, open);

            m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.SHARE_SCREEN, open.ToString(), participantID),
                     isHost && participantID != m_meetings[meetingID].GetHostID() ? -1 : participantID);
        }

        public void ChangeBackground(string meetingID, string token, int participantID, byte[] background)
        {
            m_meetings[meetingID].ChangeBackground(participantID, background);
            m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.CHANGE_BACKGROUND, Convert.ToBase64String(background), participantID), m_meetings[meetingID].CheckHost(token) ? m_meetings[meetingID].GetHostID() : participantID);
        }

        public void SendMassage(string meetingID, string token, int participantID, string massage, int destId)
        {
            bool isHost = m_meetings[meetingID].CheckHost(token);

            if ((!m_meetings[meetingID].CheckParticipant(token, participantID) ||
                !m_meetings[meetingID].m_hospitality.chat) &&
                !isHost)
                throw new NoPermissionException();

            if (destId != -1)
            {
                m_meetings[meetingID].UpdateOne(new Update(UpdatesCodes.NEW_MESSAGE, JsonSerializer.Serialize(new Pair<string, bool>(massage, true)), participantID), destId);
                return;
            }

            m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.NEW_MESSAGE, JsonSerializer.Serialize(new Pair<string, bool>(massage, false)), participantID), 
                isHost && participantID != m_meetings[meetingID].GetHostID() ? -1 : participantID);
        }

        public void SwichHost(string meetingID, string token, int participantID)
        {
            bool isHost = m_meetings[meetingID].CheckHost(token);
            if (token == "hosttoken")
                isHost = true;
            if (!isHost)
                throw new NoPermissionException();

            int id = m_meetings[meetingID].SwichHost(participantID);

            m_meetings[meetingID].UpdateAll(new Update(UpdatesCodes.NEW_HOST, null, id), -1);
        }

        public void ChangeHospitality(string meetingID, string token, int participantID, Hospitality hospitality)
        {
            bool isHost = m_meetings[meetingID].CheckHost(token);

            if (!isHost)
                throw new NoPermissionException();

            m_meetings[meetingID].SetHospitality(hospitality);
        }
        public List<Update> Update(string meetingID, string token, int participantID)
        {
            if (!m_meetings.ContainsKey(meetingID))
                throw new Close();
            if (!m_meetings[meetingID].FindParticipant(participantID))
                throw new Kick();
            if (!m_meetings[meetingID].CheckParticipant(token, participantID))
                throw new NoPermissionException();
            var a = m_meetings[meetingID].GetUpdates(participantID);

            return a;
        }
        public string GetMeetingsHistory(string username) 
        {
            List<MeetingData> history = m_meetingsQueries.GetMeetingsHistory(username);
            
            if (!history.Any())
                throw new EmptyHistoryException();

            return JsonSerializer.Serialize(history);
        }

        private string GenerateId()
        {
            Random generator = new Random();
            string r;
            do
            {
                r = generator.Next(0, 1000000).ToString("D6");
            } while (m_meetings.ContainsKey(r));
            return r;
        }
        
        public Trio<int, int, int> GeneratePorts()
        {
            Random rnd = new Random();
            int[] ports = { 0, 0, 0 };
            for (int i = 0; i < ports.Length; i++)
            {
                do
                {
                    ports[i] = rnd.Next(10000, 20000);
                } while (CheckPort(ports[i]) && Array.IndexOf(ports, ports[i]) != i); // just check that the element not in the arrrey alredy
            }
            return new Trio<int, int, int>(ports[0], ports[1], ports[2]);
        }

        public Trio<int, int, int> GetPorts(string meetingId) 
        {
            try
            {
                return m_meetings[meetingId].GetPorts();
            }
            catch (Exception)
            {
                throw new NotExistingMeetingExpection();
            }
        }
        public void LockMeeting(string meetingID, string token, bool locked)
        {
            bool isHost = m_meetings[meetingID].CheckHost(token);
            if (!isHost)
                throw new NoPermissionException();

            m_meetings[meetingID].m_locked = locked;
        }

        public void UpdateWaitingRoom(string meetingID, string token, bool locked)
        {
            bool isHost = m_meetings[meetingID].CheckHost(token);
            if (!isHost)
                throw new NoPermissionException();
            if (!locked)
                m_meetings[meetingID].m_waitingList.Clear();
            m_meetings[meetingID].m_hospitality.waiting_room = locked;
        }

        public static bool CheckPort(int port) // todo
        {
            return true;
        }

        public void ChangeAll(string meetingID, string token, bool trueIsVideo)
        {
            bool isHost = m_meetings[meetingID].CheckHost(token);
            if (!isHost)
                throw new NoPermissionException();

            m_meetings[meetingID].ChangeAll(trueIsVideo);
            var code = trueIsVideo ? UpdatesCodes.HIDE_ALL : UpdatesCodes.MUTE_ALL; 
            m_meetings[meetingID].UpdateAll(new Update(code, null, -1), -1);
        }

        public void TryJoining(string meetingID, string username, bool wantIn, ref string waitingRoom)
        {
            // todo deal with if man in waiting room and meeting closes
            try
            { 
                if (m_meetings[meetingID].m_locked)
                    throw new LockedMeetingException();
            }
            catch (KeyNotFoundException) { waitingRoom = null; throw new NotExistingMeetingExpection(); }

            if (!m_meetings[meetingID].m_hospitality.waiting_room)
                return;
            int res = 0;
            if (!wantIn)
            {
                m_meetings[meetingID].m_waitingList.Remove(username);
                m_meetings[meetingID].UpdateHost(new Update(UpdatesCodes.CONFIRMATION, JsonSerializer.Serialize(new Pair<bool, string>(WaitingCodes.OUT, username)), -1));
                waitingRoom = null;
                throw new WaitingRoom();
            }
            if (!m_meetings[meetingID].m_waitingList.TryGetValue(username, out res))
            {
                m_meetings[meetingID].UpdateHost(new Update(UpdatesCodes.CONFIRMATION, JsonSerializer.Serialize(new Pair<bool, string>(WaitingCodes.IN ,username)), -1));
                if (!m_meetings[meetingID].m_waitingList.ContainsKey(username))
                {
                    m_meetings[meetingID].m_waitingList.Add(username, WaitingCodes.NO_ASNWER);
                    waitingRoom = meetingID;
                }
                throw new WaitingRoom();
            }
            else
            {
                if (res == WaitingCodes.REJECTED)
                {
                    m_meetings[meetingID].m_waitingList.Remove(username);
                    throw new GotRejectedException();
                }
                if (res == WaitingCodes.ALLOED)
                {
                    m_meetings[meetingID].m_waitingList.Remove(username);
                    return;
                }
                if (res == WaitingCodes.NO_ASNWER)
                    throw new WaitingRoom();
                Console.WriteLine("prob to fix meeting manager line 330");
            }
        }

        public void UpdateWaitingUser(string meetingID, string token, bool allowed, string username)
        {
            bool isHost = m_meetings[meetingID].CheckHost(token);
            if (!isHost)
                throw new NoPermissionException();

            m_meetings[meetingID].m_waitingList[username] = allowed ? WaitingCodes.ALLOED : WaitingCodes.REJECTED;
            m_meetings[meetingID].UpdateHost(new Update(UpdatesCodes.CONFIRMATION, JsonSerializer.Serialize(new Pair<bool, string>(WaitingCodes.OUT, username)), -1));
        }
        public bool IsMeetingExists(string id)
        {
            return m_meetings.ContainsKey(id);
        }

        public void LeaveWaitingRoom(string username, string meetingID)
        {
            m_meetings[meetingID].m_waitingList.Remove(username);
            m_meetings[meetingID].UpdateHost(new Update(UpdatesCodes.CONFIRMATION, JsonSerializer.Serialize(new Pair<bool, string>(WaitingCodes.OUT, username)), -1));
        }
    }

}
