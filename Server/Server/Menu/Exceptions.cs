namespace Server
{
    public class EmptyHistoryException : MyException
    {
        public EmptyHistoryException() : base("920", "No history available.") { }
    }
}
