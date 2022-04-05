namespace Client
{
    partial class Hospitality
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chat_checkBox = new System.Windows.Forms.CheckBox();
            this.rename_checkBox = new System.Windows.Forms.CheckBox();
            this.id_checkBox = new System.Windows.Forms.CheckBox();
            this.startVideo = new System.Windows.Forms.CheckBox();
            this.shareScreen = new System.Windows.Forms.CheckBox();
            this.unmute_checkBox = new System.Windows.Forms.CheckBox();
            this.waitingRoom = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chat_checkBox
            // 
            this.chat_checkBox.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chat_checkBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chat_checkBox.Location = new System.Drawing.Point(17, 4);
            this.chat_checkBox.MinimumSize = new System.Drawing.Size(52, 20);
            this.chat_checkBox.Name = "chat_checkBox";
            this.chat_checkBox.Size = new System.Drawing.Size(99, 25);
            this.chat_checkBox.TabIndex = 74;
            this.chat_checkBox.Text = "Allow Chat";
            // 
            // rename_checkBox
            // 
            this.rename_checkBox.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rename_checkBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.rename_checkBox.Location = new System.Drawing.Point(17, 144);
            this.rename_checkBox.MinimumSize = new System.Drawing.Size(52, 20);
            this.rename_checkBox.Name = "rename_checkBox";
            this.rename_checkBox.Size = new System.Drawing.Size(198, 25);
            this.rename_checkBox.TabIndex = 73;
            this.rename_checkBox.Text = "Allow Rename themselves";
            // 
            // id_checkBox
            // 
            this.id_checkBox.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_checkBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.id_checkBox.Location = new System.Drawing.Point(17, 172);
            this.id_checkBox.MinimumSize = new System.Drawing.Size(52, 20);
            this.id_checkBox.Name = "id_checkBox";
            this.id_checkBox.Size = new System.Drawing.Size(387, 25);
            this.id_checkBox.TabIndex = 72;
            this.id_checkBox.Text = "Automatically copy meeting id when starting a meeting";
            // 
            // startVideo
            // 
            this.startVideo.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startVideo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.startVideo.Location = new System.Drawing.Point(17, 32);
            this.startVideo.MinimumSize = new System.Drawing.Size(52, 20);
            this.startVideo.Name = "startVideo";
            this.startVideo.Size = new System.Drawing.Size(134, 25);
            this.startVideo.TabIndex = 71;
            this.startVideo.Text = "Allow Start Video";
            // 
            // shareScreen
            // 
            this.shareScreen.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shareScreen.ForeColor = System.Drawing.Color.RoyalBlue;
            this.shareScreen.Location = new System.Drawing.Point(17, 60);
            this.shareScreen.MinimumSize = new System.Drawing.Size(52, 20);
            this.shareScreen.Name = "shareScreen";
            this.shareScreen.Size = new System.Drawing.Size(151, 25);
            this.shareScreen.TabIndex = 70;
            this.shareScreen.Text = "Allow Share Screen";
            // 
            // unmute_checkBox
            // 
            this.unmute_checkBox.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unmute_checkBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.unmute_checkBox.Location = new System.Drawing.Point(17, 116);
            this.unmute_checkBox.MinimumSize = new System.Drawing.Size(52, 20);
            this.unmute_checkBox.Name = "unmute_checkBox";
            this.unmute_checkBox.Size = new System.Drawing.Size(198, 25);
            this.unmute_checkBox.TabIndex = 69;
            this.unmute_checkBox.Text = "Allow Unmute themselves";
            // 
            // waitingRoom
            // 
            this.waitingRoom.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingRoom.ForeColor = System.Drawing.Color.RoyalBlue;
            this.waitingRoom.Location = new System.Drawing.Point(17, 88);
            this.waitingRoom.MinimumSize = new System.Drawing.Size(52, 20);
            this.waitingRoom.Name = "waitingRoom";
            this.waitingRoom.Size = new System.Drawing.Size(172, 25);
            this.waitingRoom.TabIndex = 68;
            this.waitingRoom.Text = "Enable Waiting Room";
            // 
            // Hospitality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.chat_checkBox);
            this.Controls.Add(this.rename_checkBox);
            this.Controls.Add(this.id_checkBox);
            this.Controls.Add(this.startVideo);
            this.Controls.Add(this.shareScreen);
            this.Controls.Add(this.unmute_checkBox);
            this.Controls.Add(this.waitingRoom);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Hospitality";
            this.Size = new System.Drawing.Size(480, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chat_checkBox;
        private System.Windows.Forms.CheckBox rename_checkBox;
        private System.Windows.Forms.CheckBox id_checkBox;
        private System.Windows.Forms.CheckBox startVideo;
        private System.Windows.Forms.CheckBox shareScreen;
        private System.Windows.Forms.CheckBox unmute_checkBox;
        private System.Windows.Forms.CheckBox waitingRoom;
    }
}