using Newtonsoft.Json;
using System.Windows.Forms;

namespace Client
{
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Hospitality : UserControl
    {
        [JsonProperty] public bool id { get => id_checkBox.Checked; set => id_checkBox.Checked = value; }
        [JsonProperty] public bool chat { get => chat_checkBox.Checked; set => chat_checkBox.Checked = value; }
        [JsonProperty] public bool start_video { get => startVideo.Checked; set => startVideo.Checked = value; }
        [JsonProperty] public bool rename { get => rename_checkBox.Checked; set => rename_checkBox.Checked = value; }
        [JsonProperty] public bool share_screen { get => shareScreen.Checked; set => shareScreen.Checked = value; }
        [JsonProperty] public bool waiting_room { get => waitingRoom.Checked; set => waitingRoom.Checked = value; }
        [JsonProperty] public bool unmute { get => unmute_checkBox.Checked; set => unmute_checkBox.Checked = value; }

        public Hospitality()
        {
            InitializeComponent();
        }
    }
}
