namespace Client
{
    partial class Meeting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            try
            {
                m_participants.Dispose();
                m_audio.Dispose();
                m_video.Dispose();
                m_share.Dispose();
                m_devices.Dispose();
                m_streamer.Dispose();
            }
            catch { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.feature_panel = new System.Windows.Forms.Panel();
            this.data_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.feature_label = new System.Windows.Forms.Label();
            this.participants_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttom_separator = new System.Windows.Forms.Panel();
            this.side_separator = new System.Windows.Forms.Panel();
            this.share_button = new System.Windows.Forms.Button();
            this.leave_button = new System.Windows.Forms.Button();
            this.end_button = new System.Windows.Forms.Button();
            this.shortcuts_button = new System.Windows.Forms.Button();
            this.devices_button = new System.Windows.Forms.Button();
            this.permissions_button = new System.Windows.Forms.Button();
            this.chat_button = new System.Windows.Forms.Button();
            this.participants_button = new System.Windows.Forms.Button();
            this.audio_button = new System.Windows.Forms.Button();
            this.video_button = new System.Windows.Forms.Button();
            this.feature_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // feature_panel
            // 
            this.feature_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.feature_panel.Controls.Add(this.data_panel);
            this.feature_panel.Controls.Add(this.feature_label);
            this.feature_panel.Location = new System.Drawing.Point(763, 1);
            this.feature_panel.Name = "feature_panel";
            this.feature_panel.Size = new System.Drawing.Size(237, 567);
            this.feature_panel.TabIndex = 4;
            // 
            // data_panel
            // 
            this.data_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_panel.BackColor = System.Drawing.Color.Transparent;
            this.data_panel.Location = new System.Drawing.Point(0, 64);
            this.data_panel.Name = "data_panel";
            this.data_panel.Size = new System.Drawing.Size(237, 503);
            this.data_panel.TabIndex = 7;
            // 
            // feature_label
            // 
            this.feature_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.feature_label.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feature_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.feature_label.Location = new System.Drawing.Point(0, 0);
            this.feature_label.Name = "feature_label";
            this.feature_label.Size = new System.Drawing.Size(237, 64);
            this.feature_label.TabIndex = 8;
            this.feature_label.Text = "Side Bar";
            this.feature_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // participants_panel
            // 
            this.participants_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.participants_panel.AutoScroll = true;
            this.participants_panel.Location = new System.Drawing.Point(0, 1);
            this.participants_panel.Name = "participants_panel";
            this.participants_panel.Size = new System.Drawing.Size(752, 567);
            this.participants_panel.TabIndex = 6;
            // 
            // buttom_separator
            // 
            this.buttom_separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttom_separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.buttom_separator.Location = new System.Drawing.Point(0, 571);
            this.buttom_separator.Name = "buttom_separator";
            this.buttom_separator.Size = new System.Drawing.Size(1001, 6);
            this.buttom_separator.TabIndex = 24;
            // 
            // side_separator
            // 
            this.side_separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.side_separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.side_separator.Location = new System.Drawing.Point(754, 1);
            this.side_separator.Name = "side_separator";
            this.side_separator.Size = new System.Drawing.Size(6, 576);
            this.side_separator.TabIndex = 25;
            // 
            // share_button
            // 
            this.share_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.share_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.share_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.share_button.FlatAppearance.BorderSize = 0;
            this.share_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.share_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.share_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.share_button.Image = global::Client.Properties.Resources.stop_share_button;
            this.share_button.Location = new System.Drawing.Point(454, 570);
            this.share_button.Name = "share_button";
            this.share_button.Size = new System.Drawing.Size(126, 66);
            this.share_button.TabIndex = 22;
            this.share_button.Text = "Share Screen";
            this.share_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.share_button.UseVisualStyleBackColor = false;
            this.share_button.Click += new System.EventHandler(this.ShareStatus);
            // 
            // leave_button
            // 
            this.leave_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.leave_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.leave_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.leave_button.FlatAppearance.BorderSize = 0;
            this.leave_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leave_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leave_button.ForeColor = System.Drawing.Color.Orange;
            this.leave_button.Image = global::Client.Properties.Resources.leave;
            this.leave_button.Location = new System.Drawing.Point(938, 570);
            this.leave_button.Name = "leave_button";
            this.leave_button.Size = new System.Drawing.Size(63, 66);
            this.leave_button.TabIndex = 20;
            this.leave_button.Text = "Leave";
            this.leave_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.leave_button.UseVisualStyleBackColor = false;
            this.leave_button.Click += new System.EventHandler(this.LeaveMeeting);
            // 
            // end_button
            // 
            this.end_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.end_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.end_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.end_button.FlatAppearance.BorderSize = 0;
            this.end_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.end_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end_button.ForeColor = System.Drawing.Color.Red;
            this.end_button.Image = global::Client.Properties.Resources.end_button;
            this.end_button.Location = new System.Drawing.Point(891, 570);
            this.end_button.Name = "end_button";
            this.end_button.Size = new System.Drawing.Size(46, 66);
            this.end_button.TabIndex = 21;
            this.end_button.Text = "End";
            this.end_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.end_button.UseVisualStyleBackColor = false;
            this.end_button.Visible = false;
            this.end_button.Click += new System.EventHandler(this.EndMeeting);
            // 
            // shortcuts_button
            // 
            this.shortcuts_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.shortcuts_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.shortcuts_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.shortcuts_button.FlatAppearance.BorderSize = 0;
            this.shortcuts_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shortcuts_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortcuts_button.ForeColor = System.Drawing.Color.White;
            this.shortcuts_button.Image = global::Client.Properties.Resources.shortcuts_button;
            this.shortcuts_button.Location = new System.Drawing.Point(350, 570);
            this.shortcuts_button.Name = "shortcuts_button";
            this.shortcuts_button.Size = new System.Drawing.Size(98, 66);
            this.shortcuts_button.TabIndex = 18;
            this.shortcuts_button.Text = "Shortcuts";
            this.shortcuts_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.shortcuts_button.UseVisualStyleBackColor = false;
            this.shortcuts_button.Click += new System.EventHandler(this.ShowShortcuts);
            // 
            // devices_button
            // 
            this.devices_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.devices_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.devices_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.devices_button.FlatAppearance.BorderSize = 0;
            this.devices_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.devices_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devices_button.ForeColor = System.Drawing.Color.White;
            this.devices_button.Image = global::Client.Properties.Resources.devices;
            this.devices_button.Location = new System.Drawing.Point(586, 570);
            this.devices_button.Name = "devices_button";
            this.devices_button.Size = new System.Drawing.Size(84, 66);
            this.devices_button.TabIndex = 19;
            this.devices_button.Text = "Devices";
            this.devices_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.devices_button.UseVisualStyleBackColor = false;
            this.devices_button.Click += new System.EventHandler(this.ShowDevices);
            // 
            // permissions_button
            // 
            this.permissions_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.permissions_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.permissions_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.permissions_button.FlatAppearance.BorderSize = 0;
            this.permissions_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.permissions_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permissions_button.ForeColor = System.Drawing.Color.White;
            this.permissions_button.Image = global::Client.Properties.Resources.permissions_button;
            this.permissions_button.Location = new System.Drawing.Point(748, 570);
            this.permissions_button.Name = "permissions_button";
            this.permissions_button.Size = new System.Drawing.Size(117, 66);
            this.permissions_button.TabIndex = 17;
            this.permissions_button.Text = "Permissions";
            this.permissions_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.permissions_button.UseVisualStyleBackColor = false;
            this.permissions_button.Visible = false;
            this.permissions_button.Click += new System.EventHandler(this.ShowPermissions);
            // 
            // chat_button
            // 
            this.chat_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chat_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.chat_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chat_button.FlatAppearance.BorderSize = 0;
            this.chat_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chat_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chat_button.ForeColor = System.Drawing.Color.White;
            this.chat_button.Image = global::Client.Properties.Resources.chat_button;
            this.chat_button.Location = new System.Drawing.Point(676, 570);
            this.chat_button.Name = "chat_button";
            this.chat_button.Size = new System.Drawing.Size(66, 66);
            this.chat_button.TabIndex = 15;
            this.chat_button.Text = "Chat";
            this.chat_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.chat_button.UseVisualStyleBackColor = false;
            this.chat_button.Click += new System.EventHandler(this.ShowChat);
            // 
            // participants_button
            // 
            this.participants_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.participants_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.participants_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.participants_button.FlatAppearance.BorderSize = 0;
            this.participants_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.participants_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participants_button.ForeColor = System.Drawing.Color.White;
            this.participants_button.Image = global::Client.Properties.Resources.participant_button;
            this.participants_button.Location = new System.Drawing.Point(227, 570);
            this.participants_button.Name = "participants_button";
            this.participants_button.Size = new System.Drawing.Size(117, 66);
            this.participants_button.TabIndex = 10;
            this.participants_button.Text = "Participants";
            this.participants_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.participants_button.UseVisualStyleBackColor = false;
            this.participants_button.Click += new System.EventHandler(this.ShowParticipants);
            // 
            // audio_button
            // 
            this.audio_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.audio_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.audio_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.audio_button.FlatAppearance.BorderSize = 0;
            this.audio_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audio_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audio_button.ForeColor = System.Drawing.Color.White;
            this.audio_button.Image = global::Client.Properties.Resources.mute_button;
            this.audio_button.Location = new System.Drawing.Point(113, 570);
            this.audio_button.Name = "audio_button";
            this.audio_button.Size = new System.Drawing.Size(79, 66);
            this.audio_button.TabIndex = 7;
            this.audio_button.Text = "Unmute";
            this.audio_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.audio_button.UseVisualStyleBackColor = false;
            this.audio_button.Click += new System.EventHandler(this.AudioStatus);
            // 
            // video_button
            // 
            this.video_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.video_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.video_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.video_button.FlatAppearance.BorderSize = 0;
            this.video_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.video_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.video_button.ForeColor = System.Drawing.Color.White;
            this.video_button.Image = global::Client.Properties.Resources.stop_button;
            this.video_button.Location = new System.Drawing.Point(3, 570);
            this.video_button.Name = "video_button";
            this.video_button.Size = new System.Drawing.Size(104, 66);
            this.video_button.TabIndex = 6;
            this.video_button.Text = "Start Video";
            this.video_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.video_button.UseVisualStyleBackColor = false;
            this.video_button.Click += new System.EventHandler(this.VideoStatus);
            // 
            // Meeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1001, 633);
            this.Controls.Add(this.side_separator);
            this.Controls.Add(this.buttom_separator);
            this.Controls.Add(this.participants_panel);
            this.Controls.Add(this.share_button);
            this.Controls.Add(this.feature_panel);
            this.Controls.Add(this.leave_button);
            this.Controls.Add(this.end_button);
            this.Controls.Add(this.shortcuts_button);
            this.Controls.Add(this.devices_button);
            this.Controls.Add(this.permissions_button);
            this.Controls.Add(this.chat_button);
            this.Controls.Add(this.participants_button);
            this.Controls.Add(this.audio_button);
            this.Controls.Add(this.video_button);
            this.Name = "Meeting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Meeting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LeaveMeeting);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LeaveMeeting);
            this.SizeChanged += new System.EventHandler(this.ResizeFeature);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Shortcuts);
            this.feature_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button video_button;
        private System.Windows.Forms.Button audio_button;
        private System.Windows.Forms.Button participants_button;
        private System.Windows.Forms.Button shortcuts_button;
        private System.Windows.Forms.Button devices_button;
        private System.Windows.Forms.Button permissions_button;
        private System.Windows.Forms.Button chat_button;
        private System.Windows.Forms.Button leave_button;
        private System.Windows.Forms.Button end_button;
        private System.Windows.Forms.Button share_button;
        private System.Windows.Forms.Panel feature_panel;
        private System.Windows.Forms.FlowLayoutPanel data_panel;
        private System.Windows.Forms.Label feature_label;
        private System.Windows.Forms.FlowLayoutPanel participants_panel;
        private System.Windows.Forms.Panel buttom_separator;
        private System.Windows.Forms.Panel side_separator;
    }
}