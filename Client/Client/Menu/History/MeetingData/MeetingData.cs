using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Client
{
    public partial class MeetingData : UserControl
    {
        public DateTime start
        { 
            get => Convert.ToDateTime(start_textBox.Text);
            set => start_textBox.Text = value.ToString();
        }

        public DateTime end
        { 
            get => Convert.ToDateTime(start.Add(TimeSpan.Parse(duration_textBox.Text)));
            set => duration_textBox.Text = value.Subtract(start).ToString(); 
        }

        public List<string> participants
        {
            get => partcipants_list.Items.Cast<string>().ToList();
            set => partcipants_list.Items.AddRange(value.ToArray());
        }

        public MeetingData()
        {
            InitializeComponent();
        }
    }
}
