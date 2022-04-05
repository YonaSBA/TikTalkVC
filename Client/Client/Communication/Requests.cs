using System.Text;

namespace Client
{
    public static class Request
    {
        public static byte[] Empty(string code) => Encoding.ASCII.GetBytes(code + "{}");
    }
}
