namespace Server
{
    public class NoPermissionException : MyException
    {
        public NoPermissionException() : base("930", "You don't have the permission to do that.") { }
    }

    public class NotExistingMeetingExpection : MyException
    {
        public NotExistingMeetingExpection() : base("700", "Meeting id not exist.") { }
    }

    public class CantKickYourselfExpection : MyException
    {
        public CantKickYourselfExpection() : base("932", "You can't kick yourself.") { }
    }

    public class NoSuchIdExpection : MyException
    {
        public NoSuchIdExpection() : base("933", "There is no such id in the meeting") { }
    }

    public class NoSuchAllowenceExpection : MyException
    {
        public NoSuchAllowenceExpection() : base("934", "There is no such allowence code") { }
    }

    public class Kick : System.Exception
    {
        public Kick()  { }
    }

    public class KickException : MyException
    {
        public KickException() : base("935", "You have been kicked form the meeting") { }
    }

    public class Close : System.Exception
    {
        public Close() { }
    }

    public class WaitingRoom : System.Exception
    {
        public WaitingRoom() { }
    }

    public class CloseException : MyException
    {
        public CloseException() : base("936", "The meeting has been closed by the host.") { }
    }

    public class LockedMeetingException : MyException
    {
        public LockedMeetingException() : base("710", "The meeting is locked.") { }
    }

    public class GotRejectedException : MyException
    {
        public GotRejectedException() : base("720", "You got rejected by the host.") { }
    }
}
