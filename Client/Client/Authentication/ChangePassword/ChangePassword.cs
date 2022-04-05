using System;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Client
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            KeyPreview = true;
            InitializeComponent();
            Program.SetEvents(new TextBox[] { code, new_password, confirm_new_password });
        }

        public byte[] SerializeRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                AuthenticationCodes.CHANGE_PASSWORD + JsonSerializer.Serialize
                (
                    new ChangePasswordRequest
                    {
                        code = code.Text,
                        password = Communicator.UseTo.Encrypt(new_password.Text)
                    }
                )
            );
        }
        private void Done(object sender, EventArgs e)
        {
            try
            {
                if (new_password.Text != confirm_new_password.Text)
                    throw new ConfirmPasswordException();

                if (!SignIn.IsPasswordValid(new_password.Text))
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
                Done(null, null);
            }
        }
    }
}
