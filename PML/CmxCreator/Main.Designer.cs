namespace DmxCreator
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.workspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_NewW = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_OpenW = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_CloseW = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_SaveW = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_SelectW = new System.Windows.Forms.ToolStripMenuItem();
            this.fixturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmxAddressesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.addCompagnieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.workspaceTree1 = new DmxCreator.Control.WorkspaceTree();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fixtureTree1 = new DmxCreator.Control.FixtureTree();
            this.fixtureConfCtrl1 = new DmxCreator.Control.FixtureConfCtrl();
            this.fixtureCtrl1 = new DmxCreator.Control.FixtureCtrl();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workspaceToolStripMenuItem,
            this.fixturesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(915, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // workspaceToolStripMenuItem
            // 
            this.workspaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_NewW,
            this.menuItem_OpenW,
            this.menuItem_CloseW,
            this.toolStripSeparator1,
            this.menuItem_SaveW,
            this.menuItem_SaveAs,
            this.toolStripSeparator2,
            this.menuItem_SelectW});
            this.workspaceToolStripMenuItem.Name = "workspaceToolStripMenuItem";
            this.workspaceToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.workspaceToolStripMenuItem.Text = "Workspace";
            // 
            // menuItem_NewW
            // 
            this.menuItem_NewW.Name = "menuItem_NewW";
            this.menuItem_NewW.Size = new System.Drawing.Size(164, 22);
            this.menuItem_NewW.Text = "New";
            this.menuItem_NewW.Click += new System.EventHandler(this.menuItem_NewW_Click);
            // 
            // menuItem_OpenW
            // 
            this.menuItem_OpenW.Name = "menuItem_OpenW";
            this.menuItem_OpenW.Size = new System.Drawing.Size(164, 22);
            this.menuItem_OpenW.Text = "Open";
            this.menuItem_OpenW.Click += new System.EventHandler(this.menuItem_OpenW_Click);
            // 
            // menuItem_CloseW
            // 
            this.menuItem_CloseW.Name = "menuItem_CloseW";
            this.menuItem_CloseW.Size = new System.Drawing.Size(164, 22);
            this.menuItem_CloseW.Text = "Close";
            this.menuItem_CloseW.Click += new System.EventHandler(this.menuItem_CloseW_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // menuItem_SaveW
            // 
            this.menuItem_SaveW.Name = "menuItem_SaveW";
            this.menuItem_SaveW.Size = new System.Drawing.Size(164, 22);
            this.menuItem_SaveW.Text = "Save";
            this.menuItem_SaveW.Click += new System.EventHandler(this.menuItem_SaveW_Click);
            // 
            // menuItem_SaveAs
            // 
            this.menuItem_SaveAs.Name = "menuItem_SaveAs";
            this.menuItem_SaveAs.Size = new System.Drawing.Size(164, 22);
            this.menuItem_SaveAs.Text = "Save as";
            this.menuItem_SaveAs.Click += new System.EventHandler(this.menuItem_SaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // menuItem_SelectW
            // 
            this.menuItem_SelectW.Name = "menuItem_SelectW";
            this.menuItem_SelectW.Size = new System.Drawing.Size(164, 22);
            this.menuItem_SelectW.Text = "Select wokspace";
            this.menuItem_SelectW.Click += new System.EventHandler(this.menuItem_SelectW_Click);
            // 
            // fixturesToolStripMenuItem
            // 
            this.fixturesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dmxAddressesToolStripMenuItem,
            this.toolStripSeparator3,
            this.addCompagnieToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fixturesToolStripMenuItem.Name = "fixturesToolStripMenuItem";
            this.fixturesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.fixturesToolStripMenuItem.Text = "Fixtures";
            // 
            // dmxAddressesToolStripMenuItem
            // 
            this.dmxAddressesToolStripMenuItem.Name = "dmxAddressesToolStripMenuItem";
            this.dmxAddressesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.dmxAddressesToolStripMenuItem.Text = "Dmx Addresses";
            this.dmxAddressesToolStripMenuItem.Click += new System.EventHandler(this.dmxAddressesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // addCompagnieToolStripMenuItem
            // 
            this.addCompagnieToolStripMenuItem.Name = "addCompagnieToolStripMenuItem";
            this.addCompagnieToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addCompagnieToolStripMenuItem.Text = "Add compagie";
            this.addCompagnieToolStripMenuItem.Click += new System.EventHandler(this.addCompagnieToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fixtureConfCtrl1);
            this.splitContainer1.Panel2.Controls.Add(this.fixtureCtrl1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 427);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(231, 427);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gold;
            this.tabPage1.Controls.Add(this.workspaceTree1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(223, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Workspace";
            // 
            // workspaceTree1
            // 
            this.workspaceTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspaceTree1.Location = new System.Drawing.Point(3, 3);
            this.workspaceTree1.Name = "workspaceTree1";
            this.workspaceTree1.Size = new System.Drawing.Size(217, 395);
            this.workspaceTree1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gold;
            this.tabPage2.Controls.Add(this.fixtureTree1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(217, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fixtures";
            // 
            // fixtureTree1
            // 
            this.fixtureTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fixtureTree1.Location = new System.Drawing.Point(3, 3);
            this.fixtureTree1.Name = "fixtureTree1";
            this.fixtureTree1.Size = new System.Drawing.Size(211, 375);
            this.fixtureTree1.TabIndex = 0;
            // 
            // fixtureConfCtrl1
            // 
            this.fixtureConfCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fixtureConfCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fixtureConfCtrl1.Name = "fixtureConfCtrl1";
            this.fixtureConfCtrl1.Size = new System.Drawing.Size(680, 427);
            this.fixtureConfCtrl1.TabIndex = 1;
            // 
            // fixtureCtrl1
            // 
            this.fixtureCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fixtureCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fixtureCtrl1.Name = "fixtureCtrl1";
            this.fixtureCtrl1.Size = new System.Drawing.Size(680, 427);
            this.fixtureCtrl1.TabIndex = 0;
            this.fixtureCtrl1.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 451);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Pimp my lights - Configuration";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem workspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_NewW;
        private System.Windows.Forms.ToolStripMenuItem menuItem_OpenW;
        private System.Windows.Forms.ToolStripMenuItem menuItem_CloseW;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SaveW;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SelectW;
        private System.Windows.Forms.ToolStripMenuItem fixturesToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DmxCreator.Control.WorkspaceTree workspaceTree1;
        private DmxCreator.Control.FixtureTree fixtureTree1;
        private System.Windows.Forms.ToolStripMenuItem dmxAddressesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem addCompagnieToolStripMenuItem;
        private DmxCreator.Control.FixtureCtrl fixtureCtrl1;
        private DmxCreator.Control.FixtureConfCtrl fixtureConfCtrl1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;

    }
}

