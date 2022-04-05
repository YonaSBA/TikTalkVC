using System;
using System.IO;
using System.Linq;
using System.Text;
using AForge.Video;
using System.Drawing;
using AForge.Controls;
using System.Threading;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;
using AForge.Video.DirectShow;
using Timer = System.Windows.Forms.Timer;
using Encoder = System.Drawing.Imaging.Encoder;

namespace Client
{
    public class Video : VideoSourcePlayer
    {
        private bool Case;
        private Timer Timer;
        private Button Button;

        private Devices Cameras;
        private Streamer Socket;
        private Participant Presenter;

        private string Camera;
        public int Quality { get; private set; }
        private Mirror Filter = new Mirror(false, true);

        private static EncoderParameters Parameters = new EncoderParameters(1);
        private static ImageCodecInfo ImageEncoder = ImageCodecInfo.GetImageEncoders().FirstOrDefault(encoder => encoder.MimeType == "image/jpeg");

        public Video(Button button, Participant presenter, Streamer streamer, Devices devices, bool state) : base()
        {
            Quality = 100;
            Button = button;
            Cameras = devices;
            Socket = streamer;
            Timer = new Timer();
            Presenter = presenter;
            Size = new Size(350, 208);
            NewFrame += new NewFrameHandler(New);
            CheckForIllegalCrossThreadCalls = true;
            PlayingFinished += new PlayingFinishedEventHandler(Suddenly);

            UpdateSource(null, null);
            Set(state);

            Timer.Interval = Program.HALF_SECOND;
            Timer.Tick += UpdateSource;
            Timer.Start();
        }

        public void Dispose()
        {
            Timer.Dispose();

            if (VideoSource != null)
            {
                Stop();
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
            if (state)
            {
                ConnectToCamera();

                if (VideoSource != null)
                {
                    Start();
                    SetButton(state);
                }
            }
            else
            {
                if (VideoSource != null)
                {
                    Stop();
                    VideoSource = null;
                }

                SetButton(state);
            }

            Presenter.SetVideo(state);
        }
        public bool IsOn() => IsRunning;
        private void ConnectToCamera()
        {
            if (Camera == null)
            {
                MessageBox.Show("Unable to find camera on entity.");
            }
            else
            {
                VideoSource = new VideoCaptureDevice(Camera);
            }
        }
        private void SetButton(bool state)
        {
            if (state)
            {
                Button.Text = "Stop Video";
                Button.Image = Properties.Resources.start_button;
            }
            else
            {
                Button.Text = "Start Video";
                Button.Image = Properties.Resources.stop_button;
            }
        }
        private void New(object sender, ref Bitmap bitmap)
        {
            Filter.ApplyInPlace(bitmap);
            Image image = ResizeImage(bitmap, 350, 208);

            Socket.SendVideo(ToBytes(image, Quality));
            Presenter.Frame(image);
            Thread.Sleep(10);
        }
        public void UpdateSource(object sender, EventArgs e)
        {
            Camera = Cameras.GetCamera();

            if (VideoSource == null || Camera != VideoSource.Source)
            {
                if (IsRunning)
                {
                    Stop();
                    ConnectToCamera();
                    Start();
                }
            }
        }
        public void SetQuality(int quality) => Quality = quality;
        public void Suddenly(object sender, ReasonToFinishPlaying reason)
        {
            if (reason == ReasonToFinishPlaying.DeviceLost)
            {
                if (Communicator.UseTo.Talk(SerializeRequest(false, Presenter.m_id)) != null)
                {
                    Case = true;
                }
            }
            else if (reason == ReasonToFinishPlaying.StoppedByUser)
            {
                Case = true;
            }
        }

        public static byte[] ImportImage()
        {
            byte[] buffer;
            int quality = 100;
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            Image image = ResizeImage(open.ShowDialog() == DialogResult.OK ? new Bitmap(open.FileName) : Properties.Resources.background, 350, 208);

            do {
                buffer = ToBytes(image, quality--);
            } while (buffer.Length > 42000);

            return buffer;
        }
        public static Image ToImage(byte[] buffer)
        {
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                return Image.FromStream(ms);
            }
        }
        public static byte[] ToBytes(Image image, int quality = 100)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Parameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                image.Save(stream, ImageEncoder, Parameters);
                return stream.ToArray();
            }     
        }
        public static Image ResizeImage(Image image, int width, int height)
        {
            return new Bitmap(image, width, height);
        }

        public static byte[] SerializeRequest(bool state, int id)
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.VIDEO + JsonSerializer.Serialize
                (
                    new VideoRequest
                    {
                        state = state,
                        participant = id
                    }
                )
            );
        }
    }
}
