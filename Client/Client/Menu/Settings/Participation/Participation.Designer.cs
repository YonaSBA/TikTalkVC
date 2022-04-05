namespace Client
{
    partial class Participation
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
            this.stopVideo = new System.Windows.Forms.CheckBox();
            this.muteMicrophone = new System.Windows.Forms.CheckBox();
            this.default_nickname = new System.Windows.Forms.TextBox();
            this.background_pictureBox = new System.Windows.Forms.PictureBox();
            this.upload_picktureBox = new AForge.Controls.PictureBox();
            this.volume_bar = new System.Windows.Forms.TrackBar();
            this.volume_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.background_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upload_picktureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // stopVideo
            // 
            this.stopVideo.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopVideo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.stopVideo.Location = new System.Drawing.Point(17, 137);
            this.stopVideo.MinimumSize = new System.Drawing.Size(52, 20);
            this.stopVideo.Name = "stopVideo";
            this.stopVideo.Size = new System.Drawing.Size(365, 25);
            this.stopVideo.TabIndex = 72;
            this.stopVideo.Text = "Stop my video when joining or creating a meeting";
            // 
            // muteMicrophone
            // 
            this.muteMicrophone.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muteMicrophone.ForeColor = System.Drawing.Color.RoyalBlue;
            this.muteMicrophone.Location = new System.Drawing.Point(17, 168);
            this.muteMicrophone.MinimumSize = new System.Drawing.Size(52, 20);
            this.muteMicrophone.Name = "muteMicrophone";
            this.muteMicrophone.Size = new System.Drawing.Size(389, 25);
            this.muteMicrophone.TabIndex = 71;
            this.muteMicrophone.Text = "Mute my microphone when joining or creating a meeting";
            // 
            // default_nickname
            // 
            this.default_nickname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.default_nickname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.default_nickname.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.default_nickname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.default_nickname.Location = new System.Drawing.Point(17, 94);
            this.default_nickname.Name = "default_nickname";
            this.default_nickname.Size = new System.Drawing.Size(188, 31);
            this.default_nickname.TabIndex = 79;
            this.default_nickname.Text = "Enter Default Nickname";
            this.default_nickname.TextChanged += new System.EventHandler(this.Rename);
            this.default_nickname.Enter += new System.EventHandler(TextBoxManager.EnterBox);
            this.default_nickname.Leave += new System.EventHandler(TextBoxManager.LeaveBox);
            // 
            // background_pictureBox
            // 
            this.background_pictureBox.BackgroundImage = global::Client.Properties.Resources.background;
            this.background_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.background_pictureBox.ErrorImage = null;
            this.background_pictureBox.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.background_pictureBox.ForeColor = System.Drawing.Color.Red;
            this.background_pictureBox.Location = new System.Drawing.Point(263, 9);
            this.background_pictureBox.Name = "background_pictureBox";
            this.background_pictureBox.Size = new System.Drawing.Size(203, 116);
            this.background_pictureBox.TabIndex = 74;
            this.background_pictureBox.TabStop = false;
            // 
            // upload_picktureBox
            // 
            this.upload_picktureBox.BackgroundImage = global::Client.Properties.Resources.add;
            this.upload_picktureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.upload_picktureBox.Image = null;
            this.upload_picktureBox.Location = new System.Drawing.Point(217, 9);
            this.upload_picktureBox.Name = "upload_picktureBox";
            this.upload_picktureBox.Size = new System.Drawing.Size(40, 40);
            this.upload_picktureBox.TabIndex = 81;
            this.upload_picktureBox.TabStop = false;
            this.upload_picktureBox.Click += new System.EventHandler(this.PickBackground);
            // 
            // volume_bar
            // 
            this.volume_bar.Location = new System.Drawing.Point(10, 41);
            this.volume_bar.Name = "volume_bar";
            this.volume_bar.Size = new System.Drawing.Size(188, 45);
            this.volume_bar.TabIndex = 83;
            // 
            // volume_label
            // 
            this.volume_label.AutoSize = true;
            this.volume_label.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volume_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.volume_label.Location = new System.Drawing.Point(68, 9);
            this.volume_label.Name = "volume_label";
            this.volume_label.Size = new System.Drawing.Size(75, 26);
            this.volume_label.TabIndex = 82;
            this.volume_label.Text = "Volume";
            // 
            // Participation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.volume_bar);
            this.Controls.Add(this.volume_label);
            this.Controls.Add(this.upload_picktureBox);
            this.Controls.Add(this.default_nickname);
            this.Controls.Add(this.background_pictureBox);
            this.Controls.Add(this.stopVideo);
            this.Controls.Add(this.muteMicrophone);
            this.Name = "Participation";
            this.Size = new System.Drawing.Size(480, 200);
            ((System.ComponentModel.ISupportInitialize)(this.background_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upload_picktureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox background_pictureBox;
        private System.Windows.Forms.CheckBox stopVideo;
        private System.Windows.Forms.CheckBox muteMicrophone;
        private System.Windows.Forms.TextBox default_nickname;
        private AForge.Controls.PictureBox upload_picktureBox;
        private System.Windows.Forms.TrackBar volume_bar;
        private System.Windows.Forms.Label volume_label;
    }
}