using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class Playground : Form
    {
        public Brush brush;
        private Graphics g;
        private Point p = Point.Empty;
        private Pen pioro;
        public Playground()
        {
            InitializeComponent();
            brush = Brushes.Black;
       
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            pioro = new Pen(Color.Black);
            button1.BackColor = Color.Black;
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

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            g.Clear(Color.White);
            pictureBox1.Refresh();
        }

        private void btnSend_Click(object sender, System.EventArgs e)
        {
            /* to bylo grzeska
            NetworkStream serverStream = Program.clientSocket.GetStream();
            byte[] outStream = Encoding.ASCII.GetBytes("Message from Client$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, (int)Program.clientSocket.ReceiveBufferSize);
            string returndata = Encoding.ASCII.GetString(inStream);
            // chat.Items.Add(returndata);
            //chat.Invalidate();
            */
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
                pioro.Color = colorDialog1.Color;
            }
        }

        private void Playground_Load(object sender, System.EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
        {
            pioro.Width = (int)brushsize_numeric.Value;
        }

        private void button2_Click(object sender, System.EventArgs e)
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
    }
}
