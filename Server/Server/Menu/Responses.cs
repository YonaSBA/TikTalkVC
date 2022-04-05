using System.Collections.Generic;

namespace Server
{
    public class GetHistoryResponse
    {
        public List<MeetingData> meetings { get; set; }
    }
    public class JoinMeetingResponse
    {
        public int participant { get; set; }
        public Dictionary<int, string> participants { get; set; }
    }
    public class CreateRequestResponse
    {
        public string meeting { get; set; }
        public int participant { get; set; }
    }
    public class GetSettingsResponse
    {
        public string settings { get; set; }
    }
}
