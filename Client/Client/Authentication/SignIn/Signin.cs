using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Client
{
    public partial class SignIn : Form
    {
        public const string PASSWORD_REGEX = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{4,}$";
        private string m_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Authentication\\SignIn\\Config.txt");

        public SignIn()
        {
            KeyPreview = true;
            InitializeComponent();
            Program.SetEvents(new TextBox[] { username, password });
        }

        private void RememberMe()
        {
            SignInRequest request = File.Exists(m_path) ? JsonSerializer.Deserialize<SignInRequest>(File.ReadAllText(m_path)) : null;
            
            if (request != null)
            {
                TextBoxManager.Set(username, request.username);
                TextBoxManager.Set(password, request.password);
            }
        }
        private byte[] SerializeRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                AuthenticationCodes.SIGN_IN + JsonSerializer.Serialize
                (
                    new SignInRequest
                    {
                        username = username.Text,
                        password = Communicator.UseTo.Encrypt(password.Text)
                    }
                )
            );
        }

        private void SignInEvent(object sender, EventArgs e)
        {
            try
            {
                if (!IsPasswordValid(password.Text))
                    throw new BadPasswordException();

                if (Communicator.UseTo.Talk(SerializeRequest()) != null)
                {
                    if (remember.Checked)
                    {
                        File.WriteAllText(m_path, JsonSerializer.Serialize(new SignInRequest
                        {
                            username = username.Text,
                            password = password.Text
                        }));
                    }

                    Program.Move(this, new Menu(username.Text));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }  
        }
        private void SignUpEvent(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SignUp().Show();
        }
        private void ForgotPasswordEvent(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ForgotPassword().Show();
        }

        public static bool IsPasswordValid(string password)
        {
            return new Regex(PASSWORD_REGEX).IsMatch(password);
        }

        private void Shortcuts(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignInEvent(null, null);
            }
        }
        private void ChangeVisible(object sender, EventArgs e)
        {
            if (Visible)
            {
                RememberMe();
            }
            else
            {
                TextBoxManager.Reset(username);
                TextBoxManager.Reset(password);
            }
        }
        private void Exit(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }
    }
}