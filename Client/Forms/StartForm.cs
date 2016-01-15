using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
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
            showDefault();
            
        }
        public void showSettings()
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { showSettings(); });
            }
            else
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(new Forms.Settings());
            }
        }
        public void showDefault()
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { showDefault(); });
            }
            else
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(new Forms.MainMenu());
            }
        }


    }
}
