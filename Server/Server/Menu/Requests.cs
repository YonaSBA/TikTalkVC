namespace Server
{
    public static class MenuCodes
    {
        public const string CREATE_MEETING = "200";
        public const string JOIN_MEETING = "201";
        public const string GET_MEETING_HISTORY = "202";
        public const string GET_SETTINGS = "203";
        public const string UPDATE_SETTINGS = "204";
        public const string SIGN_OUT = "205";
    }

    public static class HandshakeCodes
    {
        public const string CREATE = "200";
        public const string JOIN = "201";
    }

    public class JoinMeetingReq
    {
        public bool choice { get; set; }
        public string meeting { get; set; }
    }
    public class CreateMeetingRequest
    {
        public Trio<int, int, int> ports { get; set; }
        public Participation participation { get; set; }
    }

    public class JoinMeetingRequest 
    {
        public Trio<int, int, int> ports { get; set; }
        public string meeting { get; set; }
        public Participation participation { get; set; }
    }

    public class UpdateSettingsRequest
    {
        public string settings { get; set; }
    }

    public class Trio<T, U, V>
    {
        public T First { get; set; }
        public U Second { get; set; }
        public V Third { get; set; }

        public Trio(T first, U second, V third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }

    public class Pair<T, U>
    {
        public T First { get; set; }
        public U Second { get; set; }

        public Pair(T first, U second)
        {
            First = first;
            Second = second;
        }
    }

}
