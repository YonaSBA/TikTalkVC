using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class MyScreen : UserControl
    {
        public MyScreen(string name)
        {
            InitializeComponent();
            nickname.Text = name + "'s Share";
        }

        public void Frame(Image frame)
        {
            image.Image = frame;
        }
        public void Frame(byte[] frame)
        {
            image.Image = Video.ToImage(frame);
        }

        public void SetNickname(string name)
        {
            nickname.Text = name + "'s Share";
        }
    }
}
