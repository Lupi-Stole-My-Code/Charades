namespace Charades
{
    partial class Form1
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
            this.clear_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.ListBox();
            this.chatInput = new System.Windows.Forms.TextBox();
            this.buttonChatSend = new System.Windows.Forms.Button();
            this.turnBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.turnBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(9, 72);
            this.clear_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(112, 35);
            this.clear_btn.TabIndex = 1;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Draw: Gorilla";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 615);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 117);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // chat
            // 
            this.chat.FormattingEnabled = true;
            this.chat.ItemHeight = 20;
            this.chat.Location = new System.Drawing.Point(627, 2);
            this.chat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(416, 724);
            this.chat.TabIndex = 6;
            // 
            // chatInput
            // 
            this.chatInput.Location = new System.Drawing.Point(627, 746);
            this.chatInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chatInput.Name = "chatInput";
            this.chatInput.Size = new System.Drawing.Size(295, 26);
            this.chatInput.TabIndex = 7;
            // 
            // buttonChatSend
            // 
            this.buttonChatSend.Location = new System.Drawing.Point(932, 734);
            this.buttonChatSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonChatSend.Name = "buttonChatSend";
            this.buttonChatSend.Size = new System.Drawing.Size(112, 35);
            this.buttonChatSend.TabIndex = 8;
            this.buttonChatSend.Text = "Send";
            this.buttonChatSend.UseVisualStyleBackColor = true;
            this.buttonChatSend.Click += new System.EventHandler(this.buttonChatSend_Click);
            // 
            // turnBox
            // 
            this.turnBox.Controls.Add(this.clear_btn);
            this.turnBox.Controls.Add(this.label1);
            this.turnBox.Controls.Add(this.button1);
            this.turnBox.Location = new System.Drawing.Point(458, 628);
            this.turnBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.turnBox.Name = "turnBox";
            this.turnBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.turnBox.Size = new System.Drawing.Size(146, 162);
            this.turnBox.TabIndex = 9;
            this.turnBox.TabStop = false;
            this.turnBox.Text = "turnBox";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 773);
            this.Controls.Add(this.turnBox);
            this.Controls.Add(this.buttonChatSend);
            this.Controls.Add(this.chatInput);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.turnBox.ResumeLayout(false);
            this.turnBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox chat;
        private System.Windows.Forms.TextBox chatInput;
        private System.Windows.Forms.Button buttonChatSend;
        private System.Windows.Forms.GroupBox turnBox;
    }
}

