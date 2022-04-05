namespace Server
{
    public class UserAlreadyExistException : MyException
    {
        public UserAlreadyExistException() : base("910", "Username already exist.") { }
    }

    public class UserNotExistException : MyException
    {
        public UserNotExistException() : base("911", "Username doesn't exist.") { }
    }

    public class UserAlreadyInException : MyException
    {
        public UserAlreadyInException() : base("912", "User already in.") { }
    }

    public class UserNotInException : MyException
    {
        public UserNotInException() : base("913", "Username doesn't in.") { }
    }

    public class PasswordNotMatchException : MyException
    {
        public PasswordNotMatchException() : base("914", "Password doesn't match.") { }
    }

    public class EmailNotMatchException : MyException
    {
        public EmailNotMatchException() : base("915", "Email doesn't match.") { }
    }

    public class BadUsernameException : MyException
    {
        public BadUsernameException() : base("916", "Username must be more than 0 characters, less than 10 characters and begin with lower and contains UPPERS, lowers and digits only.") { }
    }

    public class BadPasswordException : MyException
    {
        public BadPasswordException() : base("917", "Password must be 4 chars at least: 1 UPPER, 1 lower and 1 digit at least required.") { }
    }

    public class BadEmailException : MyException
    {
        public BadEmailException() : base("918", "Email format: <name>@gmail.<domain>.") { }
    }

    public class CodeNotExistException : MyException
    {
        public CodeNotExistException() : base("919", "Code doesn't exist.") { }
    }

    public class NoDatabaseException : MyException
    {
        public NoDatabaseException() : base("921", "There is no database in the server.") { }
    }
}
