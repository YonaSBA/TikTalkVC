using System;
using System.Text;
using AForge.Video;
using Newtonsoft.Json;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using Timer = System.Windows.Forms.Timer;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Client
{
    public partial class Participants : UserControl
    {
        private int m_id;
        private int m_host;
        private Meeting m_form;
        private Timer m_QC = new Timer();
        private Timer m_updater  = new Timer();
        private Pair<Button, Button> m_hostButtons;

        private Video m_video;
        private Audio m_audio;
        private Share m_share;
        private Streamer m_streamer;
        private Thread m_videoThread;
        private Thread m_audioThread;
        private Thread m_shareThread;
        private Participant m_presenter;

        private Chat m_chat;
        private FlowLayoutPanel m_board;
        private Dictionary<string, Candidate> m_candidates = new Dictionary<string, Candidate>();
        private Dictionary<int, Participant> m_participants = new Dictionary<int, Participant>();

        public Participants(Participant presenter, Streamer streamer, FlowLayoutPanel board, Chat chat, Video video, Audio audio, Share share, Pair<Button, Button> hostButtons, Meeting meeting)
        {
            InitializeComponent();

            m_chat = chat;
            m_board = board;
            m_video = video;
            m_audio = audio;
            m_share = share;
            m_form = meeting;
            m_streamer = streamer;
            m_id = presenter.m_id;
            m_hostButtons = hostButtons;
            m_presenter = Add(presenter);

            SetAsHost();

            m_videoThread = new Thread(() => GetVideo());
            m_videoThread.Start();

            m_audioThread = new Thread(() => GetAudio());
            m_audioThread.Start();

            m_shareThread = new Thread(() => GetShare());
            m_shareThread.Start();

            m_QC.Interval = Program.TWO_SECOND;
            m_QC.Tick += m_streamer.SendQC;
            m_QC.Start();

            m_updater.Interval = Program.HALF_SECOND;
            m_updater.Tick += GetUpdates;
            m_updater.Start();
        }
        public Participants(Participant presenter, Streamer streamer, FlowLayoutPanel board, Chat chat, Video video, Audio audio, Share share, Pair<Button, Button> hostButtons, Meeting meeting, int host, Dictionary<int, Participation> participants)
        {
            InitializeComponent();

            m_chat = chat;
            m_board = board;
            m_video = video;
            m_audio = audio;
            m_share = share;
            m_form = meeting;
            m_streamer = streamer;
            m_id = presenter.m_id;
            m_hostButtons = hostButtons;
            m_presenter = Add(presenter);

            Add(participants);
            SetAsHost(host);

            m_videoThread = new Thread(() => GetVideo());
            m_videoThread.Start();

            m_audioThread = new Thread(() => GetAudio());
            m_audioThread.Start();

            m_shareThread = new Thread(() => GetShare());
            m_shareThread.Start();

            m_QC.Interval = Program.TWO_SECOND;
            m_QC.Tick += m_streamer.SendQC;
            m_QC.Start();

            m_updater.Interval = Program.HALF_SECOND;
            m_updater.Tick += GetUpdates;
            m_updater.Start();
        }

        public void Remove(int id)
        {
            strips.Controls.Remove(m_participants[id].m_strip);
            m_chat.Remove(m_participants[id].GetNickname());
            m_board.Controls.Remove(m_participants[id]);

            if (m_participants[id].m_isShare)
            {
                m_board.Controls.Remove(m_participants[id].m_screen);
            }

            m_participants.Remove(id);
        }
        public void Add(Update update)
        {
            Add(new Participant(update.participant, JsonSerializer.Deserialize<Participation>(update.data))).ContextMenuStrip = ImHost() ? m_participants[update.participant].host_strip : null;
            m_chat.Add(m_participants[update.participant].GetNickname(), update.participant);
        }
        public Participant Add(Participant participant)
        {
            int id = participant.m_id;

            m_participants.Add(id, participant);
            m_board.Controls.Add(m_participants[id]);
            strips.Controls.Add(m_participants[id].m_strip);

            return m_participants[id];
        }
        public void Add(Dictionary<int, Participation> participants)
        {
            foreach (KeyValuePair<int, Participation> participant in participants)
            {
                Add(new Participant(participant.Key, participant.Value));
                m_chat.Add(m_participants[participant.Key].GetNickname(), participant.Key);

                if (participant.Value.share)
                {
                    m_board.Controls.Add(m_participants[participant.Key].m_screen);
                }    
            }
        }

        private byte[] SerializeUpdateRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.UPDATE + JsonSerializer.Serialize
                (
                    new SimpleRequest
                    {
                        participant = m_id
                    }
                )
            );
        }
        private byte[] SerializeChangeHospitalityRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.CHANGE_HOSPITALITY + JsonConvert.SerializeObject
                (
                    new ChangeHospitalityRequest
                    {
                        participant = m_id,
                        hospitality = m_presenter.m_hospitality
                    }
                )
            );
        }

        private void GetVideo()
        {
            while (true)
            {
                try
                {
                    Tuple<int, byte[]> data = m_streamer.ReceiveVideo();

                    if (m_participants[data.Item1].m_isVideo)
                    {
                        m_participants[data.Item1].Frame(data.Item2);
                    }
                    else
                    {
                        m_participants[data.Item1].Clear();
                    }
                }
                catch { }    
            }
        }
        private void GetAudio()
        {
            while (true)
            {
                try
                {
                    Tuple<int, byte[]> data = m_streamer.ReceiveAudio();

                    if (data == null)
                    {
                        int devider = Convert.ToInt32(m_streamer.m_roundTrip / 150);

                        if (devider > 1)
                        {
                            m_video.SetQuality(100 / devider);
                            m_share.SetQuality(100 / devider);
                            m_audio.SetSampleRate(44100 / devider);
                        }
                    }
                    else
                    {
                        m_audio.Play(data.Item2);
                    }
                }
                catch { }
            }
        }
        private void GetShare()
        {
            while (true)
            {
                try
                {
                    Tuple<int, byte[]> data = m_streamer.ReceiveShare();
                    m_participants[data.Item1].Screen(data.Item2);
                }
                catch { }
            }
        }
        private void GetUpdates(object sender, EventArgs e)
        {
            string response = Communicator.UseTo.Talk(SerializeUpdateRequest());

            if (response != null)
            {
                List<Update> updates = JsonSerializer.Deserialize<List<Update>>(response);

                foreach (Update update in updates)
                {
                    switch (update.code)
                    {
                        case UpdateCodes.END:
                            End();
                            break;
                        case UpdateCodes.ADD:
                            Add(update);
                            break;
                        case UpdateCodes.AUDIO:
                            Audio(update);
                            break;
                        case UpdateCodes.VIDEO:
                            Video(update);
                            break;
                        case UpdateCodes.REMOVE:
                            Remove(update);
                            break;
                        case UpdateCodes.RENAME:
                            Rename(update);
                            break;
                        case UpdateCodes.NEW_HOST:
                            ReplaceHost(update);
                            break;
                        case UpdateCodes.MUTE_ALL:
                            MuteAll();
                            break;
                        case UpdateCodes.HIDE_ALL:
                            HideAll();
                            break;
                        case UpdateCodes.CANDIDATE:
                            Candidate(update);
                            break;
                        case UpdateCodes.NEW_MESSAGE:
                            Message(update);
                            break;
                        case UpdateCodes.SHARE_SCREEN:
                            ShareScreen(update);
                            break;
                        case UpdateCodes.CHANGE_BACKGROUND:
                            Background(update);
                            break;
                    }
                }
            }
            if (m_audio.Problem())
            {
                m_audio.Set(false);
            }
            if (m_video.Problem())
            {
                m_video.Set(false);
            }
        }

        public bool ImHost()
        {
            return m_host == m_id;
        }
        public bool ItsMe(int id)
        {
            return m_id == id;
        }
        public bool IsHost(int id)
        {
            return m_host == id;
        }

        private void End()
        {
            m_form.Quit();
        }
        private void MuteAll()
        {
            if (!ImHost())
            {
                m_audio.Suddenly(null, null);
            }

            foreach (KeyValuePair<int, Participant> participant in m_participants)
            {
                if (m_host != participant.Key)
                {
                    participant.Value.SetAudio(false);
                }
            }
        }
        private void HideAll()
        {
            if (!ImHost())
            {
                m_video.Suddenly(null, ReasonToFinishPlaying.StoppedByUser);
            }

            foreach (KeyValuePair<int, Participant> participant in m_participants)
            {
                if (m_host != participant.Key)
                {
                    participant.Value.SetVideo(false);
                }
            }
        }
        private void Audio(Update update)
        {
            if (ItsMe(update.participant)) 
            {
                m_audio.Suddenly(null, null);
            }
            else 
            {
                m_participants[update.participant].SetAudio(Convert.ToBoolean(update.data)); 
            }
        }
        private void Video(Update update)
        {
            if (ItsMe(update.participant))
            { 
                m_video.Suddenly(null, ReasonToFinishPlaying.StoppedByUser); 
            } 
            else 
            { 
                m_participants[update.participant].SetVideo(Convert.ToBoolean(update.data)); 
            }
        }
        private void Remove(Update update)
        {
            if (ItsMe(update.participant))
            {
                m_form.Quit();
            }
            else
            {
                Remove(update.participant);
            }
        }
        private void Rename(Update update)
        {
            if (ItsMe(update.participant) && IsHost(update.participant))
            {
                m_participants[update.participant].SetNickname(update.data, Descriptions.SELF_HOST);
            }
            else if (ItsMe(update.participant))
            {
                m_participants[update.participant].SetNickname(update.data, Descriptions.SELF);
            }
            else if (IsHost(update.participant))
            {
                m_chat.Rename(m_participants[update.participant].GetNickname(), update.data);
                m_participants[update.participant].SetNickname(update.data, Descriptions.HOST);
            }
            else
            {
                m_chat.Rename(m_participants[update.participant].GetNickname(), update.data);
                m_participants[update.participant].SetNickname(update.data);
            }
        }
        private void Message(Update update)
        {
            Pair<string, bool> data = JsonSerializer.Deserialize<Pair<string, bool>>(update.data); 
            m_chat.Recieve(m_participants[update.participant].GetNickname(), data.First, data.Second);
        }
        private void Candidate(Update update)
        {
            Pair<bool, string> data = JsonSerializer.Deserialize<Pair<bool, string>>(update.data);

            if (data.First)
            {
                m_candidates.Add(data.Second, new Candidate(data.Second));
                strips.Controls.Add(m_candidates[data.Second]);
                strips.Controls.SetChildIndex(m_candidates[data.Second], 0);
            }
            else
            {
                strips.Controls.Remove(m_candidates[data.Second]);
                m_candidates.Remove(data.Second);
            }
        }
        private void Background(Update update)
        {
            m_participants[update.participant].SetBackground(Convert.FromBase64String(update.data));
        }
        private void ShareScreen(Update update)
        {
            if (ItsMe(update.participant))
            {
                m_share.Set(false);
                m_board.Controls.Remove(m_participants[update.participant].m_screen);
            }
            else
            {
                m_participants[update.participant].SetShare(Convert.ToBoolean(update.data));

                if (Convert.ToBoolean(update.data))
                {
                    m_board.Controls.Add(m_participants[update.participant].m_screen);
                }
                else
                {
                    m_board.Controls.Remove(m_participants[update.participant].m_screen);
                }
            }
        }

        private void SetAsRegular()
        {
            m_participants[m_host].SetHost(false);

            if (ImHost())
            {
                foreach (Participant part in m_participants.Values)
                {
                    part.ContextMenuStrip = null;
                }

                m_participants[m_id].ContextMenuStrip = m_participants[m_id].participant_strip;

                m_hostButtons.First.Visible = false;
                m_hostButtons.Second.Visible = false;
            }
        }
        private void SetAsHost(int id = 0)
        {
            m_host = id;

            if (ImHost())
            {
                foreach (Participant part in m_participants.Values)
                {
                    part.ContextMenuStrip = part.host_strip;
                }

                m_participants[m_id].ContextMenuStrip = m_participants[m_id].participant_strip;

                m_hostButtons.First.Visible = true;
                m_hostButtons.Second.Visible = true;

                Communicator.UseTo.Talk(SerializeChangeHospitalityRequest());
            }

            m_participants[id].SetHost(true);
        }
        private void ReplaceHost(Update update)
        {
            SetAsRegular();
            SetAsHost(update.participant);
        }
    }
}
