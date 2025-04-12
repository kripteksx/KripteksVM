using System;
using System.Windows.Forms;

namespace KripteksVM
{
    public partial class FullScreenForm : Form
    {
        public delegate void ClickButton();
        public event ClickButton ButtonWasClicked;

        public FullScreenForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ButtonWasClicked();
        }
    }
}
