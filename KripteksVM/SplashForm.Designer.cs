namespace KripteksVM
{
    partial class SplashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.lblKripteksVM = new System.Windows.Forms.Label();
            this.tmrInit = new System.Windows.Forms.Timer(this.components);
            this.lblInitStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblKripteksVM
            // 
            this.lblKripteksVM.AutoSize = true;
            this.lblKripteksVM.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKripteksVM.ForeColor = System.Drawing.SystemColors.Control;
            this.lblKripteksVM.Location = new System.Drawing.Point(141, 83);
            this.lblKripteksVM.Name = "lblKripteksVM";
            this.lblKripteksVM.Size = new System.Drawing.Size(159, 32);
            this.lblKripteksVM.TabIndex = 1;
            this.lblKripteksVM.Text = "KripteksVM";
            // 
            // tmrInit
            // 
            this.tmrInit.Enabled = true;
            this.tmrInit.Interval = 2000;
            this.tmrInit.Tick += new System.EventHandler(this.tmrInit_Tick);
            // 
            // lblInitStatus
            // 
            this.lblInitStatus.AutoSize = true;
            this.lblInitStatus.ForeColor = System.Drawing.Color.Red;
            this.lblInitStatus.Location = new System.Drawing.Point(120, 159);
            this.lblInitStatus.Name = "lblInitStatus";
            this.lblInitStatus.Size = new System.Drawing.Size(73, 16);
            this.lblInitStatus.TabIndex = 2;
            this.lblInitStatus.Text = "initializing...";
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(450, 200);
            this.Controls.Add(this.lblInitStatus);
            this.Controls.Add(this.lblKripteksVM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashForm";
            this.Opacity = 0.7D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SplashForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKripteksVM;
        private System.Windows.Forms.Timer tmrInit;
        private System.Windows.Forms.Label lblInitStatus;
    }
}