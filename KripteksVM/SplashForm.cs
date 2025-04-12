using System;
using System.Drawing;
using System.Windows.Forms;

namespace KripteksVM
{
    public partial class SplashForm : Form
    {
        KripteksVMB MainForm = new KripteksVMB();
        public SplashForm()
        {
            InitializeComponent();

            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            //this.Bounds= Screen.PrimaryScreen.Bounds;
            //this.Bounds = new Rectangle(500,500,500,500);
            this.Location = new Point((resolution.Width - 450) / 2, (resolution.Height - 200) / 2);

            MainForm.CallBackRefreshInitStatus = new KripteksVMB.RefreshInitStatus(this.CallBackRefreshInitStatus);

            MainForm.Show();
        }

        private void tmrInit_Tick(object sender, EventArgs e)
        {
            if (MainForm.isInitialized)
            {
                tmrInit.Enabled = false;
                this.Hide();
            }
        }
        private void CallBackRefreshInitStatus(string status)
        {
            lblInitStatus.Text = status;
        }
    }
}
