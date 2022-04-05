using System;
using System.Text;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Client
{
    public partial class Join : Form
    {
        private Menu m_menu;
        private string m_username;
        private WaitingRoom m_room;
        private Timer m_asker = new Timer();

        public Join(Menu menu, string username)
        {
            m_menu = menu;
            m_username = username;

            KeyPreview = true;
            InitializeComponent();

            Program.SetEvents(new TextBox[] { meeting_ID });

            m_asker.Interval = Program.SECOND;
            m_asker.Tick += GetAnswer;
        }

        private byte[] SerializeRequest(bool choice)
        {
            return Encoding.ASCII.GetBytes
            (
                MenuCodes.JOIN_MEETING + JsonConvert.SerializeObject
                (
                    new JoinMeetingRequest
                    {
                        choice = choice,
                        meeting = meeting_ID.Text,
                    }
                )
            );
        }
        private Pair<byte[], Pair<Participation, Hospitality>> SerializeRequest(Trio<int> ports)
        {
            Settings settings = new Settings(m_username);

            byte[] request = Encoding.ASCII.GetBytes
            (
                MenuCodes.JOIN_MEETING + JsonConvert.SerializeObject
                (
                    new ExpandedHandShakeRequest
                    {
                        ports = ports,  
                        meeting = meeting_ID.Text,
                        participation = settings.GetParticipation()
                    }
                )
            );

            settings.Close();
            return new Pair<byte[], Pair<Participation, Hospitality>>(request, new Pair<Participation, Hospitality>(settings.GetParticipation(), settings.GetHospitality()));
        }

        private bool NoAnswer(Trio<int> ports) => ports.First == 0;
        
        private void GetAnswer(object sender, EventArgs e)
        {
            string response = Communicator.UseTo.Talk(SerializeRequest(true));

            if (!response.Contains("."))
            {
                if (!m_room.IsDisposed)
                {
                    Trio<int> ports = JsonSerializer.Deserialize<HandShakeResponse>(response).ports;

                    if (NoAnswer(ports))
                    {
                        Cancel(false);
                    }
                    else
                    {
                        Trio<UdpClient> sockets = Streamer.SetPort(Communicator.UseTo.GetHostName(), JsonSerializer.Deserialize<HandShakeResponse>(response).ports);
                        Pair<byte[], Pair<Participation, Hospitality>> request = SerializeRequest(Streamer.GetPort(sockets));
                        response = Communicator.UseTo.Talk(request.First);

                        if (response != null)
                        {
                            JoinMeetingResponse data = JsonSerializer.Deserialize<JoinMeetingResponse>(response);
                            Program.Move(m_menu, new Meeting(meeting_ID.Text, data.participant, sockets, request.Second.First, request.Second.Second, m_username, data.host, data.participants));
                            Stop(); Close();
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        if (Communicator.UseTo.Talk(SerializeRequest(false)) != null)
                        {
                            break;
                        }
                    }

                    Cancel(true);
                }   
            }
            else
            {
                bool isWaiting = Visible;
                Cancel(true);
                MessageBox.Show(response.Contains("not exist") && !isWaiting ? "The meeting has been closed by the host." : JsonSerializer.Deserialize<Error>(response).message);
            }
        }
        private void JoinMeeting(object sender, EventArgs e)
        {
            meeting_ID.Text = meeting_ID.Text.Trim();
            m_room = new WaitingRoom(meeting_ID.Text, m_menu, this);

            m_asker.Start();
        }

        private void Stop()
        {
            m_asker.Stop();    
            m_room.Close();
        }
        private void Cancel(bool state)
        {
            m_menu.Visible = state;
            m_room.Visible = !state;
            Visible = state;

            if (state)
            {
                Stop();
            }
        }
        public bool IsWaiting() => m_asker.Enabled;

        private void Shortcuts(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                JoinMeeting(null, null);
            }
        }
    }

    public class Pair<T, U>
    {
        public T First { get; set; }
        public U Second { get; set; }

        public Pair(T first, U second)
        {
            First = first;
            Second = second;
        }
    }
}