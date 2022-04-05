namespace Client
{
    partial class Participants
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

            m_QC.Dispose();
            m_updater.Dispose();
            m_videoThread.Abort();
            m_audioThread.Abort();
            m_shareThread.Abort();
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.strips = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // strips
            // 
            this.strips.AutoScroll = true;
            this.strips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.strips.Location = new System.Drawing.Point(0, 0);
            this.strips.Name = "strips";
            this.strips.Size = new System.Drawing.Size(237, 503);
            this.strips.TabIndex = 0;
            // 
            // Participants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.strips);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Participants";
            this.Size = new System.Drawing.Size(237, 503);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel strips;
    }
}
