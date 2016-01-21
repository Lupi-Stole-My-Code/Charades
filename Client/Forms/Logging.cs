using System;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace Client.Forms
{
    public partial class Logging : Form
    {
        public Logging()
        {
            InitializeComponent();
        }



        private void Connect_Click(object sender, EventArgs e)
        {
            loading.Enabled = true;
            loading.Visible = true;

            Program.chat_main = new Chat();
            IPAddress ip = IPAddress.Parse(textBox1.Text);
            Program.network.connect(ip);
            Preferences.Chat.connected = true;


            Program.chat_main.Show();
            Program.playground = new Forms.Playground();
            this.Hide();
            Program.playground.Show();

            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            IPAddress address;
            if (IPAddress.TryParse(textBox1.Text, out address))
            {
                Connect.Enabled = true;
            }
            else
            {
                Connect.Enabled = false;
            }

            if (textBox1.Text.ToLower() == "localhost")
            {
                textBox1.Text = "127.0.0.1";
            }
        }
    }

}
