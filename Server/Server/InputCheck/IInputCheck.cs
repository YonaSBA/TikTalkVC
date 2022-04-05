namespace Server
{
    interface IInputCheck
    {
        public bool IsEmailValid(string email);
        public bool IsPasswordValid(string password);
        public bool IsUsernameValid(string username);
    }
}
