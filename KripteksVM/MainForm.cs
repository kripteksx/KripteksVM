using System;
using System.Net;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CefSharp;
using CefSharp.DevTools.IO;
using CefSharp.WinForms;
using KripteksVM.Concrete;

namespace KripteksVM
{
    public partial class KripteksVMB : Form
    {
        private General _general = General.GetInstance();
        private VirtualMachine _virtualMachine = new VirtualMachine();
        private ControllerSettings _controllerSettings = new ControllerSettings();
        private ControllerBeckhoff _controllerBeckhoff = new ControllerBeckhoff();
        private DataGridViewVariables _dataGridViewVariables = new DataGridViewVariables();
        private IController _controller;
        private ControllerSettingsFile _controllerSettingsFile = new ControllerSettingsFile();
        private ChromiumBrowser _chromiumBrowser = new ChromiumBrowser();
        private Performance _performance = new Performance();

        private static System.Timers.Timer s_timerCamera = new System.Timers.Timer();
        private static System.Windows.Forms.Timer s_timerKeyboard = new System.Windows.Forms.Timer();
        private static System.Timers.Timer s_timerVariables = new System.Timers.Timer();
        private static System.Timers.Timer s_timerSlow = new System.Timers.Timer();
        
        private int _cursorPosXTop = 0;
        private int _cursorPosYTop = 0;

        // enum
        private DataGridViewVariableDirection _dataGridViewVariableDirection;
        private DataGridViewVariableType _dataGridViewVariableType;
        private CameraNo _cameraNo;
        
        // formlar 
        SplashForm splashForm = new SplashForm();
        FullScreenForm fullScreenForm = new FullScreenForm();
        ControllerSettingsForm controllerSettingsForm = new ControllerSettingsForm();
        ApplicationSettingsForm applicationSettingsForm = new ApplicationSettingsForm();

        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        static extern int GetAsyncKeyState(Int32 i);
        private bool[] _keyHelp = new bool[255];
        private bool[] _key = new bool[255];
        
        public KripteksVMB()
        {
            // loading 
            splashForm.Show();
            this.Hide();

            InitializeComponent();

            // loaded
            this.Show();
            splashForm.Hide();

        }

        private void KripteksVMB_Load(object sender, EventArgs e)
        {
            // ortak logger
            _general.txtLog = tbLog;

            // diger controller secimi
            _controller = _controllerBeckhoff;

            // Config okunuyor
            _controllerSettings = _controllerSettingsFile.GetControllerSettings();

            // Connect controller
            _virtualMachine = _controller.Init(_virtualMachine);
            _controller.Connect(_controllerSettings);
            _virtualMachine = _controller.RefreshVariables(_virtualMachine);
            _virtualMachine = _controller.GetComments(_virtualMachine);

            // fullscreen
            WindowState = FormWindowState.Maximized;

            // refresh
            TimerInit();

            // chromium
            _general.LogText("Host is " + Constants.Host);
            _chromiumBrowser.Init(Constants.Host, _virtualMachine.virtualApplication.CID, _virtualMachine.virtualApplication.SID, _virtualMachine.virtualApplication.AID, "1");
            scMain.Panel1.Controls.Add(_chromiumBrowser.browser);

        }
        
        #region Timers
        private void TimerInit()
        {
            // web java script
            s_timerCamera.Elapsed += new System.Timers.ElapsedEventHandler(tmrCamRefresh_Tick);
            s_timerCamera.Interval = 5;
            s_timerCamera.Enabled = true;
            s_timerCamera.AutoReset = true;

            s_timerKeyboard.Tick += new System.EventHandler(tmrKeyRefresh_Tick);
            s_timerKeyboard.Interval = 100;
            s_timerKeyboard.Enabled = true;

            // controller refresh
            s_timerVariables.Elapsed += new System.Timers.ElapsedEventHandler(tmrVarRefresh_Tick);
            s_timerVariables.Interval = 20;
            s_timerVariables.Enabled = true;
            s_timerVariables.AutoReset = true;

            // slow refresh
            s_timerSlow.Elapsed += new System.Timers.ElapsedEventHandler(tmrSlowRefresh_Tick);
            s_timerSlow.Interval = 1000;
            s_timerSlow.Enabled = true;
            s_timerSlow.AutoReset = true;

            _general.LogText("Timers started.");
        }
        private void tmrSlowRefresh_Tick(object sender, EventArgs e)
        {
            //_gpuUsage = GPUUsage.GetGPUUsage(GPUUsage.GetGPUCounters());
        }
        private void tmrKeyRefresh_Tick(object sender, EventArgs e)
        {
            // klavye ve mouse 
            for (int i = 0; i < 255; i++)
            {
                int state = GetAsyncKeyState(i);
                if (state != 0 & state != 1)
                {
                    _key[i] = true;
                }
                else if (state == 0)
                {
                    _key[i] = false;
                    _keyHelp[i] = false;
                }
            }

            // Active program ismi
            string activeWindowTitle = "";
            if (_general.GetActiveWindowTitle() != null) activeWindowTitle = _general.GetActiveWindowTitle();

            if (activeWindowTitle == "KripteksVM")
            {
                if (_key[80] & !_keyHelp[80])
                {
                    _keyHelp[80] = true;
                    _cameraNo = CameraNo.Person;
                }
                if (_key[79] & !_keyHelp[79])
                {
                    _keyHelp[79] = true;
                    _cameraNo = CameraNo.Free;
                }
                if (_key[27] & !_keyHelp[27]) // ESC
                {
                    _keyHelp[27] = true;
                    _cameraNo = CameraNo.None;
                }
                if (_key[116] & !_keyHelp[116]) // F5
                {
                    _keyHelp[116] = true;
                    _chromiumBrowser.Refresh(Constants.Host, _virtualMachine.virtualApplication.CID, _virtualMachine.virtualApplication.SID, _virtualMachine.virtualApplication.AID, "1");
                }
                if (_key[121] & !_keyHelp[121]) // F10
                {
                    _keyHelp[121] = true;
                    _general.GetShareLink(_virtualMachine.virtualApplication.CID, _virtualMachine.virtualApplication.SID, _virtualMachine.virtualApplication.AID);
                }
                if (_key[122] & !_keyHelp[122]) // F11
                {
                    _keyHelp[122] = true;
                    GoFullscreen();
                }
                if (_key[123] & !_keyHelp[123]) // F12
                {
                    _keyHelp[123] = true;
                    _chromiumBrowser.browser.ShowDevTools();
                }
            }
            if (_chromiumBrowser.isMainFrameLoaded )
            {
                try
                {
                    if (_cameraNo == CameraNo.None)
                    {
                        _chromiumBrowser.browser.ExecuteScriptAsync("boPersonCam=false");
                        _chromiumBrowser.browser.ExecuteScriptAsync("boFreeCam=false");
                    }
                    else if (_cameraNo == CameraNo.Person)
                    {
                        _chromiumBrowser.browser.ExecuteScriptAsync("boPersonCam=true");
                        _chromiumBrowser.browser.ExecuteScriptAsync("boFreeCam=false");
                    }
                    else if (_cameraNo == CameraNo.Free)
                    {
                        _chromiumBrowser.browser.ExecuteScriptAsync("boFreeCam=true");
                        _chromiumBrowser.browser.ExecuteScriptAsync("boPersonCam=false");
                    }
                    _chromiumBrowser.browser.ExecuteScriptAsync("boBrowserActive=false");
                }
                catch
                {

                }
            }
        }
        private void tmrCamRefresh_Tick(object sender, EventArgs e)
        {
            if (_chromiumBrowser.isMainFrameLoaded)
            {
                try
                {
                    int centerPointX = 0;
                    int centerPointY = 0;
                    if (fullScreenForm.Visible)
                    {
                        centerPointX = fullScreenForm.Width / 2;
                        centerPointY = (fullScreenForm.Height / 2) + 5;
                    }
                    else
                    {
                        centerPointX = this.Location.X + 16 + scMain.Panel1.Width / 2;
                        centerPointY = this.Location.Y + 80 + scMain.Panel1.Height / 2;
                    }
                    if (_cameraNo != CameraNo.None)
                    {
                        int cursorPosXFark = Cursor.Position.X - (centerPointX);
                        int cursorPosYFark = Cursor.Position.Y - (centerPointY);
                        Cursor.Position = new Point(centerPointX, centerPointY);

                        _cursorPosXTop = _cursorPosXTop + cursorPosXFark / 2;
                        _cursorPosYTop = _cursorPosYTop + cursorPosYFark / 2;
                        _chromiumBrowser.browser.ExecuteScriptAsync("PointerLockX=" + _cursorPosXTop.ToString());
                        _chromiumBrowser.browser.ExecuteScriptAsync("PointerLockY=" + _cursorPosYTop.ToString());
                    }
                }
                catch
                {

                }
            }
        }
        private void tmrVarRefresh_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();

            // Alive timer count
            _performance.varRefreshAliveCount++;

            // islem suresi
            var stopWatch = new Stopwatch();
            stopWatch.Start();


            // timer cycle time
            if (_performance.stopWatchCycleTimer.IsRunning)
            {
                _performance.varRefreshTickMs = (_performance.stopWatchCycleTimer.Elapsed - _performance.stopWatchCycleElapsed).Milliseconds;
                _performance.stopWatchCycleElapsed = _performance.stopWatchCycleTimer.Elapsed;
            }
            else
            {
                _performance.stopWatchCycleTimer.Start();
            }


            // cycle time guncelle / buradan alinmali
            s_timerVariables.Interval = _controllerSettings.cycleTime;

            // refresh controller variable
            _virtualMachine = _controller.RefreshVariables(_virtualMachine);


            try
            {
                // web -> api | api -> web
                if (_chromiumBrowser.isMainFrameLoaded)
                {
                    _chromiumBrowser.browser.ExecuteScriptAsync("wAppLive=" + _virtualMachine.controllerStatus.liveCounter);
                    _chromiumBrowser.browser.ExecuteScriptAsync("wRecLive=" + "0");

                    string[] sBoolStatus = { "false", "true" };
                    string sboAWString = "boAW=[" + sBoolStatus[Convert.ToInt16(_virtualMachine.controllerToApplicationVariables.boolArrayBuff[0])];
                    for (int i = 1; i < Constants.BoolArraySize; i++)
                    {
                        sboAWString += "," + sBoolStatus[Convert.ToInt16(_virtualMachine.controllerToApplicationVariables.boolArrayBuff[i])];
                    }
                    sboAWString += "]";
                    _chromiumBrowser.browser.ExecuteScriptAsync(sboAWString);


                    string sboWA = _chromiumBrowser.GetJSValueByVar(_chromiumBrowser.browser, "boWA");
                    string[] arrsboWA = sboWA.Split(':');
                    for (int i = 0; i < Constants.BoolArraySize; i++)
                    {
                        if (arrsboWA[i] != "") _virtualMachine.applicationToControllerVariables.boolArrayBuff[i] = Convert.ToBoolean(arrsboWA[i]);
                    }


                    _chromiumBrowser.browser.ExecuteScriptAsync("dAW=[" + _virtualMachine.controllerToApplicationVariables.doubleArrayBuff[0].ToString().Replace(",", ".") + "," + _virtualMachine.controllerToApplicationVariables.doubleArrayBuff[1].ToString().Replace(",", ".") + "," + _virtualMachine.controllerToApplicationVariables.doubleArrayBuff[2].ToString().Replace(",", ".") + "," + _virtualMachine.controllerToApplicationVariables.doubleArrayBuff[3].ToString().Replace(",", ".") + "," + _virtualMachine.controllerToApplicationVariables.doubleArrayBuff[4].ToString().Replace(",", ".") + "," + _virtualMachine.controllerToApplicationVariables.doubleArrayBuff[5].ToString().Replace(",", ".") + "," + _virtualMachine.controllerToApplicationVariables.doubleArrayBuff[6].ToString().Replace(",", ".") + "," + _virtualMachine.controllerToApplicationVariables.doubleArrayBuff[7].ToString().Replace(",", ".") + "]");

                    string sdWA = _chromiumBrowser.GetJSValueByVar(_chromiumBrowser.browser, "dWA");
                    string[] arrsdWA = sdWA.Split(':');
                    for (int i = 0; i < Constants.DoubleArraySize; i++)
                    {
                        if (arrsdWA[i] != "") _virtualMachine.applicationToControllerVariables.doubleArrayBuff[i] = Convert.ToDouble(arrsdWA[i].Replace(".", _general.FloatingPointChar()));
                    }

                    _chromiumBrowser.browser.ExecuteScriptAsync("wAW=[" + _virtualMachine.controllerToApplicationVariables.wordArrayBuff[0].ToString() + "," + _virtualMachine.controllerToApplicationVariables.wordArrayBuff[1].ToString() + "," + _virtualMachine.controllerToApplicationVariables.wordArrayBuff[2].ToString() + "," + _virtualMachine.controllerToApplicationVariables.wordArrayBuff[3].ToString() + "," + _virtualMachine.controllerToApplicationVariables.wordArrayBuff[4].ToString() + "," + _virtualMachine.controllerToApplicationVariables.wordArrayBuff[5].ToString() + "," + _virtualMachine.controllerToApplicationVariables.wordArrayBuff[6].ToString() + "," + _virtualMachine.controllerToApplicationVariables.wordArrayBuff[7].ToString() + "]");
                    string swWA = _chromiumBrowser.GetJSValueByVar(_chromiumBrowser.browser, "wWA");
                    string[] arrswWA = swWA.Split(':');
                    for (int i = 0; i < Constants.WordArraySize; i++)
                    {
                        if (arrswWA[i] != "") _virtualMachine.applicationToControllerVariables.wordArrayBuff[i] = Convert.ToUInt16(arrswWA[i]);
                    }
                }

                // controller <-> application
                _dataGridViewVariables.DataGridViewForced(_virtualMachine);
            }
            catch
            {
                // Alive timer count
                //iPerformanceVarRefreshAliveCount--;
            }

            // islem suresi
            _performance.controllerElapsedTimeMs = stopWatch.Elapsed.Milliseconds;
            stopWatch.Stop();

            // Alive timer count
            _performance.varRefreshAliveCount--;
        }
        private void tmrFormRefresh_Tick(object sender, EventArgs e)
        {
            lblATAID.Text = _virtualMachine.virtualApplication.AID;
            lblATName.Text = _virtualMachine.virtualApplication.name;
            lblATInfo.Text = _virtualMachine.virtualApplication.info;

            lblATElapsedTime.Text = _virtualMachine.controllerStatus.elapsedTime.ToString();
            
            lblBeckhoffAMSNetID.Text = _controllerSettings.controllerBeckhoff.AMSNetID;
            lblBeckhoffPortNo.Text = _controllerSettings.controllerBeckhoff.portNo;
            lblPerformanceControllerCycleTickMs.Text = _controllerSettings.cycleTime.ToString();
            lblPerformanceControllerElapsedTimeMs.Text = _performance.controllerElapsedTimeMs.ToString();
            lblPerformanceVarRefreshTickMs.Text = _performance.varRefreshTickMs.ToString();
            lblPerformanceGPUUsage.Text = _performance.gpuUsage.ToString("0.00");
            lblPerformanceVarRefreshAliveCount.Text = _performance.varRefreshAliveCount.ToString();

            // form update
            if (_virtualMachine.controllerStatus.isConnnected)
            {
                btnConnectController.Visible = false;
                btnDisconnectController.Visible = true;
                tslControllerStatus.Text = "Connected";
            }
            else
            {
                btnConnectController.Visible = true;
                btnDisconnectController.Visible = false;
                tslControllerStatus.Text = "Disconnected";
            }

            if (_virtualMachine.controllerStatus.isLive)
                lblControllerStatus_.BackColor = Color.Green;
            else
                lblControllerStatus_.BackColor = Color.Red;
            
            lblControllerStatus_.Text = _virtualMachine.controllerStatus.liveCounter.ToString();
            lblAID.Text = _virtualMachine.virtualApplication.AID;
            lblSID.Text = _virtualMachine.virtualApplication.SID;
            lblCID.Text = _virtualMachine.virtualApplication.CID;

            tslElapsedTime.Text = (DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime()).ToString().Substring(0,8);

            if (_dataGridViewVariableDirection == DataGridViewVariableDirection.ControllerToApplication)
            {
                if (_dataGridViewVariableType == DataGridViewVariableType.Word)
                {
                    _dataGridViewVariables.DataGripViewRefresh(dgvVariables, _virtualMachine.controllerToApplicationVariables.wordArrayBuff, _virtualMachine.controllerToApplicationVariables.isWordArrayForced);
                }
                else if (_dataGridViewVariableType == DataGridViewVariableType.Double)
                {
                    _dataGridViewVariables.DataGripViewRefresh(dgvVariables, _virtualMachine.controllerToApplicationVariables.doubleArrayBuff, _virtualMachine.controllerToApplicationVariables.isDoubleArrayForced);
                }
                else if (_dataGridViewVariableType == DataGridViewVariableType.Bool)
                {
                    _dataGridViewVariables.DataGripViewRefresh(dgvVariables, _virtualMachine.controllerToApplicationVariables.boolArrayBuff, _virtualMachine.controllerToApplicationVariables.isBoolArrayForced);
                }
            }
            else if (_dataGridViewVariableDirection == DataGridViewVariableDirection.ApplicationToController)
            {
                if (_dataGridViewVariableType == DataGridViewVariableType.Word)
                {
                    _dataGridViewVariables.DataGripViewRefresh(dgvVariables, _virtualMachine.applicationToControllerVariables.wordArray, _virtualMachine.applicationToControllerVariables.isWordArrayForced);
                }
                else if (_dataGridViewVariableType == DataGridViewVariableType.Double)
                {
                    _dataGridViewVariables.DataGripViewRefresh(dgvVariables, _virtualMachine.applicationToControllerVariables.doubleArray, _virtualMachine.applicationToControllerVariables.isWordArrayForced);
                }
                else if (_dataGridViewVariableType == DataGridViewVariableType.Bool)
                {
                    _dataGridViewVariables.DataGripViewRefresh(dgvVariables, _virtualMachine.applicationToControllerVariables.boolArray, _virtualMachine.applicationToControllerVariables.isBoolArrayForced);
                }
            }
        }
        #endregion
         
        #region Form Resize
        private void KripteksVMB_SizeChanged(object sender, EventArgs e)
        {
            int formWidth = this.Size.Width - 18;
            int formHeight = this.Size.Height - 78;
            scMain.Size = new Size(formWidth, formHeight);
            if (formWidth > Constants.MainPanelExplorerWidth) scMain.SplitterDistance = formWidth - Constants.MainPanelExplorerWidth;// iscMainPanel2Width;
        }
        private void scMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            tabComExplorer.Size = new Size(scMain.Panel2.Width - 3, scMain.Panel2.Height - 36);
            dgvVariables.Size = new Size(scMain.Panel2.Width - 48, dgvVariables.Height);
            gbControllerComm.Size = new Size(scMain.Panel2.Width - 33, gbControllerComm.Height);
            gbControllerVariables.Size = new Size(scMain.Panel2.Width - 33, gbControllerVariables.Height);
            tbLog.Size = new Size(scMain.Panel2.Width - 15, scMain.Panel2.Height - 110);
            btnLogClear.Location = new Point(10, scMain.Panel2.Height - 100);
        }
        #endregion

        #region DataGridViewVariables
        private void cbVariableDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbVariableDirectionTypeChanged();
        }
        private void cbVariableType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbVariableDirectionTypeChanged();
        }
        private void cbVariableDirectionTypeChanged()
        {
            _dataGridViewVariableDirection = (DataGridViewVariableDirection)cbVariableDirection.SelectedIndex;
            _dataGridViewVariableType = (DataGridViewVariableType)cbVariableType.SelectedIndex;
            _dataGridViewVariables.DataGridViewInit(dgvVariables, _dataGridViewVariableDirection, _dataGridViewVariableType, _virtualMachine);
            _virtualMachine = _controller.GetComments(_virtualMachine);
            applicationSettingsForm.VirtualMachine = _virtualMachine;
        }
        private void dgvVariables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvVariables.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void CallBackRefreshControllerSettings()
        {
            _controllerSettings = _controllerSettingsFile.GetControllerSettings();
            _controller.Disconnect(_controllerSettings);
            _controller.Connect(_controllerSettings);
            _chromiumBrowser.Refresh(Constants.Host, _virtualMachine.virtualApplication.CID, _virtualMachine.virtualApplication.SID, _virtualMachine.virtualApplication.AID, "1");
        }
        #endregion

        #region FullScreen
        void formB_ButtonWasClicked()
        {
            GoFullscreen();
        }
        private void GoFullscreen()
        {            
            if (!fullScreenForm.Visible)
            {
                var myFirstScreen = Screen.FromControl(this);
                var mySecondScreen = Screen.AllScreens.FirstOrDefault(s => !s.Equals(myFirstScreen)) ?? myFirstScreen;

                fullScreenForm = new FullScreenForm();
                fullScreenForm.ButtonWasClicked += new FullScreenForm.ClickButton(formB_ButtonWasClicked);

                //Rectangle newRec = WhichScreen();
                fullScreenForm.Controls.Add(_chromiumBrowser.browser);
               
                fullScreenForm.Left = myFirstScreen.Bounds.Left;
                fullScreenForm.Top = myFirstScreen.Bounds.Top;
                fullScreenForm.Location = myFirstScreen.Bounds.Location;
                fullScreenForm.StartPosition = FormStartPosition.Manual;

                fullScreenForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fullScreenForm.Show();
                fullScreenForm.WindowState = FormWindowState.Maximized;
                this.Hide();
            }
            else
            {
                scMain.Panel1.Controls.Add(_chromiumBrowser.browser);
                fullScreenForm.Hide();
                fullScreenForm.Dispose();
                this.Show();
                this.Focus();
            }
        }
        #endregion
        
        #region Tool Strip Menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnmsMenuFocusCam_Click(object sender, EventArgs e)
        {
            _cameraNo = CameraNo.None;
        }
        private void btnmsMenuFreeCam_Click(object sender, EventArgs e)
        {
            _cameraNo = CameraNo.Free;
        }
        private void btnmsMenuPersonCam_Click(object sender, EventArgs e)
        {
            _cameraNo = CameraNo.Person;
        }
        private void btnmsMenuNoneCam_Click(object sender, EventArgs e)
        {
            if (_chromiumBrowser.browser.Visible) _chromiumBrowser.browser.Visible = false;
            else _chromiumBrowser.browser.Visible = true;
        }
        private void btnmsMenuGoFullScreen_Click(object sender, EventArgs e)
        {
            GoFullscreen();
        }
        private void btnmsMenuDevTools_Click(object sender, EventArgs e)
        {
            _chromiumBrowser.browser.ShowDevTools();
        }
        private void btnmsMenuRefresh_Click(object sender, EventArgs e)
        {
            _chromiumBrowser.Refresh(Constants.Host, _virtualMachine.virtualApplication.CID, _virtualMachine.virtualApplication.SID, _virtualMachine.virtualApplication.AID, "1");
        }
        private void btnmsMenuShareLink_Click(object sender, EventArgs e)
        {
            _general.GetShareLink(_virtualMachine.virtualApplication.CID, _virtualMachine.virtualApplication.SID, _virtualMachine.virtualApplication.AID);
        }
        private void btnmsMenuControllerProperties_Click(object sender, EventArgs e)
        {
            controllerSettingsForm = new ControllerSettingsForm();
            controllerSettingsForm.CallBackRefreshControllerSettings = new ControllerSettingsForm.RefreshControllerSettings(this.CallBackRefreshControllerSettings);
            controllerSettingsForm.Show();
        }
        private void btnmsMenuApplicationProperties_Click(object sender, EventArgs e)
        {
            applicationSettingsForm = new ApplicationSettingsForm();
            applicationSettingsForm.VirtualMachine = _controller.GetComments(_virtualMachine);
            applicationSettingsForm.lblAID.Text = _virtualMachine.virtualApplication.AID;
            applicationSettingsForm.Show();
        }
        private void KripteksVMB_FormClosing(object sender, FormClosingEventArgs e)
        {
            s_timerVariables.Enabled = false;
            s_timerCamera.Enabled = false;
            s_timerKeyboard.Enabled = false;
            s_timerSlow.Enabled = false;
            timerForm.Enabled = false;
            _chromiumBrowser.browser.Dispose();
            _controller.Disconnect(_controllerSettings);
            Cef.Shutdown();
        }
        private void btnConnectController_Click(object sender, EventArgs e)
        {
            _controller.Connect(_controllerSettings);
        }
        private void btnDisconnectController_Click(object sender, EventArgs e)
        {
            _controller.Disconnect(_controllerSettings);
        }
        #endregion

    }
}
