namespace Client
{
    partial class WaitingRoom
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
            this.waiting_room = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // waiting_room
            // 
            this.waiting_room.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.waiting_room.AutoSize = true;
            this.waiting_room.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waiting_room.ForeColor = System.Drawing.Color.RoyalBlue;
            this.waiting_room.Location = new System.Drawing.Point(74, 196);
            this.waiting_room.Name = "waiting_room";
            this.waiting_room.Size = new System.Drawing.Size(650, 39);
            this.waiting_room.TabIndex = 1;
            this.waiting_room.Text = "Please wait, the meeting host will let you in soon.\r\n";
            // 
            // WaitingRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.waiting_room);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "WaitingRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaitingRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label waiting_room;
    }
}