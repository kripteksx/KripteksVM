using KripteksVM.Concrete;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KripteksVM
{
    public partial class ApplicationSettingsForm : Form
    {
        public string AID = "";

        public VirtualMachine VirtualMachine = new VirtualMachine();

        private TextBox[] txtdWA = new TextBox[Constants.DoubleArraySize];
        private TextBox[] txtdAW = new TextBox[Constants.DoubleArraySize];
        private TextBox[] txtwWA = new TextBox[Constants.WordArraySize];
        private TextBox[] txtwAW = new TextBox[Constants.WordArraySize];
        private TextBox[] txtboWA = new TextBox[Constants.BoolArraySize];
        private TextBox[] txtboAW = new TextBox[Constants.BoolArraySize];

        private Label[] lbldWA = new Label[Constants.DoubleArraySize];
        private Label[] lbldAW = new Label[Constants.DoubleArraySize];
        private Label[] lblwWA = new Label[Constants.WordArraySize];
        private Label[] lblwAW = new Label[Constants.WordArraySize];
        private Label[] lblboWA = new Label[Constants.BoolArraySize];
        private Label[] lblboAW = new Label[Constants.BoolArraySize];

        public ApplicationSettingsForm()
        {
            InitializeComponent();

            Init();

            VarToForm();
        }

        private void Init()
        {
            for (int i = 0; i <= 7; i++)
            {
                txtdWA[i] = new TextBox();
                txtdWA[i].Location = new Point(80, 20 + 25 * i);
                txtdWA[i].Width = 150;
                tabApplicationPropertiesWA.Controls.Add(txtdWA[i]);

                lbldWA[i] = new Label();
                lbldWA[i].Location = new Point(20, 22 + 25 * i);
                lbldWA[i].Text = "dWA[" + i.ToString() + "]";
                tabApplicationPropertiesWA.Controls.Add(lbldWA[i]);

                txtwWA[i] = new TextBox();
                txtwWA[i].Location = new Point(80, 230 + 25 * i);
                txtwWA[i].Width = 150;
                tabApplicationPropertiesWA.Controls.Add(txtwWA[i]);

                lblwWA[i] = new Label();
                lblwWA[i].Location = new Point(20, 232 + 25 * i);
                lblwWA[i].Text = "wWA[" + i.ToString() + "]";
                tabApplicationPropertiesWA.Controls.Add(lblwWA[i]);



                txtdAW[i] = new TextBox();
                txtdAW[i].Location = new Point(80, 20 + 25 * i);
                txtdAW[i].Width = 150;
                tabApplicationPropertiesAW.Controls.Add(txtdAW[i]);

                lbldAW[i] = new Label();
                lbldAW[i].Location = new Point(20, 22 + 25 * i);
                lbldAW[i].Text = "dAW[" + i.ToString() + "]";
                tabApplicationPropertiesAW.Controls.Add(lbldAW[i]);

                txtwAW[i] = new TextBox();
                txtwAW[i].Location = new Point(80, 230 + 25 * i);
                txtwAW[i].Width = 150;
                tabApplicationPropertiesAW.Controls.Add(txtwAW[i]);

                lblwAW[i] = new Label();
                lblwAW[i].Location = new Point(20, 232 + 25 * i);
                lblwAW[i].Text = "wAW[" + i.ToString() + "]";
                tabApplicationPropertiesAW.Controls.Add(lblwAW[i]);
            }

            for (int i = 0; i <= 15; i++)
            {
                txtboWA[i] = new TextBox();
                txtboWA[i].Location = new Point(320, 20 + 25 * i);
                txtboWA[i].Width = 150;
                tabApplicationPropertiesWA.Controls.Add(txtboWA[i]);

                lblboWA[i] = new Label();
                lblboWA[i].Location = new Point(250, 22 + 25 * i);
                lblboWA[i].Text = "boWA[" + i.ToString() + "]";
                tabApplicationPropertiesWA.Controls.Add(lblboWA[i]);

                txtboWA[16 + i] = new TextBox();
                txtboWA[16 + i].Location = new Point(560, 20 + 25 * i);
                txtboWA[16 + i].Width = 150;
                tabApplicationPropertiesWA.Controls.Add(txtboWA[16 + i]);

                lblboWA[16 + i] = new Label();
                lblboWA[16 + i].Location = new Point(490, 22 + 25 * i);
                lblboWA[16 + i].Text = "boWA[" + (i + 16).ToString() + "]";
                tabApplicationPropertiesWA.Controls.Add(lblboWA[16 + i]);



                txtboAW[i] = new TextBox();
                txtboAW[i].Location = new Point(320, 20 + 25 * i);
                txtboAW[i].Width = 150;
                tabApplicationPropertiesAW.Controls.Add(txtboAW[i]);

                lblboAW[i] = new Label();
                lblboAW[i].Location = new Point(250, 22 + 25 * i);
                lblboAW[i].Text = "boAW[" + i.ToString() + "]";
                tabApplicationPropertiesAW.Controls.Add(lblboAW[i]);

                txtboAW[16 + i] = new TextBox();
                txtboAW[16 + i].Location = new Point(560, 20 + 25 * i);
                txtboAW[16 + i].Width = 150;
                tabApplicationPropertiesAW.Controls.Add(txtboAW[16 + i]);

                lblboAW[16 + i] = new Label();
                lblboAW[16 + i].Location = new Point(490, 22 + 25 * i);
                lblboAW[16 + i].Text = "boAW[" + (i + 16).ToString() + "]";
                tabApplicationPropertiesAW.Controls.Add(lblboAW[16 + i]);
            }
        }



        private bool fbCheckAID(string sAIDHelp)
        {
            bool boAIDOk = false;

            if (sAIDHelp != null)
            {
                if (sAIDHelp != "")
                {
                    boAIDOk = true;
                    lblAID.BackColor = Color.White;
                }
                else
                {
                    lblAID.BackColor = Color.Red;
                }
            }
            else
            {
                lblAID.BackColor = Color.Red;
            }

            return boAIDOk;
        }

        private void VarToForm()
        {
            for (int i = 0; i < Constants.DoubleArraySize; i++)
            {
                txtdWA[i].Text = VirtualMachine.controllerToApplicationVariables.doubleArrayComments[i];
                txtdAW[i].Text = VirtualMachine.applicationToControllerVariables.doubleArrayComments[i];
            }
            for (int i = 0; i < Constants.WordArraySize; i++)
            {
                txtwWA[i].Text = VirtualMachine.controllerToApplicationVariables.wordArrayComments[i];
                txtwAW[i].Text = VirtualMachine.applicationToControllerVariables.wordArrayComments[i];
            }
            for (int i = 0; i < Constants.BoolArraySize; i++)
            {
                txtboWA[i].Text = VirtualMachine.controllerToApplicationVariables.boolArrayComments[i];
                txtboAW[i].Text = VirtualMachine.applicationToControllerVariables.boolArrayComments[i];
            }

            lblAID.Text = VirtualMachine.virtualApplication.AID;
            lblName.Text = VirtualMachine.virtualApplication.name;
            lblInfo.Text = VirtualMachine.virtualApplication.info;
        }
        private void FormToVar()
        {
            for (int i = 0; i < Constants.DoubleArraySize; i++)
            {
                VirtualMachine.controllerToApplicationVariables.doubleArrayComments[i] = txtdWA[i].Text;
                VirtualMachine.applicationToControllerVariables.doubleArrayComments[i] = txtdAW[i].Text;
            }
            for (int i = 0; i < Constants.WordArraySize; i++)
            {
                VirtualMachine.controllerToApplicationVariables.wordArrayComments[i] = txtwWA[i].Text;
                VirtualMachine.applicationToControllerVariables.wordArrayComments[i] = txtwAW[i].Text;
            }
            for (int i = 0; i < Constants.BoolArraySize; i++)
            {
                VirtualMachine.controllerToApplicationVariables.boolArrayComments[i] = txtboWA[i].Text;
                VirtualMachine.applicationToControllerVariables.boolArrayComments[i] = txtboAW[i].Text;
            }

        }

        private void ApplicationPropertiesForm_Load(object sender, EventArgs e)
        {

            VarToForm();
        }
    }
}
