namespace Client
{
    partial class Chat
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
            this.messenger = new System.Windows.Forms.FlowLayoutPanel();
            this.message = new System.Windows.Forms.TextBox();
            this.direct_label = new System.Windows.Forms.Label();
            this.nicknames = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // messenger
            // 
            this.messenger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.messenger.AutoScroll = true;
            this.messenger.Location = new System.Drawing.Point(0, 0);
            this.messenger.Name = "messenger";
            this.messenger.Size = new System.Drawing.Size(230, 428);
            this.messenger.TabIndex = 0;
            // 
            // message
            // 
            this.message.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.message.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.message.Location = new System.Drawing.Point(0, 468);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(230, 31);
            this.message.TabIndex = 12;
            this.message.Text = "Type message here...";
            // 
            // direct_label
            // 
            this.direct_label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.direct_label.AutoSize = true;
            this.direct_label.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direct_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.direct_label.Location = new System.Drawing.Point(17, 438);
            this.direct_label.Name = "direct_label";
            this.direct_label.Size = new System.Drawing.Size(79, 20);
            this.direct_label.TabIndex = 16;
            this.direct_label.Text = "Directly to:";
            // 
            // nicknames
            // 
            this.nicknames.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nicknames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.nicknames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nicknames.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nicknames.ForeColor = System.Drawing.Color.RoyalBlue;
            this.nicknames.FormattingEnabled = true;
            this.nicknames.Location = new System.Drawing.Point(102, 434);
            this.nicknames.Name = "nicknames";
            this.nicknames.Size = new System.Drawing.Size(106, 28);
            this.nicknames.TabIndex = 17;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.nicknames);
            this.Controls.Add(this.direct_label);
            this.Controls.Add(this.message);
            this.Controls.Add(this.messenger);
            this.Name = "Chat";
            this.Size = new System.Drawing.Size(237, 503);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel messenger;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Label direct_label;
        private System.Windows.Forms.ComboBox nicknames;
    }
}
