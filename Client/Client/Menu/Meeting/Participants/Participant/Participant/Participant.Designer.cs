namespace Client
{
    partial class Participant
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
            this.components = new System.ComponentModel.Container();
            this.nickname = new System.Windows.Forms.Label();
            this.host_strip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.host_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.host_change_background = new System.Windows.Forms.ToolStripMenuItem();
            this.special = new System.Windows.Forms.ToolStripSeparator();
            this.hide = new System.Windows.Forms.ToolStripMenuItem();
            this.mute = new System.Windows.Forms.ToolStripMenuItem();
            this.stop_share = new System.Windows.Forms.ToolStripMenuItem();
            this.super_special = new System.Windows.Forms.ToolStripSeparator();
            this.kick = new System.Windows.Forms.ToolStripMenuItem();
            this.make_host = new System.Windows.Forms.ToolStripMenuItem();
            this.rename = new System.Windows.Forms.ToolStripMenuItem();
            this.change_background = new System.Windows.Forms.ToolStripMenuItem();
            this.participant_strip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.audio = new System.Windows.Forms.PictureBox();
            this.image = new AForge.Controls.PictureBox();
            this.host_strip.SuspendLayout();
            this.participant_strip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // nickname
            // 
            this.nickname.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.nickname.Dock = System.Windows.Forms.DockStyle.Left;
            this.nickname.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nickname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.nickname.Location = new System.Drawing.Point(0, 208);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(309, 35);
            this.nickname.TabIndex = 1;
            this.nickname.Text = "Nickname";
            this.nickname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // host_strip
            // 
            this.host_strip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.host_strip.DropShadowEnabled = false;
            this.host_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.host_rename,
            this.host_change_background,
            this.special,
            this.hide,
            this.mute,
            this.stop_share,
            this.super_special,
            this.kick,
            this.make_host});
            this.host_strip.Name = "host_strip";
            this.host_strip.ShowImageMargin = false;
            this.host_strip.Size = new System.Drawing.Size(161, 170);
            this.host_strip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Update);
            // 
            // host_rename
            // 
            this.host_rename.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.host_rename.ForeColor = System.Drawing.Color.RoyalBlue;
            this.host_rename.Name = "host_rename";
            this.host_rename.Size = new System.Drawing.Size(160, 22);
            this.host_rename.Text = "Rename";
            // 
            // host_change_background
            // 
            this.host_change_background.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.host_change_background.ForeColor = System.Drawing.Color.RoyalBlue;
            this.host_change_background.Name = "host_change_background";
            this.host_change_background.Size = new System.Drawing.Size(160, 22);
            this.host_change_background.Text = "Change Background";
            // 
            // special
            // 
            this.special.Name = "special";
            this.special.Size = new System.Drawing.Size(157, 6);
            // 
            // hide
            // 
            this.hide.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hide.ForeColor = System.Drawing.Color.RoyalBlue;
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(160, 22);
            this.hide.Text = "Hide";
            // 
            // mute
            // 
            this.mute.Font = new System.Drawing.Font("Impact", 9.75F);
            this.mute.ForeColor = System.Drawing.Color.RoyalBlue;
            this.mute.Name = "mute";
            this.mute.Size = new System.Drawing.Size(160, 22);
            this.mute.Text = "Mute";
            // 
            // stop_share
            // 
            this.stop_share.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop_share.ForeColor = System.Drawing.Color.RoyalBlue;
            this.stop_share.Name = "stop_share";
            this.stop_share.Size = new System.Drawing.Size(160, 22);
            this.stop_share.Text = "Stop Share";
            // 
            // super_special
            // 
            this.super_special.Name = "super_special";
            this.super_special.Size = new System.Drawing.Size(157, 6);
            // 
            // kick
            // 
            this.kick.Font = new System.Drawing.Font("Impact", 9.75F);
            this.kick.ForeColor = System.Drawing.Color.RoyalBlue;
            this.kick.Name = "kick";
            this.kick.Size = new System.Drawing.Size(160, 22);
            this.kick.Text = "Kick";
            // 
            // make_host
            // 
            this.make_host.Font = new System.Drawing.Font("Impact", 9.75F);
            this.make_host.ForeColor = System.Drawing.Color.RoyalBlue;
            this.make_host.Name = "make_host";
            this.make_host.Size = new System.Drawing.Size(160, 22);
            this.make_host.Text = "Make Host";
            // 
            // rename
            // 
            this.rename.Font = new System.Drawing.Font("Impact", 9.75F);
            this.rename.ForeColor = System.Drawing.Color.RoyalBlue;
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(160, 22);
            this.rename.Text = "Rename";
            // 
            // change_background
            // 
            this.change_background.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change_background.ForeColor = System.Drawing.Color.RoyalBlue;
            this.change_background.Name = "change_background";
            this.change_background.Size = new System.Drawing.Size(160, 22);
            this.change_background.Text = "Change Background";
            // 
            // participant_strip
            // 
            this.participant_strip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.participant_strip.DropShadowEnabled = false;
            this.participant_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rename,
            this.change_background});
            this.participant_strip.Name = "participant_strip";
            this.participant_strip.ShowImageMargin = false;
            this.participant_strip.Size = new System.Drawing.Size(161, 48);
            this.participant_strip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Update);
            // 
            // audio
            // 
            this.audio.Dock = System.Windows.Forms.DockStyle.Right;
            this.audio.Location = new System.Drawing.Point(315, 208);
            this.audio.Name = "audio";
            this.audio.Size = new System.Drawing.Size(35, 35);
            this.audio.TabIndex = 2;
            this.audio.TabStop = false;
            // 
            // image
            // 
            this.image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.image.Dock = System.Windows.Forms.DockStyle.Top;
            this.image.Image = null;
            this.image.Location = new System.Drawing.Point(0, 0);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(350, 208);
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // Participant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ContextMenuStrip = this.host_strip;
            this.Controls.Add(this.audio);
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.image);
            this.Name = "Participant";
            this.Size = new System.Drawing.Size(350, 243);
            this.host_strip.ResumeLayout(false);
            this.participant_strip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.audio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected AForge.Controls.PictureBox image;
        protected System.Windows.Forms.Label nickname;
        public System.Windows.Forms.ContextMenuStrip host_strip;
        private System.Windows.Forms.ToolStripMenuItem hide;
        private System.Windows.Forms.ToolStripMenuItem mute;
        private System.Windows.Forms.ToolStripMenuItem rename;
        private System.Windows.Forms.ToolStripMenuItem kick;
        private System.Windows.Forms.ToolStripMenuItem make_host;
        private System.Windows.Forms.ToolStripMenuItem change_background;
        private System.Windows.Forms.ToolStripSeparator special;
        private System.Windows.Forms.ToolStripSeparator super_special;
        public System.Windows.Forms.ContextMenuStrip participant_strip;
        private System.Windows.Forms.PictureBox audio;
        private System.Windows.Forms.ToolStripMenuItem host_rename;
        private System.Windows.Forms.ToolStripMenuItem host_change_background;
        private System.Windows.Forms.ToolStripMenuItem stop_share;
    }
}
