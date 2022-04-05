using System;

namespace Client
{
    public class BadUsernameException : Exception
    {
        public BadUsernameException() : base("Username must begin with lower and contains UPPERS, lowers and digits only.") { }
    }

    public class BadPasswordException : Exception
    {
        public BadPasswordException() : base("Password must be 4 chars at least: 1 UPPER, 1 lower and 1 digit at least required.") { }
    }

    public class BadEmailException : Exception
    {
        public BadEmailException() : base("Email format: <name>@gmail.<domain>.") { }
    }

    public class ConfirmPasswordException : Exception
    {
        public ConfirmPasswordException() : base("Passwords don't match, please try again.") { }
    }

    public class ConfirmEmailException : Exception
    {
        public ConfirmEmailException() : base("Emails don't match, please try again.") { }
    }
}
