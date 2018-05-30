namespace DmxSoft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.softToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beatDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.AddAUtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertChannelsInAutomatiqueModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.keyborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.snapshotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.connectKnownMidiDevicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midiConfiguratiobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.connectBCF2000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bCF2000ConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dmxOutPutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SceneExplorerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.bcfModeChoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.softToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(801, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // softToolStripMenuItem
            // 
            this.softToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.toolStripSeparator8,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.softToolStripMenuItem.Name = "softToolStripMenuItem";
            this.softToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.softToolStripMenuItem.Text = "Soft";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "Dmx Address";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(149, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beatDetectionToolStripMenuItem,
            this.automaticModeToolStripMenuItem,
            this.invertChannelsInAutomatiqueModeToolStripMenuItem,
            this.toolStripSeparator4,
            this.keyborToolStripMenuItem,
            this.toolStripSeparator5,
            this.snapshotsToolStripMenuItem,
            this.toolStripSeparator6,
            this.connectKnownMidiDevicesToolStripMenuItem,
            this.midiConfiguratiobToolStripMenuItem,
            this.toolStripSeparator9,
            this.connectBCF2000ToolStripMenuItem,
            this.bCF2000ConfigurationToolStripMenuItem,
            this.bcfModeChoiceToolStripMenuItem});
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configureToolStripMenuItem.Text = "Configuration";
            // 
            // beatDetectionToolStripMenuItem
            // 
            this.beatDetectionToolStripMenuItem.Name = "beatDetectionToolStripMenuItem";
            this.beatDetectionToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.beatDetectionToolStripMenuItem.Text = "Beat detection";
            this.beatDetectionToolStripMenuItem.Click += new System.EventHandler(this.beatDetectionToolStripMenuItem_Click);
            // 
            // automaticModeToolStripMenuItem
            // 
            this.automaticModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.AddAUtoToolStripMenuItem});
            this.automaticModeToolStripMenuItem.Name = "automaticModeToolStripMenuItem";
            this.automaticModeToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.automaticModeToolStripMenuItem.Text = "Automatic mode";
            this.automaticModeToolStripMenuItem.Click += new System.EventHandler(this.automaticModeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(184, 6);
            // 
            // AddAUtoToolStripMenuItem
            // 
            this.AddAUtoToolStripMenuItem.Name = "AddAUtoToolStripMenuItem";
            this.AddAUtoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.AddAUtoToolStripMenuItem.Text = "Add automatic mode";
            this.AddAUtoToolStripMenuItem.Click += new System.EventHandler(this.AddAUtoToolStripMenuItem_Click);
            // 
            // invertChannelsInAutomatiqueModeToolStripMenuItem
            // 
            this.invertChannelsInAutomatiqueModeToolStripMenuItem.Name = "invertChannelsInAutomatiqueModeToolStripMenuItem";
            this.invertChannelsInAutomatiqueModeToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.invertChannelsInAutomatiqueModeToolStripMenuItem.Text = "Invert Channels in Automatique and sound Mode";
            this.invertChannelsInAutomatiqueModeToolStripMenuItem.Click += new System.EventHandler(this.invertChannelsInAutomatiqueModeToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(332, 6);
            // 
            // keyborToolStripMenuItem
            // 
            this.keyborToolStripMenuItem.Name = "keyborToolStripMenuItem";
            this.keyborToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.keyborToolStripMenuItem.Text = "Keybord";
            this.keyborToolStripMenuItem.Click += new System.EventHandler(this.keyborToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(332, 6);
            // 
            // snapshotsToolStripMenuItem
            // 
            this.snapshotsToolStripMenuItem.Name = "snapshotsToolStripMenuItem";
            this.snapshotsToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.snapshotsToolStripMenuItem.Text = "Snapshots";
            this.snapshotsToolStripMenuItem.Click += new System.EventHandler(this.snapshotsToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(332, 6);
            // 
            // connectKnownMidiDevicesToolStripMenuItem
            // 
            this.connectKnownMidiDevicesToolStripMenuItem.Name = "connectKnownMidiDevicesToolStripMenuItem";
            this.connectKnownMidiDevicesToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.connectKnownMidiDevicesToolStripMenuItem.Text = "Connect midi devices";
            this.connectKnownMidiDevicesToolStripMenuItem.Visible = false;
            this.connectKnownMidiDevicesToolStripMenuItem.Click += new System.EventHandler(this.connectKnownMidiDevicesToolStripMenuItem_Click);
            // 
            // midiConfiguratiobToolStripMenuItem
            // 
            this.midiConfiguratiobToolStripMenuItem.Name = "midiConfiguratiobToolStripMenuItem";
            this.midiConfiguratiobToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.midiConfiguratiobToolStripMenuItem.Text = "Midi configuration";
            this.midiConfiguratiobToolStripMenuItem.Visible = false;
            this.midiConfiguratiobToolStripMenuItem.Click += new System.EventHandler(this.midiConfiguratiobToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(332, 6);
            // 
            // connectBCF2000ToolStripMenuItem
            // 
            this.connectBCF2000ToolStripMenuItem.Name = "connectBCF2000ToolStripMenuItem";
            this.connectBCF2000ToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.connectBCF2000ToolStripMenuItem.Text = "Connect BCF2000";
            this.connectBCF2000ToolStripMenuItem.Click += new System.EventHandler(this.connectBCF2000ToolStripMenuItem_Click);
            // 
            // bCF2000ConfigurationToolStripMenuItem
            // 
            this.bCF2000ConfigurationToolStripMenuItem.Name = "bCF2000ConfigurationToolStripMenuItem";
            this.bCF2000ConfigurationToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.bCF2000ConfigurationToolStripMenuItem.Text = "BCF2000 configuration";
            this.bCF2000ConfigurationToolStripMenuItem.Click += new System.EventHandler(this.bCF2000ConfigurationToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dmxOutPutToolStripMenuItem,
            this.explorerToolStripMenuItem,
            this.SceneExplorerMenuItem,
            this.toolStripSeparator2,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator7,
            this.fullScreenToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // dmxOutPutToolStripMenuItem
            // 
            this.dmxOutPutToolStripMenuItem.Name = "dmxOutPutToolStripMenuItem";
            this.dmxOutPutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dmxOutPutToolStripMenuItem.Text = "DmxOutPut";
            this.dmxOutPutToolStripMenuItem.Click += new System.EventHandler(this.dmxOutPutToolStripMenuItem_Click);
            // 
            // explorerToolStripMenuItem
            // 
            this.explorerToolStripMenuItem.Name = "explorerToolStripMenuItem";
            this.explorerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.explorerToolStripMenuItem.Text = "Explorer";
            this.explorerToolStripMenuItem.Click += new System.EventHandler(this.explorerToolStripMenuItem_Click);
            // 
            // SceneExplorerMenuItem
            // 
            this.SceneExplorerMenuItem.Name = "SceneExplorerMenuItem";
            this.SceneExplorerMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SceneExplorerMenuItem.Text = "Scene Explorer";
            this.SceneExplorerMenuItem.Click += new System.EventHandler(this.SceneExplorerMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(149, 6);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fullScreenToolStripMenuItem.Text = "Full screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.AutoSize = true;
            this.dockPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 24);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(801, 321);
            this.dockPanel1.TabIndex = 4;
            // 
            // bcfModeChoiceToolStripMenuItem
            // 
            this.bcfModeChoiceToolStripMenuItem.Name = "bcfModeChoiceToolStripMenuItem";
            this.bcfModeChoiceToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.bcfModeChoiceToolStripMenuItem.Text = "Bcf Mode Choice";
            this.bcfModeChoiceToolStripMenuItem.Click += new System.EventHandler(this.bcfModeChoiceToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(801, 345);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Pimp My Lights";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem softToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dmxOutPutToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem explorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beatDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaticModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertChannelsInAutomatiqueModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SceneExplorerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddAUtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem snapshotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem connectKnownMidiDevicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem midiConfiguratiobToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem connectBCF2000ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bCF2000ConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bcfModeChoiceToolStripMenuItem;
    }
}

