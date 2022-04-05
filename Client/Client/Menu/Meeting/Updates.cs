namespace Client
{
    public static class UpdateCodes
    {

        public const string                CANDIDATE = "800";
        public const string                      ADD = "805";
        public const string                   REMOVE = "810";
        public const string                    VIDEO = "815";
        public const string                    AUDIO = "820";
        public const string                   RENAME = "825";
        public const string              NEW_MESSAGE = "830";
        public const string             SHARE_SCREEN = "835";
        public const string        CHANGE_BACKGROUND = "840";
        public const string                 NEW_HOST = "845";
        public const string                 MUTE_ALL = "850";
        public const string                 HIDE_ALL = "855";
        public const string                      END = "860";
    }

    public class Update
    {
        public string code { get; set; }
        public string data { get; set; }
        public int participant { get; set; }
    }
}
