using System;
using System.Net;
using System.Text;
using System.Linq;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace Server
{
    public class Streamer
    {
        private Dictionary<int, Trio<IPEndPoint, IPEndPoint, IPEndPoint>> participants;
        private static byte[] QC = Encoding.ASCII.GetBytes("QCQC");
        private const int BUFFER_SIZE = 1024;

        private AutoResetEvent VideoNotefier;
        private AutoResetEvent AudioNotefier;
        private AutoResetEvent ScreenNotefier;
        
        private int m_VideoPort;
        private int m_SoundPort;
        private int m_ScreenPort;

        private UdpClient m_imSocket;
        private UdpClient m_auSocket;
        private UdpClient m_scSocket;

        Thread ReceiveImThread;
        Thread SendImThread;
        Thread ReceiveAuThread;
        Thread SendAuThread;
        Thread ReceiveScThread;
        Thread SendScThread;

        private Queue<Tuple<IPEndPoint, byte[]>> m_images;
        private Queue<Tuple<IPEndPoint, byte[]>> m_sounds;
        private Queue<Tuple<IPEndPoint, byte[]>> m_screenShots;
        
        public Streamer(Trio<int, int ,int> ports)
        {
            m_VideoPort = ports.First;
            m_SoundPort = ports.Second;
            m_ScreenPort = ports.Third;
            Console.WriteLine("Streamer runs video " + m_VideoPort.ToString() + ", sound " + m_SoundPort.ToString() + ", screenShere " + m_ScreenPort.ToString());

            participants = new Dictionary<int, Trio<IPEndPoint, IPEndPoint, IPEndPoint>>();
            VideoNotefier = new AutoResetEvent(false);
            AudioNotefier = new AutoResetEvent(false);
            ScreenNotefier = new AutoResetEvent(false);

            m_imSocket = new UdpClient(new IPEndPoint(IPAddress.Any, m_VideoPort));
            m_auSocket = new UdpClient(new IPEndPoint(IPAddress.Any, m_SoundPort));
            m_scSocket = new UdpClient(new IPEndPoint(IPAddress.Any, m_ScreenPort));

            m_images = new Queue<Tuple<IPEndPoint, byte[]>>();
            m_sounds = new Queue<Tuple<IPEndPoint, byte[]>>();
            m_screenShots = new Queue<Tuple<IPEndPoint, byte[]>>();

            SendImThread = new Thread(() => SendVideo());
            SendImThread.Start();

            ReceiveImThread = new Thread(() => ReceiveVideo());
            ReceiveImThread.Start();

            SendAuThread = new Thread(() => SendAudio());
            SendAuThread.Start();

            ReceiveAuThread = new Thread(() => ReceiveSound());
            ReceiveAuThread.Start();

            SendScThread = new Thread(() => SendScreen());
            SendScThread.Start();

            ReceiveScThread = new Thread(() => ReceiveScreen());
            ReceiveScThread.Start();
        }
        public void Close()
        {
            Console.WriteLine("Streamer closed video " + m_VideoPort.ToString() + ", sound " + m_SoundPort.ToString() + ", screenShere " + m_ScreenPort.ToString());
            m_imSocket.Close();
            m_imSocket.Dispose();
            m_auSocket.Close();
            m_auSocket.Dispose();
            m_scSocket.Close();
            m_scSocket.Dispose();
        }
        public void AddUser(int id, Trio<IPEndPoint, IPEndPoint, IPEndPoint> ports)
        {
            if (participants.ContainsKey(id))
                throw new NoSuchIdExpection();
            participants[id] = ports;
        }
        public void RemoveUser(int id)
        {
            if (!participants.Remove(id))
                Console.WriteLine("error line 102");
        }
        private void ReceiveVideo()
        {
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[BUFFER_SIZE];
            while (true)
            {
                try
                {
                    data = m_imSocket.Receive(ref sender);

                    m_images.Enqueue(new Tuple<IPEndPoint, byte[]>(sender, data));
                    VideoNotefier.Set();
                }
                catch (Exception )
                {
                    break;
                }
            }
        }
        private void SendVideo()
        {
            while (true)
            {
                try
                {
                    VideoNotefier.WaitOne();
                    Tuple<IPEndPoint, byte[]> picture = m_images.Dequeue();

                    if (IsMonitoingPacket(picture.Item2))
                        SendPic(picture.Item2, picture.Item1);
                    else
                    {
                        foreach (var item in participants.Values)
                        {
                            if (!picture.Item1.Equals(item.First))
                                SendPic(picture.Item2, item.First);
                        }
                    }
                }
                catch (Exception e) { Console.WriteLine("error while sending: " + e.Message); }
            }
        }
        private void ReceiveSound()
        {
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[BUFFER_SIZE];
            while (true)
            {
                try
                {
                    data = m_auSocket.Receive(ref sender);

                    m_sounds.Enqueue(new Tuple<IPEndPoint, byte[]>(sender, data));
                    AudioNotefier.Set();
                }
                catch (Exception)
                {
                    break;
                }
            }
        }
        private void SendAudio()
        {
            while (true)
            {
                try
                {
                    AudioNotefier.WaitOne();
                    Tuple<IPEndPoint, byte[]> sound = m_sounds.Dequeue();

                    if (IsMonitoingPacket(sound.Item2))
                    {
                        SendAu(sound.Item2, sound.Item1);
                    }
                    else
                    {
                        foreach (var item in participants.Values)
                        {
                            if (!sound.Item1.Equals(item.Second))
                                SendAu(sound.Item2, item.Second);
                        }
                    }
                }
                catch (Exception e) { Console.WriteLine("error while sending: " + e.Message); }
            }
        }
        private void ReceiveScreen()
        {
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[BUFFER_SIZE];
            while (true)
            {
                try
                {
                    data = m_scSocket.Receive(ref sender);

                    m_screenShots.Enqueue(new Tuple<IPEndPoint, byte[]>(sender, data));
                    ScreenNotefier.Set();
                }
                catch (Exception)
                {
                    break;
                }
            }
        }
        private void SendScreen()
        {
            while (true)
            {
                try
                {
                    ScreenNotefier.WaitOne();
                    Tuple<IPEndPoint, byte[]> screenShots = m_screenShots.Dequeue();
                    foreach (var item in participants.Values)
                    {
                        if (!screenShots.Item1.Equals(item.Third))
                            SendSs(screenShots.Item2, item.Third);
                    }
                }
                catch (Exception e) { Console.WriteLine("error while sending: " + e.Message); }
            }
        }
        private void SendPic(byte[] buffer, IPEndPoint endPoint)
        {
            m_imSocket.Send(buffer, buffer.Length, endPoint);
        }
        private void SendAu(byte[] buffer, IPEndPoint endPoint)
        {
            m_auSocket.Send(buffer, buffer.Length, endPoint);
        }
        private void SendSs(byte[] buffer, IPEndPoint endPoint)
        {
            m_scSocket.Send(buffer, buffer.Length, endPoint);
        }

        public Trio<int,int,int> GetPorts() { return new Trio<int, int, int>(m_VideoPort, m_SoundPort, m_ScreenPort); }

        private bool IsMonitoingPacket(byte[] packet) 
        {
            return Encoding.ASCII.GetString(packet) == Encoding.ASCII.GetString(QC);
        }
    }
}
