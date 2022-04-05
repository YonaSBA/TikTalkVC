using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class Message : UserControl
    {
        public Message(string name, string message)
        {
            InitializeComponent();

            nickname.Text = name;
            context.Text = message;
            time.Text = DateTime.Now.ToString("HH:mm");
            Size = new Size(Size.Width, Size.Height + context.Size.Height);
        }
    }
}
