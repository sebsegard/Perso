namespace DmxSoft.Forms.Midi.ActionCtrl
{
    partial class ScenePlyerCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fullTreeCtrl1 = new DmxSoft.Control.FullTreeCtrl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fullTreeCtrl1
            // 
            this.fullTreeCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fullTreeCtrl1.CheckedChannels = null;
            this.fullTreeCtrl1.CheckedScenes = null;
            this.fullTreeCtrl1.HideNonBtnChannel = false;
            this.fullTreeCtrl1.LoadChannel = false;
            this.fullTreeCtrl1.LoadScene = true;
            this.fullTreeCtrl1.Location = new System.Drawing.Point(3, 3);
            this.fullTreeCtrl1.MultiSelection = false;
            this.fullTreeCtrl1.Name = "fullTreeCtrl1";
            this.fullTreeCtrl1.SelectedChannel = null;
            this.fullTreeCtrl1.SelectedScene = null;
            this.fullTreeCtrl1.Size = new System.Drawing.Size(297, 205);
            this.fullTreeCtrl1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 214);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(297, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(113, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ScenePlyerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.fullTreeCtrl1);
            this.Name = "ScenePlyerCtrl";
            this.Size = new System.Drawing.Size(303, 265);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DmxSoft.Control.FullTreeCtrl fullTreeCtrl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}
