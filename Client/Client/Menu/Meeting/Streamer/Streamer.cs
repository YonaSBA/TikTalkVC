using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace Client
{
    public class Streamer
    {
        private UdpClient m_video;
        private UdpClient m_audio;
        private UdpClient m_share;

        private IPEndPoint m_remoteVideo;
        private IPEndPoint m_remoteAudio;
        private IPEndPoint m_remoteShare;

        private Stopwatch m_watch = new Stopwatch();
        public double m_roundTrip { get; private set; }

        private byte[] m_id = new byte[4];
        private static byte[] QC = Encoding.ASCII.GetBytes("QCQC");

        public Streamer(int id, Trio<UdpClient> udpClients)
        {
            m_id = BitConverter.GetBytes(id);

            m_video = udpClients.First;
            m_share = udpClients.Third;
            m_audio = udpClients.Second;

            m_remoteVideo = m_video.Client.RemoteEndPoint as IPEndPoint;
            m_remoteAudio = m_audio.Client.RemoteEndPoint as IPEndPoint;
            m_remoteShare = m_share.Client.RemoteEndPoint as IPEndPoint;
        }
        
        public void Dispose()
        {
            m_video.Close();
            m_audio.Close();
            m_share.Close();
        }

        public void SendAudio(byte[] buffer)
        {
            byte[] message = Authenticate(buffer);
            m_audio.Send(message, message.Length);
        }
        public void SendVideo(byte[] buffer)
        {
            byte[] message = Authenticate(buffer);
            m_video.Send(message, message.Length);
        }
        public void SendShare(byte[] buffer)
        {
            byte[] message = Authenticate(buffer);
            m_share.Send(message, message.Length);
        }
        public void SendQC(object sender, EventArgs e)
        {
            try
            {
                m_watch.Start();
                m_audio.Send(QC, QC.Length);
            }
            catch { }
        }

        public Tuple<int, byte[]> ReceiveVideo()
        {
            try
            {
                return Extract(m_video.Receive(ref m_remoteVideo));
            }
            catch
            {
                throw;
            }
        }
        public Tuple<int, byte[]> ReceiveShare()
        {
            try 
            { 
                return Extract(m_share.Receive(ref m_remoteShare)); 
            } 
            catch 
            {
                throw;
            }   
        }
        public Tuple<int, byte[]> ReceiveAudio()
        {
            try
            {
                byte[] message = m_audio.Receive(ref m_remoteAudio);
                return IsQC(message) ? SetRoundTrip() : Extract(message);
            }
            catch
            {
                throw;
            }
        }

        private bool IsQC(byte[] buffer)
        {
            return Encoding.ASCII.GetString(buffer) == Encoding.ASCII.GetString(QC);
        }
        private byte[] Combine(byte[][] arrays)
        {
            return arrays.SelectMany(array => array).ToArray();
        }
        public Tuple<int, byte[]> SetRoundTrip()
        {
            m_watch.Stop();
            m_roundTrip = m_watch.Elapsed.TotalMilliseconds;

            m_watch.Reset();
            return null;
        }
        private byte[] Authenticate(byte[] buffer)
        {
            return Combine(new byte[][] { m_id, buffer, m_id});
        }
        private Tuple<bool, int> Identify(byte[] buffer)
        {
            int id = BitConverter.ToInt32(buffer.Take(4).ToArray(), 0);
            int confirm_id = BitConverter.ToInt32(buffer.Skip(buffer.Length - 4).Take(4).ToArray(), 0);

            return new Tuple<bool, int>(id == confirm_id, id);
        }
        private Tuple<int, byte[]> Extract(byte[] buffer)
        {
            Tuple<bool, int> result = Identify(buffer);
            return result.Item1 ? new Tuple<int, byte[]>(result.Item2, buffer.Skip(4).Take(buffer.Length - 8).ToArray()) : null;
        }

        public static Trio<int> GetPort(Trio<UdpClient> sockets)
        {
            return new Trio<int>
            (
                (sockets.First.Client.LocalEndPoint as IPEndPoint).Port,
                (sockets.Second.Client.LocalEndPoint as IPEndPoint).Port,
                (sockets.Third.Client.LocalEndPoint as IPEndPoint).Port
            );
        }
        public static Trio<UdpClient> SetPort(string host, Trio<int> ports)
        {
            return new Trio<UdpClient>
            (
                new UdpClient(host, ports.First),
                new UdpClient(host, ports.Second),
                new UdpClient(host, ports.Third)
            );
        }
    }
}
