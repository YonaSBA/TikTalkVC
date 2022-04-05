using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Server
{
    public class Client
    {
        private TcpClient m_tcp;
        private IRequestHandler m_requestHandler;
        private Trio<IPEndPoint, IPEndPoint, IPEndPoint> m_udp;

        public Client(TcpClient client, AuthenticationHandler authenticationHandler)
        {
            m_tcp = client;
            m_requestHandler = authenticationHandler;
        }

        public Client(Client other)
        {
            m_tcp = other.m_tcp;
            m_udp = other.m_udp;
            m_requestHandler = other.m_requestHandler;
        }
        public IPEndPoint GetTCPEndPoint()
        {
            return m_tcp.Client.RemoteEndPoint as IPEndPoint;
        }
        public NetworkStream GetTCPStream()
        {
            return m_tcp.GetStream();
        }

        public Trio<IPEndPoint, IPEndPoint, IPEndPoint> GetUDPEndPoints()
        {
            return m_udp;
        }
        public void SetUDPEndPoints(Trio<int, int, int> ports)
        {
            IPAddress ip = GetTCPEndPoint().Address;
            m_udp = new Trio<IPEndPoint, IPEndPoint, IPEndPoint>(new IPEndPoint(ip, ports.First), new IPEndPoint(ip, ports.Second), new IPEndPoint(ip, ports.Third));
        }

        public IRequestHandler GetRequestHandler()
        {
            return m_requestHandler;
        }
        public void SetRequestHandler(IRequestHandler requestHandler)
        {
            m_requestHandler = requestHandler;
        }
    }
}
