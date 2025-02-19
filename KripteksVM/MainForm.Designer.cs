namespace KripteksVM
{
    partial class KripteksVMB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KripteksVMB));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.lblTrigValue = new System.Windows.Forms.Label();
            this.sFormStatus = new System.Windows.Forms.StatusStrip();
            this.tsslControllerStatus_ = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslControllerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSeperator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslServerStatus_ = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSeperator2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslClientsStatus_ = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslClientsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSeperator3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSeperator4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmsMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmsMenuDevTools = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmsMenuShareLink = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmsMenuApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmsMenuApplicationProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.controllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmsMenuControllerProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmsMenuFocusCam = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmsMenuFreeCam = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmsMenuFirstPersonCam = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmsMenuGoFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tabComExplorer = new System.Windows.Forms.TabControl();
            this.tabCEController = new System.Windows.Forms.TabPage();
            this.gbControllerVariables = new System.Windows.Forms.GroupBox();
            this.cbVariablesSource = new System.Windows.Forms.ComboBox();
            this.cbVariablesType = new System.Windows.Forms.ComboBox();
            this.dgvVariables = new System.Windows.Forms.DataGridView();
            this.Variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Force = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbControllerComm = new System.Windows.Forms.GroupBox();
            this.lblBeckhoffAMSNetID = new System.Windows.Forms.Label();
            this.lblBeckhoffAMSNetID_ = new System.Windows.Forms.Label();
            this.lblBeckhoffPortNo = new System.Windows.Forms.Label();
            this.lblBeckhoffPortNo_ = new System.Windows.Forms.Label();
            this.lblCID = new System.Windows.Forms.Label();
            this.lblCID_ = new System.Windows.Forms.Label();
            this.lblAID = new System.Windows.Forms.Label();
            this.lblSID = new System.Windows.Forms.Label();
            this.btnConnectController = new System.Windows.Forms.Button();
            this.lblAID_ = new System.Windows.Forms.Label();
            this.lblControllerStatus_ = new System.Windows.Forms.Label();
            this.lblSID_ = new System.Windows.Forms.Label();
            this.btnDisconnectController = new System.Windows.Forms.Button();
            this.tabCEApplication = new System.Windows.Forms.TabPage();
            this.lblATElapsedTimeUnit = new System.Windows.Forms.Label();
            this.lblATElapsedTime = new System.Windows.Forms.Label();
            this.lblATElapsedTime_ = new System.Windows.Forms.Label();
            this.lblATInfo = new System.Windows.Forms.Label();
            this.lblATInfo_ = new System.Windows.Forms.Label();
            this.lblATName = new System.Windows.Forms.Label();
            this.lblATName_ = new System.Windows.Forms.Label();
            this.lblATAID = new System.Windows.Forms.Label();
            this.lblATAID_ = new System.Windows.Forms.Label();
            this.tabCEServer = new System.Windows.Forms.TabPage();
            this.gbSignalRComm = new System.Windows.Forms.GroupBox();
            this.dgvUserList = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConnectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblServerStatus_ = new System.Windows.Forms.Label();
            this.tmrFormRefresh = new System.Windows.Forms.Timer(this.components);
            this.tabCELog = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnLogClear = new System.Windows.Forms.Button();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.sFormStatus.SuspendLayout();
            this.msMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tabComExplorer.SuspendLayout();
            this.tabCEController.SuspendLayout();
            this.gbControllerVariables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariables)).BeginInit();
            this.gbControllerComm.SuspendLayout();
            this.tabCEApplication.SuspendLayout();
            this.tabCEServer.SuspendLayout();
            this.gbSignalRComm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).BeginInit();
            this.tabCELog.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripContainer.ContentPanel.Controls.Add(this.lblTrigValue);
            this.toolStripContainer.ContentPanel.Controls.Add(this.sFormStatus);
            this.toolStripContainer.ContentPanel.Controls.Add(this.msMenu);
            this.toolStripContainer.ContentPanel.Controls.Add(this.scMain);
            this.toolStripContainer.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(970, 728);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.RightToolStripPanelVisible = false;
            this.toolStripContainer.Size = new System.Drawing.Size(970, 753);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // lblTrigValue
            // 
            this.lblTrigValue.AutoSize = true;
            this.lblTrigValue.Location = new System.Drawing.Point(589, 12);
            this.lblTrigValue.Name = "lblTrigValue";
            this.lblTrigValue.Size = new System.Drawing.Size(16, 17);
            this.lblTrigValue.TabIndex = 6;
            this.lblTrigValue.Text = "  ";
            this.lblTrigValue.TextChanged += new System.EventHandler(this.lblTrigValue_TextChanged);
            // 
            // sFormStatus
            // 
            this.sFormStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.sFormStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sFormStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslControllerStatus_,
            this.tslControllerStatus,
            this.tslSeperator1,
            this.tslServerStatus_,
            this.tslServerStatus,
            this.tslSeperator2,
            this.tslClientsStatus_,
            this.tslClientsStatus,
            this.tslSeperator3,
            this.tslElapsedTime,
            this.tslSeperator4});
            this.sFormStatus.Location = new System.Drawing.Point(0, 698);
            this.sFormStatus.Name = "sFormStatus";
            this.sFormStatus.Size = new System.Drawing.Size(970, 30);
            this.sFormStatus.TabIndex = 5;
            this.sFormStatus.Text = "FormStatus";
            // 
            // tsslControllerStatus_
            // 
            this.tsslControllerStatus_.Name = "tsslControllerStatus_";
            this.tsslControllerStatus_.Size = new System.Drawing.Size(82, 25);
            this.tsslControllerStatus_.Text = "Controller :";
            // 
            // tslControllerStatus
            // 
            this.tslControllerStatus.AutoSize = false;
            this.tslControllerStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.tslControllerStatus.Name = "tslControllerStatus";
            this.tslControllerStatus.Size = new System.Drawing.Size(100, 25);
            this.tslControllerStatus.Text = "Connected";
            this.tslControllerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tslSeperator1
            // 
            this.tslSeperator1.Name = "tslSeperator1";
            this.tslSeperator1.Size = new System.Drawing.Size(13, 25);
            this.tslSeperator1.Text = "|";
            // 
            // tslServerStatus_
            // 
            this.tslServerStatus_.Name = "tslServerStatus_";
            this.tslServerStatus_.Size = new System.Drawing.Size(57, 25);
            this.tslServerStatus_.Text = "Server :";
            // 
            // tslServerStatus
            // 
            this.tslServerStatus.AutoSize = false;
            this.tslServerStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.tslServerStatus.Name = "tslServerStatus";
            this.tslServerStatus.Size = new System.Drawing.Size(100, 25);
            this.tslServerStatus.Text = "Connected";
            this.tslServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tslSeperator2
            // 
            this.tslSeperator2.Name = "tslSeperator2";
            this.tslSeperator2.Size = new System.Drawing.Size(13, 25);
            this.tslSeperator2.Text = "|";
            // 
            // tslClientsStatus_
            // 
            this.tslClientsStatus_.Name = "tslClientsStatus_";
            this.tslClientsStatus_.Size = new System.Drawing.Size(60, 25);
            this.tslClientsStatus_.Text = "Clients :";
            // 
            // tslClientsStatus
            // 
            this.tslClientsStatus.AutoSize = false;
            this.tslClientsStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.tslClientsStatus.Name = "tslClientsStatus";
            this.tslClientsStatus.Size = new System.Drawing.Size(30, 25);
            this.tslClientsStatus.Text = "0";
            this.tslClientsStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tslSeperator3
            // 
            this.tslSeperator3.Name = "tslSeperator3";
            this.tslSeperator3.Size = new System.Drawing.Size(13, 25);
            this.tslSeperator3.Text = "|";
            // 
            // tslElapsedTime
            // 
            this.tslElapsedTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.tslElapsedTime.Name = "tslElapsedTime";
            this.tslElapsedTime.Size = new System.Drawing.Size(63, 25);
            this.tslElapsedTime.Text = "00:00:00";
            // 
            // tslSeperator4
            // 
            this.tslSeperator4.Name = "tslSeperator4";
            this.tslSeperator4.Size = new System.Drawing.Size(13, 25);
            this.tslSeperator4.Text = "|";
            // 
            // msMenu
            // 
            this.msMenu.AutoSize = false;
            this.msMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.msMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.userToolStripMenuItem,
            this.browserToolStripMenuItem,
            this.btnmsMenuApplication,
            this.controllerToolStripMenuItem,
            this.cameraToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Padding = new System.Windows.Forms.Padding(6, 4, 0, 3);
            this.msMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.msMenu.Size = new System.Drawing.Size(970, 30);
            this.msMenu.TabIndex = 3;
            this.msMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.saveAsToolStripMenuItem.Text = "Save as";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(50, 23);
            this.userToolStripMenuItem.Text = "User";
            // 
            // browserToolStripMenuItem
            // 
            this.browserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnmsMenuRefresh,
            this.btnmsMenuDevTools,
            this.btnmsMenuShareLink});
            this.browserToolStripMenuItem.Name = "browserToolStripMenuItem";
            this.browserToolStripMenuItem.Size = new System.Drawing.Size(74, 23);
            this.browserToolStripMenuItem.Text = "Browser";
            // 
            // btnmsMenuRefresh
            // 
            this.btnmsMenuRefresh.Name = "btnmsMenuRefresh";
            this.btnmsMenuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.btnmsMenuRefresh.ShowShortcutKeys = false;
            this.btnmsMenuRefresh.Size = new System.Drawing.Size(188, 26);
            this.btnmsMenuRefresh.Text = "Refresh [F5]";
            this.btnmsMenuRefresh.Click += new System.EventHandler(this.btnmsMenuRefresh_Click);
            // 
            // btnmsMenuDevTools
            // 
            this.btnmsMenuDevTools.Name = "btnmsMenuDevTools";
            this.btnmsMenuDevTools.Size = new System.Drawing.Size(188, 26);
            this.btnmsMenuDevTools.Text = "DevTools [F12]";
            this.btnmsMenuDevTools.Click += new System.EventHandler(this.btnmsMenuDevTools_Click);
            // 
            // btnmsMenuShareLink
            // 
            this.btnmsMenuShareLink.Name = "btnmsMenuShareLink";
            this.btnmsMenuShareLink.Size = new System.Drawing.Size(188, 26);
            this.btnmsMenuShareLink.Text = "Share Link [F10]";
            this.btnmsMenuShareLink.Click += new System.EventHandler(this.btnmsMenuShareLink_Click);
            // 
            // btnmsMenuApplication
            // 
            this.btnmsMenuApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnmsMenuApplicationProperties});
            this.btnmsMenuApplication.Name = "btnmsMenuApplication";
            this.btnmsMenuApplication.Size = new System.Drawing.Size(98, 23);
            this.btnmsMenuApplication.Text = "Application";
            this.btnmsMenuApplication.Click += new System.EventHandler(this.btnmsMenuApplication_Click);
            // 
            // btnmsMenuApplicationProperties
            // 
            this.btnmsMenuApplicationProperties.Name = "btnmsMenuApplicationProperties";
            this.btnmsMenuApplicationProperties.Size = new System.Drawing.Size(151, 26);
            this.btnmsMenuApplicationProperties.Text = "Properties";
            this.btnmsMenuApplicationProperties.Click += new System.EventHandler(this.btnmsMenuApplicationProperties_Click);
            // 
            // controllerToolStripMenuItem
            // 
            this.controllerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnmsMenuControllerProperties});
            this.controllerToolStripMenuItem.Name = "controllerToolStripMenuItem";
            this.controllerToolStripMenuItem.Size = new System.Drawing.Size(87, 23);
            this.controllerToolStripMenuItem.Text = "Controller";
            // 
            // btnmsMenuControllerProperties
            // 
            this.btnmsMenuControllerProperties.Name = "btnmsMenuControllerProperties";
            this.btnmsMenuControllerProperties.Size = new System.Drawing.Size(151, 26);
            this.btnmsMenuControllerProperties.Text = "Properties";
            this.btnmsMenuControllerProperties.Click += new System.EventHandler(this.btnmsMenuControllerProperties_Click);
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnmsMenuFocusCam,
            this.btnmsMenuFreeCam,
            this.btnmsMenuFirstPersonCam,
            this.btnmsMenuGoFullScreen});
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(72, 23);
            this.cameraToolStripMenuItem.Text = "Camera";
            // 
            // btnmsMenuFocusCam
            // 
            this.btnmsMenuFocusCam.Name = "btnmsMenuFocusCam";
            this.btnmsMenuFocusCam.Size = new System.Drawing.Size(192, 26);
            this.btnmsMenuFocusCam.Text = "Focus [ESC]";
            this.btnmsMenuFocusCam.Click += new System.EventHandler(this.btnmsMenuFocusCam_Click);
            // 
            // btnmsMenuFreeCam
            // 
            this.btnmsMenuFreeCam.Name = "btnmsMenuFreeCam";
            this.btnmsMenuFreeCam.Size = new System.Drawing.Size(192, 26);
            this.btnmsMenuFreeCam.Text = "Free [O]";
            this.btnmsMenuFreeCam.Click += new System.EventHandler(this.btnmsMenuFreeCam_Click);
            // 
            // btnmsMenuFirstPersonCam
            // 
            this.btnmsMenuFirstPersonCam.Name = "btnmsMenuFirstPersonCam";
            this.btnmsMenuFirstPersonCam.Size = new System.Drawing.Size(192, 26);
            this.btnmsMenuFirstPersonCam.Text = "First Person [P]";
            this.btnmsMenuFirstPersonCam.Click += new System.EventHandler(this.btnmsMenuFirstPersonCam_Click);
            // 
            // btnmsMenuGoFullScreen
            // 
            this.btnmsMenuGoFullScreen.Name = "btnmsMenuGoFullScreen";
            this.btnmsMenuGoFullScreen.Size = new System.Drawing.Size(192, 26);
            this.btnmsMenuGoFullScreen.Text = "Full Screen [F11]";
            this.btnmsMenuGoFullScreen.Click += new System.EventHandler(this.btnmsMenuGoFullScreen_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // scMain
            // 
            this.scMain.Location = new System.Drawing.Point(0, 35);
            this.scMain.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.scMain.Panel2.Controls.Add(this.tabComExplorer);
            this.scMain.Panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.scMain.Size = new System.Drawing.Size(900, 692);
            this.scMain.SplitterDistance = 600;
            this.scMain.TabIndex = 4;
            this.scMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scMain_SplitterMoved);
            // 
            // tabComExplorer
            // 
            this.tabComExplorer.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabComExplorer.Controls.Add(this.tabCEController);
            this.tabComExplorer.Controls.Add(this.tabCEApplication);
            this.tabComExplorer.Controls.Add(this.tabCEServer);
            this.tabComExplorer.Controls.Add(this.tabCELog);
            this.tabComExplorer.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabComExplorer.Location = new System.Drawing.Point(0, 0);
            this.tabComExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.tabComExplorer.Name = "tabComExplorer";
            this.tabComExplorer.Padding = new System.Drawing.Point(0, 0);
            this.tabComExplorer.SelectedIndex = 0;
            this.tabComExplorer.Size = new System.Drawing.Size(296, 581);
            this.tabComExplorer.TabIndex = 15;
            this.tabComExplorer.SelectedIndexChanged += new System.EventHandler(this.tabComExplorer_SelectedIndexChanged);
            // 
            // tabCEController
            // 
            this.tabCEController.BackColor = System.Drawing.SystemColors.Window;
            this.tabCEController.Controls.Add(this.gbControllerVariables);
            this.tabCEController.Controls.Add(this.gbControllerComm);
            this.tabCEController.Location = new System.Drawing.Point(4, 4);
            this.tabCEController.Name = "tabCEController";
            this.tabCEController.Padding = new System.Windows.Forms.Padding(3);
            this.tabCEController.Size = new System.Drawing.Size(288, 552);
            this.tabCEController.TabIndex = 0;
            this.tabCEController.Text = "Controller";
            // 
            // gbControllerVariables
            // 
            this.gbControllerVariables.Controls.Add(this.cbVariablesSource);
            this.gbControllerVariables.Controls.Add(this.cbVariablesType);
            this.gbControllerVariables.Controls.Add(this.dgvVariables);
            this.gbControllerVariables.Location = new System.Drawing.Point(6, 250);
            this.gbControllerVariables.Name = "gbControllerVariables";
            this.gbControllerVariables.Size = new System.Drawing.Size(267, 338);
            this.gbControllerVariables.TabIndex = 18;
            this.gbControllerVariables.TabStop = false;
            this.gbControllerVariables.Text = "Variables";
            // 
            // cbVariablesSource
            // 
            this.cbVariablesSource.FormattingEnabled = true;
            this.cbVariablesSource.Items.AddRange(new object[] {
            "None",
            "Api -> Web",
            "Web-> Api"});
            this.cbVariablesSource.Location = new System.Drawing.Point(6, 21);
            this.cbVariablesSource.Name = "cbVariablesSource";
            this.cbVariablesSource.Size = new System.Drawing.Size(121, 24);
            this.cbVariablesSource.TabIndex = 13;
            this.cbVariablesSource.Text = "None";
            this.cbVariablesSource.SelectedIndexChanged += new System.EventHandler(this.cbVariablesSource_SelectedIndexChanged);
            // 
            // cbVariablesType
            // 
            this.cbVariablesType.FormattingEnabled = true;
            this.cbVariablesType.Items.AddRange(new object[] {
            "None",
            "word",
            "double",
            "bool"});
            this.cbVariablesType.Location = new System.Drawing.Point(133, 21);
            this.cbVariablesType.Name = "cbVariablesType";
            this.cbVariablesType.Size = new System.Drawing.Size(121, 24);
            this.cbVariablesType.TabIndex = 14;
            this.cbVariablesType.Text = "None";
            this.cbVariablesType.SelectedIndexChanged += new System.EventHandler(this.cbVariablesType_SelectedIndexChanged);
            // 
            // dgvVariables
            // 
            this.dgvVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Variable,
            this.Value,
            this.Force,
            this.Type,
            this.Comment});
            this.dgvVariables.Location = new System.Drawing.Point(6, 51);
            this.dgvVariables.Name = "dgvVariables";
            this.dgvVariables.RowHeadersVisible = false;
            this.dgvVariables.RowTemplate.Height = 24;
            this.dgvVariables.Size = new System.Drawing.Size(270, 281);
            this.dgvVariables.TabIndex = 0;
            this.dgvVariables.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVariables_CellContentClick);
            // 
            // Variable
            // 
            this.Variable.HeaderText = "Variable";
            this.Variable.Name = "Variable";
            this.Variable.ReadOnly = true;
            this.Variable.Width = 80;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Value.Width = 80;
            // 
            // Force
            // 
            this.Force.HeaderText = "Force";
            this.Force.Name = "Force";
            this.Force.Width = 50;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 80;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Comment.Width = 200;
            // 
            // gbControllerComm
            // 
            this.gbControllerComm.Controls.Add(this.lblBeckhoffAMSNetID);
            this.gbControllerComm.Controls.Add(this.lblBeckhoffAMSNetID_);
            this.gbControllerComm.Controls.Add(this.lblBeckhoffPortNo);
            this.gbControllerComm.Controls.Add(this.lblBeckhoffPortNo_);
            this.gbControllerComm.Controls.Add(this.lblCID);
            this.gbControllerComm.Controls.Add(this.lblCID_);
            this.gbControllerComm.Controls.Add(this.lblAID);
            this.gbControllerComm.Controls.Add(this.lblSID);
            this.gbControllerComm.Controls.Add(this.btnConnectController);
            this.gbControllerComm.Controls.Add(this.lblAID_);
            this.gbControllerComm.Controls.Add(this.lblControllerStatus_);
            this.gbControllerComm.Controls.Add(this.lblSID_);
            this.gbControllerComm.Controls.Add(this.btnDisconnectController);
            this.gbControllerComm.Location = new System.Drawing.Point(6, 6);
            this.gbControllerComm.Name = "gbControllerComm";
            this.gbControllerComm.Size = new System.Drawing.Size(267, 225);
            this.gbControllerComm.TabIndex = 17;
            this.gbControllerComm.TabStop = false;
            this.gbControllerComm.Text = "Communication";
            // 
            // lblBeckhoffAMSNetID
            // 
            this.lblBeckhoffAMSNetID.AutoSize = true;
            this.lblBeckhoffAMSNetID.Location = new System.Drawing.Point(112, 80);
            this.lblBeckhoffAMSNetID.Name = "lblBeckhoffAMSNetID";
            this.lblBeckhoffAMSNetID.Size = new System.Drawing.Size(16, 17);
            this.lblBeckhoffAMSNetID.TabIndex = 24;
            this.lblBeckhoffAMSNetID.Text = "0";
            // 
            // lblBeckhoffAMSNetID_
            // 
            this.lblBeckhoffAMSNetID_.AutoSize = true;
            this.lblBeckhoffAMSNetID_.Location = new System.Drawing.Point(6, 80);
            this.lblBeckhoffAMSNetID_.Name = "lblBeckhoffAMSNetID_";
            this.lblBeckhoffAMSNetID_.Size = new System.Drawing.Size(76, 17);
            this.lblBeckhoffAMSNetID_.TabIndex = 23;
            this.lblBeckhoffAMSNetID_.Text = "AmsNETID";
            // 
            // lblBeckhoffPortNo
            // 
            this.lblBeckhoffPortNo.AutoSize = true;
            this.lblBeckhoffPortNo.Location = new System.Drawing.Point(112, 105);
            this.lblBeckhoffPortNo.Name = "lblBeckhoffPortNo";
            this.lblBeckhoffPortNo.Size = new System.Drawing.Size(16, 17);
            this.lblBeckhoffPortNo.TabIndex = 22;
            this.lblBeckhoffPortNo.Text = "0";
            // 
            // lblBeckhoffPortNo_
            // 
            this.lblBeckhoffPortNo_.AutoSize = true;
            this.lblBeckhoffPortNo_.Location = new System.Drawing.Point(6, 105);
            this.lblBeckhoffPortNo_.Name = "lblBeckhoffPortNo_";
            this.lblBeckhoffPortNo_.Size = new System.Drawing.Size(34, 17);
            this.lblBeckhoffPortNo_.TabIndex = 21;
            this.lblBeckhoffPortNo_.Text = "Port";
            // 
            // lblCID
            // 
            this.lblCID.AutoSize = true;
            this.lblCID.Location = new System.Drawing.Point(112, 180);
            this.lblCID.Name = "lblCID";
            this.lblCID.Size = new System.Drawing.Size(16, 17);
            this.lblCID.TabIndex = 20;
            this.lblCID.Text = "0";
            // 
            // lblCID_
            // 
            this.lblCID_.AutoSize = true;
            this.lblCID_.Location = new System.Drawing.Point(6, 180);
            this.lblCID_.Name = "lblCID_";
            this.lblCID_.Size = new System.Drawing.Size(30, 17);
            this.lblCID_.TabIndex = 19;
            this.lblCID_.Text = "CID";
            // 
            // lblAID
            // 
            this.lblAID.AutoSize = true;
            this.lblAID.Location = new System.Drawing.Point(112, 155);
            this.lblAID.Name = "lblAID";
            this.lblAID.Size = new System.Drawing.Size(16, 17);
            this.lblAID.TabIndex = 18;
            this.lblAID.Text = "0";
            // 
            // lblSID
            // 
            this.lblSID.AutoSize = true;
            this.lblSID.Location = new System.Drawing.Point(112, 130);
            this.lblSID.Name = "lblSID";
            this.lblSID.Size = new System.Drawing.Size(16, 17);
            this.lblSID.TabIndex = 17;
            this.lblSID.Text = "0";
            // 
            // btnConnectController
            // 
            this.btnConnectController.Location = new System.Drawing.Point(6, 21);
            this.btnConnectController.Name = "btnConnectController";
            this.btnConnectController.Size = new System.Drawing.Size(100, 30);
            this.btnConnectController.TabIndex = 11;
            this.btnConnectController.Text = "Connect";
            this.btnConnectController.UseVisualStyleBackColor = true;
            this.btnConnectController.Click += new System.EventHandler(this.btnConnectController_Click);
            // 
            // lblAID_
            // 
            this.lblAID_.AutoSize = true;
            this.lblAID_.Location = new System.Drawing.Point(6, 155);
            this.lblAID_.Name = "lblAID_";
            this.lblAID_.Size = new System.Drawing.Size(30, 17);
            this.lblAID_.TabIndex = 16;
            this.lblAID_.Text = "AID";
            // 
            // lblControllerStatus_
            // 
            this.lblControllerStatus_.Location = new System.Drawing.Point(112, 21);
            this.lblControllerStatus_.Name = "lblControllerStatus_";
            this.lblControllerStatus_.Size = new System.Drawing.Size(30, 30);
            this.lblControllerStatus_.TabIndex = 7;
            this.lblControllerStatus_.Text = "  ";
            this.lblControllerStatus_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSID_
            // 
            this.lblSID_.AutoSize = true;
            this.lblSID_.Location = new System.Drawing.Point(6, 130);
            this.lblSID_.Name = "lblSID_";
            this.lblSID_.Size = new System.Drawing.Size(30, 17);
            this.lblSID_.TabIndex = 15;
            this.lblSID_.Text = "SID";
            // 
            // btnDisconnectController
            // 
            this.btnDisconnectController.Location = new System.Drawing.Point(6, 21);
            this.btnDisconnectController.Name = "btnDisconnectController";
            this.btnDisconnectController.Size = new System.Drawing.Size(100, 30);
            this.btnDisconnectController.TabIndex = 12;
            this.btnDisconnectController.Text = "Disconnect";
            this.btnDisconnectController.UseVisualStyleBackColor = true;
            this.btnDisconnectController.Click += new System.EventHandler(this.btnDisconnectController_Click);
            // 
            // tabCEApplication
            // 
            this.tabCEApplication.BackColor = System.Drawing.SystemColors.Window;
            this.tabCEApplication.Controls.Add(this.lblATElapsedTimeUnit);
            this.tabCEApplication.Controls.Add(this.lblATElapsedTime);
            this.tabCEApplication.Controls.Add(this.lblATElapsedTime_);
            this.tabCEApplication.Controls.Add(this.lblATInfo);
            this.tabCEApplication.Controls.Add(this.lblATInfo_);
            this.tabCEApplication.Controls.Add(this.lblATName);
            this.tabCEApplication.Controls.Add(this.lblATName_);
            this.tabCEApplication.Controls.Add(this.lblATAID);
            this.tabCEApplication.Controls.Add(this.lblATAID_);
            this.tabCEApplication.Location = new System.Drawing.Point(4, 4);
            this.tabCEApplication.Name = "tabCEApplication";
            this.tabCEApplication.Padding = new System.Windows.Forms.Padding(3);
            this.tabCEApplication.Size = new System.Drawing.Size(288, 552);
            this.tabCEApplication.TabIndex = 1;
            this.tabCEApplication.Text = "Application";
            // 
            // lblATElapsedTimeUnit
            // 
            this.lblATElapsedTimeUnit.AutoSize = true;
            this.lblATElapsedTimeUnit.Location = new System.Drawing.Point(134, 453);
            this.lblATElapsedTimeUnit.Name = "lblATElapsedTimeUnit";
            this.lblATElapsedTimeUnit.Size = new System.Drawing.Size(34, 17);
            this.lblATElapsedTimeUnit.TabIndex = 17;
            this.lblATElapsedTimeUnit.Text = "sec.";
            // 
            // lblATElapsedTime
            // 
            this.lblATElapsedTime.Location = new System.Drawing.Point(68, 453);
            this.lblATElapsedTime.Name = "lblATElapsedTime";
            this.lblATElapsedTime.Size = new System.Drawing.Size(60, 20);
            this.lblATElapsedTime.TabIndex = 16;
            this.lblATElapsedTime.Text = "    ";
            // 
            // lblATElapsedTime_
            // 
            this.lblATElapsedTime_.AutoSize = true;
            this.lblATElapsedTime_.Location = new System.Drawing.Point(9, 453);
            this.lblATElapsedTime_.Name = "lblATElapsedTime_";
            this.lblATElapsedTime_.Size = new System.Drawing.Size(47, 17);
            this.lblATElapsedTime_.TabIndex = 15;
            this.lblATElapsedTime_.Text = "Time :";
            // 
            // lblATInfo
            // 
            this.lblATInfo.Location = new System.Drawing.Point(68, 81);
            this.lblATInfo.Name = "lblATInfo";
            this.lblATInfo.Size = new System.Drawing.Size(200, 372);
            this.lblATInfo.TabIndex = 14;
            this.lblATInfo.Text = "    ";
            // 
            // lblATInfo_
            // 
            this.lblATInfo_.AutoSize = true;
            this.lblATInfo_.Location = new System.Drawing.Point(9, 81);
            this.lblATInfo_.Name = "lblATInfo_";
            this.lblATInfo_.Size = new System.Drawing.Size(39, 17);
            this.lblATInfo_.TabIndex = 13;
            this.lblATInfo_.Text = "Info :";
            // 
            // lblATName
            // 
            this.lblATName.Location = new System.Drawing.Point(68, 46);
            this.lblATName.Name = "lblATName";
            this.lblATName.Size = new System.Drawing.Size(200, 23);
            this.lblATName.TabIndex = 12;
            this.lblATName.Text = "    ";
            // 
            // lblATName_
            // 
            this.lblATName_.AutoSize = true;
            this.lblATName_.Location = new System.Drawing.Point(9, 49);
            this.lblATName_.Name = "lblATName_";
            this.lblATName_.Size = new System.Drawing.Size(53, 17);
            this.lblATName_.TabIndex = 11;
            this.lblATName_.Text = "Name :";
            // 
            // lblATAID
            // 
            this.lblATAID.Location = new System.Drawing.Point(68, 13);
            this.lblATAID.Name = "lblATAID";
            this.lblATAID.Size = new System.Drawing.Size(33, 23);
            this.lblATAID.TabIndex = 10;
            this.lblATAID.Text = "    ";
            // 
            // lblATAID_
            // 
            this.lblATAID_.AutoSize = true;
            this.lblATAID_.Location = new System.Drawing.Point(9, 16);
            this.lblATAID_.Name = "lblATAID_";
            this.lblATAID_.Size = new System.Drawing.Size(38, 17);
            this.lblATAID_.TabIndex = 9;
            this.lblATAID_.Text = "AID :";
            // 
            // tabCEServer
            // 
            this.tabCEServer.BackColor = System.Drawing.SystemColors.Window;
            this.tabCEServer.Controls.Add(this.gbSignalRComm);
            this.tabCEServer.Location = new System.Drawing.Point(4, 4);
            this.tabCEServer.Name = "tabCEServer";
            this.tabCEServer.Size = new System.Drawing.Size(288, 552);
            this.tabCEServer.TabIndex = 2;
            this.tabCEServer.Text = "Server";
            // 
            // gbSignalRComm
            // 
            this.gbSignalRComm.Controls.Add(this.dgvUserList);
            this.gbSignalRComm.Controls.Add(this.lblServerStatus_);
            this.gbSignalRComm.Location = new System.Drawing.Point(3, 3);
            this.gbSignalRComm.Name = "gbSignalRComm";
            this.gbSignalRComm.Size = new System.Drawing.Size(267, 266);
            this.gbSignalRComm.TabIndex = 9;
            this.gbSignalRComm.TabStop = false;
            this.gbSignalRComm.Text = "Communication";
            // 
            // dgvUserList
            // 
            this.dgvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.ConnectionID});
            this.dgvUserList.Location = new System.Drawing.Point(6, 21);
            this.dgvUserList.Name = "dgvUserList";
            this.dgvUserList.RowHeadersVisible = false;
            this.dgvUserList.RowTemplate.Height = 24;
            this.dgvUserList.Size = new System.Drawing.Size(242, 230);
            this.dgvUserList.TabIndex = 8;
            // 
            // UserID
            // 
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            // 
            // ConnectionID
            // 
            this.ConnectionID.HeaderText = "ConnectionID";
            this.ConnectionID.Name = "ConnectionID";
            this.ConnectionID.Width = 110;
            // 
            // lblServerStatus_
            // 
            this.lblServerStatus_.Location = new System.Drawing.Point(113, 21);
            this.lblServerStatus_.Name = "lblServerStatus_";
            this.lblServerStatus_.Size = new System.Drawing.Size(30, 30);
            this.lblServerStatus_.TabIndex = 2;
            this.lblServerStatus_.Text = " ";
            // 
            // tmrFormRefresh
            // 
            this.tmrFormRefresh.Enabled = true;
            this.tmrFormRefresh.Interval = 250;
            this.tmrFormRefresh.Tick += new System.EventHandler(this.tmrFormRefresh_Tick);
            // 
            // tabCELog
            // 
            this.tabCELog.Controls.Add(this.btnLogClear);
            this.tabCELog.Controls.Add(this.rtbLog);
            this.tabCELog.Location = new System.Drawing.Point(4, 4);
            this.tabCELog.Name = "tabCELog";
            this.tabCELog.Size = new System.Drawing.Size(288, 552);
            this.tabCELog.TabIndex = 3;
            this.tabCELog.Text = "Log";
            this.tabCELog.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.Enabled = false;
            this.rtbLog.Location = new System.Drawing.Point(3, 3);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(282, 472);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "KripteksVM V1.0";
            // 
            // btnLogClear
            // 
            this.btnLogClear.Location = new System.Drawing.Point(12, 514);
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Size = new System.Drawing.Size(75, 25);
            this.btnLogClear.TabIndex = 1;
            this.btnLogClear.Text = "Clear";
            this.btnLogClear.UseVisualStyleBackColor = true;
            // 
            // KripteksVMB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(970, 753);
            this.Controls.Add(this.toolStripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KripteksVMB";
            this.Text = "KripteksVM";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.KripteksVMB_Activated);
            this.Deactivate += new System.EventHandler(this.KripteksVMB_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KripteksVMB_FormClosing);
            this.Load += new System.EventHandler(this.KripteksVMB_Load);
            this.ResizeEnd += new System.EventHandler(this.KripteksVMB_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.KripteksVMB_SizeChanged);
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.ContentPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.sFormStatus.ResumeLayout(false);
            this.sFormStatus.PerformLayout();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.tabComExplorer.ResumeLayout(false);
            this.tabCEController.ResumeLayout(false);
            this.gbControllerVariables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariables)).EndInit();
            this.gbControllerComm.ResumeLayout(false);
            this.gbControllerComm.PerformLayout();
            this.tabCEApplication.ResumeLayout(false);
            this.tabCEApplication.PerformLayout();
            this.tabCEServer.ResumeLayout(false);
            this.gbSignalRComm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).EndInit();
            this.tabCELog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.Label lblServerStatus_;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Label lblControllerStatus_;
        private System.Windows.Forms.Button btnDisconnectController;
        private System.Windows.Forms.Button btnConnectController;
        private System.Windows.Forms.TabControl tabComExplorer;
        private System.Windows.Forms.TabPage tabCEController;
        private System.Windows.Forms.TabPage tabCEApplication;
        private System.Windows.Forms.TabPage tabCEServer;
        private System.Windows.Forms.DataGridView dgvVariables;
        private System.Windows.Forms.ComboBox cbVariablesSource;
        private System.Windows.Forms.ComboBox cbVariablesType;
        private System.Windows.Forms.GroupBox gbControllerComm;
        private System.Windows.Forms.Label lblAID_;
        private System.Windows.Forms.Label lblSID_;
        private System.Windows.Forms.GroupBox gbControllerVariables;
        private System.Windows.Forms.Label lblAID;
        private System.Windows.Forms.Label lblSID;
        private System.Windows.Forms.Timer tmrFormRefresh;
        private System.Windows.Forms.DataGridView dgvUserList;
        private System.Windows.Forms.GroupBox gbSignalRComm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Force;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.StatusStrip sFormStatus;
        private System.Windows.Forms.ToolStripMenuItem browserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnmsMenuDevTools;
        private System.Windows.Forms.ToolStripMenuItem btnmsMenuShareLink;
        private System.Windows.Forms.ToolStripMenuItem btnmsMenuRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConnectionID;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tsslControllerStatus_;
        private System.Windows.Forms.ToolStripStatusLabel tslControllerStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslSeperator1;
        private System.Windows.Forms.ToolStripStatusLabel tslServerStatus_;
        private System.Windows.Forms.ToolStripStatusLabel tslServerStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslSeperator2;
        private System.Windows.Forms.ToolStripStatusLabel tslClientsStatus_;
        private System.Windows.Forms.ToolStripStatusLabel tslClientsStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslSeperator3;
        private System.Windows.Forms.ToolStripStatusLabel tslElapsedTime;
        private System.Windows.Forms.ToolStripStatusLabel tslSeperator4;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnmsMenuFocusCam;
        private System.Windows.Forms.Label lblTrigValue;
        private System.Windows.Forms.ToolStripMenuItem btnmsMenuFreeCam;
        private System.Windows.Forms.ToolStripMenuItem btnmsMenuFirstPersonCam;
        private System.Windows.Forms.ToolStripMenuItem btnmsMenuGoFullScreen;
        private System.Windows.Forms.ToolStripMenuItem btnmsMenuApplication;
        private System.Windows.Forms.ToolStripMenuItem btnmsMenuApplicationProperties;
        private System.Windows.Forms.ToolStripMenuItem controllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnmsMenuControllerProperties;
        private System.Windows.Forms.Label lblCID;
        private System.Windows.Forms.Label lblCID_;
        public System.Windows.Forms.Label lblATInfo;
        private System.Windows.Forms.Label lblATInfo_;
        public System.Windows.Forms.Label lblATName;
        private System.Windows.Forms.Label lblATName_;
        public System.Windows.Forms.Label lblATAID;
        private System.Windows.Forms.Label lblATAID_;
        public System.Windows.Forms.Label lblATElapsedTime;
        private System.Windows.Forms.Label lblATElapsedTime_;
        private System.Windows.Forms.Label lblATElapsedTimeUnit;
        private System.Windows.Forms.Label lblBeckhoffAMSNetID;
        private System.Windows.Forms.Label lblBeckhoffAMSNetID_;
        private System.Windows.Forms.Label lblBeckhoffPortNo;
        private System.Windows.Forms.Label lblBeckhoffPortNo_;
        private System.Windows.Forms.TabPage tabCELog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnLogClear;
    }
}