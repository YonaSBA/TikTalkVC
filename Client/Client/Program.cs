using System;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        public const int SECOND = 1000;
        public const int TWO_SECOND = 2000;
        public const int HALF_SECOND = 500;

        public static bool OpenDetailFormOnClose = false;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignIn());
        }

        public static void Move(Form current, Form next)
        {
            current.Hide(); 
            next.Closed += (sender, e) => current.Close();
            next.Show();
        }

        public static void SetEvents(TextBox[] boxes)
        {
            foreach (TextBox box in boxes)
            {
                box.Enter += TextBoxManager.EnterBox;
                box.Leave += TextBoxManager.LeaveBox;
            }
        }
    }
}
