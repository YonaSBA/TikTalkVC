using System;
using NAudio.Wave;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Client
{
    public class Audio
    {
        private bool Case;
        private Timer Timer;
        private Button Button;
        private bool IsRunning;

        private Devices Waves;
        private Streamer Socket;
        private Participant Presenter;

        private WaveOut Speaker;
        private WaveIn Microphone;
        private BufferedWaveProvider Provider;

        private int Speaker_Number;
        private int Microphone_Number;
        public int SampleRate { get; set; }
        
        public Audio(Button button, Participant presenter, Streamer streamer, Devices devices, bool state) : base()
        {
            Waves = devices;
            Button = button;
            Socket = streamer;
            SampleRate = 44100;
            Timer = new Timer();
            Presenter = presenter;

            UpdateSource(null, null);
            Set(state);

            ConnectSpeaker();
            Speaker.Play();

            Timer.Interval = Program.HALF_SECOND;
            Timer.Tick += UpdateSource;
            Timer.Start();
        }
        
        public void Dispose()
        {
            Timer.Dispose();
            
            if (Speaker != null)
            {
                Speaker.Stop();
                Speaker.Dispose();
            }
            if (Microphone != null)
            {
                Microphone.StopRecording();
                Microphone.Dispose();
            }
        }
        public bool Problem()
        {
            bool temp = Case;
            Case = false;
            return temp;
        }
        public void Set(bool state)
        {
            IsRunning = state;
            Presenter.SetAudio(state);

            if (state)
            {
                ConnectMicrophone();

                if (Microphone != null)
                {
                    Microphone.StartRecording();
                    SetButton(state);
                }        
            }
            else
            {
                if (Microphone != null)
                {
                    Microphone.StopRecording();
                    Microphone.Dispose();
                }

                SetButton(state);
            }
        }
        public bool IsOn() => IsRunning;
        private void ConnectSpeaker()
        {
            if (Speaker_Number == Devices.NOT_FOUND)
            {
                MessageBox.Show("Unable to find speaker on entity.");
            }
            else
            {
                Speaker = new WaveOut();

                Speaker.DeviceNumber = Speaker_Number;
                Provider = new BufferedWaveProvider(new WaveFormat(SampleRate, WaveOut.GetCapabilities(Speaker_Number).Channels));

                Speaker.Init(Provider);
            }
        }
        public void Play(byte[] audio)
        {
            Provider.AddSamples(audio, 0, audio.Length);
        }
        private void ConnectMicrophone()
        {
            if (Microphone_Number == Devices.NOT_FOUND)
            {
                MessageBox.Show("Unable to find microphone on entity.");
            }
            else
            {
                Microphone = new WaveIn();

                Microphone.DeviceNumber = Microphone_Number;
                Microphone.WaveFormat = new WaveFormat(SampleRate, WaveIn.GetCapabilities(Microphone_Number).Channels);

                Microphone.DataAvailable += new EventHandler<WaveInEventArgs>(New);
                Microphone.RecordingStopped += new EventHandler<StoppedEventArgs>(Suddenly);
            }
        }
        private void SetButton(bool state)
        {
            if (state)
            {
                Button.Text = "Mute";
                Button.Image = Properties.Resources.unmute_button;
            }
            else
            {
                Button.Text = "Unmute";
                Button.Image = Properties.Resources.mute_button;
            }
        }
        public void SetSampleRate(int rate)
        {
            SampleRate = rate;
            ConnectSpeaker();

            if (IsRunning)
            {
                ConnectMicrophone();
            }
        }
        private void New(object sender, WaveInEventArgs e)
        {
            Socket.SendAudio(e.Buffer);
        }
        public void UpdateSource(object sender, EventArgs e)
        {
            Speaker_Number = Waves.GetSpeaker();
            Microphone_Number = Waves.GetMicrophone();

            if (Microphone != null && Microphone_Number != Microphone.DeviceNumber && IsRunning)
            {
                Microphone.StopRecording();

                Microphone.Dispose();
                ConnectMicrophone();

                Microphone.StartRecording();
            }

            if (Speaker != null)
            {
                Speaker.Volume = Waves.m_volume;

                if (Speaker_Number != Speaker.DeviceNumber)
                {
                    Speaker.Stop();

                    Speaker.Dispose();
                    ConnectSpeaker();

                    Speaker.Play();
                }
            }
        }
        public void Suddenly(object sender, StoppedEventArgs reason)
        {
            if (IsRunning)
            {
                if (Communicator.UseTo.Talk(SerializeRequest(false, Presenter.m_id)) != null)
                {
                    Case = true;
                }
            }
        }

        public static byte[] SerializeRequest(bool state, int id)
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.AUDIO + JsonSerializer.Serialize
                (
                    new AudioRequest
                    {
                        state = state,
                        participant = id
                    }
                )
            );
        }
    }
}
