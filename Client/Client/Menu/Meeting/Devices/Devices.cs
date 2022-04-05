using System;
using NAudio.Wave;
using System.Threading;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using Timer = System.Windows.Forms.Timer;

namespace Client
{
    public partial class Devices : UserControl
    {
        private string m_camera = null;
        private FilterInfoCollection m_cameras;

        private Pair<int, WaveOutCapabilities> m_speaker = new Pair<int, WaveOutCapabilities>(NOT_FOUND, new WaveOutCapabilities());
        private Pair<int, WaveInCapabilities> m_microphone = new Pair<int, WaveInCapabilities>(NOT_FOUND, new WaveInCapabilities());

        public const int NOT_FOUND = -1;

        public float m_volume { get => (float)(volume_bar.Value * 0.1); private set => volume_bar.Value = (int)value; }

        private Timer m_refresher = new Timer();
        private ManualResetEvent m_cameraLock = new ManualResetEvent(false);
        private ManualResetEvent m_speakerLock = new ManualResetEvent(false);
        private ManualResetEvent m_microphoneLock = new ManualResetEvent(false);

        public Devices(int volume)
        {
            InitializeComponent();

            Refresh(null, null);

            m_volume = volume;

            m_refresher.Interval = Program.SECOND;
            m_refresher.Tick += Refresh;
            m_refresher.Start();
        }

        private int GetCameras()
        {
            int index = NOT_FOUND;

            m_cameraLock.Reset();

            cameras.Items.Clear();

            m_cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            for (int i = 0; i < m_cameras.Count; i++)
            {
                cameras.Items.Add(m_cameras[i].Name);

                if (m_cameras[i].MonikerString == m_camera)
                {
                    index = i;
                }
            }

            m_cameraLock.Set();

            return index;
        }
        private int GetSpeakers()
        {
            int index = NOT_FOUND;

            m_speakerLock.Reset();

            speakers.Items.Clear();

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                speakers.Items.Add(WaveOut.GetCapabilities(i).ProductName);

                if (WaveOut.GetCapabilities(i).Equals(m_speaker.Second))
                {
                    index = i;
                }
            }

            m_speakerLock.Set();

            return index;
        }
        private int GetMicrophones()
        {
            int index = NOT_FOUND;

            m_microphoneLock.Reset();

            microphones.Items.Clear();

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                microphones.Items.Add(WaveIn.GetCapabilities(i).ProductName);

                if (WaveIn.GetCapabilities(i).Equals(m_microphone.Second))
                {
                    index = i;
                }
            }
            
            m_microphoneLock.Set();

            return index;
        }

        private void Refresh(object sender, EventArgs e)
        {
            int index;

            if ((index = GetCameras()) == NOT_FOUND)
            {
                ConnectToCamera(null, null);
            }
            else
            {
                cameras.SelectedItem = m_cameras[index].Name;
            }

            if ((index = GetSpeakers()) == NOT_FOUND)
            {
                ConnectToSpeaker(null, null);
            }
            else
            {
                speakers.SelectedItem = WaveOut.GetCapabilities(index).ProductName;
            }

            if ((index = GetMicrophones()) == NOT_FOUND)
            {
                ConnectToMicrophone(null, null);
            }
            else
            {
                microphones.SelectedItem = WaveIn.GetCapabilities(index).ProductName;
            }
        }

        public void ConnectToCamera(object sender, EventArgs e)
        {
            m_cameraLock.WaitOne();

            if (sender != null)
            {
                m_camera = m_cameras[cameras.SelectedIndex].MonikerString;
            }
            else if (cameras.Items.Count > 0)
            {
                m_camera = m_cameras[0].MonikerString;
            }
            else
            {
                m_camera = null;
            }

            m_cameraLock.Set();
        }
        public void ConnectToSpeaker(object sender, EventArgs e)
        {
            m_speakerLock.WaitOne();

            if (sender != null)
            {
                m_speaker = new Pair<int, WaveOutCapabilities>(speakers.SelectedIndex, WaveOut.GetCapabilities(speakers.SelectedIndex));
            }
            else if (speakers.Items.Count > 0)
            {
                m_speaker = new Pair<int, WaveOutCapabilities>(0, WaveOut.GetCapabilities(0));
            }
            else
            {
                m_speaker = new Pair<int, WaveOutCapabilities>(NOT_FOUND, new WaveOutCapabilities());
            }

            m_speakerLock.Set();
        }
        public void ConnectToMicrophone(object sender, EventArgs e)
        {
            m_microphoneLock.WaitOne();

            if (sender != null)
            {
                m_microphone = new Pair<int, WaveInCapabilities>(microphones.SelectedIndex, WaveIn.GetCapabilities(microphones.SelectedIndex));
            }
            else if (microphones.Items.Count > 0)
            {
                m_microphone = new Pair<int, WaveInCapabilities>(0, WaveIn.GetCapabilities(0));
            }
            else
            {
                m_microphone = new Pair<int, WaveInCapabilities>(NOT_FOUND, new WaveInCapabilities());
            }

            m_microphoneLock.Set();
        }

        public int GetSpeaker()
        {
            return m_speaker.First;
        }
        public string GetCamera()
        {
            return m_camera;
        }
        public int GetMicrophone()
        {
            return m_microphone.First;
        }
    }
}
