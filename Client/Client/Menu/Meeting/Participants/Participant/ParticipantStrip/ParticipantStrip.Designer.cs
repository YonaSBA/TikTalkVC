namespace Client
{
    partial class ParticipantStrip
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nickname = new System.Windows.Forms.Label();
            this.share = new System.Windows.Forms.PictureBox();
            this.audio = new System.Windows.Forms.PictureBox();
            this.video = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.share)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.video)).BeginInit();
            this.SuspendLayout();
            // 
            // nickname
            // 
            this.nickname.Dock = System.Windows.Forms.DockStyle.Left;
            this.nickname.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nickname.ForeColor = System.Drawing.Color.RoyalBlue;
            this.nickname.Location = new System.Drawing.Point(0, 0);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(120, 35);
            this.nickname.TabIndex = 1;
            this.nickname.Text = "Nickname";
            this.nickname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // share
            // 
            this.share.Dock = System.Windows.Forms.DockStyle.Right;
            this.share.Location = new System.Drawing.Point(122, 0);
            this.share.Name = "share";
            this.share.Size = new System.Drawing.Size(35, 35);
            this.share.TabIndex = 0;
            this.share.TabStop = false;
            // 
            // audio
            // 
            this.audio.Dock = System.Windows.Forms.DockStyle.Right;
            this.audio.Location = new System.Drawing.Point(157, 0);
            this.audio.Name = "audio";
            this.audio.Size = new System.Drawing.Size(35, 35);
            this.audio.TabIndex = 0;
            this.audio.TabStop = false;
            // 
            // video
            // 
            this.video.Dock = System.Windows.Forms.DockStyle.Right;
            this.video.Location = new System.Drawing.Point(192, 0);
            this.video.Name = "video";
            this.video.Size = new System.Drawing.Size(35, 35);
            this.video.TabIndex = 0;
            this.video.TabStop = false;
            // 
            // ParticipantStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.share);
            this.Controls.Add(this.audio);
            this.Controls.Add(this.video);
            this.Name = "ParticipantStrip";
            this.Size = new System.Drawing.Size(227, 35);
            ((System.ComponentModel.ISupportInitialize)(this.share)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.video)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox video;
        private System.Windows.Forms.PictureBox audio;
        private System.Windows.Forms.PictureBox share;
        private System.Windows.Forms.Label nickname;
    }
}
