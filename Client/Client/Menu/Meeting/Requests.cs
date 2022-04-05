namespace Client
{
    public static class MeetingCodes
    {
        public const string                     UPDATE = "300";
        public const string                      VIDEO = "301";
        public const string                      AUDIO = "302";
        public const string                     RENAME = "304";
        public const string          CHANGE_BACKGROUND = "305";
        public const string               SEND_MESSAGE = "306";
        public const string               SHARE_SCREEN = "307";
        public const string                      LEAVE = "308";


        public const string        ENABLE_WAITING_ROOM = "310";
        public const string                  CANDIDATE = "311";
        public const string               LOCK_MEETING = "312";
        public const string                       KICK = "313";
        public const string                  MAKE_HOST = "314";
        public const string         CHANGE_HOSPITALITY = "315";
        public const string                   HIDE_ALL = "316";
        public const string                   MUTE_ALL = "317";
        public const string                        END = "318";


        public const string               ALLOW_CHAT   = "320";
        public const string               ALLOW_SHOW   = "321";
        public const string               ALLOW_SHARE  = "322";
        public const string               ALLOW_UNMUTE = "323";
        public const string               ALLOW_RENAME = "324";
    }

    public class VideoRequest : SimpleRequest
    {
        public bool state { get; set; }
    }
    public class AudioRequest : SimpleRequest
    {
        public bool state { get; set; }
    }
    public class SimpleRequest
    {
        public int participant { get; set; }
    }
    public class RenameRequest : SimpleRequest
    {
        public string nickname { get; set; }
    }
    public class ConfirmRequest
    {
        public bool confirm { get; set; }
        public string username { get; set; }
    }
    public class PermissionRequest : SimpleRequest
    {
        public bool state { get; set; }
    }
    public class SendMessageRequest : SimpleRequest
    {
        public int direct { get; set; }
        public string message { get; set; }
    }
    public class ShareScreenRequest : SimpleRequest
    {
        public bool state { get; set; }
    }
    public class ChangeBackgroundRequest : SimpleRequest
    {
        public byte[] background { get; set; }
    }
    public class ChangeHospitalityRequest : SimpleRequest
    {
        public Hospitality hospitality { get; set; }
    }
}
