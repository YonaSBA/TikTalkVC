using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace Client
{
    public class TextBoxManager
    {
        private static TextInfo converter = new CultureInfo("en-US", false).TextInfo;

        public static void Reset(TextBox box)
        {
            box.Text = GetHint(box);
            box.PasswordChar = '\0';
            box.ForeColor = Color.FromArgb(100, 100, 100);
        }
        public static void Set(TextBox box, string text = "")
        {
            box.Text = text;
            box.ForeColor = Color.RoyalBlue;
            box.PasswordChar = box.Name.Contains("password") ? '*' : '\0';
        }

        public static string GetHint(TextBox box)
        {
            string text = converter.ToTitleCase(box.Name).Replace('_', ' ');

            if (text.Contains("Confirm"))
            {
                return text;
            }
            else if (text.Contains("Message"))
            {
                return "Type message here...";
            }
            else
            {
                return "Enter " + text;
            }
        }
        public static string Return(TextBox box, string value)
        {
            return value == GetHint(box) || value == "" ? null : value;
        }

        public static void EnterBox(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;

            if (box.Text == GetHint(box))
            {
                Set(box);
            }
        }
        public static void LeaveBox(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;

            if (box.Text == "")
            {
                Reset(box);
            }
        }
    }
}
