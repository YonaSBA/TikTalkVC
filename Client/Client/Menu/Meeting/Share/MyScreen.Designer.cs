namespace Client
{
    partial class MyScreen
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
            this.image = new AForge.Controls.PictureBox();
            this.nickname = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
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
            // nickname
            // 
            this.nickname.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.nickname.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nickname.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nickname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.nickname.Location = new System.Drawing.Point(0, 208);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(350, 42);
            this.nickname.TabIndex = 1;
            this.nickname.Text = "Nickname\'s Share";
            this.nickname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.image);
            this.Name = "MyScreen";
            this.Size = new System.Drawing.Size(350, 250);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected AForge.Controls.PictureBox image;
        protected System.Windows.Forms.Label nickname;
    }
}
