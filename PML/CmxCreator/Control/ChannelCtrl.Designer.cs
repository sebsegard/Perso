namespace DmxCreator.Control
{
    partial class ChannelCtrl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Channels = new System.Windows.Forms.TabPage();
            this.chanMain1 = new DmxCreator.Control.Channels.ChanMain();
            this.tabControl1.SuspendLayout();
            this.tab_Channels.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Channels);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 357);
            this.tabControl1.TabIndex = 3;
            // 
            // tab_Channels
            // 
            this.tab_Channels.Controls.Add(this.chanMain1);
            this.tab_Channels.Location = new System.Drawing.Point(4, 22);
            this.tab_Channels.Name = "tab_Channels";
            this.tab_Channels.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Channels.Size = new System.Drawing.Size(570, 331);
            this.tab_Channels.TabIndex = 0;
            this.tab_Channels.Text = "DMX Channels";
            this.tab_Channels.UseVisualStyleBackColor = true;
            // 
            // chanMain1
            // 
            this.chanMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chanMain1.Location = new System.Drawing.Point(3, 3);
            this.chanMain1.Name = "chanMain1";
            this.chanMain1.Size = new System.Drawing.Size(564, 325);
            this.chanMain1.TabIndex = 0;
            // 
            // ChannelCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ChannelCtrl";
            this.Size = new System.Drawing.Size(578, 357);
            this.tabControl1.ResumeLayout(false);
            this.tab_Channels.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Channels;
        private DmxCreator.Control.Channels.ChanMain chanMain1;
    }
}
