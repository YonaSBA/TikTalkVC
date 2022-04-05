using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server
{
    class MenuHandler : IRequestHandler
    {
        private string m_username;
        public string m_waitingRoom;
        private char m_requestFamily = '2';
        private Authenticator m_authenticator;
        private Pair<bool, bool> m_kickAndClose;
        private MeetingManager m_meetingManager;
        private ISettingsQueries m_settingsQueries;
        private RequestHandlerFactory m_requestHandlerFactory;

        public MenuHandler(ref RequestHandlerFactory requestHandlerFactory, ref ISettingsQueries settingsQweries, string username, Pair<bool, bool> kickAndClose)
        {
            m_waitingRoom = null;
            m_username = username;
            m_settingsQueries = settingsQweries;
            m_requestHandlerFactory = requestHandlerFactory;
            m_authenticator = m_requestHandlerFactory.GetAuthenticator();
            m_meetingManager = m_requestHandlerFactory.GetMeetingManager();
            m_kickAndClose = kickAndClose == null ? new Pair<bool, bool>(false, false) : kickAndClose;
        }

        public Response HandleRequest(Request info)
        {
            if (info.m_code == MeetingCodes.GET_STATUS)
            {
                GetUpdateRequest req = JsonSerializer.Deserialize<GetUpdateRequest>(info.m_data);

                string s = "[";
                Update u;
                // if (m_meetingManager.IsMeetingExists(req.meeting)) the early line
                if (m_kickAndClose.First)
                    u = new Update(UpdatesCodes.REMOVE, null, req.participant);
                else if (m_kickAndClose.Second)
                {
                    m_kickAndClose.Second = false;
                    u = new Update(UpdatesCodes.END, null, req.participant);
                }
                else
                {
                    u = new Update(UpdatesCodes.END, null, req.participant);
                    Console.WriteLine("error menu line 43");
                }
                s += JsonSerializer.Serialize(u);
                s += "]";
                return new Response(MeetingCodes.GET_STATUS, s);
            }
            if (info.getFamily() == m_requestFamily)
            {
                try
                {
                    switch (info.m_code)
                    {
                        case MenuCodes.CREATE_MEETING:
                            return CreateMeeting(info);

                        case MenuCodes.JOIN_MEETING:
                            return JoinMeeting(info);

                        case MenuCodes.GET_MEETING_HISTORY:
                            return GetMeetingHistory();

                        case MenuCodes.GET_SETTINGS:
                            return GetSettings();

                        case MenuCodes.UPDATE_SETTINGS:
                            return UpdateSettings(info);

                        case MenuCodes.SIGN_OUT:
                            return SignOut();
                        default:
                            return new Response(new UnknownRequestException());
                    }
                }
                catch (MyException exception)
                {
                    return new Response(exception);
                }
            }
            else
            {
                return new Response(new OtherFamilyException());
            }
        }

        private Response CreateMeeting(Request info)
        {
            var ports = m_meetingManager.GeneratePorts();
            HandShakeResponse res = new HandShakeResponse { ports = ports };
            return new Response(MenuCodes.JOIN_MEETING, JsonSerializer.Serialize(res), m_requestHandlerFactory.CreateHandshakeHandler(m_username,ref m_settingsQueries, ports));
        }

        private Response JoinMeeting(Request info)
        {
            JoinMeetingReq req = JsonSerializer.Deserialize<JoinMeetingReq>(info.m_data);

            try
            {
                m_meetingManager.TryJoining(req.meeting, m_username, req.choice, ref m_waitingRoom);
                var ports = m_meetingManager.GetPorts(req.meeting);
                HandShakeResponse res = new HandShakeResponse { ports = ports };
                return new Response(MenuCodes.JOIN_MEETING, JsonSerializer.Serialize(res), m_requestHandlerFactory.CreateHandshakeHandler(m_username, ref m_settingsQueries));
            }
            catch (LockedMeetingException exception)
            {
                return new Response(exception, m_requestHandlerFactory.CreateMenuHandler(m_username));
            }
            catch (WaitingRoom)
            {
                HandShakeResponse res = new HandShakeResponse { ports = new Trio<int, int, int>(WaitingCodes.NO_ASNWER, 0, 0) };
                return new Response(MenuCodes.JOIN_MEETING, JsonSerializer.Serialize(res));
            }
            catch (GotRejectedException exception)
            {
                return new Response(exception, m_requestHandlerFactory.CreateMenuHandler(m_username));
            }
        }

        private Response GetMeetingHistory()
        {
            var s = m_meetingManager.GetMeetingsHistory(m_username);
            return new Response(MenuCodes.GET_MEETING_HISTORY, s);
        }

        private Response GetSettings()
        {
            GetSettingsResponse res = new GetSettingsResponse { settings = m_settingsQueries.GetSettings(m_username) };
            return new Response(MenuCodes.GET_SETTINGS, JsonSerializer.Serialize(res));
        }

        private Response UpdateSettings(Request info)
        {
            UpdateSettingsRequest req = JsonSerializer.Deserialize<UpdateSettingsRequest>(info.m_data);

            m_settingsQueries.UpdateSettings(m_username, req.settings);
            return new Response(MenuCodes.UPDATE_SETTINGS);

        }
        private Response SignOut()
        {
            m_authenticator.SignOut(m_username);
            return new Response(MenuCodes.SIGN_OUT, m_requestHandlerFactory.CreateAuthenticationHandler());
        }

        public string GetUsername()
        {
            return m_username;
        }
    }
}
