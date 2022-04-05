using System.Windows.Forms;

namespace Client
{
    public partial class ParticipantStrip : UserControl
    {
        public ParticipantStrip(Participation participation)
        {
            InitializeComponent();

            SetShare(participation.share);
            SetAudio(!participation.mute);
            SetVideo(!participation.stop_video);
            SetNickname(participation.nickname);
        }

        public void SetShare(bool state)
        {
            share.BackgroundImage = state ? Properties.Resources.share : null;
        }
        public void SetVideo(bool state)
        {
            video.BackgroundImage = state ? Properties.Resources.start : Properties.Resources.stop;
        }
        public void SetAudio(bool state)
        {
            audio.BackgroundImage = state ? Properties.Resources.unmute : Properties.Resources.mute;
        }
        public void SetNickname(string nickname)
        {
            this.nickname.Text = nickname;
        }

        public string GetNickname() => nickname.Text;
    }
}
