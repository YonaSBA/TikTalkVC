using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Timers;

namespace Server
{
    class Communicator
    {
        private const int INT_SIZE = 4;
        private const int SRC_PORT = 3704;
        private const int TOKEN_SIZE = 16;
        private const int LENGTH_SIZE = TOKEN_SIZE + INT_SIZE;

        private ClientsManager m_clientManager;
        private TcpListener m_tcpListener;
        private RequestHandlerFactory m_requestHandlerFactory;
         
        public Communicator(ref RequestHandlerFactory requestHandlerFactory)
        {
            m_requestHandlerFactory = requestHandlerFactory;
            m_clientManager = requestHandlerFactory.GetClinetsMamager();
            m_tcpListener = new TcpListener(new IPEndPoint(GetMyIP(), SRC_PORT));
        }

        public void Run()
        {
            Console.WriteLine("Server brodcasting ip: " + GetMyIP());
            // create a timer
            var timer = new System.Timers.Timer();
            timer.Interval = 2000;
            timer.Elapsed += BrodcastIP;
            timer.AutoReset = true;
            timer.Enabled = true;

            m_tcpListener.Start();
            Console.WriteLine("Listening on port: " + SRC_PORT);

            while (true)
            {
                Client newClient = new Client(m_tcpListener.AcceptTcpClient(), m_requestHandlerFactory.CreateAuthenticationHandler());
                Console.WriteLine("Tcp Client accepted: " + newClient.GetTCPEndPoint());

                byte[] buffer = new byte[TOKEN_SIZE];
                newClient.GetTCPStream().Read(buffer, 0, buffer.Length);

                try
                {
                    m_clientManager.AddClient(Encoding.ASCII.GetString(buffer), newClient);

                    Response res = new Response("000", m_requestHandlerFactory.CreateAuthenticationHandler());
                    newClient.GetTCPStream().Write(res.getBuffer(), 0, res.getLength());

                    Thread thread = new Thread(() => HandleClient(ref newClient));
                    thread.Start();
                }
                catch (MyException exception)
                {
                    Response res = new Response(exception);
                    newClient.GetTCPStream().Write(res.getBuffer(), 0, res.getLength()); 
                }

                Console.WriteLine("Tcp Clients count: " + m_clientManager.GetCount());
            }
        }

        private void HandleClient(ref Client client)
        {
            byte[] buffer = new byte[LENGTH_SIZE];
            NetworkStream stream = client.GetTCPStream();

            while (true)
            {
                try
                {
                    if (Convert.ToBoolean(stream.Read(buffer, 0, buffer.Length)))
                    {
                        buffer = new byte[BitConverter.ToInt32(buffer, 16)];
                        stream.Read(buffer, 0, buffer.Length);

                        Response res;
                        try
                        { res = client.GetRequestHandler().HandleRequest(new Request(buffer)); }
                        catch (JsonException)
                        { res = new Response(new BadJsonException()); }
                        catch (Kick)
                        {
                            res = new Response(new KickException());
                            client.SetRequestHandler(m_requestHandlerFactory.CreateMenuHandler(client.GetRequestHandler().GetUsername(), new Pair<bool, bool>(true, false)));
                        }
                        catch (Close)
                        {
                            res = new Response(new CloseException());
                            client.SetRequestHandler(m_requestHandlerFactory.CreateMenuHandler(client.GetRequestHandler().GetUsername(), new Pair<bool, bool>(false, true)));
                        }

                        stream.Write(BitConverter.GetBytes(res.getLength()), 0, INT_SIZE);
                        stream.Write(res.getBuffer(), 0, res.getLength());

                        if (res.getNewHandler() != null)
                            client.SetRequestHandler(res.getNewHandler());

                        buffer = new byte[LENGTH_SIZE];
                    }
                    else
                        throw new Exception("socket closed");

                }
                catch (Exception e)
                {
                    Console.WriteLine("Client left: " + e.Message);
                    Console.WriteLine("Client left: " + e.StackTrace);
                    Console.WriteLine("Client left: " + e.Source);
                    
                    var ClientHandler = client.GetRequestHandler();
                    var b = m_requestHandlerFactory.CreateAuthenticationHandler();
                    var c = m_requestHandlerFactory.CreateMenuHandler("");
                    var d = m_requestHandlerFactory.CreateMeetingHandler("1", 0, "1");

                    if (!(ClientHandler.GetType() == b.GetType()))
                    {
                        if (ClientHandler.GetType() == c.GetType())
                        {
                            MenuHandler m = (MenuHandler)ClientHandler;
                            if (m.m_waitingRoom != null)
                            {
                                m_requestHandlerFactory.GetMeetingManager().LeaveWaitingRoom(m.GetUsername(), m.m_waitingRoom);
                            }
                        }
                        else if (ClientHandler.GetType() == d.GetType())
                        {
                            MeetingHandler m = (MeetingHandler)ClientHandler;
                            try
                            {
                                m_requestHandlerFactory.GetMeetingManager().LeaveMeeting(m.GetCode(), m.GetParticipantID());
                            }
                            catch (Exception)
                            {
                            }
                        }
                        m_requestHandlerFactory.GetAuthenticator().SignOut(ClientHandler.GetUsername());
                    }

                    m_clientManager.RemoveClient(client);
                    Console.WriteLine("Tcp Clients count: " + m_clientManager.GetCount());
                    try
                    { client.GetTCPStream().Close(); }
                    catch { }
                    // todo write to log file
                    break;
                }
            }        
        }
        static void BrodcastIP(object source, ElapsedEventArgs e)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep1 = new IPEndPoint(IPAddress.Broadcast, 9050);
            IPEndPoint iep2 = new IPEndPoint(IPAddress.Parse("192.168.255.255"), 9050);
            IPEndPoint iep3 = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9050);

            byte[] data = Encoding.ASCII.GetBytes("Hi! I'm TikTalk Server binding to IP: " + GetMyIP().ToString());
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            sock.SendTo(data, iep1);
            sock.SendTo(data, iep2);
            sock.SendTo(data, iep3);
            sock.Close();
        }

        private static IPAddress GetMyIP()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address;
            }
        }
    }
}