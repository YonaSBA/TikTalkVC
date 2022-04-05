using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;

namespace Server
{
    public class Authenticator
    {
        private List<string> m_users;
        private IInputCheck m_checker;
        private IUsersQueries m_usersQueries;
        private Dictionary<string, string> m_codes = new Dictionary<string, string>();

        public Authenticator(ref IUsersQueries usersQweries)
        {
            m_users = new List<string>();
            m_usersQueries = usersQweries;
            m_checker = new RegexInputCheck();
        }

        internal void SignIn(string username, string password)
        {
            if (!m_checker.IsUsernameValid(username) || !m_usersQueries.DoesUserExist(username))
                throw new UserNotExistException();

            if (m_users.Contains(username))
                throw new UserAlreadyInException();

            if (!m_checker.IsPasswordValid(password) || !m_usersQueries.DoesPasswordMatch(username, password))
                throw new PasswordNotMatchException();

            m_users.Add(username);
        }

        internal void SignUp(string username, string password, string email)
        {
            if (!m_checker.IsUsernameValid(username))
                throw new BadUsernameException();

            if (!m_checker.IsEmailValid(email))
                throw new BadEmailException();

            if (!m_checker.IsPasswordValid(password))
                throw new BadPasswordException();

            if (m_usersQueries.DoesUserExist(username))
                throw new UserAlreadyExistException();

            m_usersQueries.AddNewUser(username, password, email);
        }

        internal void SignOut(string username)
        {
            if (!m_users.Remove(username))
                throw new UserNotInException();
        }

        internal void ForgotPassword(string username, string email)
        {
            if (!m_checker.IsUsernameValid(username) || !m_usersQueries.DoesUserExist(username))
                throw new UserNotExistException();

            if (!m_usersQueries.DoesEmailMatch(username, email))
                throw new EmailNotMatchException();

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("tiktalkvc2@gmail.com", "gilad&yona");

            try
            {
                client.Send(new MailMessage("tiktalkvc2@gmail.com", email, "Your Code", GenerateCode(username)));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        internal void ChangePassword(string code, string password)
        {
            if (!m_checker.IsPasswordValid(password))
                throw new BadPasswordException();

            m_usersQueries.ChangePassword(m_codes[code], password);
            m_codes.Remove(code);
        }

        private string GenerateCode(string username)
        {
            string code;
            Random generator = new Random();

            do
            {
                code = generator.Next(0, 1000000).ToString("D6");
            } while (m_codes.ContainsKey(code));

            m_codes.Add(code, username);
            return code;
        }
    }
}
