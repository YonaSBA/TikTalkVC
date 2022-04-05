namespace Server
{   
    public interface ISettingsQueries
    {
        public string GetSettings(string username);
        public void UpdateSettings(string username, string settings);
    }
}
