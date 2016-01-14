using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charades
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private Point p = Point.Empty;
        private Pen pioro;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(400, 400);
            g = Graphics.FromImage(pictureBox1.Image);
            pioro = new Pen(Color.Black);

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

        private void clear_btn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            g.Clear(Color.White);
            pictureBox1.Refresh();
        }

        private void buttonChatSend_Click(object sender, EventArgs e)
        {
            NetworkStream serverStream = Program.clientSocket.GetStream();
            byte[] outStream = Encoding.ASCII.GetBytes("Message from Client$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, (int)Program.clientSocket.ReceiveBufferSize);
            string returndata = Encoding.ASCII.GetString(inStream);
           // chat.Items.Add(returndata);
            //chat.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // Program.clientSocket.Connect("127.0.0.1", Program.port);
        }
    }     
}
