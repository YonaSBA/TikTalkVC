using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Server
{
    public static class MeetingCodes
    {
        public const string GET_STATUS = "300";
        public const string UPDATE_CAM = "301";
        public const string UPDATE_MIC = "302";

        public const string RENAME = "304";
        public const string CHANGE_BACKGROUND = "305";
        public const string SENT_MESSAGE = "306";
        public const string SHARE_SCREEN = "307";
        public const string LEAVE_MEETING = "308";


        public const string WAITING_ROOM = "310";
        public const string CONFIRMATION = "311";
        public const string LOCK_MEETING = "312";
        public const string KICK_USER = "313";
        public const string MAKE_HOST = "314";
        public const string CHANGE_HOSPITALITY = "315";
        public const string HIDE_ALL = "316";
        public const string MUTE_ALL = "317";
        public const string END_MEETING = "318";


        public const string ALLOW_CHAT = "320";
        public const string ALLOW_SHOW = "321";
        public const string ALLOW_SHARE = "322";
        public const string ALLOW_UNMUTE = "323";
        public const string ALLOW_RENAME = "324";

    }

    public static class WaitingCodes
    {
        public const short NO_ASNWER = 0;
        public const short REJECTED = -1;
        public const short ALLOED = 1;

        public const bool IN = true;
        public const bool OUT = false;

    }
    public class MeetingRequest 
    {
        //public string meeting { get; set; }
    }
    public class LeaveMeetingRequest : MeetingRequest
    {
        public int participant { get; set; }
    }

    public class CloseMeetingRequest : MeetingRequest 
    {
        public int participant { get; set; }
    }
    public class RenameRequest : MeetingRequest
    {
        public string nickname { get; set; }
        public int participant { get; set; }
    }

    public class ChangeBackgroundRequest : MeetingRequest
    {
        public string nickname { get; set; }
        public int participant { get; set; }
        public byte[] background { get; set; }
    }

    public class KickRequest : MeetingRequest
    {
        public int participant { get; set; }
    }

    public class ChangeAllRequest : MeetingRequest
    {
    }

    public class SwichHostRequest : MeetingRequest
    {
        public int participant { get; set; }
    }

    public class GetUpdateRequest : MeetingRequest 
    {
        public int participant { get; set; } 
    }

    public class UpdateCam : MeetingRequest
    {
        public bool state { get; set; } 
        public int participant { get; set; }
    }

    public class UpdateMic : MeetingRequest
    {
        public bool state { get; set; }
        public int participant { get; set; }
    }
    public class ShereScreenRequest : MeetingRequest
    {
        public bool state { get; set; }
        public int participant { get; set; }
    }

    public class UpdateAllowRequest : MeetingRequest
    {
        public bool state { get; set; }
        public int participant { get; set; }
    }
    public class SendMassage : MeetingRequest 
    {
        public int participant { get; set; }
        public string message { get; set; }
        public int direct { get; set; }
    }

    public class ChangeHospitalityRequest : MeetingRequest
    {
        public Hospitality hospitality { get; set; }
        public int participant { get; set; }
    }

    public class LockMeetingRequest : MeetingRequest
    {
        public bool state { get; set; }
    }
    public class UpdateWaitingRoomRequest : MeetingRequest
    {
        public bool state { get; set; }
    }

    public class UpdateWaitingUserRequest : MeetingRequest
    {
        public bool confirm { get; set; }
        public string username { get; set; }
    }
    public class Hospitality
    {
        public bool id { get; set; }
        public bool chat { get; set; }
        public bool rename { get; set; }
        public bool unmute { get; set; }
        public bool start_video { get; set; }
        public bool share_screen { get; set; }
        public bool waiting_room { get; set; }
    }
    public class Participation
    {
        public int volume { get; set; }
        public bool mute { get; set; }
        public bool share { get; set; }
        public string nickname { get; set; }
        public bool stop_video { get; set; }
        public byte[] background { get; set; }
    }
}
