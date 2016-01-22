using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
            SystemMessage("Welcome to chat!");
            Program.chatRun = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chattext.Text.Length > 0)
            {
                //append(chattext.Text);
                if (Preferences.Chat.connected)
                {
                    Program.network.send(chattext.Text);
                    chattext.Text = String.Empty;
                }
                else
                {
                    MessageBox.Show("Disconnected from server");
                    this.Close();
                }
            }
        }

        private void append(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { append(message); });
            }
            else
            {
                append(message, Program.PlayerName);
            }
        }

        private void append(string message, string name)
        {
            if(this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { append(message, name); });
            }
            chatBox.AppendText("[" + DateTime.Now.ToLongTimeString() + "] ", Color.LightCoral);
            chatBox.AppendText("[" + name + "]", Color.Green);
            chatBox.AppendText("  " + message + "\n", Color.Blue);
        }

        private void SystemMessage(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { SystemMessage(text); });
            }
            else
            {
                SystemMessage(text, Color.Red);
            }
        }

        private void SystemMessage(string text, Color color)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { SystemMessage(text, color); });
            }
            else
            {
                Font font = new Font("Microsoft Sans Serif", 10);
                chatBox.AppendText("[@]", Color.Red, font);
                chatBox.AppendText(" " + text + Environment.NewLine, color, font);
            }
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            this.ActiveControl = chattext;
        }

        public void Msg(string text)
        {
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { Msg(text); });
            else
            {
                if (text.Contains(" says : "))
                {
                    int i = text.IndexOf(" says : ");
                    int c = " says : ".Length;
                    string user = text.Substring(0, i);
                    string msg = text.Substring(i + c);
                    append(msg, user);
                }
                else
                {
                    SystemMessage(text);
                }
            }
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.chatRun = false;
            if (Program.playgroundRun) Program.playground.Close();
            if (!Program.mainRun)
            {
                Program.mainRun = true;
                Program.startform.Show();
            }
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color, Font font = null)
        {
            if (font == null)
            {
                font = new Font("Microsoft Sans Serif", 8.25F);
            }

            if (box.InvokeRequired)
            {
                box.Invoke((MethodInvoker)delegate { box.AppendText(text, color, font); });
            }
            else
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;

                box.SelectionColor = color;
                box.SelectionFont = font;
                box.AppendText(text);
                box.SelectionColor = box.ForeColor;
            }
  
        }
    }
}
