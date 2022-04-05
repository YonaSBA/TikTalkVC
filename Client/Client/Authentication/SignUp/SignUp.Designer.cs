namespace Client
{
    partial class SignUp
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
            this.title = new System.Windows.Forms.Label();
            this.signup_button = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.confirm_password = new System.Windows.Forms.TextBox();
            this.confirm_email = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.title.Location = new System.Drawing.Point(11, 15);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(283, 39);
            this.title.TabIndex = 20;
            this.title.Text = "Welcome To TikTalk!";
            // 
            // signup_button
            // 
            this.signup_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.signup_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.signup_button.FlatAppearance.BorderSize = 0;
            this.signup_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signup_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.signup_button.Location = new System.Drawing.Point(73, 287);
            this.signup_button.Name = "signup_button";
            this.signup_button.Size = new System.Drawing.Size(160, 33);
            this.signup_button.TabIndex = 17;
            this.signup_button.Text = "Sign up";
            this.signup_button.UseVisualStyleBackColor = false;
            this.signup_button.Click += new System.EventHandler(this.SignUpEvent);
            // 
            // password
            // 
            this.password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.password.Location = new System.Drawing.Point(64, 109);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(180, 31);
            this.password.TabIndex = 47;
            this.password.Text = "Enter Password";
            // 
            // username
            // 
            this.username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.username.Location = new System.Drawing.Point(64, 71);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(180, 31);
            this.username.TabIndex = 48;
            this.username.Text = "Enter Username";
            // 
            // email
            // 
            this.email.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.email.Location = new System.Drawing.Point(64, 185);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(180, 31);
            this.email.TabIndex = 49;
            this.email.Text = "Enter Email";
            // 
            // confirm_password
            // 
            this.confirm_password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.confirm_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.confirm_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirm_password.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.confirm_password.Location = new System.Drawing.Point(64, 147);
            this.confirm_password.Name = "confirm_password";
            this.confirm_password.Size = new System.Drawing.Size(180, 31);
            this.confirm_password.TabIndex = 50;
            this.confirm_password.Text = "Confirm Password";
            // 
            // confirm_email
            // 
            this.confirm_email.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.confirm_email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.confirm_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirm_email.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.confirm_email.Location = new System.Drawing.Point(64, 223);
            this.confirm_email.Name = "confirm_email";
            this.confirm_email.Size = new System.Drawing.Size(180, 31);
            this.confirm_email.TabIndex = 52;
            this.confirm_email.Text = "Confirm Email";
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(304, 341);
            this.Controls.Add(this.confirm_email);
            this.Controls.Add(this.email);
            this.Controls.Add(this.confirm_password);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.title);
            this.Controls.Add(this.signup_button);
            this.Name = "SignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Shortcuts);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button signup_button;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox confirm_password;
        private System.Windows.Forms.TextBox confirm_email;
    }
}