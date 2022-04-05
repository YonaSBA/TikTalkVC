using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class Shortcuts : UserControl
    {
        public Shortcuts()
        {
            InitializeComponent();
        }

        private void Button(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string replace = button.Text;

            button.Text = button.Name;

            button.Font = new Font("Impact", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);

            button.Name = replace;
        }
        private void Method(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string replace = button.Text;

            button.Text = button.Name;

            button.Font = new Font("Impact", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

            button.Name = replace;
        }
    }
}
