using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class Playground : Form
    {
        public guess guess;
        public Wait wait;
        bool isGuess = false;

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

        public void setCharade(Bitmap bmp)
        {
            this.Invoke((MethodInvoker)delegate { _setCharade(bmp); });
        }

        private void _setCharade(Bitmap bmp)
        {
            this.wait.setCharade(bmp);
        }

        public void clear()
        {
            this.Invoke((MethodInvoker)delegate { _clear(); });
        }

        private void _clear()
        {
            try
            {
                if (isGuess)
                {
                    setCanDraw(true);
                }
                else
                {
                    setCanDraw(false);
                   
                }
            }
            catch
            {

            }
        }

        private void _setCanDraw(bool state)
        {
            guess = new guess();
            wait = new Wait();
            panel1.Controls.Clear();
            if (state)
            {
                panel1.Controls.Add(guess);
                isGuess = true;
            }
            else
            {
                panel1.Controls.Add(wait);
                isGuess = false;
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
