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
        }
    }
}
