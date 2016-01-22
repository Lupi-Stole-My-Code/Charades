using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class Playground : Form
    {
        private guess guess;
        private Wait wait;

        public Playground()
        {
            InitializeComponent();
            guess = new guess();
            wait = new Wait();
        }

        private void Playground_Load(object sender, System.EventArgs e)
        {
            setCanDraw(false);
        }

        public void setCanDraw(bool state)
        {
            this.Invoke((MethodInvoker)delegate { _setCanDraw(state); });
        }

        private void _setCanDraw(bool state)
        {
            panel1.Controls.Clear();
            if (state)
            {
                panel1.Controls.Add(guess);
            }
            else
            {
                panel1.Controls.Add(wait);
            }
        }

        private void Playground_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.playgroundRun = false;
            if (Program.chatRun) Program.chat_main.Close();
            if (!Program.mainRun)
            {
                Program.mainRun = true;
                Program.startform.Show();
            }
        }
    }
}
