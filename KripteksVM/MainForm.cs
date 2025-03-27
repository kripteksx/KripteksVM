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
        private IController _controller;
        private ControllerSettingsFile _controllerSettingsFile = new ControllerSettingsFile();
        private ChromiumBrowser _chromiumBrowser = new ChromiumBrowser();

        private static System.Timers.Timer s_timerCamera = new System.Timers.Timer();
        private static System.Timers.Timer s_timerVariables = new System.Timers.Timer();
        private static System.Timers.Timer s_timerSlow = new System.Timers.Timer();


        private int _performanceControllerElapsedTimeMs = 0;
        private int _performanceVarRefreshTickMs = 0;
        private int _performanceVarRefreshAliveCount = 0;
        private float _gpuUsage = 0;
        private TimeSpan _stopWatchCycleElapsed;
        private Stopwatch _stopWatchCycleTimer = new Stopwatch();
        
        private string _host = "http://www.kripteks.net";
        //private string sHost = "http://localhost:56436";
        
        private int iscMainPanel2Width = 300;
        private int iscMainSplitterDistance = 0;
        private int iFormWidthOld = 0;
        
        // guncellenen degiskenler
        private int _browserInitCount = 0;
        private bool _isBrowserInitAck = false;
        private int _commentsRefreshCount = 0;

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
        private bool[] boAW = new bool[32];
        private bool[] boWA = new bool[32];
        
        // enum a donecek
        private bool _isCursorVisible =true;
        private bool _isFreeCam = false;
        private bool _isPersonCam = false;
        private int _cursorPosXTop = 0;
        private int _cursorPosYTop = 0;

        // Formlar 
        SplashForm splashForm = new SplashForm();
        FullScreenForm fullScreenForm = new FullScreenForm();
        ControllerSettingsForm controllerSettingsForm = new ControllerSettingsForm();
        ApplicationSettingsForm applicationSettingsForm = new ApplicationSettingsForm();

        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        private bool[] _keyHelp = new bool[255];
        private bool[] _key = new bool[255];
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        
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

            // formda gosterilen variable list olustruluyor
            VariablesInit();

            // fullscreen
            WindowState = FormWindowState.Maximized;
            MainFormResize();

            // refresh
            TimerInit();

            // chromium
            _general.LogText("Host is " + _host);
            _chromiumBrowser.Init(_host, _virtualMachine.virtualApplication.CID, _virtualMachine.virtualApplication.SID, _virtualMachine.virtualApplication.AID, "1");
            scMain.Panel1.Controls.Add(_chromiumBrowser.browser);

            // diger formdan bu forma click
            FullScreenInit();
        }

        #region Genel
        private string GetActiveWindowTitle()
        {
            const int chars = 256;
            StringBuilder buff = new StringBuilder(chars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, buff, chars) > 0)
            {
                return buff.ToString();
            }
            return null;
        }
        private string FloatingPointChar()
        {
            string _floatingPointChar = ".";
            string _double = "10.0";
            if (Convert.ToDouble(_double) == 10)
            {
                _floatingPointChar = ".";
            }
            else
            {
                _floatingPointChar = ",";
            }
            return _floatingPointChar;
        }
        private Rectangle WhichScreen()
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
        private void GetScreenProperties()
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
        
        private void GetShareLink()
        {
            Thread thread = new Thread(() => Clipboard.SetText(_host + "/application.aspx?CID=" + _virtualMachine.virtualApplication.CID + "&SID=" + _virtualMachine.virtualApplication.SID + "&AID=" + _virtualMachine.virtualApplication.AID));
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join(); //Wait for the thread to end
            thread.Abort();
        }
        #endregion

        #region Timers
        private void TimerInit()
        {
            // web java script
            s_timerCamera.Elapsed += new System.Timers.ElapsedEventHandler(tmrCamRefresh_Tick);
            s_timerCamera.Interval = 20;
            s_timerCamera.Enabled = true;
            s_timerCamera.AutoReset = true;

            // controller refresh
            s_timerVariables.Elapsed += new System.Timers.ElapsedEventHandler(tmrVarRefresh_Tick);
            s_timerVariables.Interval = 100;
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
            _gpuUsage = GPUUsage.GetGPUUsage(GPUUsage.GetGPUCounters());
        }

        private void tmrCamRefresh_Tick(object sender, EventArgs e)
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
            if (GetActiveWindowTitle() != null) activeWindowTitle = GetActiveWindowTitle();

            int centerPointX = 0;
            int centerPointY = 0;
            // ekran cozunurlugu
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
            if (activeWindowTitle == "KripteksVM")
            {
                if (_key[80] & !_keyHelp[80])
                {
                    Cursor.Position = new Point(centerPointX, centerPointY);
                    _keyHelp[80] = true;
                    PersonCam();
                }
                if (_key[79] & !_keyHelp[79])
                {
                    Cursor.Position = new Point(centerPointX, centerPointY);
                    _keyHelp[79] = true;
                    FreeCam();
                }
            }
            if (_key[27] & !_keyHelp[27]) // ESC
            {
                _keyHelp[27] = true;
                CancelCam();
            }
            if (_key[116] & !_keyHelp[116]) // F5
            {
                _keyHelp[116] = true;
                _chromiumBrowser.Refresh(_host, _virtualMachine.virtualApplication.CID, _virtualMachine.virtualApplication.SID, _virtualMachine.virtualApplication.AID, "1");
            }
            if (_key[121] & !_keyHelp[121]) // F10
            {
                _keyHelp[121] = true;
                GetShareLink();
            }
            if (_key[122] & !_keyHelp[122]) // F11
            {
                _keyHelp[122] = true;
                lblTrigValue.Invoke((MethodInvoker)(() => lblTrigValue.Text = lblTrigValue.Text + " "));
            }
            if (_key[123] & !_keyHelp[123]) // F12
            {
                _keyHelp[123] = true;
                _chromiumBrowser.browser.ShowDevTools();
            }
            // klavye ve mouse 


            // gecikmeli refresh
            if (_browserInitCount > 100)
            {
                // program acildiktan sonra refresh
                if (!_isBrowserInitAck)
                {
                    _isBrowserInitAck = true;
                    _chromiumBrowser.Refresh(_host, _virtualMachine.virtualApplication.CID, _virtualMachine.virtualApplication.SID, _virtualMachine.virtualApplication.AID, "1");
                    _general.LogText("Browser refreshed.");
                }
            }
            else
            {
                _browserInitCount++;
            }


            if (_chromiumBrowser.isMainFrameLoaded & _isBrowserInitAck)
            {
                try
                {
                    // cursor takip
                    string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
                    string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();

                    if (_isCursorVisible)
                    {
                        _chromiumBrowser.browser.ExecuteScriptAsync("boPersonCam=false");
                        _chromiumBrowser.browser.ExecuteScriptAsync("boFreeCam=false");
                    }
                    else
                    {
                        if(_isPersonCam) _chromiumBrowser.browser.ExecuteScriptAsync("boPersonCam=true");
                        else _chromiumBrowser.browser.ExecuteScriptAsync("boPersonCam=false");
                        if (_isFreeCam) _chromiumBrowser.browser.ExecuteScriptAsync("boFreeCam=true");
                        else _chromiumBrowser.browser.ExecuteScriptAsync("boFreeCam=false");
                    }

                    if (!_isCursorVisible)
                    {
                        int cursorPosXFark = Cursor.Position.X - (centerPointX);
                        int cursorPosYFark = Cursor.Position.Y - (centerPointY);
                        Cursor.Position = new Point(centerPointX, centerPointY);

                        _cursorPosXTop = _cursorPosXTop + cursorPosXFark / 2;
                        _cursorPosYTop = _cursorPosYTop + cursorPosYFark / 2;
                    }
                    _chromiumBrowser.browser.ExecuteScriptAsync("boBrowserActive=false");
                    _chromiumBrowser.browser.ExecuteScriptAsync("PointerLockX=" + _cursorPosXTop.ToString());
                    _chromiumBrowser.browser.ExecuteScriptAsync("PointerLockY=" + _cursorPosYTop.ToString());
                    // cursor takip
                    
                }
                catch
                {

                }
            }

        }
        
        private void tmrVarRefresh_Tick(object sender, EventArgs e)
        {
            // Alive timer count
            _performanceVarRefreshAliveCount++;

            // islem suresi
            var stopWatch = new Stopwatch();
            stopWatch.Start();


            // timer cycle time
            if (_stopWatchCycleTimer.IsRunning)
            {
                _performanceVarRefreshTickMs = (_stopWatchCycleTimer.Elapsed - _stopWatchCycleElapsed).Milliseconds;
                _stopWatchCycleElapsed = _stopWatchCycleTimer.Elapsed;
            }
            else
            {
                _stopWatchCycleTimer.Start();
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
                    string sboAWString = "boAW=[" + sBoolStatus[Convert.ToInt16(boAW[0])];
                    for (int i = 1; i < Constants.BoolArraySize; i++)
                    {
                        sboAWString += "," + sBoolStatus[Convert.ToInt16(boAW[i])];
                    }
                    sboAWString += "]";
                    _chromiumBrowser.browser.ExecuteScriptAsync(sboAWString);


                    string sboWA = _chromiumBrowser.GetJSValueByVar(_chromiumBrowser.browser, "boWA");
                    string[] arrsboWA = sboWA.Split(':');
                    for (int i = 0; i < Constants.BoolArraySize; i++)
                    {
                        if (arrsboWA[i] != "") boWA[i] = Convert.ToBoolean(arrsboWA[i]);
                    }


                    _chromiumBrowser.browser.ExecuteScriptAsync("dAW=[" + dAW[0].ToString().Replace(",", ".") + "," + dAW[1].ToString().Replace(",", ".") + "," + dAW[2].ToString().Replace(",", ".") + "," + dAW[3].ToString().Replace(",", ".") + "," + dAW[4].ToString().Replace(",", ".") + "," + dAW[5].ToString().Replace(",", ".") + "," + dAW[6].ToString().Replace(",", ".") + "," + dAW[7].ToString().Replace(",", ".") + "]");

                    string sdWA = _chromiumBrowser.GetJSValueByVar(_chromiumBrowser.browser, "dWA");
                    string[] arrsdWA = sdWA.Split(':');
                    for (int i = 0; i < Constants.DoubleArraySize; i++)
                    {
                        if (arrsdWA[i] != "") dWA[i] = Convert.ToDouble(arrsdWA[i].Replace(".", FloatingPointChar()));
                    }

                    _chromiumBrowser.browser.ExecuteScriptAsync("wAW=[" + wAW[0].ToString() + "," + wAW[1].ToString() + "," + wAW[2].ToString() + "," + wAW[3].ToString() + "," + wAW[4].ToString() + "," + wAW[5].ToString() + "," + wAW[6].ToString() + "," + wAW[7].ToString() + "]");
                    string swWA = _chromiumBrowser.GetJSValueByVar(_chromiumBrowser.browser, "wWA");
                    string[] arrswWA = swWA.Split(':');
                    for (int i = 0; i < Constants.WordArraySize; i++)
                    {
                        if (arrswWA[i] != "") wWA[i] = Convert.ToUInt16(arrswWA[i]);
                    }
                }
                
                // controller -> api | api -> controller
                for (int i = 0; i < Constants.DoubleArraySize; i++)
                {
                    if (!bodWAForce[i]) _virtualMachine.applicationToControllerVariables.doubleArray[i] = dWA[i];
                    if (!bodAWForce[i]) dAW[i] = _virtualMachine.controllerToApplicationVariables.doubleArray[i];
                }
                for (int i = 0; i < Constants.WordArraySize; i++)
                {
                    if (!bowAWForce[i]) wAW[i] = _virtualMachine.controllerToApplicationVariables.wordArray[i];
                    if (!bowWAForce[i]) _virtualMachine.applicationToControllerVariables.wordArray[i] = wWA[i];
                }
                for (int i = 0; i < Constants.BoolArraySize; i++)
                {
                    if (!boboAWForce[i]) boAW[i] = _virtualMachine.controllerToApplicationVariables.boolArray[i];
                    if (!boboWAForce[i]) _virtualMachine.applicationToControllerVariables.boolArray[i] = boWA[i];
                }
            }
            catch
            {
                // Alive timer count
                //iPerformanceVarRefreshAliveCount--;
            }

            // islem suresi
            _performanceControllerElapsedTimeMs = stopWatch.Elapsed.Milliseconds;
            stopWatch.Stop();

            // Alive timer count
            _performanceVarRefreshAliveCount--;
        }

        private void tmrFormRefresh_Tick(object sender, EventArgs e)
        {
            _commentsRefreshCount++;
            if (_commentsRefreshCount >= 10)
            {
                _commentsRefreshCount = 0;

                _virtualMachine = _controller.GetComments(_virtualMachine);
                applicationSettingsForm.VirtualMachine = _virtualMachine;

                this.lblATAID.BeginInvoke((MethodInvoker)delegate () { this.lblATAID.Text = _virtualMachine.virtualApplication.AID; });
                this.lblATName.BeginInvoke((MethodInvoker)delegate () { this.lblATName.Text = _virtualMachine.virtualApplication.name; });
                this.lblATInfo.BeginInvoke((MethodInvoker)delegate () { this.lblATInfo.Text = _virtualMachine.virtualApplication.info; });

            }

            this.lblATElapsedTime.BeginInvoke((MethodInvoker)delegate () { this.lblATElapsedTime.Text = _virtualMachine.controllerStatus.elapsedTime.ToString(); });


            lblBeckhoffAMSNetID.Text = _controllerSettings.controllerBeckhoff.AMSNetID;
            lblBeckhoffPortNo.Text = _controllerSettings.controllerBeckhoff.portNo;
            lblPerformanceControllerCycleTickMs.Text = _controllerSettings.cycleTime.ToString();
            lblPerformanceControllerElapsedTimeMs.Text = _performanceControllerElapsedTimeMs.ToString();
            lblPerformanceVarRefreshTickMs.Text = _performanceVarRefreshTickMs.ToString();
            lblPerformanceGPUUsage.Text = _gpuUsage.ToString("0.00");
            lblPerformanceVarRefreshAliveCount.Text = _performanceVarRefreshAliveCount.ToString();

            // form update
            if (_virtualMachine.controllerStatus.isConnnected)
            {
                btnConnectController.Visible = false;
                btnDisconnectController.Visible = true;
                tslControllerStatus.Text = "Connected";
            }
            else
            {
                tslControllerStatus.Text = "Disconnected";
                btnConnectController.Visible = true;
                btnDisconnectController.Visible = false;
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

            if (cbVariablesSource.SelectedIndex == 1)
            {
                if (cbVariablesType.SelectedIndex == 1 & dgvVariables.Rows.Count == 9)
                {
                    for (int i = 0; i < Constants.WordArraySize; i++)
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
                else if (cbVariablesType.SelectedIndex == 2 & dgvVariables.Rows.Count == 9)
                {
                    for (int i = 0; i < Constants.DoubleArraySize; i++)
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
                else if (cbVariablesType.SelectedIndex == 3 & dgvVariables.Rows.Count == 33)
                {
                    for (int i = 0; i < Constants.BoolArraySize; i++)
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
            else if (cbVariablesSource.SelectedIndex == 2)
            {
                if (cbVariablesType.SelectedIndex == 1 & dgvVariables.Rows.Count == 9)
                {
                    for (int i = 0; i < Constants.WordArraySize; i++)
                    {
                        if (Convert.ToBoolean(dgvVariables.Rows[i].Cells[2].Value) == true)
                        {
                            bowWAForce[i] = true;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.Red;
                            _virtualMachine.applicationToControllerVariables.wordArray[i] = Convert.ToUInt16(dgvVariables.Rows[i].Cells[1].Value.ToString());
                        }
                        else
                        {
                            bowWAForce[i] = false;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.White;
                            dgvVariables.Rows[i].Cells[1].Value = _virtualMachine.applicationToControllerVariables.wordArray[i].ToString();
                        }
                    }
                }
                else if (cbVariablesType.SelectedIndex == 2 & dgvVariables.Rows.Count == 9)
                {
                    for (int i = 0; i < Constants.DoubleArraySize; i++)
                    {
                        if (Convert.ToBoolean(dgvVariables.Rows[i].Cells[2].Value) == true)
                        {
                            bodWAForce[i] = true;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.Red;
                            _virtualMachine.applicationToControllerVariables.doubleArray[i] = Convert.ToDouble(dgvVariables.Rows[i].Cells[1].Value.ToString());
                        }
                        else
                        {
                            bodWAForce[i] = false;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.White;
                            dgvVariables.Rows[i].Cells[1].Value = _virtualMachine.applicationToControllerVariables.doubleArray[i].ToString();
                        }
                    }
                }
                else if (cbVariablesType.SelectedIndex == 3 & dgvVariables.Rows.Count == 33)
                {
                    for (int i = 0; i < Constants.BoolArraySize; i++)
                    {
                        if (Convert.ToBoolean(dgvVariables.Rows[i].Cells[2].Value) == true)
                        {
                            boboWAForce[i] = true;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.Red;

                            if (dgvVariables.Rows[i].Cells[1].Value.ToString() == "0" | dgvVariables.Rows[i].Cells[1].Value.ToString() == "1")
                            {
                                if (dgvVariables.Rows[i].Cells[1].Value.ToString() == "1") _virtualMachine.applicationToControllerVariables.boolArray[i] = true;
                                else if (dgvVariables.Rows[i].Cells[1].Value.ToString() == "0") _virtualMachine.applicationToControllerVariables.boolArray[i] = false;
                            }
                            else
                            {
                                dgvVariables.Rows[i].Cells[1].Value = "0"; _virtualMachine.applicationToControllerVariables.boolArray[i] = false;
                            }
                        }
                        else
                        {
                            boboWAForce[i] = false;
                            dgvVariables.Rows[i].Cells[1].Style.BackColor = Color.White;
                            if (_virtualMachine.applicationToControllerVariables.boolArray[i])
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
        private void KripteksVMB_SizeChanged(object sender, EventArgs e)
        {
            MainFormResize();
        }
        public void MainFormResize()
        {
            int formWidth = this.Size.Width - 18;
            int formHeight = this.Size.Height - 78;
            scMain.Size = new Size(formWidth, formHeight);
            if (formWidth > iscMainPanel2Width) scMain.SplitterDistance = formWidth - iscMainPanel2Width;
        }
        private void scMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            TabComExplorerResize();
            int iFormWidth = this.Size.Width - 18;
            if (iFormWidthOld == this.Size.Width)
                iscMainPanel2Width = iFormWidth - scMain.SplitterDistance;
            else
                iFormWidthOld = this.Size.Width;

            iscMainSplitterDistance = scMain.SplitterDistance;
        }
        private void TabComExplorerResize()
        {
            tabComExplorer.Size = new Size(scMain.Panel2.Width - 3, scMain.Panel2.Height - 36);
            
            dgvVariables.Size = new Size(scMain.Panel2.Width - 48, dgvVariables.Height);
            gbControllerComm.Size = new Size(scMain.Panel2.Width - 33, gbControllerComm.Height);
            gbControllerVariables.Size = new Size(scMain.Panel2.Width - 33, gbControllerVariables.Height);

            tbLog.Size = new Size(scMain.Panel2.Width - 15, scMain.Panel2.Height - 110);
            btnLogClear.Location = new Point(10, scMain.Panel2.Height - 100);
        }
        private void tabComExplorer_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void KripteksVMB_ResizeEnd(object sender, EventArgs e)
        {
            MainFormResize();
        }
        #endregion

        #region Variables
        private void VariablesInit()
        {
            dgvVariables.Rows.Clear();
            if (cbVariablesSource.SelectedIndex == 1)
            {
                if (cbVariablesType.SelectedIndex == 1)
                {
                    for (int i = 0; i < Constants.WordArraySize; i++)
                    {
                        dgvVariables.Rows.Add("wAW[" + i + "]", "0", bowAWForce[i], "word", _virtualMachine.controllerToApplicationVariables.wordArrayComments[i]);
                    }
                }
                if (cbVariablesType.SelectedIndex == 2)
                {
                    for (int i = 0; i < Constants.DoubleArraySize; i++)
                    {
                        dgvVariables.Rows.Add("dAW[" + i + "]", "0", bodAWForce[i], "double", _virtualMachine.controllerToApplicationVariables.doubleArrayComments[i]);
                    }
                }
                if (cbVariablesType.SelectedIndex == 3)
                {
                    for (int i = 0; i < Constants.BoolArraySize; i++)
                    {
                        dgvVariables.Rows.Add("boAW[" + i + "]", "0", boboAWForce[i], "bool", _virtualMachine.controllerToApplicationVariables.boolArrayComments[i]);
                    }
                }
            }
            else if (cbVariablesSource.SelectedIndex == 2)
            {
                if (cbVariablesType.SelectedIndex == 1)
                {
                    for (int i = 0; i < Constants.WordArraySize; i++)
                    {
                        dgvVariables.Rows.Add("wWA[" + i + "]", "0", bowWAForce[i], "word", _virtualMachine.applicationToControllerVariables.wordArrayComments[i]);
                    }
                }
                if (cbVariablesType.SelectedIndex == 2)
                {
                    for (int i = 0; i < Constants.DoubleArraySize; i++)
                    {
                        dgvVariables.Rows.Add("dWA[" + i + "]", "0", bodWAForce[i], "double", _virtualMachine.applicationToControllerVariables.doubleArrayComments[i]);
                    }
                }
                if (cbVariablesType.SelectedIndex == 3)
                {
                    for (int i = 0; i < Constants.BoolArraySize; i++)
                    {
                        dgvVariables.Rows.Add("boWA[" + i + "]", "0", boboWAForce[i], "bool", _virtualMachine.applicationToControllerVariables.boolArrayComments[i]);
                    }
                }
            }
        }
        private void cbVariablesSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            VariablesInit();
        }
        private void cbVariablesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            VariablesInit();
        }
        private void dgvVariables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvVariables.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        #endregion

        #region FullScreen
        private void FullScreenInit()
        {
            fullScreenForm = new FullScreenForm();
            fullScreenForm.ButtonWasClicked += new FullScreenForm.ClickButton(formB_ButtonWasClicked);
            // Properties form closing
        }
        void formB_ButtonWasClicked()
        {
            GoFullscreen();
        }

        private void FormApplicastionSettingsInit()
        {
            applicationSettingsForm = new ApplicationSettingsForm();
        }

        private void fbFormControllerPropertiesInit()
        {
            controllerSettingsForm = new ControllerSettingsForm();

            // Properties form closing
            controllerSettingsForm.CallBackRefreshControllerSettings = new ControllerSettingsForm.RefreshControllerSettings(this.CallBackRefreshControllerSettings);
        }

        private void CallBackRefreshControllerSettings()
        {
            _controllerSettings = _controllerSettingsFile.GetControllerSettings();
            _controller.Disconnect(_controllerSettings);
            _controller.Connect(_controllerSettings);
            _isBrowserInitAck = false;
            _browserInitCount = 0;
        }

        private void GoFullscreen()
        {            
            if (!fullScreenForm.Visible)
            {
                var myFirstScreen = Screen.FromControl(this);
                var mySecondScreen = Screen.AllScreens.FirstOrDefault(s => !s.Equals(myFirstScreen)) ?? myFirstScreen;

                FullScreenInit();

                Rectangle newRec = WhichScreen();
                fullScreenForm.Controls.Add(_chromiumBrowser.browser);
               
                fullScreenForm.Left = myFirstScreen.Bounds.Left;
                fullScreenForm.Top = myFirstScreen.Bounds.Top;
                fullScreenForm.Location = myFirstScreen.Bounds.Location;
                fullScreenForm.StartPosition = FormStartPosition.Manual;

                fullScreenForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fullScreenForm.Show();
                fullScreenForm.WindowState = FormWindowState.Maximized;
                //this.Hide();
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

        #region Camera
        private void PersonCam()
        {
            _isCursorVisible = false;
            _isFreeCam = false;
            _isPersonCam = true;
        }
        private void FreeCam()
        {
            _isCursorVisible = false;
            _isFreeCam = true;
            _isPersonCam = false;
        }
        private void CancelCam()
        {
            _isCursorVisible = true;
            _isFreeCam = false;
            _isPersonCam = false;
        }

        private void KripteksVMB_Activated(object sender, EventArgs e)
        {
        }

        private void KripteksVMB_Deactivate(object sender, EventArgs e)
        {
            CancelCam();
        }
        #endregion

        #region Tool Strip Menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnmsMenuFocusCam_Click(object sender, EventArgs e)
        {
            CancelCam();
        }
        private void btnmsMenuFreeCam_Click(object sender, EventArgs e)
        {
            FreeCam();
        }
        private void btnmsMenuFirstPersonCam_Click(object sender, EventArgs e)
        {
            PersonCam();
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
            _chromiumBrowser.Refresh(_host, _virtualMachine.virtualApplication.CID, _virtualMachine.virtualApplication.SID, _virtualMachine.virtualApplication.AID, "1");
        }
        private void btnmsMenuShareLink_Click(object sender, EventArgs e)
        {
            GetShareLink();
        }
        private void btnmsMenuControllerProperties_Click(object sender, EventArgs e)
        {
            fbFormControllerPropertiesInit();
            controllerSettingsForm.Show();
        }
        private void btnmsMenuApplicationProperties_Click(object sender, EventArgs e)
        {
            applicationSettingsForm.Show();
            applicationSettingsForm.lblAID.Text = _virtualMachine.virtualApplication.AID;
            FormApplicastionSettingsInit();
        }
        private void btnmsMenuApplication_Click(object sender, EventArgs e)
        {
            _virtualMachine = _controller.GetComments(_virtualMachine);
            applicationSettingsForm.VirtualMachine = _virtualMachine;
        }
        private void KripteksVMB_FormClosing(object sender, FormClosingEventArgs e)
        {
            s_timerVariables.Enabled = false;
            s_timerCamera.Enabled = false;
            timerForm.Enabled = false;
            _chromiumBrowser.browser.Dispose();
            _controller.Disconnect(_controllerSettings);
            Cef.Shutdown();
        }
        private void lblTrigValue_TextChanged(object sender, EventArgs e)
        {
            GoFullscreen();
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
