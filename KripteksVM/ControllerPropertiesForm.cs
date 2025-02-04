using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KripteksVM.Controls;

namespace KripteksVM
{
    public partial class ControllerPropertiesForm : Form
    {

        private ControlConfig clControlConfig = new ControlConfig();

        public ControllerPropertiesForm()
        {
            InitializeComponent();

            fbReadControllerProperties();
        }
        
        private void fbReadControllerProperties()
        {
            clControlConfig.fbGetControllerProperties();

            for (int i = 0; i < cbControllerType.Items.Count; i++)
            {
                if (cbControllerType.Items[i].ToString() == clControlConfig.stControllerProperties.sControllerType)
                    cbControllerType.SelectedIndex = i;
            }

            tbBeckhoffAMSNetID.Text = clControlConfig.stControllerProperties.sBeckhoffAMSNetID;
            tbBeckhoffPortNo.Text = clControlConfig.stControllerProperties.sBeckhoffPortNo;
        }

        private void btnControllerPropertiesSave_Click(object sender, EventArgs e)
        {
            clControlConfig.stControllerProperties.sBeckhoffAMSNetID = tbBeckhoffAMSNetID.Text;
            clControlConfig.stControllerProperties.sBeckhoffPortNo = tbBeckhoffPortNo.Text;
            clControlConfig.stControllerProperties.sControllerType = cbControllerType.SelectedItem.ToString();
            clControlConfig.fbSetControllerProperties();
        }

        private void btnControllerPropertiesCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
