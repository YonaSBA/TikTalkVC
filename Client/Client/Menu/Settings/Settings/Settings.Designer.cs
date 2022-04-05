namespace Client
{
    partial class Settings
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
            this.categories_pannel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.user_pictureBox = new AForge.Controls.PictureBox();
            this.username = new System.Windows.Forms.Label();
            this.signer = new System.Windows.Forms.Panel();
            this.hospitality_button = new System.Windows.Forms.Button();
            this.participation_button = new System.Windows.Forms.Button();
            this.symbol = new AForge.Controls.PictureBox();
            this.app_pannel = new System.Windows.Forms.Panel();
            this.setting_label = new System.Windows.Forms.Label();
            this.category_pannel = new System.Windows.Forms.Panel();
            this.categories_pannel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.symbol)).BeginInit();
            this.app_pannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // categories_pannel
            // 
            this.categories_pannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.categories_pannel.Controls.Add(this.panel1);
            this.categories_pannel.Controls.Add(this.signer);
            this.categories_pannel.Controls.Add(this.hospitality_button);
            this.categories_pannel.Controls.Add(this.participation_button);
            this.categories_pannel.Controls.Add(this.symbol);
            this.categories_pannel.Dock = System.Windows.Forms.DockStyle.Left;
            this.categories_pannel.Location = new System.Drawing.Point(0, 0);
            this.categories_pannel.Name = "categories_pannel";
            this.categories_pannel.Size = new System.Drawing.Size(110, 258);
            this.categories_pannel.TabIndex = 54;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.user_pictureBox);
            this.panel1.Controls.Add(this.username);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 70);
            this.panel1.TabIndex = 1;
            // 
            // user_pictureBox
            // 
            this.user_pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.user_pictureBox.BackgroundImage = global::Client.Properties.Resources.user;
            this.user_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.user_pictureBox.Image = null;
            this.user_pictureBox.Location = new System.Drawing.Point(34, 4);
            this.user_pictureBox.Name = "user_pictureBox";
            this.user_pictureBox.Size = new System.Drawing.Size(40, 40);
            this.user_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.user_pictureBox.TabIndex = 0;
            this.user_pictureBox.TabStop = false;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.RoyalBlue;
            this.username.Location = new System.Drawing.Point(16, 44);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(76, 20);
            this.username.TabIndex = 0;
            this.username.Text = "Username";
            this.username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signer
            // 
            this.signer.BackColor = System.Drawing.Color.RoyalBlue;
            this.signer.Location = new System.Drawing.Point(0, 81);
            this.signer.Name = "signer";
            this.signer.Size = new System.Drawing.Size(4, 60);
            this.signer.TabIndex = 3;
            // 
            // hospitality_button
            // 
            this.hospitality_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.hospitality_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hospitality_button.FlatAppearance.BorderSize = 4;
            this.hospitality_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hospitality_button.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hospitality_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.hospitality_button.Location = new System.Drawing.Point(0, 69);
            this.hospitality_button.Name = "hospitality_button";
            this.hospitality_button.Size = new System.Drawing.Size(110, 42);
            this.hospitality_button.TabIndex = 2;
            this.hospitality_button.Text = "Hospitality";
            this.hospitality_button.UseVisualStyleBackColor = false;
            this.hospitality_button.Click += new System.EventHandler(this.HospitalityEvent);
            // 
            // participation_button
            // 
            this.participation_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.participation_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.participation_button.FlatAppearance.BorderSize = 4;
            this.participation_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.participation_button.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participation_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.participation_button.Location = new System.Drawing.Point(0, 111);
            this.participation_button.Name = "participation_button";
            this.participation_button.Size = new System.Drawing.Size(110, 42);
            this.participation_button.TabIndex = 2;
            this.participation_button.Text = "Participation";
            this.participation_button.UseVisualStyleBackColor = false;
            this.participation_button.Click += new System.EventHandler(this.ParticipationEvent);
            // 
            // symbol
            // 
            this.symbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.symbol.BackgroundImage = global::Client.Properties.Resources.settings21;
            this.symbol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.symbol.Image = null;
            this.symbol.Location = new System.Drawing.Point(0, 153);
            this.symbol.Name = "symbol";
            this.symbol.Size = new System.Drawing.Size(110, 105);
            this.symbol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.symbol.TabIndex = 0;
            this.symbol.TabStop = false;
            // 
            // app_pannel
            // 
            this.app_pannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.app_pannel.Controls.Add(this.setting_label);
            this.app_pannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.app_pannel.Location = new System.Drawing.Point(110, 0);
            this.app_pannel.Name = "app_pannel";
            this.app_pannel.Size = new System.Drawing.Size(484, 53);
            this.app_pannel.TabIndex = 55;
            // 
            // setting_label
            // 
            this.setting_label.AutoSize = true;
            this.setting_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.setting_label.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.setting_label.Location = new System.Drawing.Point(0, 0);
            this.setting_label.Name = "setting_label";
            this.setting_label.Size = new System.Drawing.Size(157, 48);
            this.setting_label.TabIndex = 0;
            this.setting_label.Text = "Settings";
            // 
            // category_pannel
            // 
            this.category_pannel.BackColor = System.Drawing.Color.Transparent;
            this.category_pannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.category_pannel.Location = new System.Drawing.Point(110, 53);
            this.category_pannel.Name = "category_pannel";
            this.category_pannel.Size = new System.Drawing.Size(484, 200);
            this.category_pannel.TabIndex = 56;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(594, 258);
            this.Controls.Add(this.category_pannel);
            this.Controls.Add(this.app_pannel);
            this.Controls.Add(this.categories_pannel);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Save);
            this.categories_pannel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.symbol)).EndInit();
            this.app_pannel.ResumeLayout(false);
            this.app_pannel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel categories_pannel;
        private AForge.Controls.PictureBox symbol;
        private System.Windows.Forms.Panel signer;
        private System.Windows.Forms.Button hospitality_button;
        private System.Windows.Forms.Button participation_button;
        private System.Windows.Forms.Panel app_pannel;
        private System.Windows.Forms.Label setting_label;
        private System.Windows.Forms.Panel category_pannel;
        private System.Windows.Forms.Panel panel1;
        private AForge.Controls.PictureBox user_pictureBox;
        private System.Windows.Forms.Label username;
    }
}