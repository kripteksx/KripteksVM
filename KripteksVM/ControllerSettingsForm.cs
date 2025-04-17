using KripteksVM.Concrete;
using System;
using System.Windows.Forms;

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

            txtBeckhoffAMSNetID.Text = controllerSettings.controllerBeckhoff.AMSNetID;
            txtBeckhoffPortNo.Text = controllerSettings.controllerBeckhoff.portNo;
            txtControllerCycleMs.Text = controllerSettings.cycleTime.ToString();

            txtModbusIPAddress.Text = controllerSettings.controllerModbusTCP.IPAddress;
            txtModbusPortNo.Text = controllerSettings.controllerModbusTCP.portNo.ToString();
        }

        private void btnControllerPropertiesClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnControllerSettingsApply_Click(object sender, EventArgs e)
        {

            ControllerSettings controllerSettings = new ControllerSettings();

            controllerSettings.controllerBeckhoff.AMSNetID = txtBeckhoffAMSNetID.Text;
            controllerSettings.controllerBeckhoff.portNo = txtBeckhoffPortNo.Text;
            controllerSettings.controllerType = cbControllerType.SelectedItem.ToString();
            controllerSettings.cycleTime = int.Parse(txtControllerCycleMs.Text);

            controllerSettings.controllerModbusTCP.IPAddress = txtModbusIPAddress.Text;
            controllerSettings.controllerModbusTCP.portNo = Convert.ToUInt16(txtModbusPortNo.Text);
            clControlFile.SetControllerSettings(controllerSettings);

            CallBackRefreshControllerSettings();// diger form u tetikle
        }

        private void ControllerSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
