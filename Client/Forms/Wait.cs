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
    
    public partial class Wait : UserControl
    {
        public Wait()
        {
            InitializeComponent();
        }

        public void setCharade(Bitmap bmp)
        {
            this.Invoke((MethodInvoker)delegate { _setCharade(bmp); });
        }

        private void _setCharade(Bitmap bmp)
        {
            pictureBox1.Image = bmp;
        }

        private void Wait_Load(object sender, EventArgs e)
        {

        }

        private void commands_btn_Click(object sender, EventArgs e)
        {
            Program.network.send("/commands");
        }
    }
}
