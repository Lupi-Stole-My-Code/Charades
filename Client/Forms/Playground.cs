using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class Playground : Form
    {
  
        public Playground()
        {
            InitializeComponent();

            

        }


        private void Playground_Load(object sender, System.EventArgs e)
        {
            this.TopMost = false;
            object form;
            if (Program.turn)
            {
                form = new guess();
                
            }
            else
            {
                form = new Wait();
            }
            panel1.Controls.Clear();
            panel1.Controls.Add((Control)form);

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
