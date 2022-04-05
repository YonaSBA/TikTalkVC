using System;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Client
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            KeyPreview = true;
            InitializeComponent();
            Program.SetEvents(new TextBox[] { username, password, confirm_password, email, confirm_email });
        }

        public byte[] SerializeRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                AuthenticationCodes.SIGN_UP + JsonSerializer.Serialize
                (
                    new SignUpRequest
                    {
                        email = email.Text,
                        username = username.Text,
                        password = Communicator.UseTo.Encrypt(password.Text)
                    }
                )
            );
        }

        private void SignUpEvent(object sender, EventArgs e)
        {
            try
            {
                if (password.Text != confirm_password.Text)
                    throw new ConfirmPasswordException();

                if (email.Text != confirm_email.Text)
                    throw new ConfirmEmailException();

                if (!SignIn.IsPasswordValid(password.Text))
                    throw new BadPasswordException();

                if (Communicator.UseTo.Talk(SerializeRequest()) != null)
                    Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Shortcuts(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignUpEvent(null, null);
            }
        }
    }
}
