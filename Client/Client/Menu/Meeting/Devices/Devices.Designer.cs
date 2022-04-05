namespace Client
{
    partial class Devices
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

            m_refresher.Dispose();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.camera_label = new System.Windows.Forms.Label();
            this.microphone_label = new System.Windows.Forms.Label();
            this.speaker_label = new System.Windows.Forms.Label();
            this.cameras = new System.Windows.Forms.ComboBox();
            this.microphones = new System.Windows.Forms.ComboBox();
            this.speakers = new System.Windows.Forms.ComboBox();
            this.volume_bar = new System.Windows.Forms.TrackBar();
            this.volume_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.volume_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // camera_label
            // 
            this.camera_label.AutoSize = true;
            this.camera_label.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.camera_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.camera_label.Location = new System.Drawing.Point(66, 0);
            this.camera_label.Name = "camera_label";
            this.camera_label.Size = new System.Drawing.Size(103, 34);
            this.camera_label.TabIndex = 3;
            this.camera_label.Text = "Camera";
            // 
            // microphone_label
            // 
            this.microphone_label.AutoSize = true;
            this.microphone_label.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.microphone_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.microphone_label.Location = new System.Drawing.Point(44, 76);
            this.microphone_label.Name = "microphone_label";
            this.microphone_label.Size = new System.Drawing.Size(148, 34);
            this.microphone_label.TabIndex = 3;
            this.microphone_label.Text = "Microphone";
            // 
            // speaker_label
            // 
            this.speaker_label.AutoSize = true;
            this.speaker_label.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speaker_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.speaker_label.Location = new System.Drawing.Point(63, 147);
            this.speaker_label.Name = "speaker_label";
            this.speaker_label.Size = new System.Drawing.Size(108, 34);
            this.speaker_label.TabIndex = 3;
            this.speaker_label.Text = "Speaker";
            // 
            // cameras
            // 
            this.cameras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cameras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cameras.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameras.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cameras.FormattingEnabled = true;
            this.cameras.Location = new System.Drawing.Point(57, 40);
            this.cameras.Name = "cameras";
            this.cameras.Size = new System.Drawing.Size(120, 25);
            this.cameras.TabIndex = 4;
            this.cameras.SelectedIndexChanged += new System.EventHandler(this.ConnectToCamera);
            // 
            // microphones
            // 
            this.microphones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.microphones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.microphones.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.microphones.ForeColor = System.Drawing.Color.RoyalBlue;
            this.microphones.FormattingEnabled = true;
            this.microphones.Location = new System.Drawing.Point(57, 113);
            this.microphones.Name = "microphones";
            this.microphones.Size = new System.Drawing.Size(120, 25);
            this.microphones.TabIndex = 4;
            this.microphones.SelectedIndexChanged += new System.EventHandler(this.ConnectToMicrophone);
            // 
            // speakers
            // 
            this.speakers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.speakers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speakers.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speakers.ForeColor = System.Drawing.Color.RoyalBlue;
            this.speakers.FormattingEnabled = true;
            this.speakers.Location = new System.Drawing.Point(57, 184);
            this.speakers.Name = "speakers";
            this.speakers.Size = new System.Drawing.Size(120, 25);
            this.speakers.TabIndex = 4;
            this.speakers.SelectedIndexChanged += new System.EventHandler(this.ConnectToSpeaker);
            // 
            // volume_bar
            // 
            this.volume_bar.Location = new System.Drawing.Point(16, 297);
            this.volume_bar.Name = "volume_bar";
            this.volume_bar.Size = new System.Drawing.Size(205, 45);
            this.volume_bar.TabIndex = 73;
            // 
            // volume_label
            // 
            this.volume_label.AutoSize = true;
            this.volume_label.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volume_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.volume_label.Location = new System.Drawing.Point(68, 260);
            this.volume_label.Name = "volume_label";
            this.volume_label.Size = new System.Drawing.Size(99, 34);
            this.volume_label.TabIndex = 72;
            this.volume_label.Text = "Volume";
            // 
            // Devices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.volume_bar);
            this.Controls.Add(this.volume_label);
            this.Controls.Add(this.speakers);
            this.Controls.Add(this.microphones);
            this.Controls.Add(this.cameras);
            this.Controls.Add(this.speaker_label);
            this.Controls.Add(this.microphone_label);
            this.Controls.Add(this.camera_label);
            this.Name = "Devices";
            this.Size = new System.Drawing.Size(237, 503);
            ((System.ComponentModel.ISupportInitialize)(this.volume_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label camera_label;
        private System.Windows.Forms.Label microphone_label;
        private System.Windows.Forms.Label speaker_label;
        private System.Windows.Forms.ComboBox cameras;
        private System.Windows.Forms.ComboBox microphones;
        private System.Windows.Forms.ComboBox speakers;
        private System.Windows.Forms.TrackBar volume_bar;
        private System.Windows.Forms.Label volume_label;
    }
}