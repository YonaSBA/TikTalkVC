using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Client
{
    public partial class Chat : UserControl
    {
        private int m_id;
        private Dictionary<string, int> m_participants = new Dictionary<string, int>();

        public Chat(int id)
        {
            InitializeComponent();
            
            m_id = id;

            nicknames.Items.Add("Everyone");
            m_participants.Add("Everyone", -1);

            nicknames.SelectedIndex = 0;

            Program.SetEvents(new TextBox[] {message});
        }

        public void Remove(string nickname)
        {
            m_participants.Remove(nickname);
            
            if (nicknames.SelectedItem.ToString() == nickname)
            {
                nicknames.SelectedIndex = 0;
            }

            nicknames.Items.Remove(nickname);
        }
        public void Add(string nickname, int id)
        {
            nicknames.Items.Add(nickname);
            m_participants.Add(nickname, id);
        }
        public void Rename(string before, string after)
        {
            int id = m_participants[before];

            Remove(before);
            Add(after, id);
        }
        
        private byte[] SerializeMessageRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.SEND_MESSAGE + JsonSerializer.Serialize
                (
                    new SendMessageRequest
                    {
                        participant = m_id,
                        message = message.Text,
                        direct = m_participants[nicknames.SelectedItem.ToString()]
                    }
                )
            );
        }

        public void Send()
        {
            if (nicknames.SelectedItem != null && message.Text.Replace(" ", "").Length != 0 && Communicator.UseTo.Talk(SerializeMessageRequest()) != null)
            {
                messenger.Controls.Add(new Message("Me (to " + nicknames.SelectedItem.ToString() + ")", message.Text));
                message.Text = "";
            }
        }
        public void Recieve(string nickname, string message, bool direct)
        {
            messenger.Controls.Add(new Message(nickname + (direct ? " (directly)" : ""), message));
        }
    }
}
