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
    public partial class Settings : UserControl
    {
        bool musicStatus = true;

        public Settings()
        {
            InitializeComponent();
            music_btn.Text = "ON";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.startform.showDefault();
        }

        private void music_btn_Click(object sender, EventArgs e)
        {
            if (musicStatus)
            {
                musicStatus = false;
                Music.Stop();
                music_btn.Text = "OFF";
            }
            else
            {
                musicStatus = true;
                Music.WelcomeSound();
                music_btn.Text = "ON";

            }
        }
    }
}
