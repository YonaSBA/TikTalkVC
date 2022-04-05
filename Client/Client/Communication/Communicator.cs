using System;
using System.Net;
using System.Text;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Client
{
    public sealed class Communicator
    {
        private byte[] m_token;
        private TcpClient m_tcp;
        private string m_hostName;
        private NetworkStream m_stream;

        private const int INT_SIZE = 4;
        private const int IP_INDEX = 38;
        private const int DST_PORT = 3704;
        private const int TOKEN_SIZE = 16;
        private const int LENGTH_SIZE = TOKEN_SIZE + INT_SIZE;

        private static Communicator m_communicator = new Communicator();
        public static Communicator UseTo { get => m_communicator; }
        private Communicator()
        {
            m_tcp = new TcpClient(GetHostName(), DST_PORT);
            m_stream = m_tcp.GetStream();
            ConfirmToken();
        }
        ~Communicator()
        {
            m_tcp.Close();
        }
    
        public string GetHostName()
        {
            if (m_hostName == null)
            {
                string message = "";
                IPEndPoint local = new IPEndPoint(IPAddress.Any, 9050);
                UdpClient sock = new UdpClient(local);

                do
                {
                    message = Encoding.ASCII.GetString(sock.Receive(ref local));
                } while (!message.Contains("TikTalk Server"));

                sock.Close();
                m_hostName = message.Substring(IP_INDEX);
            }
            return m_hostName;
        }

        private void ConfirmToken()
        {
            m_token = CreateToken();

            m_stream.Write(m_token, 0, m_token.Length);
            byte[] buffer = new byte[TOKEN_SIZE];
            m_stream.Read(buffer, 0, TOKEN_SIZE);

            Response response = new Response(buffer);
            if (response.IsError())
            {
                MessageBox.Show("Client Crashed.");
            }
        }
        private byte[] CreateToken()
        {
            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.ASCII.GetBytes((m_tcp.Client.LocalEndPoint as IPEndPoint).ToString()));
            }
        }
        public string Encrypt(string source)
        { 
            using (MD5 md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(source))).Replace("-", string.Empty);
            }
        }

        public string Talk(byte[] data)
        {
            byte[] buffer = m_token.Concat(data).ToArray();
            byte[] length = m_token.Concat(BitConverter.GetBytes(buffer.Length)).ToArray();
       
            try
            {
                m_stream.Write(length, 0, LENGTH_SIZE);
                m_stream.Write(buffer, 0, buffer.Length);

                length = new byte[INT_SIZE];
                m_stream.Read(length, 0, INT_SIZE);

                buffer = new byte[BitConverter.ToInt32(length, 0)];
                m_stream.Read(buffer, 0, buffer.Length);

                Response response = new Response(buffer);
                return response.IsError() ? response.ShowError() : response.m_data;
            }
            catch
            {
                MessageBox.Show("Server Crashed.");
                return null;
            }
        }
    }
}
