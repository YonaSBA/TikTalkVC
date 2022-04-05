
namespace Client
{
    partial class ForgotPassword
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
            this.recovery_button = new System.Windows.Forms.Button();
            this.sub_title = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // recovery_button
            // 
            this.recovery_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.recovery_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.recovery_button.FlatAppearance.BorderSize = 0;
            this.recovery_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recovery_button.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recovery_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.recovery_button.Location = new System.Drawing.Point(51, 187);
            this.recovery_button.Name = "recovery_button";
            this.recovery_button.Size = new System.Drawing.Size(152, 29);
            this.recovery_button.TabIndex = 32;
            this.recovery_button.Text = "Change Password";
            this.recovery_button.UseVisualStyleBackColor = false;
            this.recovery_button.Click += new System.EventHandler(this.Recovery);
            // 
            // sub_title
            // 
            this.sub_title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sub_title.AutoSize = true;
            this.sub_title.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sub_title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.sub_title.Location = new System.Drawing.Point(14, 43);
            this.sub_title.Name = "sub_title";
            this.sub_title.Size = new System.Drawing.Size(227, 34);
            this.sub_title.TabIndex = 43;
            this.sub_title.Text = "We will send you an email with a code to\r\n help you replace your old password.";
            this.sub_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.title.Location = new System.Drawing.Point(53, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(151, 34);
            this.title.TabIndex = 46;
            this.title.Text = "Don\'t Worry!";
            // 
            // email
            // 
            this.email.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.email.Location = new System.Drawing.Point(38, 135);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(180, 31);
            this.email.TabIndex = 47;
            this.email.Text = "Enter Email";
            // 
            // username
            // 
            this.username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.username.Location = new System.Drawing.Point(38, 98);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(180, 31);
            this.username.TabIndex = 48;
            this.username.Text = "Enter Username";
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(257, 233);
            this.Controls.Add(this.email);
            this.Controls.Add(this.username);
            this.Controls.Add(this.title);
            this.Controls.Add(this.sub_title);
            this.Controls.Add(this.recovery_button);
            this.Name = "ForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Shortcuts);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button recovery_button;
        private System.Windows.Forms.Label sub_title;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox username;
    }
}