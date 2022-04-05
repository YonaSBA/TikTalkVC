namespace Server
{
    public interface IDataBase
    {
        public ref IUsersQueries GetUsersQueries();
        public ref ISettingsQueries GetSettingsQueries();
        public ref IMeetingsQueries GetMeetingsQueries();
    }
}
