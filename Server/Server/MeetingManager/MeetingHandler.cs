using System.Text.Json;
using System.Collections.Generic;

namespace Server
{
    public class MeetingHandler : IRequestHandler
    { 
        private string m_username;
        private string m_meetingID;
        private int m_participantID;
        private char m_requestFamily = '3';
        private MeetingManager m_meetingManager;
        private RequestHandlerFactory m_requestHandlerFactory;

        public MeetingHandler(ref RequestHandlerFactory requestHandlerFactory, string useranme, int id, string meetingID)
        {
            m_participantID = id;
            m_username = useranme;
            m_meetingID = meetingID;
            m_requestHandlerFactory = requestHandlerFactory;
            m_meetingManager = m_requestHandlerFactory.GetMeetingManager();
        }
        public Response HandleRequest(Request info)
        {
            if (info.getFamily() == m_requestFamily)
            {
                string code = info.m_code;
                switch (code)
                {
                    case MeetingCodes.RENAME:
                        return Rename(info);

                    case MeetingCodes.END_MEETING:
                        return Close(info);

                    case MeetingCodes.GET_STATUS:
                        return GetUpdate(info);

                    case MeetingCodes.KICK_USER:
                        return Kick(info);

                    case MeetingCodes.LEAVE_MEETING:
                        return LeaveMeeting(info);

                    case MeetingCodes.SENT_MESSAGE:
                        return SendChatMassage(info);

                    case MeetingCodes.UPDATE_CAM:
                        return UpdateCam(info);

                    case MeetingCodes.UPDATE_MIC:
                        return UpdateMic(info);

                    case MeetingCodes.MUTE_ALL:
                        return ChangeAll(info);

                    case MeetingCodes.HIDE_ALL:
                        return ChangeAll(info);

                    case MeetingCodes.SHARE_SCREEN:
                        return ShereScreen(info);

                    case MeetingCodes.ALLOW_CHAT:
                        return UpdateAllowence(info);

                    case MeetingCodes.ALLOW_RENAME:
                        return UpdateAllowence(info);

                    case MeetingCodes.ALLOW_SHARE:
                        return UpdateAllowence(info);

                    case MeetingCodes.ALLOW_SHOW:
                        return UpdateAllowence(info);

                    case MeetingCodes.ALLOW_UNMUTE:
                        return UpdateAllowence(info);

                    case MeetingCodes.MAKE_HOST:
                        return SwitchHost(info);

                    case MeetingCodes.CHANGE_BACKGROUND:
                        return ChangeBackground(info);

                    case MeetingCodes.CHANGE_HOSPITALITY:
                        return ChangeHospitality(info);

                    case MeetingCodes.LOCK_MEETING:
                        return LockMeeting(info);
                    
                    case MeetingCodes.WAITING_ROOM:
                        return WaitingRoom(info);

                    case MeetingCodes.CONFIRMATION:
                        return UpdateWaitingUser(info);

                    default:
                        return new Response(new UnknownRequestException());
                }
            }
            else
            {
                return new Response(new OtherFamilyException());
            }
        }

        private Response LeaveMeeting(Request info)
        {
            LeaveMeetingRequest req = JsonSerializer.Deserialize<LeaveMeetingRequest>(info.m_data);

            try
            {
                m_meetingManager.LeaveMeeting(m_meetingID, info.m_token, req.participant);
                return new Response(MeetingCodes.LEAVE_MEETING, m_requestHandlerFactory.CreateMenuHandler(m_username));
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response Rename(Request info)
        {
            RenameRequest req = JsonSerializer.Deserialize<RenameRequest>(info.m_data);

            try
            {
                m_meetingManager.Rename(m_meetingID, info.m_token, req.participant, req.nickname);
                return new Response(MeetingCodes.RENAME);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }
        private Response Close(Request info)
        {
            CloseMeetingRequest req = JsonSerializer.Deserialize<CloseMeetingRequest>(info.m_data);

            try
            {
                m_meetingManager.CloseMeeting(m_meetingID, info.m_token);
                return new Response(MeetingCodes.END_MEETING, m_requestHandlerFactory.CreateMenuHandler(m_username));
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response Kick(Request info)
        {
            KickRequest req = JsonSerializer.Deserialize<KickRequest>(info.m_data);

            try
            {
                m_meetingManager.Kick(m_meetingID, info.m_token, req.participant);
                return new Response(MeetingCodes.KICK_USER);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response SendChatMassage(Request info)
        {
            SendMassage req = JsonSerializer.Deserialize<SendMassage>(info.m_data);

            try
            {
                m_meetingManager.SendMassage(m_meetingID, info.m_token, req.participant, req.message, req.direct);
                return new Response(MeetingCodes.SENT_MESSAGE);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response ChangeBackground(Request info)
        {
            ChangeBackgroundRequest req = JsonSerializer.Deserialize<ChangeBackgroundRequest>(info.m_data);

            try
            {
                m_meetingManager.ChangeBackground(m_meetingID, info.m_token, req.participant, req.background);
                return new Response(MeetingCodes.CHANGE_BACKGROUND);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response UpdateCam(Request info)
        {
            UpdateCam req = JsonSerializer.Deserialize<UpdateCam>(info.m_data);

            try
            {
                m_meetingManager.UpdateCam(m_meetingID, info.m_token, req.participant, req.state);
                return new Response(MeetingCodes.UPDATE_CAM);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response UpdateMic(Request info)
        {
            UpdateMic req = JsonSerializer.Deserialize<UpdateMic>(info.m_data);

            try
            {
                m_meetingManager.UpdateMic(m_meetingID, info.m_token, req.participant, req.state);
                return new Response(MeetingCodes.UPDATE_MIC);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response ShereScreen(Request info)
        {
            ShereScreenRequest req = JsonSerializer.Deserialize<ShereScreenRequest>(info.m_data);

            try
            {
                m_meetingManager.ShereScreen(m_meetingID, info.m_token, req.participant, req.state);
                return new Response(MeetingCodes.UPDATE_MIC);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response UpdateAllowence(Request info)
        {
            UpdateAllowRequest req = JsonSerializer.Deserialize<UpdateAllowRequest>(info.m_data);

            try
            {
                m_meetingManager.UpdateAllowence(m_meetingID, info.m_token, req.participant, info.m_code, req.state);
                return new Response(info.m_code);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response GetUpdate(Request info) 
        {
            GetUpdateRequest req = JsonSerializer.Deserialize<GetUpdateRequest>(info.m_data);

            try
            {
                List<Update> updates = m_meetingManager.Update(m_meetingID, info.m_token, req.participant);
                string s = "[";
                foreach (Update update in updates)
                {
                    s += JsonSerializer.Serialize(update);
                    s += ',';
                }
                if (updates.Count != 0)
                    s = s.Remove(s.Length - 1);
                s += "]";
                return new Response(MeetingCodes.GET_STATUS, s);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }
        private Response ChangeAll(Request info)
        {
            ChangeAllRequest req = JsonSerializer.Deserialize<ChangeAllRequest>(info.m_data);

            try
            {
                m_meetingManager.ChangeAll(m_meetingID, info.m_token, info.m_code == MeetingCodes.HIDE_ALL);
                return new Response(info.m_code);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }
        private Response SwitchHost(Request info)
        {
            SwichHostRequest req = JsonSerializer.Deserialize<SwichHostRequest>(info.m_data);

            try
            {
                m_meetingManager.SwichHost(m_meetingID, info.m_token, req.participant);
                return new Response(info.m_code);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response ChangeHospitality(Request info)
        {
            ChangeHospitalityRequest req = JsonSerializer.Deserialize<ChangeHospitalityRequest>(info.m_data);

            try
            {
                m_meetingManager.ChangeHospitality(m_meetingID, info.m_token, req.participant, req.hospitality);
                return new Response(info.m_code);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }
        private Response LockMeeting(Request info)
        {
            LockMeetingRequest req = JsonSerializer.Deserialize<LockMeetingRequest>(info.m_data);

            try
            {
                m_meetingManager.LockMeeting(m_meetingID, info.m_token, req.state);
                return new Response(info.m_code);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response WaitingRoom(Request info)
        {
            UpdateWaitingRoomRequest req = JsonSerializer.Deserialize<UpdateWaitingRoomRequest>(info.m_data);

            try
            {
                m_meetingManager.UpdateWaitingRoom(m_meetingID, info.m_token, req.state);
                return new Response(info.m_code);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response UpdateWaitingUser(Request info)
        {
            UpdateWaitingUserRequest req = JsonSerializer.Deserialize<UpdateWaitingUserRequest>(info.m_data);

            try
            {
                m_meetingManager.UpdateWaitingUser(m_meetingID, info.m_token, req.confirm, req.username);
                return new Response(info.m_code);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }
        public string GetCode() { return m_meetingID; }
        public string GetUsername() { return m_username; }
        public int GetParticipantID() { return m_participantID; }
    }
}
