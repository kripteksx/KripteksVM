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

        public delegate void fbRefreshControllerProperties();
        public fbRefreshControllerProperties fbRefreshControllerPropertiesCallBack;


        public ControllerPropertiesForm()
        {
            InitializeComponent();

            fbReadControllerProperties();
        }
        
        private void fbReadControllerProperties()
        {

            ST_CONTROLLER_PROPERTIES stControllerProperties = new ST_CONTROLLER_PROPERTIES();
            stControllerProperties = clControlConfig.fbGetControllerProperties();

            for (int i = 0; i < cbControllerType.Items.Count; i++)
            {
                if (cbControllerType.Items[i].ToString() == stControllerProperties.sControllerType)
                    cbControllerType.SelectedIndex = i;
            }

            tbBeckhoffAMSNetID.Text = stControllerProperties.sBeckhoffAMSNetID;
            tbBeckhoffPortNo.Text = stControllerProperties.sBeckhoffPortNo;
        }

        private void btnControllerPropertiesSave_Click(object sender, EventArgs e)
        {
            ST_CONTROLLER_PROPERTIES stControllerProperties = new ST_CONTROLLER_PROPERTIES();

            stControllerProperties.sBeckhoffAMSNetID = tbBeckhoffAMSNetID.Text;
            stControllerProperties.sBeckhoffPortNo = tbBeckhoffPortNo.Text;
            stControllerProperties.sControllerType = cbControllerType.SelectedItem.ToString();
            clControlConfig.fbSetControllerProperties(stControllerProperties);

            fbRefreshControllerPropertiesCallBack();// diger form u tetikle
        }

        private void btnControllerPropertiesClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ControllerPropertiesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fbRefreshControllerPropertiesCallBack();
        }
    }
}
