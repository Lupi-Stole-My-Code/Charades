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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(chattext.Text.Length > 0)
            {
                append(chattext.Text);
                chattext.Text = String.Empty;
            }
        }

        private void append(string message)
        {
            chatBox.AppendText("[" + DateTime.Now.ToLongTimeString() + "] ", Color.LightCoral);
            chatBox.AppendText("[" + Program.PlayerName + "]", Color.Green);
            chatBox.AppendText( "  " + message + "\n", Color.Blue);
        }

        private void SystemMessage(string text)
        {
            SystemMessage(text, Color.Red);
        }

        private void SystemMessage(string text, Color color)
        {
            chatBox.AppendText("[@]", Color.Red);
            chatBox.AppendText(" " + text + Environment.NewLine, color);
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
