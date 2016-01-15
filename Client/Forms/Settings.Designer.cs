namespace Client.Forms
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.music_lbl = new System.Windows.Forms.Label();
            this.music_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(571, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Go Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // music_lbl
            // 
            this.music_lbl.AutoSize = true;
            this.music_lbl.Location = new System.Drawing.Point(25, 22);
            this.music_lbl.Name = "music_lbl";
            this.music_lbl.Size = new System.Drawing.Size(35, 13);
            this.music_lbl.TabIndex = 2;
            this.music_lbl.Text = "Music";
            // 
            // music_btn
            // 
            this.music_btn.Location = new System.Drawing.Point(66, 17);
            this.music_btn.Name = "music_btn";
            this.music_btn.Size = new System.Drawing.Size(75, 23);
            this.music_btn.TabIndex = 3;
            this.music_btn.Text = "Music";
            this.music_btn.UseVisualStyleBackColor = true;
            this.music_btn.Click += new System.EventHandler(this.music_btn_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.music_btn);
            this.Controls.Add(this.music_lbl);
            this.Controls.Add(this.button1);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(693, 382);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label music_lbl;
        private System.Windows.Forms.Button music_btn;
    }
}
