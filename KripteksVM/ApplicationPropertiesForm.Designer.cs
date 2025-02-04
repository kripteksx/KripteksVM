namespace KripteksVM
{
    partial class ApplicationPropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationPropertiesForm));
            this.tabApplicationProperties = new System.Windows.Forms.TabControl();
            this.tabApplicationPropertiesGeneral = new System.Windows.Forms.TabPage();
            this.tabApplicationPropertiesWA = new System.Windows.Forms.TabPage();
            this.tabApplicationPropertiesAW = new System.Windows.Forms.TabPage();
            this.lblAID_ = new System.Windows.Forms.Label();
            this.lblAID = new System.Windows.Forms.Label();
            this.tabApplicationProperties.SuspendLayout();
            this.tabApplicationPropertiesGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabApplicationProperties
            // 
            this.tabApplicationProperties.Controls.Add(this.tabApplicationPropertiesGeneral);
            this.tabApplicationProperties.Controls.Add(this.tabApplicationPropertiesWA);
            this.tabApplicationProperties.Controls.Add(this.tabApplicationPropertiesAW);
            this.tabApplicationProperties.Location = new System.Drawing.Point(12, 12);
            this.tabApplicationProperties.Name = "tabApplicationProperties";
            this.tabApplicationProperties.SelectedIndex = 0;
            this.tabApplicationProperties.Size = new System.Drawing.Size(758, 500);
            this.tabApplicationProperties.TabIndex = 0;
            // 
            // tabApplicationPropertiesGeneral
            // 
            this.tabApplicationPropertiesGeneral.Controls.Add(this.lblAID);
            this.tabApplicationPropertiesGeneral.Controls.Add(this.lblAID_);
            this.tabApplicationPropertiesGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabApplicationPropertiesGeneral.Name = "tabApplicationPropertiesGeneral";
            this.tabApplicationPropertiesGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplicationPropertiesGeneral.Size = new System.Drawing.Size(750, 471);
            this.tabApplicationPropertiesGeneral.TabIndex = 0;
            this.tabApplicationPropertiesGeneral.Text = "General";
            this.tabApplicationPropertiesGeneral.UseVisualStyleBackColor = true;
            // 
            // tabApplicationPropertiesWA
            // 
            this.tabApplicationPropertiesWA.Location = new System.Drawing.Point(4, 25);
            this.tabApplicationPropertiesWA.Name = "tabApplicationPropertiesWA";
            this.tabApplicationPropertiesWA.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplicationPropertiesWA.Size = new System.Drawing.Size(750, 471);
            this.tabApplicationPropertiesWA.TabIndex = 1;
            this.tabApplicationPropertiesWA.Text = "W->A";
            this.tabApplicationPropertiesWA.UseVisualStyleBackColor = true;
            // 
            // tabApplicationPropertiesAW
            // 
            this.tabApplicationPropertiesAW.Location = new System.Drawing.Point(4, 25);
            this.tabApplicationPropertiesAW.Name = "tabApplicationPropertiesAW";
            this.tabApplicationPropertiesAW.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplicationPropertiesAW.Size = new System.Drawing.Size(750, 471);
            this.tabApplicationPropertiesAW.TabIndex = 2;
            this.tabApplicationPropertiesAW.Text = "A->W";
            this.tabApplicationPropertiesAW.UseVisualStyleBackColor = true;
            // 
            // lblAID_
            // 
            this.lblAID_.AutoSize = true;
            this.lblAID_.Location = new System.Drawing.Point(16, 19);
            this.lblAID_.Name = "lblAID_";
            this.lblAID_.Size = new System.Drawing.Size(38, 17);
            this.lblAID_.TabIndex = 3;
            this.lblAID_.Text = "AID :";
            // 
            // lblAID
            // 
            this.lblAID.Location = new System.Drawing.Point(60, 16);
            this.lblAID.Name = "lblAID";
            this.lblAID.Size = new System.Drawing.Size(30, 23);
            this.lblAID.TabIndex = 4;
            this.lblAID.Text = "    ";
            this.lblAID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplicationPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tabApplicationProperties);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ApplicationPropertiesForm";
            this.Text = "Application Properties";
            this.Load += new System.EventHandler(this.ApplicationPropertiesForm_Load);
            this.tabApplicationProperties.ResumeLayout(false);
            this.tabApplicationPropertiesGeneral.ResumeLayout(false);
            this.tabApplicationPropertiesGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabApplicationProperties;
        private System.Windows.Forms.TabPage tabApplicationPropertiesGeneral;
        private System.Windows.Forms.TabPage tabApplicationPropertiesWA;
        private System.Windows.Forms.TabPage tabApplicationPropertiesAW;
        private System.Windows.Forms.Label lblAID_;
        public System.Windows.Forms.Label lblAID;
    }
}