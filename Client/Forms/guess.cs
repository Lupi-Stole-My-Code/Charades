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
using System.IO;
using System.Threading;

namespace Client.Forms
{
    public partial class guess : UserControl
    {
        public Brush brush;
        private Graphics g;
        private Point p = Point.Empty;
        private Pen pioro;
        int secs=35;
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
            textBox1.Text = "";
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
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            TimeSpan t = TimeSpan.FromSeconds(secs);

            string answer = string.Format("{0:D2}m:{1:D2}s",
                            t.Minutes,
                            t.Seconds
                            );
            label3.Text = answer;
            if (secs < 30)
            {
                if (secs == 0)
                {
                    timer1.Stop();
                }
                label3.BackColor = Color.Red;
                if (secs % 2 == 0)
                {
                    label3.BackColor = Color.Yellow;
                }

            }
            secs = secs - 1;    
        }

        public void timerSet(int seconds)
        {
            if(this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { timerSet(seconds); });
            }
            else
            {
                this.secs = seconds;
            }
        }

        private void guess_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            label3.BackColor = Color.Green;
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0)
            {
                MessageBox.Show("Charade's answer cannot be empty!");
                return;
            }
            Bitmap image = (Bitmap)pictureBox1.Image;
            pictureBox1.Image = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            string imageStr = image.ToBase64String(ImageFormat.Bmp);
            byte[] bts = Utils.Zip(imageStr);

            string HEADER = "/#/Charade/" + textBox1.Text + "!#/";
            var header = Encoding.UTF8.GetBytes(HEADER);
            
            byte[] tempo = new byte[bts.Length + header.Length];
            bts.CopyTo(tempo, header.Length);
            header.CopyTo(tempo, 0);

            string base64 = Convert.ToBase64String(tempo);
            //byte[] base64b = Encoding.UTF8.GetBytes(base64);

            

           // byte[] send = base64b; //tempo

            Program.network.send(base64);
            Program.playground.setCanDraw(false);
            Program.turn = false;
        }

        private void commands_btn_Click(object sender, EventArgs e)
        {
            Program.network.send("/commands");
        }

        public void Clear()
        {
            this.Invoke((MethodInvoker)delegate { clear(); });
        }
        
    }

    public static class BitmapExtensions
    {
        public static string ToBase64String(this Bitmap bmp, ImageFormat imageFormat)
        {
            string base64String = string.Empty;


            MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, imageFormat);


            memoryStream.Position = 0;
            byte[] byteBuffer = memoryStream.ToArray();


            memoryStream.Close();


            base64String = Convert.ToBase64String(byteBuffer);
            byteBuffer = null;


            return base64String;
        }
    }
}
