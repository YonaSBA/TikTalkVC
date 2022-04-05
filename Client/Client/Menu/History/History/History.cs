using System;
using System.Text.Json;
using System.Windows.Forms;
using System.Collections.Generic;
        
namespace Client
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void GetHistory(object sender, EventArgs e)
        {
            string response = Communicator.UseTo.Talk(Request.Empty(MenuCodes.GET_MEETING_HISTORY));

            if (response != null)
            { 
                List<MeetingData> meetings = JsonSerializer.Deserialize<List<MeetingData>>(response);

                foreach (MeetingData meeting in meetings)
                {
                    meetings_pannel.Controls.Add(meeting);
                }

                meetings_pannel.AutoScroll = true;
            }
            else
            {
                Close();
            }
        }
    }
}
