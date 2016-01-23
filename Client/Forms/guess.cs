using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Client.Forms
{
    public partial class guess : UserControl
    {
        public Brush brush;
        private Graphics g;
        private Point p = Point.Empty;
        private Pen pioro;
        int secs=180;
        public guess()
        {
         
            InitializeComponent();
            brush = Brushes.Black;

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);


            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            
            pioro = new Pen(System.Drawing.Color.Black);
            color_btn.BackColor = System.Drawing.Color.Black;
            pioro.Width = 1;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                p = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(pioro, p, e.Location);
                p = e.Location;
                pictureBox1.Refresh();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            g.Clear(System.Drawing.Color.White);
            pictureBox1.Refresh();
        }

        private void color_btn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color_btn.BackColor = colorDialog1.Color;
                pioro.Color = colorDialog1.Color;
            }
        }

        private void brushsize_numeric_ValueChanged(object sender, EventArgs e)
        {
            pioro.Width = (int)brushsize_numeric.Value;
        }
        private void saveToFile()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter =
                "Plik BMP (*.bmp)|*.bmp|Plik JPEG (*.jpeg)|*.jpeg|Plik PNG (*.png)|*.png|Plik GIF (*.gif)|*.gif|Plik TIFF (*.tiff)|*.tiff";
            if (save.ShowDialog() == DialogResult.OK)
            {
                switch (save.FilterIndex)
                {
                    case 1:
                        pictureBox1.Image.Save(save.FileName, ImageFormat.Bmp);
                        break;
                    case 2:
                        pictureBox1.Image.Save(save.FileName, ImageFormat.Jpeg);
                        break;
                    case 3:
                        pictureBox1.Image.Save(save.FileName, ImageFormat.Png);
                        break;
                    case 4:
                        pictureBox1.Image.Save(save.FileName, ImageFormat.Gif);
                        break;
                    case 5:
                        pictureBox1.Image.Save(save.FileName, ImageFormat.Tiff);
                        break;
                }
            }
        }
        private Image sendImage()
        {

            if (this.InvokeRequired)
            {
                return (Image)this.Invoke((MethodInvoker)delegate { this.sendImage(); });
            }
            else
            {
                if (Program.turn)
                {
                    return pictureBox1.Image;
                }
                else
                {
                    return null;
                }
            }

        }
        private void setImage(Image img) // to set image in picture box when 
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { this.sendImage(); });
            }
            else
            {
                if (!Program.turn)
                {
                    pictureBox1.Image = img;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveToFile();
        }
        private void timer()
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            TimeSpan t = TimeSpan.FromSeconds(secs);

            string answer = string.Format("{0:D2}m:{1:D2}s",
                            t.Minutes,
                            t.Seconds
                            );
            label3.Text = answer;
            secs = secs - 1;
        }

        private void guess_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }
    }
}
