
namespace Client
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.title = new System.Windows.Forms.Label();
            this.new_label = new System.Windows.Forms.Label();
            this.history_label = new System.Windows.Forms.Label();
            this.settings_label = new System.Windows.Forms.Label();
            this.join_label = new System.Windows.Forms.Label();
            this.join_pictureBox = new System.Windows.Forms.PictureBox();
            this.history_pictureBox = new System.Windows.Forms.PictureBox();
            this.settings_pictureBox = new System.Windows.Forms.PictureBox();
            this.new_pictureBox = new System.Windows.Forms.PictureBox();
            this.signout_button = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.join_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.history_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.new_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(385, 80);
            this.title.TabIndex = 5;
            this.title.Text = "Let\'s Tik-Talk!";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // new_label
            // 
            this.new_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.new_label.AutoSize = true;
            this.new_label.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.new_label.Location = new System.Drawing.Point(74, 223);
            this.new_label.Name = "new_label";
            this.new_label.Size = new System.Drawing.Size(78, 17);
            this.new_label.TabIndex = 10;
            this.new_label.Text = "New Meeting";
            // 
            // history_label
            // 
            this.history_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.history_label.AutoSize = true;
            this.history_label.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.history_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.history_label.Location = new System.Drawing.Point(231, 359);
            this.history_label.Name = "history_label";
            this.history_label.Size = new System.Drawing.Size(97, 17);
            this.history_label.TabIndex = 11;
            this.history_label.Text = "Mettings History";
            // 
            // settings_label
            // 
            this.settings_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.settings_label.AutoSize = true;
            this.settings_label.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.settings_label.Location = new System.Drawing.Point(86, 359);
            this.settings_label.Name = "settings_label";
            this.settings_label.Size = new System.Drawing.Size(54, 17);
            this.settings_label.TabIndex = 12;
            this.settings_label.Text = "Settings";
            // 
            // join_label
            // 
            this.join_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.join_label.AutoSize = true;
            this.join_label.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.join_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.join_label.Location = new System.Drawing.Point(242, 223);
            this.join_label.Name = "join_label";
            this.join_label.Size = new System.Drawing.Size(77, 17);
            this.join_label.TabIndex = 13;
            this.join_label.Text = "Join Meeting";
            // 
            // join_pictureBox
            // 
            this.join_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.join_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("join_pictureBox.Image")));
            this.join_pictureBox.Location = new System.Drawing.Point(230, 120);
            this.join_pictureBox.Name = "join_pictureBox";
            this.join_pictureBox.Size = new System.Drawing.Size(100, 100);
            this.join_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.join_pictureBox.TabIndex = 9;
            this.join_pictureBox.TabStop = false;
            this.join_pictureBox.Click += new System.EventHandler(this.JoinEvent);
            // 
            // history_pictureBox
            // 
            this.history_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.history_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("history_pictureBox.Image")));
            this.history_pictureBox.Location = new System.Drawing.Point(230, 256);
            this.history_pictureBox.Name = "history_pictureBox";
            this.history_pictureBox.Size = new System.Drawing.Size(100, 100);
            this.history_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.history_pictureBox.TabIndex = 8;
            this.history_pictureBox.TabStop = false;
            this.history_pictureBox.Click += new System.EventHandler(this.HistoryEvent);
            // 
            // settings_pictureBox
            // 
            this.settings_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.settings_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("settings_pictureBox.Image")));
            this.settings_pictureBox.Location = new System.Drawing.Point(62, 256);
            this.settings_pictureBox.Name = "settings_pictureBox";
            this.settings_pictureBox.Size = new System.Drawing.Size(100, 100);
            this.settings_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.settings_pictureBox.TabIndex = 7;
            this.settings_pictureBox.TabStop = false;
            this.settings_pictureBox.Click += new System.EventHandler(this.SettingsEvent);
            // 
            // new_pictureBox
            // 
            this.new_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.new_pictureBox.Image = global::Client.Properties.Resources.create;
            this.new_pictureBox.Location = new System.Drawing.Point(62, 120);
            this.new_pictureBox.Name = "new_pictureBox";
            this.new_pictureBox.Size = new System.Drawing.Size(100, 100);
            this.new_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.new_pictureBox.TabIndex = 6;
            this.new_pictureBox.TabStop = false;
            this.new_pictureBox.Click += new System.EventHandler(this.NewEvent);
            // 
            // signout_button
            // 
            this.signout_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.signout_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.signout_button.FlatAppearance.BorderSize = 0;
            this.signout_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signout_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signout_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.signout_button.Image = global::Client.Properties.Resources.back1;
            this.signout_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.signout_button.Location = new System.Drawing.Point(131, 417);
            this.signout_button.Name = "signout_button";
            this.signout_button.Size = new System.Drawing.Size(122, 39);
            this.signout_button.TabIndex = 4;
            this.signout_button.Text = "Sign out";
            this.signout_button.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.signout_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.signout_button.UseVisualStyleBackColor = false;
            this.signout_button.Click += new System.EventHandler(this.SignOutEvent);
            // 
            // username
            // 
            this.username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.RoyalBlue;
            this.username.Location = new System.Drawing.Point(158, 80);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(73, 19);
            this.username.TabIndex = 14;
            this.username.Text = "Username";
            this.username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.username);
            this.Controls.Add(this.join_label);
            this.Controls.Add(this.settings_label);
            this.Controls.Add(this.history_label);
            this.Controls.Add(this.new_label);
            this.Controls.Add(this.join_pictureBox);
            this.Controls.Add(this.history_pictureBox);
            this.Controls.Add(this.settings_pictureBox);
            this.Controls.Add(this.new_pictureBox);
            this.Controls.Add(this.title);
            this.Controls.Add(this.signout_button);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Exit);
            this.VisibleChanged += new System.EventHandler(this.Hide);
            ((System.ComponentModel.ISupportInitialize)(this.join_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.history_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.new_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button signout_button;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox new_pictureBox;
        private System.Windows.Forms.PictureBox settings_pictureBox;
        private System.Windows.Forms.PictureBox history_pictureBox;
        private System.Windows.Forms.PictureBox join_pictureBox;
        private System.Windows.Forms.Label new_label;
        private System.Windows.Forms.Label history_label;
        private System.Windows.Forms.Label settings_label;
        private System.Windows.Forms.Label join_label;
        private System.Windows.Forms.Label username;
    }
}