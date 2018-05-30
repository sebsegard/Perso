namespace DmxSoft.Forms.BCF2000
{
    partial class BcfControlAssignement
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
            this.atctionListCtrl1 = new DmxSoft.Forms.Midi.AtctionListCtrl();
            this.SuspendLayout();
            // 
            // atctionListCtrl1
            // 
            this.atctionListCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.atctionListCtrl1.Location = new System.Drawing.Point(0, 0);
            this.atctionListCtrl1.Name = "atctionListCtrl1";
            this.atctionListCtrl1.Size = new System.Drawing.Size(841, 435);
            this.atctionListCtrl1.TabIndex = 0;
            // 
            // BcfControlAssignement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 435);
            this.Controls.Add(this.atctionListCtrl1);
            this.Name = "BcfControlAssignement";
            this.Text = "BcfControlAssignement";
            this.ResumeLayout(false);

        }

        #endregion

        private Midi.AtctionListCtrl atctionListCtrl1;
    }
}