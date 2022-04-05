namespace Client
{
    partial class Join
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
            this.meeting_ID = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.join_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // meeting_ID
            // 
            this.meeting_ID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.meeting_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.meeting_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.meeting_ID.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meeting_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.meeting_ID.Location = new System.Drawing.Point(45, 54);
            this.meeting_ID.Name = "meeting_ID";
            this.meeting_ID.Size = new System.Drawing.Size(180, 31);
            this.meeting_ID.TabIndex = 49;
            this.meeting_ID.Text = "Enter Meeting ID";
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.title.Location = new System.Drawing.Point(81, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(106, 34);
            this.title.TabIndex = 47;
            this.title.Text = "Let\'s Go!";
            // 
            // join_button
            // 
            this.join_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.join_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.join_button.FlatAppearance.BorderSize = 0;
            this.join_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.join_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.join_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.join_button.Location = new System.Drawing.Point(52, 111);
            this.join_button.Name = "join_button";
            this.join_button.Size = new System.Drawing.Size(163, 35);
            this.join_button.TabIndex = 17;
            this.join_button.Text = "Join Meeting";
            this.join_button.UseVisualStyleBackColor = false;
            this.join_button.Click += new System.EventHandler(this.JoinMeeting);
            // 
            // Join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(268, 158);
            this.Controls.Add(this.meeting_ID);
            this.Controls.Add(this.title);
            this.Controls.Add(this.join_button);
            this.Name = "Join";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Shortcuts);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button join_button;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox meeting_ID;
    }
}