namespace Client
{
    public static class AuthenticationCodes
    {
        public const string SIGN_IN                     = "100";
        public const string SIGN_UP                     = "101";
        public const string FORGOT_PASSWORD             = "102";
        public const string CHANGE_PASSWORD             = "103";
    }

    public class SignInRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class SignUpRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
    public class ForgotPasswordRequest
    {
        public string username { get; set; }
        public string email { get; set; }
    }
    public class ChangePasswordRequest
    {
        public string password { get; set; }
        public string code { get; set; }
    }
}
