namespace KripteksVM
{
    partial class ControllerSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerSettingsForm));
            this.btnControllerSettingsApply = new System.Windows.Forms.Button();
            this.btnControllerPropertiesClose = new System.Windows.Forms.Button();
            this.cbControllerType = new System.Windows.Forms.ComboBox();
            this.tabControllerProperties = new System.Windows.Forms.TabControl();
            this.tabControllerPropertiesArduino = new System.Windows.Forms.TabPage();
            this.tabControllerPropertiesBeckhoff = new System.Windows.Forms.TabPage();
            this.txtBeckhoffPortNo = new System.Windows.Forms.TextBox();
            this.txtBeckhoffAMSNetID = new System.Windows.Forms.TextBox();
            this.lblBeckhoffPortNo = new System.Windows.Forms.Label();
            this.lblBeckhoffAMSNetID = new System.Windows.Forms.Label();
            this.tabControllerPropertiesModbusTCP = new System.Windows.Forms.TabPage();
            this.txtModbusPortNo = new System.Windows.Forms.TextBox();
            this.txtModbusIPAddress = new System.Windows.Forms.TextBox();
            this.lblModbusPortNo = new System.Windows.Forms.Label();
            this.lblModbusIPAddress = new System.Windows.Forms.Label();
            this.txtControllerCycleMs = new System.Windows.Forms.TextBox();
            this.lblControllerCycleMs_ = new System.Windows.Forms.Label();
            this.tabControllerProperties.SuspendLayout();
            this.tabControllerPropertiesBeckhoff.SuspendLayout();
            this.tabControllerPropertiesModbusTCP.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnControllerSettingsApply
            // 
            this.btnControllerSettingsApply.Location = new System.Drawing.Point(12, 511);
            this.btnControllerSettingsApply.Name = "btnControllerSettingsApply";
            this.btnControllerSettingsApply.Size = new System.Drawing.Size(100, 30);
            this.btnControllerSettingsApply.TabIndex = 4;
            this.btnControllerSettingsApply.Text = "Apply";
            this.btnControllerSettingsApply.UseVisualStyleBackColor = true;
            this.btnControllerSettingsApply.Click += new System.EventHandler(this.btnControllerSettingsApply_Click);
            // 
            // btnControllerPropertiesClose
            // 
            this.btnControllerPropertiesClose.Location = new System.Drawing.Point(666, 511);
            this.btnControllerPropertiesClose.Name = "btnControllerPropertiesClose";
            this.btnControllerPropertiesClose.Size = new System.Drawing.Size(100, 30);
            this.btnControllerPropertiesClose.TabIndex = 3;
            this.btnControllerPropertiesClose.Text = "Close";
            this.btnControllerPropertiesClose.UseVisualStyleBackColor = true;
            this.btnControllerPropertiesClose.Click += new System.EventHandler(this.btnControllerPropertiesClose_Click);
            // 
            // cbControllerType
            // 
            this.cbControllerType.FormattingEnabled = true;
            this.cbControllerType.Items.AddRange(new object[] {
            "Arduino",
            "Beckhoff",
            "ModbusTCP"});
            this.cbControllerType.Location = new System.Drawing.Point(12, 12);
            this.cbControllerType.Name = "cbControllerType";
            this.cbControllerType.Size = new System.Drawing.Size(121, 24);
            this.cbControllerType.TabIndex = 2;
            this.cbControllerType.Text = "Controller Type";
            // 
            // tabControllerProperties
            // 
            this.tabControllerProperties.Controls.Add(this.tabControllerPropertiesArduino);
            this.tabControllerProperties.Controls.Add(this.tabControllerPropertiesBeckhoff);
            this.tabControllerProperties.Controls.Add(this.tabControllerPropertiesModbusTCP);
            this.tabControllerProperties.Location = new System.Drawing.Point(12, 42);
            this.tabControllerProperties.Name = "tabControllerProperties";
            this.tabControllerProperties.SelectedIndex = 0;
            this.tabControllerProperties.Size = new System.Drawing.Size(758, 463);
            this.tabControllerProperties.TabIndex = 5;
            // 
            // tabControllerPropertiesArduino
            // 
            this.tabControllerPropertiesArduino.Location = new System.Drawing.Point(4, 25);
            this.tabControllerPropertiesArduino.Name = "tabControllerPropertiesArduino";
            this.tabControllerPropertiesArduino.Padding = new System.Windows.Forms.Padding(3);
            this.tabControllerPropertiesArduino.Size = new System.Drawing.Size(750, 434);
            this.tabControllerPropertiesArduino.TabIndex = 1;
            this.tabControllerPropertiesArduino.Text = "Arduino";
            this.tabControllerPropertiesArduino.UseVisualStyleBackColor = true;
            // 
            // tabControllerPropertiesBeckhoff
            // 
            this.tabControllerPropertiesBeckhoff.Controls.Add(this.txtBeckhoffPortNo);
            this.tabControllerPropertiesBeckhoff.Controls.Add(this.txtBeckhoffAMSNetID);
            this.tabControllerPropertiesBeckhoff.Controls.Add(this.lblBeckhoffPortNo);
            this.tabControllerPropertiesBeckhoff.Controls.Add(this.lblBeckhoffAMSNetID);
            this.tabControllerPropertiesBeckhoff.Location = new System.Drawing.Point(4, 25);
            this.tabControllerPropertiesBeckhoff.Name = "tabControllerPropertiesBeckhoff";
            this.tabControllerPropertiesBeckhoff.Padding = new System.Windows.Forms.Padding(3);
            this.tabControllerPropertiesBeckhoff.Size = new System.Drawing.Size(750, 434);
            this.tabControllerPropertiesBeckhoff.TabIndex = 0;
            this.tabControllerPropertiesBeckhoff.Text = "Beckhoff";
            this.tabControllerPropertiesBeckhoff.UseVisualStyleBackColor = true;
            // 
            // txtBeckhoffPortNo
            // 
            this.txtBeckhoffPortNo.Location = new System.Drawing.Point(86, 46);
            this.txtBeckhoffPortNo.Name = "txtBeckhoffPortNo";
            this.txtBeckhoffPortNo.Size = new System.Drawing.Size(56, 22);
            this.txtBeckhoffPortNo.TabIndex = 2;
            // 
            // txtBeckhoffAMSNetID
            // 
            this.txtBeckhoffAMSNetID.Location = new System.Drawing.Point(86, 19);
            this.txtBeckhoffAMSNetID.Name = "txtBeckhoffAMSNetID";
            this.txtBeckhoffAMSNetID.Size = new System.Drawing.Size(135, 22);
            this.txtBeckhoffAMSNetID.TabIndex = 2;
            // 
            // lblBeckhoffPortNo
            // 
            this.lblBeckhoffPortNo.AutoSize = true;
            this.lblBeckhoffPortNo.Location = new System.Drawing.Point(7, 49);
            this.lblBeckhoffPortNo.Name = "lblBeckhoffPortNo";
            this.lblBeckhoffPortNo.Size = new System.Drawing.Size(52, 16);
            this.lblBeckhoffPortNo.TabIndex = 1;
            this.lblBeckhoffPortNo.Text = "Port No";
            // 
            // lblBeckhoffAMSNetID
            // 
            this.lblBeckhoffAMSNetID.AutoSize = true;
            this.lblBeckhoffAMSNetID.Location = new System.Drawing.Point(7, 22);
            this.lblBeckhoffAMSNetID.Name = "lblBeckhoffAMSNetID";
            this.lblBeckhoffAMSNetID.Size = new System.Drawing.Size(70, 16);
            this.lblBeckhoffAMSNetID.TabIndex = 0;
            this.lblBeckhoffAMSNetID.Text = "AMSNetID";
            // 
            // tabControllerPropertiesModbusTCP
            // 
            this.tabControllerPropertiesModbusTCP.Controls.Add(this.txtModbusPortNo);
            this.tabControllerPropertiesModbusTCP.Controls.Add(this.txtModbusIPAddress);
            this.tabControllerPropertiesModbusTCP.Controls.Add(this.lblModbusPortNo);
            this.tabControllerPropertiesModbusTCP.Controls.Add(this.lblModbusIPAddress);
            this.tabControllerPropertiesModbusTCP.Location = new System.Drawing.Point(4, 25);
            this.tabControllerPropertiesModbusTCP.Name = "tabControllerPropertiesModbusTCP";
            this.tabControllerPropertiesModbusTCP.Size = new System.Drawing.Size(750, 434);
            this.tabControllerPropertiesModbusTCP.TabIndex = 2;
            this.tabControllerPropertiesModbusTCP.Text = "ModbusTCP";
            this.tabControllerPropertiesModbusTCP.UseVisualStyleBackColor = true;
            // 
            // txtModbusPortNo
            // 
            this.txtModbusPortNo.Location = new System.Drawing.Point(86, 46);
            this.txtModbusPortNo.Name = "txtModbusPortNo";
            this.txtModbusPortNo.Size = new System.Drawing.Size(56, 22);
            this.txtModbusPortNo.TabIndex = 5;
            // 
            // txtModbusIPAddress
            // 
            this.txtModbusIPAddress.Location = new System.Drawing.Point(86, 19);
            this.txtModbusIPAddress.Name = "txtModbusIPAddress";
            this.txtModbusIPAddress.Size = new System.Drawing.Size(135, 22);
            this.txtModbusIPAddress.TabIndex = 6;
            // 
            // lblModbusPortNo
            // 
            this.lblModbusPortNo.AutoSize = true;
            this.lblModbusPortNo.Location = new System.Drawing.Point(7, 49);
            this.lblModbusPortNo.Name = "lblModbusPortNo";
            this.lblModbusPortNo.Size = new System.Drawing.Size(52, 16);
            this.lblModbusPortNo.TabIndex = 4;
            this.lblModbusPortNo.Text = "Port No";
            // 
            // lblModbusIPAddress
            // 
            this.lblModbusIPAddress.AutoSize = true;
            this.lblModbusIPAddress.Location = new System.Drawing.Point(7, 22);
            this.lblModbusIPAddress.Name = "lblModbusIPAddress";
            this.lblModbusIPAddress.Size = new System.Drawing.Size(70, 16);
            this.lblModbusIPAddress.TabIndex = 3;
            this.lblModbusIPAddress.Text = "AMSNetID";
            // 
            // txtControllerCycleMs
            // 
            this.txtControllerCycleMs.Location = new System.Drawing.Point(246, 12);
            this.txtControllerCycleMs.Name = "txtControllerCycleMs";
            this.txtControllerCycleMs.Size = new System.Drawing.Size(50, 22);
            this.txtControllerCycleMs.TabIndex = 6;
            // 
            // lblControllerCycleMs_
            // 
            this.lblControllerCycleMs_.AutoSize = true;
            this.lblControllerCycleMs_.Location = new System.Drawing.Point(166, 15);
            this.lblControllerCycleMs_.Name = "lblControllerCycleMs_";
            this.lblControllerCycleMs_.Size = new System.Drawing.Size(70, 16);
            this.lblControllerCycleMs_.TabIndex = 3;
            this.lblControllerCycleMs_.Text = "Cycle (ms)";
            // 
            // ControllerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.lblControllerCycleMs_);
            this.Controls.Add(this.txtControllerCycleMs);
            this.Controls.Add(this.tabControllerProperties);
            this.Controls.Add(this.btnControllerPropertiesClose);
            this.Controls.Add(this.btnControllerSettingsApply);
            this.Controls.Add(this.cbControllerType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControllerSettingsForm";
            this.Text = "Controller Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControllerSettingsForm_FormClosing);
            this.tabControllerProperties.ResumeLayout(false);
            this.tabControllerPropertiesBeckhoff.ResumeLayout(false);
            this.tabControllerPropertiesBeckhoff.PerformLayout();
            this.tabControllerPropertiesModbusTCP.ResumeLayout(false);
            this.tabControllerPropertiesModbusTCP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnControllerSettingsApply;
        private System.Windows.Forms.Button btnControllerPropertiesClose;
        private System.Windows.Forms.ComboBox cbControllerType;
        private System.Windows.Forms.TabControl tabControllerProperties;
        private System.Windows.Forms.TabPage tabControllerPropertiesBeckhoff;
        private System.Windows.Forms.TextBox txtBeckhoffPortNo;
        private System.Windows.Forms.TextBox txtBeckhoffAMSNetID;
        private System.Windows.Forms.Label lblBeckhoffPortNo;
        private System.Windows.Forms.Label lblBeckhoffAMSNetID;
        private System.Windows.Forms.TabPage tabControllerPropertiesArduino;
        private System.Windows.Forms.TextBox txtControllerCycleMs;
        private System.Windows.Forms.Label lblControllerCycleMs_;
        private System.Windows.Forms.TabPage tabControllerPropertiesModbusTCP;
        private System.Windows.Forms.TextBox txtModbusPortNo;
        private System.Windows.Forms.TextBox txtModbusIPAddress;
        private System.Windows.Forms.Label lblModbusPortNo;
        private System.Windows.Forms.Label lblModbusIPAddress;
    }
}