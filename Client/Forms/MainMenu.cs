using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //  Program.chat_main = new Forms.Chat();
            //  Program.network.connect(IPAddress.Loopback);
            // Forms.Logging a = new Forms.Logging();
            // this.Hide();
            //  Program.chat_main.ShowDialog();
            Program.playground = new Forms.Playground();
            Program.playground.ShowDialog();

            this.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Program.startform.showSettings();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Program.Exit();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Black;
        }
    }
}
