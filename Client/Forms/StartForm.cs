using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            Music.WelcomeSound();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Black;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Program.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Forms.Chat a = new Forms.Chat();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }
    }
}
