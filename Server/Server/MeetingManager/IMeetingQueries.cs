using System.Collections.Generic;

namespace Server
{
    public interface IMeetingsQueries
    {
        public void AddNewMeeting(MeetingData meeting);
        public List<MeetingData> GetMeetingsHistory(string username);
    }
}
