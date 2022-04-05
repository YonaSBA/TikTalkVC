namespace Client
{
    public static class MenuCodes
    {
        public const string CREATE_MEETING              = "200";
        public const string JOIN_MEETING                = "201";
        public const string GET_MEETING_HISTORY         = "202";
        public const string GET_SETTINGS                = "203";
        public const string UPDATE_SETTINGS             = "204";
        public const string SIGN_OUT                    = "205";
        public const string GET_INFORMATION             = "206";
    }

    public class HandShakeRequest
    {
        public Trio<int> ports { get; set; } 
        public Participation participation { get; set; }
    }
    public class JoinMeetingRequest
    {
        public bool choice { get; set; }
        public string meeting { get; set; }
    }
    public class UpdateSettingsRequest
    {
        public string settings { get; set; }
    }
    public class ExpandedHandShakeRequest : HandShakeRequest
    {
        public string meeting { get; set; }
    }
}