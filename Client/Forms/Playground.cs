using System.Drawing;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class Playground : Form
    {
        public Brush brush;
        public Playground()
        {
            InitializeComponent();
            brush = Brushes.Black;
        }
    }
}
