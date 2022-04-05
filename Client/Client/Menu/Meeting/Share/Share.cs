using System;
using System.Text;
using System.Drawing;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Client
{
    public class Share
    {
        private Thread Screen;
        private Button Button;

        private Streamer Socket;
        private int Quality = 50;
        private Participant Presenter;

        public bool IsRunning { get; private set; }

        public Share(Button button, Participant presenter, Streamer streamer)
        {
            Button = button;
            Socket = streamer;
            IsRunning = false;
            Presenter = presenter;
            Screen = new Thread(() => ShareScreen());
        }
        
        public void Dispose()
        {
            Screen.Abort();
        }
        public void ShareScreen()
        {
            while (true)
            {
                Rectangle bound = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
                Bitmap shot = new Bitmap(bound.Width, bound.Height, PixelFormat.Format32bppRgb);

                Graphics graphics = Graphics.FromImage(shot);
                graphics.CopyFromScreen(bound.X, bound.Y, 0, 0, bound.Size, CopyPixelOperation.SourceCopy);

                Image image = Video.ResizeImage(shot, 350, 208);
                Socket.SendShare(Video.ToBytes(image, Quality));
                Presenter.m_screen.Frame(image);
            } 
        }
        public void Set(bool state)
        {
            SetButton(state);
            IsRunning = state;
            Presenter.SetShare(state);

            if (state)
            {
                Screen.Start();
            }
            else
            {
                Screen.Abort();
                Screen = new Thread(() => ShareScreen());
            }
        }
        private void SetButton(bool state)
        {
            if (state)
            {  
                Button.Text = "Stop Share";
                Button.Image = Properties.Resources.share_button;
            }
            else
            {
                Button.Text = "Share Screen";
                Button.Image = Properties.Resources.stop_share_button;
            }
        }
        public void SetQuality(int quality) => Quality = quality;

        public static byte[] SerializeRequest(bool state, int id)
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.SHARE_SCREEN + JsonSerializer.Serialize
                (
                    new ShareScreenRequest
                    {
                        state = state,
                        participant = id
                    }
                )
            );
        }
    }
}
