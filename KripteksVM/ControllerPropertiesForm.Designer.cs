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
            this.btnControllerPropertiesSave = new System.Windows.Forms.Button();
            this.btnControllerPropertiesCancel = new System.Windows.Forms.Button();
            this.cbControllerType = new System.Windows.Forms.ComboBox();
            this.tabControllerProperties = new System.Windows.Forms.TabControl();
            this.tabControllerPropertiesBeckhoff = new System.Windows.Forms.TabPage();
            this.tbBeckhoffPortNo = new System.Windows.Forms.TextBox();
            this.tbBeckhoffAMSNetID = new System.Windows.Forms.TextBox();
            this.lblBeckhoffPortNo = new System.Windows.Forms.Label();
            this.lblBeckhoffAMSNetID = new System.Windows.Forms.Label();
            this.tabControllerPropertiesArduino = new System.Windows.Forms.TabPage();
            this.tabControllerProperties.SuspendLayout();
            this.tabControllerPropertiesBeckhoff.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnControllerPropertiesSave
            // 
            this.btnControllerPropertiesSave.Location = new System.Drawing.Point(12, 511);
            this.btnControllerPropertiesSave.Name = "btnControllerPropertiesSave";
            this.btnControllerPropertiesSave.Size = new System.Drawing.Size(100, 30);
            this.btnControllerPropertiesSave.TabIndex = 4;
            this.btnControllerPropertiesSave.Text = "Save";
            this.btnControllerPropertiesSave.UseVisualStyleBackColor = true;
            this.btnControllerPropertiesSave.Click += new System.EventHandler(this.btnControllerPropertiesSave_Click);
            // 
            // btnControllerPropertiesCancel
            // 
            this.btnControllerPropertiesCancel.Location = new System.Drawing.Point(666, 511);
            this.btnControllerPropertiesCancel.Name = "btnControllerPropertiesCancel";
            this.btnControllerPropertiesCancel.Size = new System.Drawing.Size(100, 30);
            this.btnControllerPropertiesCancel.TabIndex = 3;
            this.btnControllerPropertiesCancel.Text = "Cancel";
            this.btnControllerPropertiesCancel.UseVisualStyleBackColor = true;
            this.btnControllerPropertiesCancel.Click += new System.EventHandler(this.btnControllerPropertiesCancel_Click);
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
            // PropertiesControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tabControllerProperties);
            this.Controls.Add(this.btnControllerPropertiesCancel);
            this.Controls.Add(this.btnControllerPropertiesSave);
            this.Controls.Add(this.cbControllerType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PropertiesControllerForm";
            this.Text = "Controller Properties";
            this.tabControllerProperties.ResumeLayout(false);
            this.tabControllerPropertiesBeckhoff.ResumeLayout(false);
            this.tabControllerPropertiesBeckhoff.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnControllerPropertiesSave;
        private System.Windows.Forms.Button btnControllerPropertiesCancel;
        private System.Windows.Forms.ComboBox cbControllerType;
        private System.Windows.Forms.TabControl tabControllerProperties;
        private System.Windows.Forms.TabPage tabControllerPropertiesBeckhoff;
        private System.Windows.Forms.TextBox tbBeckhoffPortNo;
        private System.Windows.Forms.TextBox tbBeckhoffAMSNetID;
        private System.Windows.Forms.Label lblBeckhoffPortNo;
        private System.Windows.Forms.Label lblBeckhoffAMSNetID;
        private System.Windows.Forms.TabPage tabControllerPropertiesArduino;
    }
}