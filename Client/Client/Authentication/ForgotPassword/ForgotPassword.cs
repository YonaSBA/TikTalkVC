using System;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Client
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            KeyPreview = true;
            InitializeComponent();
            Program.SetEvents(new TextBox[] { username, email });
        }

        public byte[] SerializeRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                AuthenticationCodes.FORGOT_PASSWORD + JsonSerializer.Serialize
                (
                    new ForgotPasswordRequest
                    {
                        username = username.Text,
                        email = email.Text
                    }
                )
            );
        }

        private void Recovery(object sender, EventArgs e)
        {
            if (Communicator.UseTo.Talk(SerializeRequest()) != null)
            {   
                new ChangePassword().Show();
            }
        }

        private void Shortcuts(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Recovery(null, null);
            }
        }
    }
}
