using System;
using System.Text;
using System.Text.Json;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Client
{
    public partial class Meeting : Form
    {
        private int m_id;
        private string m_username;

        private Video m_video;
        private Audio m_audio;
        private Share m_share;
        private Participant m_presenter;

        private Chat m_chat;
        private Devices m_devices;
        private Streamer m_streamer;
        private Shortcuts m_shortcuts;
        private Permissions m_permissions;
        private Participants m_participants;

        public Meeting(string meeting, int participant, Trio<UdpClient> sockets, Participation participation, Hospitality hospitality, string username)
        {
            InitializeComponent();

            KeyPreview = true;
            Client.Menu.m_inMeeting = true;

            m_id = participant;
            m_username = username;

            m_shortcuts = new Shortcuts();

            m_chat = new Chat(m_id);

            m_streamer = new Streamer(m_id, sockets);

            m_devices = new Devices(participation.volume);

            m_presenter = new Participant(m_id, participation, hospitality);

            m_share = new Share(share_button, m_presenter, m_streamer);
            m_audio = new Audio(audio_button, m_presenter, m_streamer, m_devices, !participation.mute);
            m_video = new Video(video_button, m_presenter, m_streamer, m_devices, !participation.stop_video);

            m_participants = new Participants(m_presenter, m_streamer, participants_panel, m_chat, m_video, m_audio, m_share, new Pair<Button, Button>(end_button, permissions_button), this);

            m_permissions = new Permissions(m_id, meeting, hospitality);

            if (hospitality.id)
            {
                Clipboard.SetText(meeting);
            }
        }
        public Meeting(string meeting, int participant, Trio<UdpClient> sockets, Participation participation, Hospitality hospitality, string username, int host, Dictionary<int, Participation> participants)
        {
            InitializeComponent();

            KeyPreview = true;
            Client.Menu.m_inMeeting = true;

            m_id = participant;
            m_username = username;

            m_shortcuts = new Shortcuts();

            m_chat = new Chat(m_id);

            m_streamer = new Streamer(m_id, sockets);

            m_devices = new Devices(participation.volume);

            m_presenter = new Participant(m_id, participation, hospitality);

            m_share = new Share(share_button, m_presenter, m_streamer);
            m_audio = new Audio(audio_button, m_presenter, m_streamer, m_devices, !participation.mute);
            m_video = new Video(video_button, m_presenter, m_streamer, m_devices, !participation.stop_video);

            m_participants = new Participants(m_presenter, m_streamer, participants_panel, m_chat, m_video, m_audio, m_share, new Pair<Button, Button>(end_button, permissions_button), this, host, participants);

            m_permissions = new Permissions(m_id, meeting, hospitality);
        }

        private void ResizeFeature(object sender, EventArgs e)
        {
            try
            {
                data_panel.Controls[0].Size = data_panel.Size;
            }
            catch { }
        }
        private void Focus(object sender, UserControl feature)
        {
            data_panel.Controls.Clear();
            data_panel.Controls.Add(feature);
            data_panel.Controls[0].Size = data_panel.Size;
            feature_label.Text = ((Button)sender).Text;
        }

        private void ShowChat(object sender, EventArgs e)
        {
            Focus(sender, m_chat);
        }
        private void ShowDevices(object sender, EventArgs e)
        {
            Focus(sender, m_devices);
        }
        private void ShowShortcuts(object sender, EventArgs e)
        {
            Focus(sender, m_shortcuts);
        }
        private void ShowPermissions(object sender, EventArgs e)
        {
            Focus(sender, m_permissions);
        }
        private void ShowParticipants(object sender, EventArgs e)
        {
            Focus(sender, m_participants);
        }

        private void VideoStatus(object sender, EventArgs e)
        {
            if (m_video.IsOn())
            {
                if (Communicator.UseTo.Talk(Video.SerializeRequest(false, m_id)) != null)
                {
                    m_video.Set(false);
                }           
            }
            else
            {
                if (Communicator.UseTo.Talk(Video.SerializeRequest(true, m_id)) != null)
                {
                    m_video.Set(true);
                }
            }
        }
        private void AudioStatus(object sender, EventArgs e)
        {
            if (m_audio.IsOn())
            {
                if (Communicator.UseTo.Talk(Audio.SerializeRequest(false, m_id)) != null)
                {
                    m_audio.Set(false);
                }
            }
            else
            {
                if (Communicator.UseTo.Talk(Audio.SerializeRequest(true, m_id)) != null)
                {
                    m_audio.Set(true);
                }
            }
        }
        private void ShareStatus(object sender, EventArgs e)
        {
            if (m_share.IsRunning)
            {
                if (Communicator.UseTo.Talk(Share.SerializeRequest(false, m_id)) != null)
                {
                    participants_panel.Controls.Remove(m_presenter.m_screen);
                    m_share.Set(false);
                }
            }
            else
            {
                if (Communicator.UseTo.Talk(Share.SerializeRequest(true, m_id)) != null)
                {
                    m_share.Set(true);
                    participants_panel.Controls.Add(m_presenter.m_screen);
                }
            }
        }

        public void Quit()
        {
            Dispose(true);
            Client.Menu.m_inMeeting = false;
            Program.Move(this, new Menu(m_username)); 
        }   
        public byte[] SerializeEndRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.END + JsonSerializer.Serialize
                (
                    new SimpleRequest
                    {
                        participant = m_id
                    }
                )
            );
        }
        public byte[] SerializeLeaveRequest()
        {
            return Encoding.ASCII.GetBytes
            (
                MeetingCodes.LEAVE + JsonSerializer.Serialize
                (
                    new SimpleRequest
                    {
                        participant = m_id
                    }
                )
            );
        }

        private void EndMeeting(object sender, EventArgs e)
        {
            if (Communicator.UseTo.Talk(SerializeEndRequest()) != null)
            {
                Quit();
            }
        }
        private void LeaveMeeting(object sender, EventArgs e)
        {
            if (Communicator.UseTo.Talk(SerializeLeaveRequest()) != null)
            {
                Quit();
            }
        }
        private void LeaveMeeting(object sender, FormClosingEventArgs e)
        {
            if (Communicator.UseTo.Talk(SerializeLeaveRequest()) != null)
            {
                e.Cancel = true;
                Quit();
            }
        }

        private void Shortcuts(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.F1:
                    VideoStatus(null, null);
                    break;
                case Keys.F2:
                    AudioStatus(null, null);
                    break;
                case Keys.F3:
                    ShareStatus(null, null);
                    break;
                case Keys.F4:
                    ShowChat(chat_button, null);
                    break;
                case Keys.F5:
                    ShowDevices(devices_button, null);
                    break;
                case Keys.F6:
                    ShowShortcuts(shortcuts_button, null);
                    break;
                case Keys.F7:
                    ShowPermissions(permissions_button, null);
                    break;
                case Keys.F8:
                    ShowParticipants(participants_button, null);
                    break;
                case Keys.F9:
                    LeaveMeeting(null, null);
                    break;
                case Keys.F10:
                    EndMeeting(null, null);
                    break;
                case Keys.Enter:
                    m_chat.Send();
                    break;
            }
        }
    }
}