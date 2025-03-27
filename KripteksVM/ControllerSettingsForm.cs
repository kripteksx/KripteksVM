using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KripteksVM.Concrete;

namespace KripteksVM
{
    public partial class ControllerSettingsForm : Form
    {

        private ControllerSettingsFile clControlFile = new ControllerSettingsFile();

        public delegate void RefreshControllerSettings();
        public RefreshControllerSettings CallBackRefreshControllerSettings;


        public ControllerSettingsForm()
        {
            InitializeComponent();

            GetControllerSettings();
        }
        
        private void GetControllerSettings()
        {
            ControllerSettings controllerSettings = new ControllerSettings();
            controllerSettings = clControlFile.GetControllerSettings();

            for (int i = 0; i < cbControllerType.Items.Count; i++)
            {
                if (cbControllerType.Items[i].ToString() == controllerSettings.controllerType)
                    cbControllerType.SelectedIndex = i;
            }

            tbBeckhoffAMSNetID.Text = controllerSettings.controllerBeckhoff.AMSNetID;
            tbBeckhoffPortNo.Text = controllerSettings.controllerBeckhoff.portNo;
            tbControllerCycleMs.Text = controllerSettings.cycleTime.ToString(); 
        }
        
        private void btnControllerPropertiesClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private void btnControllerSettingsApply_Click(object sender, EventArgs e)
        {

            ControllerSettings controllerSettings = new ControllerSettings();

            controllerSettings.controllerBeckhoff.AMSNetID = tbBeckhoffAMSNetID.Text;
            controllerSettings.controllerBeckhoff.portNo = tbBeckhoffPortNo.Text;
            controllerSettings.controllerType = cbControllerType.SelectedItem.ToString();
            controllerSettings.cycleTime = int.Parse(tbControllerCycleMs.Text);
            clControlFile.SetControllerSettings(controllerSettings);

            CallBackRefreshControllerSettings();// diger form u tetikle
        }

        private void ControllerSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
