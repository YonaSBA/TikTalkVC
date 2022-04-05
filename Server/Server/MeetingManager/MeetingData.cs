using System;
using System.Collections.Generic;

namespace Server
{
    public class MeetingData
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public HashSet<string> participants { get; set; }

        public MeetingData(DateTime start, DateTime end, HashSet<string> participants)
        {
            this.end = end;
            this.start = start;
            this.participants = participants;
        }
    }
}
