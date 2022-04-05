using System.Collections.Generic;

namespace Server
{
    public class HandShakeResponse
    {
        public Trio<int, int, int> ports { get; set; }
    }
    public class MeetingResponses
    {
        public List<MeetingData> participants { get; set; } 
    }

    public class JoinMeeting
    {
        public Dictionary<int, Participation> participants { get; set; }
        public int participant { get; set; }
        public int host { get; set; }
    }
}
