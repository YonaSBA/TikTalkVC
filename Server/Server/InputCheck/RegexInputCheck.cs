using System.Text.RegularExpressions;

namespace Server
{
    class RegexInputCheck : IInputCheck
    {
        private const string USERNAME_REGEX = "^[A-Za-z][A-Za-z0-9]{1,9}$";
        private const string EMAIL_REGEX = "^[A-Za-z0-9]+@gmail.+([a-z.]){3}$";
        //private const string PASSWORD_REGEX = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{4,}$";
        private const string HASH_REGEX = "^[A-Za-z0-9]+$";

        bool IInputCheck.IsEmailValid(string email)
        {
            return new Regex(EMAIL_REGEX).IsMatch(email);
        }

        bool IInputCheck.IsPasswordValid(string password)
        {
            return new Regex(HASH_REGEX).IsMatch(password);
        }

        bool IInputCheck.IsUsernameValid(string username)
        {
            return new Regex(USERNAME_REGEX).IsMatch(username);
        }
    }
}
