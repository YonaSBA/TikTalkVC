using Newtonsoft.Json;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class WaitingRoom : Form
    {
        private Join m_join;
        private Menu m_menu;
        private string m_meeting;

        public WaitingRoom(string meeting, Menu menu, Join join)
        {
            m_menu = menu;
            m_join = join;
            m_meeting = meeting;

            InitializeComponent();
        }
    }
}
