using System;
using System.Text;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Windows.Forms;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Client
{
    public partial class Menu : Form
    {
        private Join m_join;
        private History m_history;
        private Settings m_settings;

        public static bool m_inMeeting = false;

        public Menu(string username)
        {
            InitializeComponent();
            this.username.Text = username;
        }

        private Pair<byte[], Pair<Participation, Hospitality>> SerializeRequest(Trio<int> ports)
        {
            Settings settings = new Settings(username.Text);

            byte[] request = Encoding.ASCII.GetBytes
            (
                MenuCodes.CREATE_MEETING + JsonConvert.SerializeObject
                (
                    new HandShakeRequest
                    {
                        ports = ports,
                        participation = settings.GetParticipation()
                    }
                )
            );

            settings.Close();
            return new Pair<byte[], Pair<Participation, Hospitality>>(request, new Pair<Participation, Hospitality>(settings.GetParticipation(), settings.GetHospitality()));
        }

        private void NewEvent(object sender, EventArgs e)
        {
            string response = Communicator.UseTo.Talk(Request.Empty(MenuCodes.CREATE_MEETING));

            if (response != null)
            {
                Trio<UdpClient> sockets = Streamer.SetPort(Communicator.UseTo.GetHostName(), JsonSerializer.Deserialize<HandShakeResponse>(response).ports);
                Pair<byte[], Pair<Participation, Hospitality>> request = SerializeRequest(Streamer.GetPort(sockets));
                response = Communicator.UseTo.Talk(request.First);

                if (response != null)
                {
                    CreateMeetingResponse data = JsonSerializer.Deserialize<CreateMeetingResponse>(response);
                    Program.Move(this, new Meeting(data.meeting, data.participant, sockets, request.Second.First, request.Second.Second, username.Text));
                }
            }
        }
        private void JoinEvent(object sender, EventArgs e)
        {
            if (m_join != null && !m_join.IsDisposed)
            {
                m_join.BringToFront();
            }
            else
            {
                m_join = new Join(this, username.Text);
                m_join.Show();
            }        
        }
        private void HistoryEvent(object sender, EventArgs e)
        {
            if (m_history != null && !m_history.IsDisposed)
            {
                m_history.BringToFront();
            }
            else
            {
                m_history = new History();
                m_history.Show();
            }
        }
        private void SignOutEvent(object sender, EventArgs e)
        {
            Communicator.UseTo.Talk(Request.Empty(MenuCodes.SIGN_OUT));
            Program.Move(this, new SignIn());
        }
        private void SettingsEvent(object sender, EventArgs e)
        {
            if (m_settings != null && !m_settings.IsDisposed)
            {
                m_settings.BringToFront();
            }
            else
            {
                m_settings = new Settings(username.Text);
                m_settings.Show();
            }
        }

        private void Exit(object sender, FormClosedEventArgs e)
        {
            if (!m_inMeeting)
            {
                Communicator.UseTo.Talk(Request.Empty(MenuCodes.SIGN_OUT));
                Application.ExitThread();
                Environment.Exit(0);
            }
        }

        private void Hide(object sender, EventArgs e)
        {
            if (Visible)
                return;
            if (m_join != null && !m_join.IsWaiting())
                m_join.Close();
            if (m_history != null)
                m_history.Close();
            if (m_settings != null)
                m_settings.Close();
        }
    }

    public class Trio<T>
    {
        public T First { get; set; }
        public T Third { get; set; }
        public T Second { get; set; }

        public Trio(T first, T second, T third)
        {
            First = first;
            Third = third;
            Second = second;
        }
    }
}
