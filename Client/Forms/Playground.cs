using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class Playground : Form
    {
        public object activeForm;

        public Playground()
        {
            InitializeComponent();
        }

        private void Playground_Load(object sender, System.EventArgs e)
        {
            this.TopMost = false;
            setCanDraw(false);
        }

        public void setCanDraw(bool state)
        {
            if (state)
            {
                activeForm = new guess();
            }
            else
            {
                activeForm = new Wait();
            }
            panel1.Controls.Clear();
            panel1.Controls.Add((Control)activeForm);
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
