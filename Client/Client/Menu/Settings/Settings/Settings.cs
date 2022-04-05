using System;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;
using System.Windows.Forms;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Client
{
    public partial class Settings : Form
    {
        private Button m_current;
        private SettingsData m_data;

        public Settings(string name)
        {
            InitializeComponent();

            Open();
            username.Text = name;
            m_current = participation_button;
        }

        public Hospitality GetHospitality()
        {
            return m_data.hospitality;
        }
        public Participation GetParticipation()
        {
            return m_data.participation;
        }

        private void Focus(Button button, UserControl settings)
        {
            signer.Left = button.Left;
            signer.Top = button.Top + 4;
            signer.Height = button.Height - 4;

            setting_label.Text = button.Text;

            m_current.BackColor = Color.FromArgb(60, 60, 60);
            button.BackColor = Color.FromArgb(40, 40, 40);

            m_current = button;
            category_pannel.Controls.Clear();
            category_pannel.Controls.Add(settings);
        }

        private void HospitalityEvent(object sender, EventArgs e)
        {
            Focus(hospitality_button, m_data.hospitality);
        }
        private void ParticipationEvent(object sender, EventArgs e)
        {
            Focus(participation_button, m_data.participation);
        }

        private byte[] SerializeUpdateSettingsRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                MenuCodes.UPDATE_SETTINGS + JsonConvert.SerializeObject
                (
                    new UpdateSettingsRequest
                    {
                        settings = JsonConvert.SerializeObject(m_data)
                    }
                )
            );
        }

        private void Open()
        {
            m_data = JsonSerializer.Deserialize<SettingsData>(JsonSerializer.Deserialize<GetSettingsResponse>(Communicator.UseTo.Talk(Request.Empty(MenuCodes.GET_SETTINGS))).settings);
        }
        public void Save(object sender, FormClosingEventArgs e)
        {
            Communicator.UseTo.Talk(SerializeUpdateSettingsRequest());
        }
    }

    public class SettingsData
    {
        public Hospitality hospitality { get; set; }
        public Participation participation { get; set; }
    }
}