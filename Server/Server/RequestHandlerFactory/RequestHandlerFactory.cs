namespace Server
{
    public class RequestHandlerFactory
    {
        private IDataBase m_dataBase;
        private Authenticator m_authenticator;
        private MeetingManager m_meetingManager;
        private ClientsManager m_clientsManager;
        
        public RequestHandlerFactory(ref IDataBase dataBase)
        {
            m_dataBase = dataBase;
            m_clientsManager = new ClientsManager();
            m_authenticator = new Authenticator(ref dataBase.GetUsersQueries());
            m_meetingManager = new MeetingManager(ref dataBase.GetMeetingsQueries(), ref m_clientsManager);
        }

        public IRequestHandler CreateMenuHandler(string username, Pair<bool, bool> kickAndClose = null)
        {
            var me = this;
            return new MenuHandler(ref me, ref m_dataBase.GetSettingsQueries(), username, kickAndClose);
        }

        public AuthenticationHandler CreateAuthenticationHandler()
        {
            var me = this;
            return new AuthenticationHandler(ref me);
        }

        public IRequestHandler CreateHandshakeHandler(string username, ref ISettingsQueries settingsQweries,  Trio<int, int, int> ports = null)
        {
            var me = this;
            return new HandshakeHandler(ref me, ref settingsQweries, username, ports);
        }
        public IRequestHandler CreateMeetingHandler(string username, int id, string meetingID)
        {
            var me = this;
            return new MeetingHandler(ref me, username, id, meetingID);
        }
        public ref Authenticator GetAuthenticator()
        {
            return ref m_authenticator;
        }

        public ref MeetingManager GetMeetingManager()
        {
            return ref m_meetingManager;
        }

        public ref ClientsManager GetClinetsMamager()
        {
            return ref m_clientsManager;
        }
    }
}
