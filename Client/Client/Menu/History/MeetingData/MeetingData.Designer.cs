
namespace Client
{
    partial class MeetingData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeetingData));
            this.start_textBox = new System.Windows.Forms.Label();
            this.properties_pannel = new System.Windows.Forms.Panel();
            this.participants_button = new System.Windows.Forms.Button();
            this.duration_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.duration_textBox = new System.Windows.Forms.Label();
            this.partcipants_list = new System.Windows.Forms.ListBox();
            this.properties_pannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_textBox
            // 
            this.start_textBox.AutoSize = true;
            this.start_textBox.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_textBox.ForeColor = System.Drawing.Color.AliceBlue;
            this.start_textBox.Location = new System.Drawing.Point(176, 15);
            this.start_textBox.Name = "start_textBox";
            this.start_textBox.Size = new System.Drawing.Size(235, 29);
            this.start_textBox.TabIndex = 3;
            this.start_textBox.Text = "DD/MM/YYYY HH:MM:SS";
            // 
            // properties_pannel
            // 
            this.properties_pannel.Controls.Add(this.participants_button);
            this.properties_pannel.Controls.Add(this.duration_button);
            this.properties_pannel.Controls.Add(this.start_button);
            this.properties_pannel.Location = new System.Drawing.Point(10, 6);
            this.properties_pannel.Name = "properties_pannel";
            this.properties_pannel.Size = new System.Drawing.Size(160, 136);
            this.properties_pannel.TabIndex = 13;
            // 
            // participants_button
            // 
            this.participants_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.participants_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.participants_button.FlatAppearance.BorderSize = 0;
            this.participants_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.participants_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participants_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.participants_button.Image = global::Client.Properties.Resources.participants1;
            this.participants_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.participants_button.Location = new System.Drawing.Point(0, 90);
            this.participants_button.Name = "participants_button";
            this.participants_button.Size = new System.Drawing.Size(160, 45);
            this.participants_button.TabIndex = 0;
            this.participants_button.Text = "Participants";
            this.participants_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.participants_button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.participants_button.UseVisualStyleBackColor = false;
            // 
            // duration_button
            // 
            this.duration_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.duration_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.duration_button.FlatAppearance.BorderSize = 0;
            this.duration_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.duration_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duration_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.duration_button.Image = ((System.Drawing.Image)(resources.GetObject("duration_button.Image")));
            this.duration_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.duration_button.Location = new System.Drawing.Point(0, 45);
            this.duration_button.Name = "duration_button";
            this.duration_button.Size = new System.Drawing.Size(160, 45);
            this.duration_button.TabIndex = 0;
            this.duration_button.Text = "Duration";
            this.duration_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.duration_button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.duration_button.UseVisualStyleBackColor = false;
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.start_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.start_button.FlatAppearance.BorderSize = 0;
            this.start_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_button.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_button.ForeColor = System.Drawing.Color.RoyalBlue;
            this.start_button.Image = ((System.Drawing.Image)(resources.GetObject("start_button.Image")));
            this.start_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.start_button.Location = new System.Drawing.Point(0, 0);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(160, 45);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "Start";
            this.start_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.start_button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.start_button.UseVisualStyleBackColor = false;
            // 
            // duration_textBox
            // 
            this.duration_textBox.AutoSize = true;
            this.duration_textBox.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duration_textBox.ForeColor = System.Drawing.Color.AliceBlue;
            this.duration_textBox.Location = new System.Drawing.Point(176, 59);
            this.duration_textBox.Name = "duration_textBox";
            this.duration_textBox.Size = new System.Drawing.Size(107, 29);
            this.duration_textBox.TabIndex = 3;
            this.duration_textBox.Text = "HH:MM:SS";
            // 
            // partcipants_list
            // 
            this.partcipants_list.AllowDrop = true;
            this.partcipants_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.partcipants_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.partcipants_list.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partcipants_list.ForeColor = System.Drawing.Color.White;
            this.partcipants_list.FormattingEnabled = true;
            this.partcipants_list.ItemHeight = 29;
            this.partcipants_list.Location = new System.Drawing.Point(176, 102);
            this.partcipants_list.Name = "partcipants_list";
            this.partcipants_list.Size = new System.Drawing.Size(166, 29);
            this.partcipants_list.TabIndex = 14;
            // 
            // MeetingData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BackgroundImage = global::Client.Properties.Resources.meeting;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.partcipants_list);
            this.Controls.Add(this.properties_pannel);
            this.Controls.Add(this.duration_textBox);
            this.Controls.Add(this.start_textBox);
            this.Name = "MeetingData";
            this.Size = new System.Drawing.Size(422, 148);
            this.properties_pannel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label start_textBox;
        private System.Windows.Forms.Panel properties_pannel;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button participants_button;
        private System.Windows.Forms.Button duration_button;
        private System.Windows.Forms.Label duration_textBox;
        private System.Windows.Forms.ListBox partcipants_list;
    }
}
