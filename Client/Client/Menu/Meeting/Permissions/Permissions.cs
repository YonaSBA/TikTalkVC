using System;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Client
{
    public partial class Permissions : UserControl
    {
        private int m_id { get; set; }

        public Permissions(int id, string meeting, Hospitality hospitality)
        {
            InitializeComponent();

            m_id = id;
            ID.Text = meeting;

            c320.Checked = hospitality.chat;
            c323.Checked = hospitality.unmute;
            c324.Checked = hospitality.rename;
            c321.Checked = hospitality.start_video;
            c322.Checked = hospitality.share_screen;
            c310.Checked = hospitality.waiting_room;

            c320.Click += Permission;
            c323.Click += Permission;
            c324.Click += Permission;
            c321.Click += Permission;
            c322.Click += Permission;
            c312.Click += Permission;
            c310.Click += Permission;
        }

        private byte[] SerializeMethodRequest(string code)
        {
            return Encoding.ASCII.GetBytes
            (
                code + JsonSerializer.Serialize
                (
                    new SimpleRequest
                    {
                        participant = m_id
                    }
                )
            );
        }
        private byte[] SerializePermissionRequest(string code, bool state)
        {
            return Encoding.ASCII.GetBytes
            (
                code + JsonSerializer.Serialize
                (
                    new PermissionRequest
                    {
                        state = state,
                        participant = m_id
                    }
                )
            );
        }

        private void Method(object sender, EventArgs e)
        {
            Communicator.UseTo.Talk(SerializeMethodRequest((sender as Button).Name.Substring(1, 3)));
        }
        private void Permission(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (Communicator.UseTo.Talk(SerializePermissionRequest(checkBox.Name.Substring(1, 3), checkBox.Checked)) == null)
            {
                checkBox.Checked = !checkBox.Checked;
            }
        }

        private void Copy(object sender, EventArgs e)
        {
            Clipboard.SetText(ID.Text);
        }
    }
}
