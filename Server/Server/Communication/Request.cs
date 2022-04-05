using System.Linq;
using System.Text;

namespace Server
{
    public class Request
    {
        public string m_code { get; private set; }
        public string m_data { get; private set; }
        public string m_token { get; private set; }

        public Request(byte[] buffer)
        {
            m_token = Encoding.ASCII.GetString(buffer.Take(16).ToArray());
            m_code = Encoding.ASCII.GetString(buffer.Skip(16).Take(3).ToArray());
            m_data = Encoding.ASCII.GetString(buffer.Skip(19).Take(buffer.Length - 19).ToArray());
        }

        public char getFamily()
        {
            return m_code[0];
        }
    };
}
