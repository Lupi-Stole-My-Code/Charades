using System;
using System.Drawing;
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
             // Program.chat_main = new Forms.Chat();
              //Program.network.connect(IPAddress.Loopback);
            Program.startform.Hide();
            
            while (Program.PlayerName == "0")
            {
                Forms.UserNameSelect uname = new UserNameSelect();
                uname.ShowDialog();
            }

            Program.loggingform = new Logging();
            Program.loggingform.Show();
            Program.startform.Hide();
            Program.mainRun = false;
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
