using System.Text;

namespace Server
{
    public class Response
    {
        private byte[] m_buffer { get; set; }
        private IRequestHandler m_newHandler { get; set; }

        public Response(string code, IRequestHandler newHandler)
        {
            m_buffer = Encoding.ASCII.GetBytes(code + "{}");
            m_newHandler = newHandler;
        }

        public Response(string code)
        {
            m_buffer = Encoding.ASCII.GetBytes(code + "{}");
            m_newHandler = null;
        }

        public Response(string code, string data, IRequestHandler newHandler)
        {
            m_buffer = Encoding.ASCII.GetBytes(code + data);
            m_newHandler = newHandler;
        }

        public Response(string code, string data)
        {
            m_buffer = Encoding.ASCII.GetBytes(code + data);
            m_newHandler = null;
        }

        public Response(MyException exception, IRequestHandler newHandler)
        {
            m_buffer = Encoding.ASCII.GetBytes(exception.ToString());
            m_newHandler = newHandler;
        }

        public Response(MyException exception)
        {
            m_buffer = Encoding.ASCII.GetBytes(exception.ToString());
            m_newHandler = null;
        }

        public byte[] getBuffer()
        {
            return m_buffer;
        }

        public int getLength()
        {
            return m_buffer.Length;
        }

        public IRequestHandler getNewHandler()
        {
            return m_newHandler;
        }
    };
}
