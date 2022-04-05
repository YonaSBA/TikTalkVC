namespace Client
{
    partial class SignIn
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
            this.remember = new System.Windows.Forms.CheckBox();
            this.forgot_linkLabel = new System.Windows.Forms.LinkLabel();
            this.signin_button = new System.Windows.Forms.Button();
            this.signup_label = new System.Windows.Forms.Label();
            this.signup_linkLabel = new System.Windows.Forms.LinkLabel();
            this.title = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // remember
            // 
            this.remember.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.remember.AutoSize = true;
            this.remember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remember.ForeColor = System.Drawing.Color.RoyalBlue;
            this.remember.Location = new System.Drawing.Point(59, 147);
            this.remember.Name = "remember";
            this.remember.Size = new System.Drawing.Size(123, 19);
            this.remember.TabIndex = 4;
            this.remember.Text = "Keep me signed in";
            this.remember.UseVisualStyleBackColor = true;
            // 
            // forgot_linkLabel
            // 
            this.forgot_linkLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.forgot_linkLabel.AutoSize = true;
            this.forgot_linkLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.forgot_linkLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.forgot_linkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.forgot_linkLabel.Location = new System.Drawing.Point(89, 176);
            this.forgot_linkLabel.Name = "forgot_linkLabel";
            this.forgot_linkLabel.Size = new System.Drawing.Size(127, 15);
            this.forgot_linkLabel.TabIndex = 5;
            this.forgot_linkLabel.TabStop = true;
            this.forgot_linkLabel.Text = "Forgot your password?";
            this.forgot_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ForgotPasswordEvent);
            // 
            // signin_button
            // 
            this.signin_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.signin_button.AutoSize = true;
            this.signin_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.signin_button.FlatAppearance.BorderSize = 0;
            this.signin_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signin_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signin_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.signin_button.Location = new System.Drawing.Point(67, 230);
            this.signin_button.Name = "signin_button";
            this.signin_button.Size = new System.Drawing.Size(163, 33);
            this.signin_button.TabIndex = 6;
            this.signin_button.Text = "Sign in";
            this.signin_button.UseVisualStyleBackColor = false;
            this.signin_button.Click += new System.EventHandler(this.SignInEvent);
            // 
            // signup_label
            // 
            this.signup_label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.signup_label.AutoSize = true;
            this.signup_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.signup_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.signup_label.Location = new System.Drawing.Point(41, 270);
            this.signup_label.Name = "signup_label";
            this.signup_label.Size = new System.Drawing.Size(150, 15);
            this.signup_label.TabIndex = 7;
            this.signup_label.Text = "Don\'t have an account yet?";
            // 
            // signup_linkLabel
            // 
            this.signup_linkLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.signup_linkLabel.AutoSize = true;
            this.signup_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.signup_linkLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.signup_linkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.signup_linkLabel.Location = new System.Drawing.Point(188, 269);
            this.signup_linkLabel.Name = "signup_linkLabel";
            this.signup_linkLabel.Size = new System.Drawing.Size(75, 15);
            this.signup_linkLabel.TabIndex = 8;
            this.signup_linkLabel.TabStop = true;
            this.signup_linkLabel.Text = "Sign up now";
            this.signup_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SignUpEvent);
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.title.Location = new System.Drawing.Point(98, 21);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(108, 39);
            this.title.TabIndex = 9;
            this.title.Text = "TikTalk";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // password
            // 
            this.password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.password.Location = new System.Drawing.Point(59, 110);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(180, 31);
            this.password.TabIndex = 11;
            this.password.Text = "Enter Password";
            // 
            // username
            // 
            this.username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.username.Location = new System.Drawing.Point(59, 72);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(180, 31);
            this.username.TabIndex = 11;
            this.username.Text = "Enter Username";
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(304, 303);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.title);
            this.Controls.Add(this.signup_linkLabel);
            this.Controls.Add(this.signup_label);
            this.Controls.Add(this.signin_button);
            this.Controls.Add(this.forgot_linkLabel);
            this.Controls.Add(this.remember);
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Exit);
            this.VisibleChanged += new System.EventHandler(this.ChangeVisible);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Shortcuts);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox remember;
        private System.Windows.Forms.LinkLabel forgot_linkLabel;
        private System.Windows.Forms.Button signin_button;
        private System.Windows.Forms.Label signup_label;
        private System.Windows.Forms.LinkLabel signup_linkLabel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
    }
}