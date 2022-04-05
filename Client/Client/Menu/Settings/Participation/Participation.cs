using System;
using System.Drawing;
using Newtonsoft.Json;
using System.Text.Json;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Client
{
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Participation : UserControl
    {
        private string m_nickname { get; set; }
        private byte[] m_background { get; set; }

        [JsonProperty] public string nickname
        {
            get => TextBoxManager.Return(default_nickname, m_nickname);
            set
            {
                m_nickname = value;
                default_nickname.Text = value;
                default_nickname.ForeColor = Color.RoyalBlue;
            }
        }
        [JsonProperty] public byte[] background
        {
            get => m_background;
            set
            {
                m_background = value;
                background_pictureBox.BackgroundImage = Video.ToImage(value);
            }
        }
        [JsonProperty] public bool share { get; set; }
        [JsonProperty] public int volume { get => volume_bar.Value; set => volume_bar.Value = value; }
        [JsonProperty] public bool stop_video { get => stopVideo.Checked; set => stopVideo.Checked = value; }
        [JsonProperty] public bool mute { get => muteMicrophone.Checked; set => muteMicrophone.Checked = value; }

        public Participation()
        {
            InitializeComponent();
            Program.SetEvents(new TextBox[] { default_nickname });
        }
        public Participation(string nickname)
        {
            InitializeComponent();
            this.nickname = nickname;
            Program.SetEvents(new TextBox[] { default_nickname });
        }

        private void Rename(object sender, EventArgs e)
        {
            if (new Regex("^[a-zA-Z0-9_.-]{1,10}$").IsMatch(default_nickname.Text))
            {
                m_nickname = default_nickname.Text;
            }
            else
            {
                MessageBox.Show("Nickname must be more than 0 characters, less than 10 characters, and contains only lowers, uppers, numbers and underscore.");
            }
        }
        private void PickBackground(object sender, EventArgs e)
        {
            background = Video.ImportImage();
        }
    }
}