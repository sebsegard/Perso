namespace DmxCreator.Control.Channels
{
    partial class ChanMain
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.col_ChannelNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chan_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ChanType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_Copy = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_Visibility = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ChannelNum,
            this.chan_Name,
            this.col_ChanType,
            this.col_Copy,
            this.col_Visibility});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(395, 280);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChannelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 26);
            // 
            // addChannelToolStripMenuItem
            // 
            this.addChannelToolStripMenuItem.Name = "addChannelToolStripMenuItem";
            this.addChannelToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addChannelToolStripMenuItem.Text = "Add channel";
            this.addChannelToolStripMenuItem.Click += new System.EventHandler(this.addChannelToolStripMenuItem_Click);
            // 
            // col_ChannelNum
            // 
            this.col_ChannelNum.HeaderText = "Channel Number";
            this.col_ChannelNum.Name = "col_ChannelNum";
            // 
            // chan_Name
            // 
            this.chan_Name.HeaderText = "Name";
            this.chan_Name.Name = "chan_Name";
            this.chan_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_ChanType
            // 
            this.col_ChanType.HeaderText = "Channel type";
            this.col_ChanType.Items.AddRange(new object[] {
            "Pan",
            "Tilt",
            "Basic",
            "buttons",
            "List"});
            this.col_ChanType.Name = "col_ChanType";
            // 
            // col_Copy
            // 
            this.col_Copy.HeaderText = "Copy";
            this.col_Copy.Name = "col_Copy";
            // 
            // col_Visibility
            // 
            this.col_Visibility.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_Visibility.HeaderText = "Hide in control";
            this.col_Visibility.Name = "col_Visibility";
            this.col_Visibility.ToolTipText = "Hide canal in the advanced dmx control";
            this.col_Visibility.Width = 73;
            // 
            // ChanMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "ChanMain";
            this.Size = new System.Drawing.Size(395, 280);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addChannelToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ChannelNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn chan_Name;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_ChanType;
        private System.Windows.Forms.DataGridViewLinkColumn col_Copy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Visibility;
    }
}
