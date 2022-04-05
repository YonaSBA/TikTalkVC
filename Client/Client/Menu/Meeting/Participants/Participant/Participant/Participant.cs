using System.Text;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace Client
{
    public partial class Participant : UserControl
    {
        public int m_id { get; private set; }
        public bool m_isShare { get; private set; }
        public bool m_isVideo { get; private set; }
        public MyScreen m_screen { get; private set; }
        public ParticipantStrip m_strip { get; private set; }
        public Hospitality m_hospitality { get; private set; }

        public Participant(int id, Participation participation)
        {
            InitializeComponent();

            m_id = id;

            ContextMenuStrip = null;
            nickname.Text = participation.nickname;
            image.BackgroundImage = Video.ToImage(participation.background);
            audio.BackgroundImage = participation.mute ? Properties.Resources.mute : Properties.Resources.unmute;

            m_isShare = false;
            m_isVideo = !participation.stop_video;
            m_strip = new ParticipantStrip(participation);
            m_screen = new MyScreen(participation.nickname);
        }
        public Participant(int id, Participation participation, Hospitality hospitality)
        {
            InitializeComponent();

            m_id = id;
            m_hospitality = hospitality;

            ContextMenuStrip = participant_strip;
            nickname.Text = participation.nickname + Descriptions.SELF;
            image.BackgroundImage = Video.ToImage(participation.background);
            audio.BackgroundImage = participation.mute ? Properties.Resources.mute : Properties.Resources.unmute;

            m_isShare = false;
            m_isVideo = !participation.stop_video;
            m_strip = new ParticipantStrip(participation);
            m_screen = new MyScreen(participation.nickname);
        }

        public void SetHost(bool state)
        {
            if (state)
            {
                if (nickname.Text.Contains(Descriptions.SELF))
                {
                    SetNickname(m_strip.GetNickname(), Descriptions.SELF_HOST);
                }
                else
                {
                    SetNickname(nickname.Text, Descriptions.HOST);
                }
            }
            else
            {
                if (nickname.Text.Contains(Descriptions.SELF_HOST))
                {
                    SetNickname(m_strip.GetNickname(), Descriptions.SELF);
                }
                else
                {
                    SetNickname(m_strip.GetNickname());
                }
            }
        }
        public void SetAudio(bool state)
        {
            m_strip.SetAudio(state);
            audio.BackgroundImage = state ? Properties.Resources.unmute : Properties.Resources.mute;
        }
        public void SetVideo(bool state)
        {
            m_strip.SetVideo(state);
            m_isVideo = state;

            if (!state)
            {
                Clear();
            }
        }
        public void SetShare(bool state)
        {
            m_isShare = state;
            m_strip.SetShare(state);
        }

        public void Clear()
        {
            image.Image = null;
        }
        public void Frame(Image frame)
        {
            image.Image = frame;
        }
        public void Frame(byte[] frame)
        {
            image.Image = Video.ToImage(frame);
        }
        public void Screen(byte[] shot)
        {
            m_screen.Frame(shot);
        }

        public void SetBackground(byte[] background)
        {
            image.BackgroundImage = Video.ToImage(background);
        }
        public byte[] GetBackground() => Video.ToBytes(image.BackgroundImage);

        public string GetNickname() => m_strip.GetNickname();
        public void SetNickname(string nickname, string description = "")
        {
            this.nickname.Text = nickname + description;
            m_strip.SetNickname(nickname);

            try 
            { 
                m_screen.SetNickname(nickname); 
            } 
            catch { }
        }

        private byte[] SerializeKickRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.KICK + JsonSerializer.Serialize
                (
                    new SimpleRequest
                    {
                        participant = m_id
                    }
                )
            );
        }
        private byte[] SerializeMakeHostRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.MAKE_HOST + JsonSerializer.Serialize
                (
                    new SimpleRequest
                    {
                        participant = m_id
                    }
                )
            );
        }
        private byte[] SerializeRenameRequest(string nickname)
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.RENAME + JsonSerializer.Serialize
                (
                    new RenameRequest
                    {
                        participant = m_id,
                        nickname = nickname
                    }
                )
            );
        }
        private byte[] SerializeChangeBackgroundRequest(byte[] background)
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.CHANGE_BACKGROUND + JsonSerializer.Serialize
                (
                    new ChangeBackgroundRequest
                    {
                        participant = m_id,
                        background = background
                    }
                )
            );
        }

        private void Mute()
        {
            if (Communicator.UseTo.Talk(Audio.SerializeRequest(false, m_id)) != null)
            {
                SetAudio(false);
            }
        }
        private void Hide()
        {
            if (Communicator.UseTo.Talk(Video.SerializeRequest(false, m_id)) != null)
            {
                SetVideo(false);
            }
        }
        private void Kick()
        {
            Communicator.UseTo.Talk(SerializeKickRequest());
        }
        private void Rename()
        {
            string nickname = Interaction.InputBox("Enter a new screen name:", "Rename", this.nickname.Text.Split(' ')[0]);

            if (new Regex("^[a-zA-Z0-9_.-]{1,10}$").IsMatch(nickname))
            {
                Communicator.UseTo.Talk(SerializeRenameRequest(nickname));
            }
            else
            {
                MessageBox.Show("Nickname must be more than 0 characters, less than 10 characters, and contains only lowers, uppers, numbers and underscore.");
            }
        }
        private void MakeHost()
        {
            Communicator.UseTo.Talk(SerializeMakeHostRequest());
        }
        private void StopShare()
        {
            Communicator.UseTo.Talk(Share.SerializeRequest(false, m_id));
        }
        private void ChangeBackground()
        {
            byte[] background = Video.ImportImage();

            if (background != null && Communicator.UseTo.Talk(SerializeChangeBackgroundRequest(background)) != null)
            {
                SetBackground(background);
            }
        }

        private void Update(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "hide":
                    Hide();
                    break;
                case "mute":
                    Mute();
                    break;
                case "kick":
                    Kick();
                    break;
                case "rename":
                case "host_rename":
                    Rename();
                    break;
                case "stop_share":
                    StopShare();
                    break;
                case "make_host":
                    MakeHost();
                    break;
                case "change_background":
                case "host_change_background":
                    ChangeBackground();
                    break;
            }
        }
    }

    public class Descriptions
    {
        public const string SELF = " (Me)";
        public const string HOST = " (Host)";
        public const string SELF_HOST = " (Me, Host)";
    }
}
