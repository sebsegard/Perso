namespace DmxSoft.Forms.BCF2000
{
    partial class BCF2000
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridAssign = new System.Windows.Forms.DataGridView();
            this.colAControl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colADesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colASet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lastMidiChangeCtrl1 = new DmxSoft.Forms.Midi.LastMidiChangeCtrl();
            this.midiDeviceCtrl1 = new DmxSoft.Forms.Midi.MidiDeviceCtrl();
            this.dataGridView_Conf = new System.Windows.Forms.DataGridView();
            this.colControl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommmand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.atctionListCtrl1 = new DmxSoft.Forms.Midi.AtctionListCtrl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAssign)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Conf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1417, 576);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1409, 547);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Assignement";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(87, 16);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(205, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Template";
            // 
            // dataGridAssign
            // 
            this.dataGridAssign.AllowUserToAddRows = false;
            this.dataGridAssign.AllowUserToDeleteRows = false;
            this.dataGridAssign.AllowUserToResizeRows = false;
            this.dataGridAssign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAssign.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAControl,
            this.colADesc,
            this.colASet});
            this.dataGridAssign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAssign.Location = new System.Drawing.Point(0, 0);
            this.dataGridAssign.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridAssign.Name = "dataGridAssign";
            this.dataGridAssign.RowHeadersVisible = false;
            this.dataGridAssign.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridAssign.Size = new System.Drawing.Size(468, 497);
            this.dataGridAssign.TabIndex = 1;
            this.dataGridAssign.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAssign_CellContentClick);
            // 
            // colAControl
            // 
            this.colAControl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAControl.HeaderText = "Control";
            this.colAControl.Name = "colAControl";
            this.colAControl.ReadOnly = true;
            this.colAControl.Width = 78;
            // 
            // colADesc
            // 
            this.colADesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colADesc.HeaderText = "Description";
            this.colADesc.Name = "colADesc";
            this.colADesc.ReadOnly = true;
            this.colADesc.Width = 104;
            // 
            // colASet
            // 
            this.colASet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colASet.HeaderText = "";
            this.colASet.Name = "colASet";
            this.colASet.ReadOnly = true;
            this.colASet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colASet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colASet.Text = "Set Value";
            this.colASet.Width = 19;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lastMidiChangeCtrl1);
            this.tabPage2.Controls.Add(this.midiDeviceCtrl1);
            this.tabPage2.Controls.Add(this.dataGridView_Conf);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(964, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lastMidiChangeCtrl1
            // 
            this.lastMidiChangeCtrl1.Location = new System.Drawing.Point(336, 4);
            this.lastMidiChangeCtrl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lastMidiChangeCtrl1.Name = "lastMidiChangeCtrl1";
            this.lastMidiChangeCtrl1.Size = new System.Drawing.Size(612, 98);
            this.lastMidiChangeCtrl1.TabIndex = 2;
            // 
            // midiDeviceCtrl1
            // 
            this.midiDeviceCtrl1.Location = new System.Drawing.Point(4, 7);
            this.midiDeviceCtrl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.midiDeviceCtrl1.Name = "midiDeviceCtrl1";
            this.midiDeviceCtrl1.Size = new System.Drawing.Size(324, 95);
            this.midiDeviceCtrl1.TabIndex = 1;
            // 
            // dataGridView_Conf
            // 
            this.dataGridView_Conf.AllowUserToAddRows = false;
            this.dataGridView_Conf.AllowUserToDeleteRows = false;
            this.dataGridView_Conf.AllowUserToResizeRows = false;
            this.dataGridView_Conf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Conf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Conf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colControl,
            this.colDevice,
            this.colCommmand,
            this.colChannel,
            this.colData1,
            this.colSet});
            this.dataGridView_Conf.Location = new System.Drawing.Point(0, 110);
            this.dataGridView_Conf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_Conf.Name = "dataGridView_Conf";
            this.dataGridView_Conf.RowHeadersVisible = false;
            this.dataGridView_Conf.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_Conf.Size = new System.Drawing.Size(957, 324);
            this.dataGridView_Conf.TabIndex = 0;
            this.dataGridView_Conf.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Conf_CellContentClick);
            // 
            // colControl
            // 
            this.colControl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colControl.HeaderText = "Control";
            this.colControl.Name = "colControl";
            this.colControl.ReadOnly = true;
            // 
            // colDevice
            // 
            this.colDevice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDevice.HeaderText = "Device";
            this.colDevice.Name = "colDevice";
            this.colDevice.ReadOnly = true;
            this.colDevice.Width = 76;
            // 
            // colCommmand
            // 
            this.colCommmand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCommmand.HeaderText = "Command";
            this.colCommmand.Name = "colCommmand";
            this.colCommmand.ReadOnly = true;
            this.colCommmand.Width = 96;
            // 
            // colChannel
            // 
            this.colChannel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colChannel.HeaderText = "Channel";
            this.colChannel.Name = "colChannel";
            this.colChannel.ReadOnly = true;
            this.colChannel.Width = 85;
            // 
            // colData1
            // 
            this.colData1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colData1.HeaderText = "data1";
            this.colData1.Name = "colData1";
            this.colData1.ReadOnly = true;
            this.colData1.Width = 69;
            // 
            // colSet
            // 
            this.colSet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSet.HeaderText = "";
            this.colSet.Name = "colSet";
            this.colSet.ReadOnly = true;
            this.colSet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSet.Text = "Set Value";
            this.colSet.Width = 19;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 47);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridAssign);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.atctionListCtrl1);
            this.splitContainer1.Size = new System.Drawing.Size(1406, 497);
            this.splitContainer1.SplitterDistance = 468;
            this.splitContainer1.TabIndex = 4;
            // 
            // atctionListCtrl1
            // 
            this.atctionListCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.atctionListCtrl1.Location = new System.Drawing.Point(0, 0);
            this.atctionListCtrl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.atctionListCtrl1.Name = "atctionListCtrl1";
            this.atctionListCtrl1.Size = new System.Drawing.Size(934, 497);
            this.atctionListCtrl1.TabIndex = 0;
            this.atctionListCtrl1.Visible = false;
            // 
            // BCF2000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 576);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BCF2000";
            this.Text = "BCF2000";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAssign)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Conf)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView_Conf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommmand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData1;
        private System.Windows.Forms.DataGridViewButtonColumn colSet;
        private System.Windows.Forms.DataGridView dataGridAssign;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colADesc;
        private System.Windows.Forms.DataGridViewButtonColumn colASet;
        private Midi.LastMidiChangeCtrl lastMidiChangeCtrl1;
        private Midi.MidiDeviceCtrl midiDeviceCtrl1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Midi.AtctionListCtrl atctionListCtrl1;

    }
}