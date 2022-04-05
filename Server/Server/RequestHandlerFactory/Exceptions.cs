namespace Server
{
    public class UnknownRequestException : MyException
    {
        public UnknownRequestException() : base("900", "Unknown request.") { }
    }

    public class OtherFamilyException : MyException
    {
        public OtherFamilyException() : base("901", "Request from another family.") { }
    }
}
