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
    public partial class ApplicationPropertiesForm : Form
    {
        public string sAID = "";

        public ControlClass.ST_KVM stKVM = new ControlClass.ST_KVM();

        private TextBox[] tbdWA = new TextBox[ControlClass.iDoubleSize];
        private TextBox[] tbdAW = new TextBox[ControlClass.iDoubleSize];
        private TextBox[] tbwWA = new TextBox[ControlClass.iWordSize];
        private TextBox[] tbwAW = new TextBox[ControlClass.iWordSize];
        private TextBox[] tbboWA = new TextBox[ControlClass.iBoolSize];
        private TextBox[] tbboAW = new TextBox[ControlClass.iBoolSize];

        private Label[] lbldWA = new Label[ControlClass.iDoubleSize];
        private Label[] lbldAW = new Label[ControlClass.iDoubleSize];
        private Label[] lblwWA = new Label[ControlClass.iWordSize];
        private Label[] lblwAW = new Label[ControlClass.iWordSize];
        private Label[] lblboWA = new Label[ControlClass.iBoolSize];
        private Label[] lblboAW = new Label[ControlClass.iBoolSize];
        
        public ApplicationPropertiesForm()
        {
            InitializeComponent();

            fbtbInit();

            
        }
        
        private void fbtbInit()
        {
            for (int i = 0; i <= 7; i++)
            {
                tbdWA[i] = new TextBox();
                tbdWA[i].Location = new Point(80, 20 + 25 * i);
                tbdWA[i].Width = 150;
                tabApplicationPropertiesWA.Controls.Add(tbdWA[i]);

                lbldWA[i] = new Label();
                lbldWA[i].Location = new Point(20, 22 + 25 * i);
                lbldWA[i].Text = "dWA[" + i.ToString() + "]";
                tabApplicationPropertiesWA.Controls.Add(lbldWA[i]);

                tbwWA[i] = new TextBox();
                tbwWA[i].Location = new Point(80, 230 + 25 * i);
                tbwWA[i].Width = 150;
                tabApplicationPropertiesWA.Controls.Add(tbwWA[i]);

                lblwWA[i] = new Label();
                lblwWA[i].Location = new Point(20, 232 + 25 * i);
                lblwWA[i].Text = "wWA[" + i.ToString() + "]";
                tabApplicationPropertiesWA.Controls.Add(lblwWA[i]);



                tbdAW[i] = new TextBox();
                tbdAW[i].Location = new Point(80, 20 + 25 * i);
                tbdAW[i].Width = 150;
                tabApplicationPropertiesAW.Controls.Add(tbdAW[i]);

                lbldAW[i] = new Label();
                lbldAW[i].Location = new Point(20, 22 + 25 * i);
                lbldAW[i].Text = "dAW[" + i.ToString() + "]";
                tabApplicationPropertiesAW.Controls.Add(lbldAW[i]);

                tbwAW[i] = new TextBox();
                tbwAW[i].Location = new Point(80, 230 + 25 * i);
                tbwAW[i].Width = 150;
                tabApplicationPropertiesAW.Controls.Add(tbwAW[i]);

                lblwAW[i] = new Label();
                lblwAW[i].Location = new Point(20, 232 + 25 * i);
                lblwAW[i].Text = "wAW[" + i.ToString() + "]";
                tabApplicationPropertiesAW.Controls.Add(lblwAW[i]);
            }

            for (int i = 0; i <= 15; i++)
            {
                tbboWA[i] = new TextBox();
                tbboWA[i].Location = new Point(320, 20 + 25 * i);
                tbboWA[i].Width = 150;
                tabApplicationPropertiesWA.Controls.Add(tbboWA[i]);

                lblboWA[i] = new Label();
                lblboWA[i].Location = new Point(250, 22 + 25 * i);
                lblboWA[i].Text = "boWA[" + i.ToString() + "]";
                tabApplicationPropertiesWA.Controls.Add(lblboWA[i]);

                tbboWA[16 + i] = new TextBox();
                tbboWA[16 + i].Location = new Point(560, 20 + 25 * i);
                tbboWA[16 + i].Width = 150;
                tabApplicationPropertiesWA.Controls.Add(tbboWA[16 + i]);

                lblboWA[16 + i] = new Label();
                lblboWA[16 + i].Location = new Point(490, 22 + 25 * i);
                lblboWA[16 + i].Text = "boWA[" + (i + 16).ToString() + "]";
                tabApplicationPropertiesWA.Controls.Add(lblboWA[16 + i]);



                tbboAW[i] = new TextBox();
                tbboAW[i].Location = new Point(320, 20 + 25 * i);
                tbboAW[i].Width = 150;
                tabApplicationPropertiesAW.Controls.Add(tbboAW[i]);

                lblboAW[i] = new Label();
                lblboAW[i].Location = new Point(250, 22 + 25 * i);
                lblboAW[i].Text = "boAW[" + i.ToString() + "]";
                tabApplicationPropertiesAW.Controls.Add(lblboAW[i]);

                tbboAW[16 + i] = new TextBox();
                tbboAW[16 + i].Location = new Point(560, 20 + 25 * i);
                tbboAW[16 + i].Width = 150;
                tabApplicationPropertiesAW.Controls.Add(tbboAW[16 + i]);

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

        private void fbVarToForm()
        {
            for (int i = 0; i < ControlClass.iDoubleSize; i++)
            {
                tbdWA[i].Text = stKVM.stCA.sdCAComments[i];
                tbdAW[i].Text = stKVM.stAC.sdACComments[i];
            }
            for (int i = 0; i < ControlClass.iWordSize; i++)
            {
                tbwWA[i].Text = stKVM.stCA.swCAComments[i];
                tbwAW[i].Text = stKVM.stAC.swACComments[i];
            }
            for (int i = 0; i < ControlClass.iBoolSize; i++)
            {
                tbboWA[i].Text = stKVM.stCA.sboCAComments[i];
                tbboAW[i].Text = stKVM.stAC.sboACComments[i];
            }
        }
        private void fbFormToVar()
        {
            for (int i = 0; i < ControlClass.iDoubleSize; i++)
            {
                stKVM.stCA.sdCAComments[i] = tbdWA[i].Text;
                stKVM.stAC.sdACComments[i] = tbdAW[i].Text;
            }
            for (int i = 0; i < ControlClass.iWordSize; i++)
            {
                stKVM.stCA.swCAComments[i] = tbwWA[i].Text;
                stKVM.stAC.swACComments[i] = tbwAW[i].Text;
            }
            for (int i = 0; i < ControlClass.iBoolSize; i++)
            {
                stKVM.stCA.sboCAComments[i] = tbboWA[i].Text;
                stKVM.stAC.sboACComments[i] = tbboAW[i].Text;
            }

        }

        private void ApplicationPropertiesForm_Load(object sender, EventArgs e)
        {
            
            fbVarToForm();
        }
    }
}
