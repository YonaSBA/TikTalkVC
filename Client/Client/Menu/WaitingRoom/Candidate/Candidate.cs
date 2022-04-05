using System;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Client
{
    public partial class Candidate : UserControl
    {
        public Candidate(string username)
        {
            InitializeComponent();

            this.username.Text = username;
        }

        private byte[] SerializeRequest(bool choice)
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.CANDIDATE + JsonSerializer.Serialize
                (
                    new ConfirmRequest
                    {
                        confirm = choice,
                        username = username.Text
                    }
                )
            );
        }

        private void Confirm(object sender, EventArgs e)
        {
            Communicator.UseTo.Talk(SerializeRequest((sender as Button).Text == "Admit"));
        }
    }
}
