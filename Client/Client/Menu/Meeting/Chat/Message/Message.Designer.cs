namespace Client
{
    partial class Message
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
            this.context = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nickname
            // 
            this.nickname.AutoSize = true;
            this.nickname.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nickname.ForeColor = System.Drawing.Color.RoyalBlue;
            this.nickname.Location = new System.Drawing.Point(-3, 0);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(71, 19);
            this.nickname.TabIndex = 0;
            this.nickname.Text = "Nickname";
            // 
            // context
            // 
            this.context.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.context.AutoSize = true;
            this.context.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.context.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.context.ForeColor = System.Drawing.Color.White;
            this.context.Location = new System.Drawing.Point(-2, 23);
            this.context.MaximumSize = new System.Drawing.Size(141, 1700);
            this.context.Name = "context";
            this.context.Size = new System.Drawing.Size(57, 17);
            this.context.TabIndex = 1;
            this.context.Text = "Message";
            // 
            // time
            // 
            this.time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.ForeColor = System.Drawing.Color.Gray;
            this.time.Location = new System.Drawing.Point(94, 39);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(44, 19);
            this.time.TabIndex = 2;
            this.time.Text = "00:00";
            this.time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.time);
            this.Controls.Add(this.context);
            this.Controls.Add(this.nickname);
            this.Name = "Message";
            this.Size = new System.Drawing.Size(138, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nickname;
        private System.Windows.Forms.Label context;
        private System.Windows.Forms.Label time;
    }
}
