namespace KripteksVM
{
    partial class ControllerPropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerPropertiesForm));
            this.btnControllerPropertiesApply = new System.Windows.Forms.Button();
            this.btnControllerPropertiesClose = new System.Windows.Forms.Button();
            this.cbControllerType = new System.Windows.Forms.ComboBox();
            this.tabControllerProperties = new System.Windows.Forms.TabControl();
            this.tabControllerPropertiesBeckhoff = new System.Windows.Forms.TabPage();
            this.tbBeckhoffPortNo = new System.Windows.Forms.TextBox();
            this.tbBeckhoffAMSNetID = new System.Windows.Forms.TextBox();
            this.lblBeckhoffPortNo = new System.Windows.Forms.Label();
            this.lblBeckhoffAMSNetID = new System.Windows.Forms.Label();
            this.tabControllerPropertiesArduino = new System.Windows.Forms.TabPage();
            this.tbControllerCycleMs = new System.Windows.Forms.TextBox();
            this.lblControllerCycleMs_ = new System.Windows.Forms.Label();
            this.tabControllerProperties.SuspendLayout();
            this.tabControllerPropertiesBeckhoff.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnControllerPropertiesApply
            // 
            this.btnControllerPropertiesApply.Location = new System.Drawing.Point(12, 511);
            this.btnControllerPropertiesApply.Name = "btnControllerPropertiesApply";
            this.btnControllerPropertiesApply.Size = new System.Drawing.Size(100, 30);
            this.btnControllerPropertiesApply.TabIndex = 4;
            this.btnControllerPropertiesApply.Text = "Apply";
            this.btnControllerPropertiesApply.UseVisualStyleBackColor = true;
            this.btnControllerPropertiesApply.Click += new System.EventHandler(this.btnControllerPropertiesApply_Click);
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
            "Beckhoff"});
            this.cbControllerType.Location = new System.Drawing.Point(12, 12);
            this.cbControllerType.Name = "cbControllerType";
            this.cbControllerType.Size = new System.Drawing.Size(121, 24);
            this.cbControllerType.TabIndex = 2;
            this.cbControllerType.Text = "Controller Type";
            // 
            // tabControllerProperties
            // 
            this.tabControllerProperties.Controls.Add(this.tabControllerPropertiesBeckhoff);
            this.tabControllerProperties.Controls.Add(this.tabControllerPropertiesArduino);
            this.tabControllerProperties.Location = new System.Drawing.Point(12, 42);
            this.tabControllerProperties.Name = "tabControllerProperties";
            this.tabControllerProperties.SelectedIndex = 0;
            this.tabControllerProperties.Size = new System.Drawing.Size(758, 463);
            this.tabControllerProperties.TabIndex = 5;
            // 
            // tabControllerPropertiesBeckhoff
            // 
            this.tabControllerPropertiesBeckhoff.Controls.Add(this.tbBeckhoffPortNo);
            this.tabControllerPropertiesBeckhoff.Controls.Add(this.tbBeckhoffAMSNetID);
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
            // tbBeckhoffPortNo
            // 
            this.tbBeckhoffPortNo.Location = new System.Drawing.Point(86, 46);
            this.tbBeckhoffPortNo.Name = "tbBeckhoffPortNo";
            this.tbBeckhoffPortNo.Size = new System.Drawing.Size(56, 22);
            this.tbBeckhoffPortNo.TabIndex = 2;
            // 
            // tbBeckhoffAMSNetID
            // 
            this.tbBeckhoffAMSNetID.Location = new System.Drawing.Point(86, 19);
            this.tbBeckhoffAMSNetID.Name = "tbBeckhoffAMSNetID";
            this.tbBeckhoffAMSNetID.Size = new System.Drawing.Size(135, 22);
            this.tbBeckhoffAMSNetID.TabIndex = 2;
            // 
            // lblBeckhoffPortNo
            // 
            this.lblBeckhoffPortNo.AutoSize = true;
            this.lblBeckhoffPortNo.Location = new System.Drawing.Point(7, 49);
            this.lblBeckhoffPortNo.Name = "lblBeckhoffPortNo";
            this.lblBeckhoffPortNo.Size = new System.Drawing.Size(56, 17);
            this.lblBeckhoffPortNo.TabIndex = 1;
            this.lblBeckhoffPortNo.Text = "Port No";
            // 
            // lblBeckhoffAMSNetID
            // 
            this.lblBeckhoffAMSNetID.AutoSize = true;
            this.lblBeckhoffAMSNetID.Location = new System.Drawing.Point(7, 22);
            this.lblBeckhoffAMSNetID.Name = "lblBeckhoffAMSNetID";
            this.lblBeckhoffAMSNetID.Size = new System.Drawing.Size(72, 17);
            this.lblBeckhoffAMSNetID.TabIndex = 0;
            this.lblBeckhoffAMSNetID.Text = "AMSNetID";
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
            // tbControllerCycleMs
            // 
            this.tbControllerCycleMs.Location = new System.Drawing.Point(246, 12);
            this.tbControllerCycleMs.Name = "tbControllerCycleMs";
            this.tbControllerCycleMs.Size = new System.Drawing.Size(50, 22);
            this.tbControllerCycleMs.TabIndex = 6;
            // 
            // lblControllerCycleMs_
            // 
            this.lblControllerCycleMs_.AutoSize = true;
            this.lblControllerCycleMs_.Location = new System.Drawing.Point(166, 15);
            this.lblControllerCycleMs_.Name = "lblControllerCycleMs_";
            this.lblControllerCycleMs_.Size = new System.Drawing.Size(74, 17);
            this.lblControllerCycleMs_.TabIndex = 3;
            this.lblControllerCycleMs_.Text = "Cycle (ms)";
            // 
            // ControllerPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.lblControllerCycleMs_);
            this.Controls.Add(this.tbControllerCycleMs);
            this.Controls.Add(this.tabControllerProperties);
            this.Controls.Add(this.btnControllerPropertiesClose);
            this.Controls.Add(this.btnControllerPropertiesApply);
            this.Controls.Add(this.cbControllerType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControllerPropertiesForm";
            this.Text = "Controller Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControllerPropertiesForm_FormClosing);
            this.tabControllerProperties.ResumeLayout(false);
            this.tabControllerPropertiesBeckhoff.ResumeLayout(false);
            this.tabControllerPropertiesBeckhoff.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnControllerPropertiesApply;
        private System.Windows.Forms.Button btnControllerPropertiesClose;
        private System.Windows.Forms.ComboBox cbControllerType;
        private System.Windows.Forms.TabControl tabControllerProperties;
        private System.Windows.Forms.TabPage tabControllerPropertiesBeckhoff;
        private System.Windows.Forms.TextBox tbBeckhoffPortNo;
        private System.Windows.Forms.TextBox tbBeckhoffAMSNetID;
        private System.Windows.Forms.Label lblBeckhoffPortNo;
        private System.Windows.Forms.Label lblBeckhoffAMSNetID;
        private System.Windows.Forms.TabPage tabControllerPropertiesArduino;
        private System.Windows.Forms.TextBox tbControllerCycleMs;
        private System.Windows.Forms.Label lblControllerCycleMs_;
    }
}