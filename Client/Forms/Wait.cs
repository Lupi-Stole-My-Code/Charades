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
        int secs = 180;
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
            timer1.Interval = 1000;
            timer1.Start();
            label1.BackColor = Color.Green;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            TimeSpan t = TimeSpan.FromSeconds(secs);

            string answer = string.Format("{0:D2}m:{1:D2}s",
                            t.Minutes,
                            t.Seconds
                            );
            label1.Text = answer;
            if (secs < 30)
            {
                if (secs == 0)
                {
                    timer1.Stop();
                }
                label1.BackColor = Color.Red;
                if (secs % 2 == 0)
                {
                    label1.BackColor = Color.Yellow;
                }

            }
            secs = secs - 1;
        }

        public void timerSet(int seconds)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { timerSet(seconds); });
            }
            else
            {
                this.secs = seconds;
            }
        }

    }
}
