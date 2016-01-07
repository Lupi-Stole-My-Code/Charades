namespace Client.Forms
{
    partial class Chat
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
            this.send = new System.Windows.Forms.Button();
            this.chattext = new System.Windows.Forms.TextBox();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // send
            // 
            this.send.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.send.Location = new System.Drawing.Point(229, -1);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(63, 45);
            this.send.TabIndex = 0;
            this.send.Text = "Send!";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.button1_Click);
            // 
            // chattext
            // 
            this.chattext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chattext.Location = new System.Drawing.Point(0, 0);
            this.chattext.Multiline = true;
            this.chattext.Name = "chattext";
            this.chattext.Size = new System.Drawing.Size(231, 43);
            this.chattext.TabIndex = 1;
            // 
            // chatBox
            // 
            this.chatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.chatBox.Location = new System.Drawing.Point(0, 0);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chatBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.chatBox.Size = new System.Drawing.Size(291, 488);
            this.chatBox.TabIndex = 3;
            this.chatBox.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chattext);
            this.panel1.Controls.Add(this.send);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 486);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 43);
            this.panel1.TabIndex = 4;
            // 
            // Chat
            // 
            this.AcceptButton = this.send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 529);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chatBox);
            this.Name = "Chat";
            this.Text = "Charades | Chat";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox chattext;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.Panel panel1;
    }
}