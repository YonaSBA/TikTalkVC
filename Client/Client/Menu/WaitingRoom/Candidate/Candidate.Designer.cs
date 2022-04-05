namespace Client
{
    partial class Candidate
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
            this.username = new System.Windows.Forms.Label();
            this.admit_button = new System.Windows.Forms.Button();
            this.reject_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.Dock = System.Windows.Forms.DockStyle.Left;
            this.username.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.RoyalBlue;
            this.username.Location = new System.Drawing.Point(0, 0);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(116, 35);
            this.username.TabIndex = 1;
            this.username.Text = "Username";
            this.username.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // admit_button
            // 
            this.admit_button.AutoSize = true;
            this.admit_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.admit_button.FlatAppearance.BorderSize = 0;
            this.admit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admit_button.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admit_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.admit_button.Location = new System.Drawing.Point(122, 3);
            this.admit_button.Name = "admit_button";
            this.admit_button.Size = new System.Drawing.Size(48, 29);
            this.admit_button.TabIndex = 2;
            this.admit_button.Text = "Admit";
            this.admit_button.UseVisualStyleBackColor = false;
            this.admit_button.Click += new System.EventHandler(this.Confirm);
            // 
            // reject_button
            // 
            this.reject_button.AutoSize = true;
            this.reject_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.reject_button.FlatAppearance.BorderSize = 0;
            this.reject_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reject_button.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reject_button.ForeColor = System.Drawing.Color.Red;
            this.reject_button.Location = new System.Drawing.Point(176, 3);
            this.reject_button.Name = "reject_button";
            this.reject_button.Size = new System.Drawing.Size(48, 29);
            this.reject_button.TabIndex = 2;
            this.reject_button.Text = "Reject";
            this.reject_button.UseVisualStyleBackColor = false;
            this.reject_button.Click += new System.EventHandler(this.Confirm);
            // 
            // Candidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.reject_button);
            this.Controls.Add(this.admit_button);
            this.Controls.Add(this.username);
            this.Name = "Candidate";
            this.Size = new System.Drawing.Size(227, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Button admit_button;
        private System.Windows.Forms.Button reject_button;
    }
}