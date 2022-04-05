namespace Client
{
    partial class ChangePassword
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
            this.confirm_new_password = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.new_password = new System.Windows.Forms.TextBox();
            this.code = new System.Windows.Forms.TextBox();
            this.done_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // confirm_new_password
            // 
            this.confirm_new_password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.confirm_new_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.confirm_new_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirm_new_password.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_new_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.confirm_new_password.Location = new System.Drawing.Point(66, 135);
            this.confirm_new_password.Name = "confirm_new_password";
            this.confirm_new_password.Size = new System.Drawing.Size(200, 31);
            this.confirm_new_password.TabIndex = 52;
            this.confirm_new_password.Text = "Confirm New Password";
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.title.Location = new System.Drawing.Point(26, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(277, 39);
            this.title.TabIndex = 53;
            this.title.Text = "Password Changing";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // new_password
            // 
            this.new_password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.new_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.new_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.new_password.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.new_password.Location = new System.Drawing.Point(66, 98);
            this.new_password.Name = "new_password";
            this.new_password.Size = new System.Drawing.Size(200, 31);
            this.new_password.TabIndex = 54;
            this.new_password.Text = "Enter New Password";
            // 
            // code
            // 
            this.code.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.code.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.code.Location = new System.Drawing.Point(66, 61);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(200, 31);
            this.code.TabIndex = 55;
            this.code.Text = "Enter Code";
            // 
            // done_button
            // 
            this.done_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.done_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.done_button.FlatAppearance.BorderSize = 0;
            this.done_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.done_button.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.done_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.done_button.Location = new System.Drawing.Point(127, 177);
            this.done_button.Name = "done_button";
            this.done_button.Size = new System.Drawing.Size(72, 29);
            this.done_button.TabIndex = 56;
            this.done_button.Text = "Done";
            this.done_button.UseVisualStyleBackColor = false;
            this.done_button.Click += new System.EventHandler(this.Done);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(328, 217);
            this.Controls.Add(this.done_button);
            this.Controls.Add(this.new_password);
            this.Controls.Add(this.code);
            this.Controls.Add(this.title);
            this.Controls.Add(this.confirm_new_password);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Shortcuts);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox confirm_new_password;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox new_password;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Button done_button;
    }
}