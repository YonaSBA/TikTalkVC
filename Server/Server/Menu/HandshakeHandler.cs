using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server
{
    class HandshakeHandler : IRequestHandler
    {
        private string m_username;
        private char m_requestFamily = '2';
        private Trio<int, int, int> m_ports;
        private MeetingManager m_meetingManager;
        private ISettingsQueries m_settingsQueries;
        private RequestHandlerFactory m_requestHandlerFactory;

        public HandshakeHandler(ref RequestHandlerFactory requestHandlerFactory, ref ISettingsQueries settingsQweries, string username, Trio<int, int, int> ports)
        {
            m_ports = ports;
            m_username = username;
            m_settingsQueries = settingsQweries;
            m_requestHandlerFactory = requestHandlerFactory;
            m_meetingManager = m_requestHandlerFactory.GetMeetingManager();
        }

        public Response HandleRequest(Request info)
        {
            if (info.getFamily() == m_requestFamily)
            {
                switch (info.m_code)
                {
                    case HandshakeCodes.CREATE:
                        return CreateMeeting(info);

                    case HandshakeCodes.JOIN:
                        return JoinMeeting(info);

                    case MenuCodes.GET_SETTINGS:
                        return GetSettings();

                    default:
                        return new Response(new UnknownRequestException());
                }
            }
            else
            {
                return new Response(new OtherFamilyException());
            }
        }

        private Response CreateMeeting(Request info)
        {
            CreateMeetingRequest req = JsonSerializer.Deserialize<CreateMeetingRequest>(info.m_data);

            try
            {
                string meetingID = m_meetingManager.CreateMeeting(info.m_token, req.participation, m_ports, req.ports, m_username);
                CreateRequestResponse res = new CreateRequestResponse { meeting = meetingID, participant = 0 };
                return new Response(MenuCodes.CREATE_MEETING, JsonSerializer.Serialize(res), m_requestHandlerFactory.CreateMeetingHandler(m_username, 0, meetingID));
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response JoinMeeting(Request info)
        {
            JoinMeetingRequest req = JsonSerializer.Deserialize<JoinMeetingRequest>(info.m_data);

            try
            {
                Tuple<int, Dictionary<int, Participation>, int> data = m_meetingManager.JoinMeeting(req.meeting, info.m_token, req.participation, req.ports, m_username);
                JoinMeeting res = new JoinMeeting { participant = data.Item1, participants = data.Item2, host = data.Item3};
                return new Response(MenuCodes.JOIN_MEETING, JsonSerializer.Serialize(res), m_requestHandlerFactory.CreateMeetingHandler(m_username, data.Item1, req.meeting));
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }
        private Response GetSettings()
        {
            try
            {
                GetSettingsResponse res = new GetSettingsResponse { settings = m_settingsQueries.GetSettings(m_username) };
                return new Response(MenuCodes.GET_SETTINGS, JsonSerializer.Serialize(res));
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }
        public string GetUsername()
        {
            return m_username;
        }
    }
}
