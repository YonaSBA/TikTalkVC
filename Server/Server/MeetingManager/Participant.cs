using System.Collections.Generic;

namespace Server
{
    class Participant
    {
        public string m_token { get; private set; }
        public Participation m_participation { get; private set; }
        private int m_meetingId { get; set; }
        private List<Update> m_updateList { get; set; }

        public Participant(string token, int id, Participation p)
        {
            m_token = token;
            m_meetingId = id;
            m_participation = p;
            m_updateList = new List<Update>();
        }
        public void Rename(string newName) { m_participation.nickname = newName; }
        public void UpdateCam(bool open) { m_participation.stop_video = !open; }
        public void UpdateMic(bool open) { m_participation.mute = !open; }
        public void UpdateShereScreen(bool open) => m_participation.share = open;
        public void AddUpdate(Update u) { m_updateList.Add(u); } 
        public List<Update> GetUpdates() { return m_updateList; }
        public void CleanUpdates() { m_updateList = new List<Update>(); }
        public bool CheckToken(string token) { return m_token == token; }
    }
}
