// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using CefSharp.DevTools.IO;
using CefSharp.WinForms;
using KripteksVM.Controls;
using CefSharp;
using System.Drawing;
using System;
using System.Net;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Threading;

namespace KripteksVM
{
    public partial class KripteksVMB : Form
    {
        private Controller clController = new Controller();
        private ControlBrowser clControlBrowser = new ControlBrowser();
        private ControlConfig clControlConfig = new ControlConfig();
        
        private static System.Timers.Timer tmrCamRefresh = new System.Timers.Timer();
        private static System.Timers.Timer tmrVarRefresh = new System.Timers.Timer();
        private static System.Timers.Timer tmrInputRefresh = new System.Timers.Timer();

        private int iscMainPanel2Width = 300;
        private int iscMainSplitterDistance = 0;
        private int iFormWidthOld = 0;

        // screen center point
        public int iCenterPointX = 0;
        public int iCenterPointY = 0;

        // guncellenen degiskenler
        private int iVariablesSourceIndex = 0;
        private int iVariablesTypeIndex = 0;

        private int iInitCount = 0;
        private int iCommentsCount = 0;
        private bool boInitAck = false;

        private bool[] bodAWForce = new bool[8];
        private bool[] bodWAForce = new bool[8];
        private double[] dAW = new double[8];
        private double[] dWA = new double[8];

        private bool[] bowAWForce = new bool[8];
        private bool[] bowWAForce = new bool[8];
        private UInt16[] wAW = new UInt16[8];
        private UInt16[] wWA = new UInt16[8];

        private bool[] boboAWForce = new bool[32];
        private bool[] boboWAForce = new bool[32];
        public bool[] boAW = new bool[32];
        public bool[] boWA = new bool[32];
        
        public bool boFullScreen = false;

        public bool boCursorVisible =true;
        public bool boFreeCam = false;
        public bool boPersonCam = false;
        public int iCursorPosXFark = 0;
        public int iCursorPosYFark = 0;
        public int iCursorPosXTop = 0;
        public int iCursorPosYTop = 0;

        public string sForDoubleFloatCharOld = "";
        public string sForDoubleFloatCharNew = "";

        //public Form FullScreenForm;
        SplashForm SplashForm = new SplashForm();
        FullScreenForm FullScreenForm = new FullScreenForm();
        ControllerPropertiesForm PropertiesControllerForm = new ControllerPropertiesForm();
        ApplicationPropertiesForm PropertiesApplicationForm = new ApplicationPropertiesForm();

        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        private bool[] boKeyHelp = new bool[255];
        private bool[] boKey = new bool[255];
        private bool boFormFocused = true;
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public KripteksVMB()
        {
            string sDouble = "10.0";
            if (Convert.ToDouble(sDouble) == 10)
            {
                sForDoubleFloatCharOld = ",";
                sForDoubleFloatCharNew = ".";
            }
            else
            {
                sForDoubleFloatCharOld = ".";
                sForDoubleFloatCharNew = ",";
            }

            // loading 
            SplashForm.Show();
            this.Hide();
            
            InitializeComponent();

            // Config okunuyor
            clControlConfig.fbGetControllerProperties();

            // kayitli degerler Controllere aktarilior
            clController.stControllerProperties = clControlConfig.stControllerProperties;

            // Connect controller
            clController.fbInit();
            
            // formda gosterilen variable list olustruluyor
            fbVariablesInit();
            
            // fullscreen
            WindowState = FormWindowState.Maximized;
            fbscMainResize();

            // refresh
            fbTimerInit();

            // chromium
            clControlBrowser.sHost = "http://www.kripteks.net";
            //clControlBrowser.sHost = "http://localhost:56436";
            clControlBrowser.fbInit(clController.stKVM.stApp.sCID, clController.stKVM.stApp.sSID, clController.stKVM.stApp.sAID);
            scMain.Panel1.Controls.Add(clControlBrowser.browser);

            // diger formdan bu forma click
            fbFullScreenInit();

            // loaded
            this.Show();
            SplashForm.Hide();
        }
        #region Genel
        private Rectangle fbWhichScreen()
        {
            Rectangle recSecreenWorkingArea = new Rectangle();

            // Hangi ekranda calisiyor            
            foreach (Screen screen in System.Windows.Forms.Screen.AllScreens)
            {
                Point PrgLocation = new Point(this.Location.X + 10, this.Location.Y + 10);
                if (screen.Bounds.Contains(PrgLocation))
                {
                    recSecreenWorkingArea = screen.WorkingArea;
                }
            }
            return recSecreenWorkingArea;
        }
        private void fbGetScreenProperties()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                /*
                 
    // For each screen, add the screen properties to a list box.
    listBox1.Items.Add("Device Name: " + screen.DeviceName);
    listBox1.Items.Add("Bounds: " + screen.Bounds.ToString());
    listBox1.Items.Add("Type: " + screen.GetType().ToString());
    listBox1.Items.Add("Working Area: " + screen.WorkingArea.ToString());
    listBox1.Items.Add("Primary Screen: " + screen.Primary.ToString());
    */
            }
        }
        
        private void fbGetShareLink()
        {
            Thread thread = new Thread(() => Clipboard.SetText(clControlBrowser.sHost + "/application.aspx?CID=" + clController.stKVM.stApp.sCID + "&SID=" + clController.stKVM.stApp.sSID + "&AID=" + clController.stKVM.stApp.sAID));
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join(); //Wait for the thread to end
            thread.Abort();
        }
        #endregion

        #region Timers
        private void fbTimerInit()
        {
            // web java script
            tmrCamRefresh.Elapsed += new System.Timers.ElapsedEventHandler(tmrCamRefresh_Tick);
            tmrCamRefresh.Interval = 20;
            tmrCamRefresh.Enabled = true;
            tmrCamRefresh.AutoReset = true;

            // controller refresh
            tmrVarRefresh.Elapsed += new System.Timers.ElapsedEventHandler(tmrVarRefresh_Tick);
            tmrVarRefresh.Interval = 100;
            tmrVarRefresh.Enabled = true;
            tmrVarRefresh.AutoReset = true;
          
            // mouse, keyboard
            tmrInputRefresh.Elapsed += new System.Timers.ElapsedEventHandler(tmrInputRefresh_Tick);
            tmrInputRefresh.Interval = 20;
            tmrInputRefresh.Enabled = true;
            tmrInputRefresh.AutoReset = true;
        }



        private void tmrInputRefresh_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 255; i++)
            {
                int state = GetAsyncKeyState(i);
                if (state != 0 & state != 1)
                {
                    boKey[i] = true;
                }
                else if (state == 0)
                {
                    boKey[i] = false;
                    boKeyHelp[i] = false;
                }
            }

            // Active program ismi
            string sActiveWindowTitle = "";
            if (GetActiveWindowTitle() != null)  sActiveWindowTitle = GetActiveWindowTitle();


            // ekran cozunurlugu
            if (boFullScreen)
            {
                iCenterPointX = FullScreenForm.Width / 2;
                iCenterPointY = (FullScreenForm.Height / 2)+5;
            }
            else
            {
                iCenterPointX = this.Location.X + 16 + scMain.Panel1.Width / 2;
                iCenterPointY = this.Location.Y + 80 + scMain.Panel1.Height / 2;
            }
            if (sActiveWindowTitle == "KripteksVM")
            {
                if (boKey[80] & !boKeyHelp[80])
                {
                    Cursor.Position = new Point(iCenterPointX, iCenterPointY);
                    boKeyHelp[80] = true;
                    fbPersonCam();
                }
                if (boKey[79] & !boKeyHelp[79])
                {
                    Cursor.Position = new Point(iCenterPointX, iCenterPointY);
                    boKeyHelp[79] = true;
                    fbFreeCam();
                }
            }
            if (boKey[27] & !boKeyHelp[27]) // ESC
            {
                boKeyHelp[27] = true;
                fbCancelCam();
            }
            if (boKey[116] & !boKeyHelp[116]) // F5
            {
                boKeyHelp[116] = true;
                clControlBrowser.fbRefresh(clController.stKVM.stApp.sCID, clController.stKVM.stApp.sSID, clController.stKVM.stApp.sAID,"1");
            }
            if (boKey[121] & !boKeyHelp[121]) // F10
            {
                boKeyHelp[121] = true;
                fbGetShareLink();
            }
            if (boKey[122] & !boKeyHelp[122]) // F11
            {
                boKeyHelp[122] = true;
                lblTrigValue.Invoke((MethodInvoker)(() => lblTrigValue.Text = lblTrigValue.Text+" "));
            }
            if (boKey[123] & !boKeyHelp[123]) // F12
            {
                boKeyHelp[123] = true;
                clControlBrowser.browser.ShowDevTools();
            }



        }
        private void tmrCamRefresh_Tick(object sender, EventArgs e)
        {
            if (clControlBrowser.boMainFrameLoaded)
            {
                try
                {
                    // cursor takip
                    string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
                    string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();

                    if (boCursorVisible)
                    {
                        clControlBrowser.browser.ExecuteScriptAsync("boPersonCam=false");
                        clControlBrowser.browser.ExecuteScriptAsync("boFreeCam=false");
                    }
                    else
                    {
                        if(boPersonCam) clControlBrowser.browser.ExecuteScriptAsync("boPersonCam=true");
                        else clControlBrowser.browser.ExecuteScriptAsync("boPersonCam=false");
                        if (boFreeCam) clControlBrowser.browser.ExecuteScriptAsync("boFreeCam=true");
                        else clControlBrowser.browser.ExecuteScriptAsync("boFreeCam=false");
                    }

                    if (!boCursorVisible)
                    {
                        iCursorPosXFark = Cursor.Position.X - (iCenterPointX);
                        iCursorPosYFark = Cursor.Position.Y - (iCenterPointY);
                        Cursor.Position = new Point(iCenterPointX, iCenterPointY);

                        /*if (iCursorPosXFark > 20) iCursorPosXFark = 20;
                        else if (iCursorPosXFark < -20) iCursorPosXFark = -20;
                        if (iCursorPosYFark > 20) iCursorPosYFark = 20;
                        else if (iCursorPosYFark < -20) iCursorPosYFark = -20;*/
                        iCursorPosXTop = iCursorPosXTop + iCursorPosXFark/2;
                        iCursorPosYTop = iCursorPosYTop + iCursorPosYFark/2;


                    }
                    clControlBrowser.browser.ExecuteScriptAsync("boBrowserActive=false");
                    clControlBrowser.browser.ExecuteScriptAsync("PointerLockX=" + iCursorPosXTop.ToString());
                    clControlBrowser.browser.ExecuteScriptAsync("PointerLockY=" + iCursorPosYTop.ToString());
                    // cursor takip
                    
                }
                catch
                {

                }
            }

        }
        
        private void tmrVarRefresh_Tick(object sender, EventArgs e)
        {
            // program acildiktan sonra refresh
            iInitCount++;
            if (iInitCount > 25 & !boInitAck)
            {
                boInitAck = true;
                clControlBrowser.fbRefresh(clController.stKVM.stApp.sCID, clController.stKVM.stApp.sSID, clController.stKVM.stApp.sAID, "1");
            }

            clController.stControllerProperties = clControlConfig.stControllerProperties;

            // controller -> api -> web
            for (int i = 0; i < ControlClass.iDoubleSize; i++)
            {
                if (!bodWAForce[i]) clController.stKVM.stAC.dAC[i] = dWA[i];
                if (!bodAWForce[i]) dAW[i] = clController.stKVM.stCA.dCA[i];
            }
            for (int i = 0; i < ControlClass.iWordSize; i++)
            {
                if (!bowAWForce[i]) wAW[i] = clController.stKVM.stCA.wCA[i];
                if (!bowWAForce[i]) clController.stKVM.stAC.wAC[i] = wWA[i];
            }

            for (int i = 0; i < ControlClass.iBoolSize; i++)
            {
                if (!boboAWForce[i]) boAW[i] = clController.stKVM.stCA.boCA[i];
                if (!boboWAForce[i]) clController.stKVM.stAC.boAC[i] = boWA[i];
            }


            try
            {
                // web refresh
                if (clControlBrowser.boMainFrameLoaded)
                {
                    clControlBrowser.browser.ExecuteScriptAsync("wAppLive=" + clController.stKVM.stStatus.wLiveCounter);
                    clControlBrowser.browser.ExecuteScriptAsync("wRecLive=" + "0");

                    string[] sBoolStatus = { "false", "true" };
                    string sboAWString = "boAW=[" + sBoolStatus[Convert.ToInt16(boAW[0])];
                    for (int i = 1; i < ControlClass.iBoolSize; i++)
                    {
                        sboAWString += "," + sBoolStatus[Convert.ToInt16(boAW[i])];
                    }
                    sboAWString += "]";
                    clControlBrowser.browser.ExecuteScriptAsync(sboAWString);

                    string sboWA = clControlBrowser.GetJSValueByVar(clControlBrowser.browser, "boWA");
                    string[] arrsboWA = sboWA.Split(':');
                    for (int i = 0; i < ControlClass.iBoolSize; i++)
                    {
                        if (arrsboWA[i] != "") boWA[i] = Convert.ToBoolean(arrsboWA[i]);
                    }


                    clControlBrowser.browser.ExecuteScriptAsync("dAW=[" + dAW[0].ToString().Replace(sForDoubleFloatCharOld, sForDoubleFloatCharNew) + "," + dAW[1].ToString().Replace(",", ".") + "," + dAW[2].ToString().Replace(",", ".") + "," + dAW[3].ToString().Replace(",", ".") + "," + dAW[4].ToString().Replace(",", ".") + "," + dAW[5].ToString().Replace(",", ".") + "," + dAW[6].ToString().Replace(",", ".") + "," + dAW[7].ToString().Replace(",", ".") + "]");

                    string sdWA = clControlBrowser.GetJSValueByVar(clControlBrowser.browser, "dWA");
                    string[] arrsdWA = sdWA.Split(':');
                    for (int i = 0; i < ControlClass.iDoubleSize; i++)
                    {
                        if (arrsdWA[i] != "") dWA[i] = Convert.ToDouble(arrsdWA[i].Replace(sForDoubleFloatCharOld, sForDoubleFloatCharNew));
                    }

                    clControlBrowser.browser.ExecuteScriptAsync("wAW=[" + wAW[0].ToString() + "," + wAW[1].ToString() + "," + wAW[2].ToString() + "," + wAW[3].ToString() + "," + wAW[4].ToString() + "," + wAW[5].ToString() + "," + wAW[6].ToString() + "," + wAW[7].ToString() + "]");
                    string swWA = clControlBrowser.GetJSValueByVar(clControlBrowser.browser, "wWA");
                    string[] arrswWA = swWA.Split(':');
                    for (int i = 0; i < ControlClass.iWordSize; i++)
                    {
                        if (arrswWA[i] != "") wWA[i] = Convert.ToUInt16(arrswWA[i]);
                    }
                }
            }
            catch
            {

            }
            iCommentsCount++;
            if (iCommentsCount >= 100)
            {
                iCommentsCount = 0;

                clController.fbControllerBeckhoffGetComments();
                PropertiesApplicationForm.stKVM = clController.stKVM;

                this.lblATAID.BeginInvoke((MethodInvoker)delegate () { this.lblATAID.Text = clController.stKVM.stApp.sAID; ; });
                this.lblATName.BeginInvoke((MethodInvoker)delegate () { this.lblATName.Text = clController.stKVM.stApp.sName; ; });
                this.lblATInfo.BeginInvoke((MethodInvoker)delegate () { this.lblATInfo.Text = clController.stKVM.stApp.sInfo; ; });

                /*lblATAID.Text = clController.stKVM.stApp.sAID;
                lblATName.Text = clController.stKVM.stApp.sName;
                lblATInfo.Text = clController.stKVM.stApp.sInfo;*/
                
            }

            this.lblATElapsedTime.BeginInvoke((MethodInvoker)delegate () { this.lblATElapsedTime.Text = clController.stKVM.stStatus.dElapsedTimeSec.ToString(); ; });
        }

        private void tmrFormRefresh_Tick(object sender, EventArgs e)
        {

            // form update
            btnConnectController.Visible = clController.boConnectControllerVisible;
            btnDisconnectController.Visible = clController.boDisconnectControllerVisible;
            lblControllerStatus_.BackColor = clController.colorControllerStatus;
            lblAID.Text = clController.stKVM.stApp.sAID;
            lblSID.Text = clController.stKVM.stApp.sSID;
            lblCID.Text = clController.stKVM.stApp.sCID;

            if (clController.boDisconnectControllerVisible) tslControllerStatus.Text = "Connected";
            else tslControllerStatus.Text = "Disconnected";
            
            tslElapsedTime.Text = (DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime()).ToString().Substring(0,8);

            if (iVariablesSourceIndex == 1)
            {
                if (iVariablesTypeIndex == 1 & dgvVariables.Rows.Count == 9)
                {
                    for (int i = 0; i < ControlClass.iWordSize; i++)
                    {
                        if (Convert.ToBoolean(dgvVariables.Rows[i].Cells[2].Value) == true)
                        {
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.Red;
                            wAW[i] = Convert.ToUInt16(dgvVariables.Rows[i].Cells[1].EditedFormattedValue);
                            bowAWForce[i] = true;
                        }
                        else
                        {
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.White;
                            dgvVariables.Rows[i].Cells[1].Value = wAW[i].ToString();
                            bowAWForce[i] = false;
                        }
                    }
                }
                else if (iVariablesTypeIndex == 2 & dgvVariables.Rows.Count == 9)
                {
                    for (int i = 0; i < ControlClass.iDoubleSize; i++)
                    {
                        if (Convert.ToBoolean(dgvVariables.Rows[i].Cells[2].Value) == true)
                        {
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.Red;
                            dAW[i] = Convert.ToDouble(dgvVariables.Rows[i].Cells[1].EditedFormattedValue);
                            bodAWForce[i] = true;
                        }
                        else
                        {
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.White;
                            dgvVariables.Rows[i].Cells[1].Value = dAW[i].ToString();
                            bodAWForce[i] = false;
                        }
                    }
                }
                else if (iVariablesTypeIndex == 3 & dgvVariables.Rows.Count == 33)
                {
                    for (int i = 0; i < ControlClass.iBoolSize; i++)
                    {
                        if (Convert.ToBoolean(dgvVariables.Rows[i].Cells[2].Value) == true)
                        {
                            boboAWForce[i] = true;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.Red;
                            if (dgvVariables.Rows[i].Cells[1].EditedFormattedValue.ToString() == "1")
                                boAW[i] = true;
                            else if (dgvVariables.Rows[i].Cells[1].EditedFormattedValue.ToString() == "0")
                                boAW[i] = false;

                        }
                        else
                        {
                            boboAWForce[i] = false;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.White;
                            if(boAW[i])
                                dgvVariables.Rows[i].Cells[1].Value = "1";
                            else
                                dgvVariables.Rows[i].Cells[1].Value = "0";
                        }
                    }
                }
            }
            else if (iVariablesSourceIndex == 2)
            {
                if (iVariablesTypeIndex == 1 & dgvVariables.Rows.Count == 9)
                {
                    for (int i = 0; i < ControlClass.iWordSize; i++)
                    {
                        if (Convert.ToBoolean(dgvVariables.Rows[i].Cells[2].Value) == true)
                        {
                            bowWAForce[i] = true;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.Red;
                            clController.stKVM.stAC.wAC[i] = Convert.ToUInt16(dgvVariables.Rows[i].Cells[1].Value.ToString());
                        }
                        else
                        {
                            bowWAForce[i] = false;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.White;
                            dgvVariables.Rows[i].Cells[1].Value = clController.stKVM.stAC.wAC[i].ToString();
                        }
                    }
                }
                else if (iVariablesTypeIndex == 2 & dgvVariables.Rows.Count == 9)
                {
                    for (int i = 0; i < ControlClass.iDoubleSize; i++)
                    {
                        if (Convert.ToBoolean(dgvVariables.Rows[i].Cells[2].Value) == true)
                        {
                            bodWAForce[i] = true;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.Red;
                            clController.stKVM.stAC.dAC[i] = Convert.ToDouble(dgvVariables.Rows[i].Cells[1].Value.ToString());
                        }
                        else
                        {
                            bodWAForce[i] = false;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.White;
                            dgvVariables.Rows[i].Cells[1].Value = clController.stKVM.stAC.dAC[i].ToString();
                        }
                    }
                }
                else if (iVariablesTypeIndex == 3 & dgvVariables.Rows.Count == 33)
                {
                    for (int i = 0; i < ControlClass.iBoolSize; i++)
                    {
                        if (Convert.ToBoolean(dgvVariables.Rows[i].Cells[2].Value) == true)
                        {
                            boboWAForce[i] = true;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.Red;

                            if(dgvVariables.Rows[i].Cells[1].Value.ToString() =="0"| dgvVariables.Rows[i].Cells[1].Value.ToString() == "1")
                            {
                                if (dgvVariables.Rows[i].Cells[1].Value.ToString() == "1") clController.stKVM.stAC.boAC[i] = true;
                                else if(dgvVariables.Rows[i].Cells[1].Value.ToString() == "0") clController.stKVM.stAC.boAC[i] = false;
                            }
                            else
                            {
                                dgvVariables.Rows[i].Cells[1].Value = "0"; clController.stKVM.stAC.boAC[i] = false;
                            }
                        }
                        else
                        {
                            boboWAForce[i] = false;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.White;
                            if (clController.stKVM.stAC.boAC[i])
                                dgvVariables.Rows[i].Cells[1].Value = "1";
                            else
                                dgvVariables.Rows[i].Cells[1].Value = "0";
                        }
                    }
                }
            }
            
        }
        #endregion
         
        #region Form Resize
        private void KripteksVMB_Load(object sender, EventArgs e)
        {
            fbscMainResize();
        }
        private void KripteksVMB_SizeChanged(object sender, EventArgs e)
        {
            fbscMainResize();
        }
        public void fbscMainResize()
        {
            int iFormWidth = this.Size.Width - 18;
            int iFormHeight = this.Size.Height - 78;
            scMain.Size = new Size(iFormWidth, iFormHeight);
            if (iFormWidth > iscMainPanel2Width) scMain.SplitterDistance = iFormWidth - iscMainPanel2Width;
        }
        private void fbTabComExplorerResize()
        {
            tabComExplorer.Size = new Size(scMain.Panel2.Width - 3, scMain.Panel2.Height - 36);
            //lblTabMainTitle.Size= new Size(scMain.Panel2.Width - 3, 30);
            //lblTabMainTitle.Text = tabComExplorer.SelectedTab.Text;

            dgvVariables.Size= new Size(scMain.Panel2.Width - 48, dgvVariables.Height);
            gbControllerComm.Size = new Size(scMain.Panel2.Width - 33, gbControllerComm.Height);
            gbControllerVariables.Size = new Size(scMain.Panel2.Width - 33, gbControllerVariables.Height);
        }
        private void scMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            fbTabComExplorerResize();
            int iFormWidth = this.Size.Width - 18;
            if(iFormWidthOld == this.Size.Width)
                iscMainPanel2Width = iFormWidth - scMain.SplitterDistance;
            else
                iFormWidthOld = this.Size.Width;

            iscMainSplitterDistance = scMain.SplitterDistance;
        }
        private void tabComExplorer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblTabMainTitle.Text = tabComExplorer.SelectedTab.Text;
        }
        private void KripteksVMB_ResizeEnd(object sender, EventArgs e)
        {
            fbscMainResize();
        }
        #endregion

        #region Variables
        private void fbVariablesInit()
        {
            dgvVariables.Rows.Clear();
            if (cbVariablesSource.SelectedIndex == 1)
            {
                if (cbVariablesType.SelectedIndex == 1)
                {
                    for (int i = 0; i < ControlClass.iWordSize; i++)
                    {
                        dgvVariables.Rows.Add("wAW[" + i + "]", "0", bowAWForce[i], "word", clController.stKVM.stAC.swACComments[i]);
                    }
                }
                if (cbVariablesType.SelectedIndex == 2)
                {
                    for (int i = 0; i < ControlClass.iDoubleSize; i++)
                    {
                        dgvVariables.Rows.Add("dAW[" + i + "]", "0", bodAWForce[i], "double", clController.stKVM.stAC.sdACComments[i]);
                    }
                }
                if (cbVariablesType.SelectedIndex == 3)
                {
                    for (int i = 0; i < ControlClass.iBoolSize; i++)
                    {
                        dgvVariables.Rows.Add("boAW[" + i + "]", "0", boboAWForce[i], "bool", clController.stKVM.stAC.sboACComments[i]);
                    }
                }
            }
            else if (cbVariablesSource.SelectedIndex == 2)
            {
                if (cbVariablesType.SelectedIndex == 1)
                {
                    for (int i = 0; i < ControlClass.iWordSize; i++)
                    {
                        dgvVariables.Rows.Add("wWA[" + i + "]", "0", bowWAForce[i], "word", clController.stKVM.stCA.swCAComments[i]);
                    }
                }
                if (cbVariablesType.SelectedIndex == 2)
                {
                    for (int i = 0; i < ControlClass.iDoubleSize; i++)
                    {
                        dgvVariables.Rows.Add("dWA[" + i + "]", "0", bodWAForce[i], "double", clController.stKVM.stCA.sdCAComments[i]);
                    }
                }
                if (cbVariablesType.SelectedIndex == 3)
                {
                    for (int i = 0; i < ControlClass.iBoolSize; i++)
                    {
                        dgvVariables.Rows.Add("boWA[" + i + "]", "0", boboWAForce[i], "bool", clController.stKVM.stCA.sboCAComments[i]);
                    }
                }
            }
            iVariablesSourceIndex = cbVariablesSource.SelectedIndex;
            iVariablesTypeIndex = cbVariablesType.SelectedIndex;
        }
        private void cbVariablesSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            fbVariablesInit();
        }
        private void cbVariablesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fbVariablesInit();
        }
        private void dgvVariables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvVariables.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        #endregion

        #region FullScreen
        private void fbFullScreenInit()
        {
            FullScreenForm = new FullScreenForm();
        }

        private void fbFormApplicationPropertiesInit()
        {
            PropertiesApplicationForm = new ApplicationPropertiesForm();
        }
        private void fbFormControllerPropertiesInit()
        {
            PropertiesControllerForm = new ControllerPropertiesForm();
        }

        private void GoFullscreen()
        {
            boFullScreen = !boFullScreen;
            if (boFullScreen)
            {
                var myFirstScreen = Screen.FromControl(this);
                var mySecondScreen = Screen.AllScreens.FirstOrDefault(s => !s.Equals(myFirstScreen)) ?? myFirstScreen;

                fbFullScreenInit();

                Rectangle newRec = fbWhichScreen();
                FullScreenForm.Controls.Add(clControlBrowser.browser);
               
                FullScreenForm.Left = myFirstScreen.Bounds.Left;
                FullScreenForm.Top = myFirstScreen.Bounds.Top;
                FullScreenForm.Location = myFirstScreen.Bounds.Location;
                FullScreenForm.StartPosition = FormStartPosition.Manual;

                FullScreenForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                FullScreenForm.Show();
                FullScreenForm.WindowState = FormWindowState.Maximized;
                //this.Hide();
            }
            else
            {

                scMain.Panel1.Controls.Add(clControlBrowser.browser);
                FullScreenForm.Hide();
                FullScreenForm.Dispose();
                this.Show();
                this.Focus();
            }
        }
   
        #endregion

        #region Camera
        private void fbPersonCam()
        {
            boCursorVisible = false;
            boFreeCam = false;
            boPersonCam = true;
        }
        private void fbFreeCam()
        {
            boCursorVisible = false;
            boFreeCam = true;
            boPersonCam = false;
        }
        private void fbCancelCam()
        {
            boCursorVisible = true;
            boFreeCam = false;
            boPersonCam = false;
        }

        private void KripteksVMB_Activated(object sender, EventArgs e)
        {
            boFormFocused = this.Focused;
        }

        private void KripteksVMB_Deactivate(object sender, EventArgs e)
        {
            boFormFocused = this.Focused;
            fbCancelCam();
        }
        #endregion

        #region Tool Strip Menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnmsMenuFocusCam_Click(object sender, EventArgs e)
        {
            fbCancelCam();
        }
        private void btnmsMenuFreeCam_Click(object sender, EventArgs e)
        {
            fbFreeCam();
        }
        private void btnmsMenuFirstPersonCam_Click(object sender, EventArgs e)
        {
            fbPersonCam();
        }
        private void btnmsMenuGoFullScreen_Click(object sender, EventArgs e)
        {
            GoFullscreen();
        }
        private void btnmsMenuDevTools_Click(object sender, EventArgs e)
        {
            clControlBrowser.browser.ShowDevTools();
        }
        private void btnmsMenuRefresh_Click(object sender, EventArgs e)
        {
            clControlBrowser.fbRefresh(clController.stKVM.stApp.sCID, clController.stKVM.stApp.sSID, clController.stKVM.stApp.sAID, "1");
        }
        private void btnmsMenuShareLink_Click(object sender, EventArgs e)
        {
            fbGetShareLink();
        }
        private void btnmsMenuControllerProperties_Click(object sender, EventArgs e)
        {
            fbFormControllerPropertiesInit();
            PropertiesControllerForm.Show();
        }
        private void btnmsMenuApplicationProperties_Click(object sender, EventArgs e)
        {
            PropertiesApplicationForm.Show();
            PropertiesApplicationForm.lblAID.Text = clController.stKVM.stApp.sAID;
            fbFormApplicationPropertiesInit();
        }
        private void btnmsMenuApplication_Click(object sender, EventArgs e)
        {
            clController.fbControllerBeckhoffGetComments();
            PropertiesApplicationForm.stKVM = clController.stKVM;
        }
        #endregion

        #region Form General
        private void KripteksVMB_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrVarRefresh.Enabled = false;
            tmrCamRefresh.Enabled = false;
            tmrFormRefresh.Enabled = false;
            tmrInputRefresh.Enabled = false;
            clControlBrowser.browser.Dispose();
            clController.fbDisconnect();
            Cef.Shutdown();
        }
        private void lblTrigValue_TextChanged(object sender, EventArgs e)
        {
            GoFullscreen();
        }
        #endregion

        #region Controller
        private void btnConnectController_Click(object sender, EventArgs e)
        {
            clController.fbConnect();
        }

        private void btnDisconnectController_Click(object sender, EventArgs e)
        {
            clController.fbDisconnect();
        }

        #endregion
        

    }
}
