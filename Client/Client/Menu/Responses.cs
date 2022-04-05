using System.Collections.Generic;

namespace Client
{
    public class HandShakeResponse
    {
        public Trio<int> ports { get; set; }
    }
    public class JoinMeetingResponse
    {
        public int host { get; set; }
        public int participant { get; set; }
        public Dictionary<int, Participation> participants { get; set; }
    } 
    public class GetSettingsResponse
    {
        public string settings { get; set; }
    }
    public class CreateMeetingResponse
    {
        public string meeting { get; set; }
        public int participant { get; set; }
    }
}