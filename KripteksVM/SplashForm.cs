using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace KripteksVM
{
    public partial class SplashForm : Form
    {

        public SplashForm()
        {
            InitializeComponent();
            
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            //this.Bounds= Screen.PrimaryScreen.Bounds;
            //this.Bounds = new Rectangle(500,500,500,500);
            this.Location = new Point((resolution.Width -450) / 2, (resolution.Height - 200) / 2);
            //lblFormYukleniyor.Visible = true;



        }

        private void lblKripteksVM_Click(object sender, EventArgs e)
        {

        }
    }
}
