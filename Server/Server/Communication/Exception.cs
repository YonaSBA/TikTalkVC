using System;

namespace Server
{
    public class MyException : Exception
    {
        public string Code { get; set; }

        public MyException (string code, string message) : base(message)
        {
            Code = code;
        }

        public override string ToString()
        {
            return Code + "{\"message\":\"" + Message + "\"}";
        }
    }

    public class TokenException : MyException
    {
        public TokenException() : base("900", "Token - Taken.") { }
    }

    public class BadJsonException : MyException
    {
        public BadJsonException() : base("901", "Bad Json received.") { }
    }

    public class UnknownException : MyException
    {
        public UnknownException() : base("999", "Unknown exception.") { }
    }
}
