namespace DmxSoft.Forms
{
    partial class FixtureParameters
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabChannelParameters = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listChannel = new System.Windows.Forms.ListBox();
            this.propertyGridChannel = new System.Windows.Forms.PropertyGrid();
            this.tabAutoMode = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listAutoMode = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_Pan = new System.Windows.Forms.CheckBox();
            this.chk_Tilt = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabChannelParameters.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabAutoMode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabChannelParameters);
            this.tabControl.Controls.Add(this.tabAutoMode);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(516, 266);
            this.tabControl.TabIndex = 0;
            // 
            // tabChannelParameters
            // 
            this.tabChannelParameters.Controls.Add(this.splitContainer1);
            this.tabChannelParameters.Location = new System.Drawing.Point(4, 22);
            this.tabChannelParameters.Name = "tabChannelParameters";
            this.tabChannelParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabChannelParameters.Size = new System.Drawing.Size(508, 240);
            this.tabChannelParameters.TabIndex = 0;
            this.tabChannelParameters.Text = "Channel parameters";
            this.tabChannelParameters.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listChannel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGridChannel);
            this.splitContainer1.Size = new System.Drawing.Size(502, 234);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.TabIndex = 0;
            // 
            // listChannel
            // 
            this.listChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listChannel.FormattingEnabled = true;
            this.listChannel.Location = new System.Drawing.Point(0, 0);
            this.listChannel.Name = "listChannel";
            this.listChannel.Size = new System.Drawing.Size(167, 225);
            this.listChannel.TabIndex = 1;
            this.listChannel.SelectedIndexChanged += new System.EventHandler(this.listChannel_SelectedIndexChanged);
            // 
            // propertyGridChannel
            // 
            this.propertyGridChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridChannel.Location = new System.Drawing.Point(0, 0);
            this.propertyGridChannel.Name = "propertyGridChannel";
            this.propertyGridChannel.Size = new System.Drawing.Size(331, 234);
            this.propertyGridChannel.TabIndex = 0;
            // 
            // tabAutoMode
            // 
            this.tabAutoMode.Controls.Add(this.groupBox2);
            this.tabAutoMode.Controls.Add(this.groupBox1);
            this.tabAutoMode.Location = new System.Drawing.Point(4, 22);
            this.tabAutoMode.Name = "tabAutoMode";
            this.tabAutoMode.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutoMode.Size = new System.Drawing.Size(508, 240);
            this.tabAutoMode.TabIndex = 1;
            this.tabAutoMode.Text = "Automatique mode";
            this.tabAutoMode.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listAutoMode);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automatique group";
            // 
            // listAutoMode
            // 
            this.listAutoMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAutoMode.FormattingEnabled = true;
            this.listAutoMode.Location = new System.Drawing.Point(3, 16);
            this.listAutoMode.Name = "listAutoMode";
            this.listAutoMode.Size = new System.Drawing.Size(202, 199);
            this.listAutoMode.TabIndex = 0;
            this.listAutoMode.SelectedIndexChanged += new System.EventHandler(this.listAutoMode_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_Tilt);
            this.groupBox2.Controls.Add(this.chk_Pan);
            this.groupBox2.Location = new System.Drawing.Point(222, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 226);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channel inversion (if enabled)";
            // 
            // chk_Pan
            // 
            this.chk_Pan.AutoSize = true;
            this.chk_Pan.Location = new System.Drawing.Point(7, 29);
            this.chk_Pan.Name = "chk_Pan";
            this.chk_Pan.Size = new System.Drawing.Size(45, 17);
            this.chk_Pan.TabIndex = 0;
            this.chk_Pan.Text = "Pan";
            this.chk_Pan.UseVisualStyleBackColor = true;
            this.chk_Pan.CheckedChanged += new System.EventHandler(this.chk_Pan_CheckedChanged);
            // 
            // chk_Tilt
            // 
            this.chk_Tilt.AutoSize = true;
            this.chk_Tilt.Location = new System.Drawing.Point(6, 52);
            this.chk_Tilt.Name = "chk_Tilt";
            this.chk_Tilt.Size = new System.Drawing.Size(40, 17);
            this.chk_Tilt.TabIndex = 1;
            this.chk_Tilt.Text = "Tilt";
            this.chk_Tilt.UseVisualStyleBackColor = true;
            this.chk_Tilt.CheckedChanged += new System.EventHandler(this.chk_Tilt_CheckedChanged);
            // 
            // FixtureParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 266);
            this.Controls.Add(this.tabControl);
            this.Name = "FixtureParameters";
            this.Text = "FixtureParameters";
            this.tabControl.ResumeLayout(false);
            this.tabChannelParameters.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabAutoMode.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabChannelParameters;
        private System.Windows.Forms.TabPage tabAutoMode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listChannel;
        private System.Windows.Forms.PropertyGrid propertyGridChannel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listAutoMode;
        private System.Windows.Forms.CheckBox chk_Tilt;
        private System.Windows.Forms.CheckBox chk_Pan;
    }
}