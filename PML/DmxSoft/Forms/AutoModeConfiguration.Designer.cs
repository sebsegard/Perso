namespace DmxSoft.Forms
{
    partial class AutoModeConfiguration
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
            this.autoModeConfigCtrl1 = new DmxSoft.Control.AutoModeConfigCtrl();
            this.SuspendLayout();
            // 
            // autoModeConfigCtrl1
            // 
            this.autoModeConfigCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoModeConfigCtrl1.Location = new System.Drawing.Point(0, 0);
            this.autoModeConfigCtrl1.Name = "autoModeConfigCtrl1";
            this.autoModeConfigCtrl1.Size = new System.Drawing.Size(388, 170);
            this.autoModeConfigCtrl1.TabIndex = 0;
            // 
            // AutoModeConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 170);
            this.Controls.Add(this.autoModeConfigCtrl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoModeConfiguration";
            this.Text = "Automatic Mode";
            this.ResumeLayout(false);

        }

        #endregion

        private DmxSoft.Control.AutoModeConfigCtrl autoModeConfigCtrl1;

    }
}