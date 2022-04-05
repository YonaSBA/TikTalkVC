using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Client
{
    public class Response
    {
        public const int CODE_SIZE = 3;
        public string m_code { get; private set; }
        public string m_data { get; private set; }

        public Response(byte[] buffer)
        {
            m_code = Encoding.ASCII.GetString(buffer.Take(CODE_SIZE).ToArray());
            m_data = Encoding.ASCII.GetString(buffer.Skip(CODE_SIZE).Take(buffer.Length - CODE_SIZE).ToArray());
        }

        public bool IsError()
        {
            return m_code[0] == Error.SIGN;
        }
        public string ShowError()
        { 
            if (JsonSerializer.Deserialize<Error>(m_data).message == "Request from another family.")
            {
                File.WriteAllText("error.txt", m_code.ToString());
            }
            else
            {
                MessageBox.Show(JsonSerializer.Deserialize<Error>(m_data).message);
            }

            return null;
        }
    };

    public class Error
    {
        public const char SIGN = '9';
        public string message { get; set; }
    }
}
