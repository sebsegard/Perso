namespace DmxSoft.Forms
{
    partial class Explorer
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParameterstoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.basicDmxConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedDmxConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.poursuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.musicalDetectiobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InvertTiltStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InvertPanStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(2, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(264, 295);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDetailsToolStripMenuItem,
            this.ParameterstoolStripMenuItem1,
            this.toolStripSeparator1,
            this.basicDmxConsoleToolStripMenuItem,
            this.advancedDmxConsoleToolStripMenuItem,
            this.toolStripSeparator2,
            this.panelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.scenesToolStripMenuItem,
            this.toolStripSeparator4,
            this.poursuitToolStripMenuItem,
            this.toolStripSeparator5,
            this.musicalDetectiobToolStripMenuItem,
            this.InvertTiltStripMenuItem,
            this.InvertPanStripMenuItem,
            this.toolStripSeparator6,
            this.lockToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 320);
            // 
            // viewDetailsToolStripMenuItem
            // 
            this.viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            this.viewDetailsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.viewDetailsToolStripMenuItem.Text = "View details";
            this.viewDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewDetailsToolStripMenuItem_Click);
            // 
            // ParameterstoolStripMenuItem1
            // 
            this.ParameterstoolStripMenuItem1.Name = "ParameterstoolStripMenuItem1";
            this.ParameterstoolStripMenuItem1.Size = new System.Drawing.Size(201, 22);
            this.ParameterstoolStripMenuItem1.Text = "Parameters";
            this.ParameterstoolStripMenuItem1.Click += new System.EventHandler(this.ParameterstoolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // basicDmxConsoleToolStripMenuItem
            // 
            this.basicDmxConsoleToolStripMenuItem.Name = "basicDmxConsoleToolStripMenuItem";
            this.basicDmxConsoleToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.basicDmxConsoleToolStripMenuItem.Text = "Basic dmx console";
            this.basicDmxConsoleToolStripMenuItem.Click += new System.EventHandler(this.basicDmxConsoleToolStripMenuItem_Click);
            // 
            // advancedDmxConsoleToolStripMenuItem
            // 
            this.advancedDmxConsoleToolStripMenuItem.Name = "advancedDmxConsoleToolStripMenuItem";
            this.advancedDmxConsoleToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.advancedDmxConsoleToolStripMenuItem.Text = "Advanced dmx console";
            this.advancedDmxConsoleToolStripMenuItem.Click += new System.EventHandler(this.advancedDmxConsoleToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(198, 6);
            // 
            // scenesToolStripMenuItem
            // 
            this.scenesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sceneToolStripMenuItem,
            this.quickSceneToolStripMenuItem});
            this.scenesToolStripMenuItem.Name = "scenesToolStripMenuItem";
            this.scenesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.scenesToolStripMenuItem.Text = "Scenes Management";
            this.scenesToolStripMenuItem.Click += new System.EventHandler(this.scenesToolStripMenuItem_Click);
            // 
            // panelToolStripMenuItem
            // 
            this.panelToolStripMenuItem.Name = "panelToolStripMenuItem";
            this.panelToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.panelToolStripMenuItem.Text = "Scene Shortcuts";
            this.panelToolStripMenuItem.Click += new System.EventHandler(this.panelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItem1.Text = "Scene Explorer";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(198, 6);
            // 
            // poursuitToolStripMenuItem
            // 
            this.poursuitToolStripMenuItem.Name = "poursuitToolStripMenuItem";
            this.poursuitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.poursuitToolStripMenuItem.Text = "Poursuit";
            this.poursuitToolStripMenuItem.Click += new System.EventHandler(this.poursuitToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(198, 6);
            // 
            // musicalDetectiobToolStripMenuItem
            // 
            this.musicalDetectiobToolStripMenuItem.Name = "musicalDetectiobToolStripMenuItem";
            this.musicalDetectiobToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.musicalDetectiobToolStripMenuItem.Text = "Musical detection";
            this.musicalDetectiobToolStripMenuItem.Click += new System.EventHandler(this.musicalDetectionToolStripMenuItem_Click);
            // 
            // InvertTiltStripMenuItem
            // 
            this.InvertTiltStripMenuItem.Name = "InvertTiltStripMenuItem";
            this.InvertTiltStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.InvertTiltStripMenuItem.Text = "Invert Tilt in auto mode";
            this.InvertTiltStripMenuItem.Click += new System.EventHandler(this.InvertTiltStripMenuItem_Click);
            // 
            // InvertPanStripMenuItem
            // 
            this.InvertPanStripMenuItem.Name = "InvertPanStripMenuItem";
            this.InvertPanStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.InvertPanStripMenuItem.Text = "Invert Pan in auto mode";
            this.InvertPanStripMenuItem.Click += new System.EventHandler(this.InvertPanStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(198, 6);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.lockToolStripMenuItem.Text = "Lock";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // sceneToolStripMenuItem
            // 
            this.sceneToolStripMenuItem.Name = "sceneToolStripMenuItem";
            this.sceneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sceneToolStripMenuItem.Text = "Scene";
            this.sceneToolStripMenuItem.Click += new System.EventHandler(this.sceneToolStripMenuItem_Click);
            // 
            // quickSceneToolStripMenuItem
            // 
            this.quickSceneToolStripMenuItem.Name = "quickSceneToolStripMenuItem";
            this.quickSceneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quickSceneToolStripMenuItem.Text = "Quick Scene";
            this.quickSceneToolStripMenuItem.Click += new System.EventHandler(this.quickSceneToolStripMenuItem_Click);
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(270, 299);
            this.Controls.Add(this.treeView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Explorer";
            this.TabText = "WorkSpace";
            this.Text = "Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Explorer_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem basicDmxConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedDmxConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem scenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem poursuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem musicalDetectiobToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InvertTiltStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InvertPanStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ParameterstoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickSceneToolStripMenuItem;
    }
}