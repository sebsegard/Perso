namespace DmxSoft.Forms.BCF2000
{
    partial class BcfFader
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
            this.components = new System.ComponentModel.Container();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.confgureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.trackBar1.Location = new System.Drawing.Point(0, 0);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.RightToLeftLayout = true;
            this.trackBar1.Size = new System.Drawing.Size(45, 53);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 25;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confgureToolStripMenuItem,
            this.configureActionsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 70);
            // 
            // confgureToolStripMenuItem
            // 
            this.confgureToolStripMenuItem.Name = "confgureToolStripMenuItem";
            this.confgureToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.confgureToolStripMenuItem.Text = "Configure Midi";
            this.confgureToolStripMenuItem.Click += new System.EventHandler(this.confgureToolStripMenuItem_Click);
            // 
            // configureActionsToolStripMenuItem
            // 
            this.configureActionsToolStripMenuItem.Name = "configureActionsToolStripMenuItem";
            this.configureActionsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.configureActionsToolStripMenuItem.Text = "Configure Actions";
            this.configureActionsToolStripMenuItem.Click += new System.EventHandler(this.configureActionsToolStripMenuItem_Click);
            // 
            // BcfFader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackBar1);
            this.Name = "BcfFader";
            this.Size = new System.Drawing.Size(47, 56);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem confgureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureActionsToolStripMenuItem;
    }
}
