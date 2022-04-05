namespace Server
{
    public interface IUsersQueries
    {
        public string GetPassword(string username);
        public bool DoesUserExist(string username);
        public bool DoesEmailMatch(string username, string email);
        public void ChangePassword(string username, string password);
        public bool DoesPasswordMatch(string username, string password);
        public void AddNewUser(string username, string password, string email);
    }
}
