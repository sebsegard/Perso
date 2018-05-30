namespace DmxCreator.Control.Channels
{
    partial class ChanBtn
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
            this.col_Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_Copy = new System.Windows.Forms.DataGridViewLinkColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSeveralRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reworkValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_NbColumns = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_NbLines = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Min,
            this.col_Max,
            this.col_Text,
            this.col_Image,
            this.col_Copy});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(405, 213);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // col_Min
            // 
            this.col_Min.HeaderText = "Min Value";
            this.col_Min.Name = "col_Min";
            // 
            // col_Max
            // 
            this.col_Max.HeaderText = "Max value";
            this.col_Max.Name = "col_Max";
            // 
            // col_Text
            // 
            this.col_Text.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Text.HeaderText = "Text";
            this.col_Text.Name = "col_Text";
            // 
            // col_Image
            // 
            this.col_Image.HeaderText = "Image";
            this.col_Image.Name = "col_Image";
            // 
            // col_Copy
            // 
            this.col_Copy.HeaderText = "Sub channels";
            this.col_Copy.Name = "col_Copy";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRowToolStripMenuItem,
            this.addSeveralRowToolStripMenuItem,
            this.reworkValuesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 70);
            // 
            // addRowToolStripMenuItem
            // 
            this.addRowToolStripMenuItem.Name = "addRowToolStripMenuItem";
            this.addRowToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addRowToolStripMenuItem.Text = "Add row";
            this.addRowToolStripMenuItem.Click += new System.EventHandler(this.addRowToolStripMenuItem_Click);
            // 
            // addSeveralRowToolStripMenuItem
            // 
            this.addSeveralRowToolStripMenuItem.Name = "addSeveralRowToolStripMenuItem";
            this.addSeveralRowToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addSeveralRowToolStripMenuItem.Text = "Add several values";
            this.addSeveralRowToolStripMenuItem.Click += new System.EventHandler(this.addSeveralRowToolStripMenuItem_Click);
            // 
            // reworkValuesToolStripMenuItem
            // 
            this.reworkValuesToolStripMenuItem.Name = "reworkValuesToolStripMenuItem";
            this.reworkValuesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.reworkValuesToolStripMenuItem.Text = "Rework values";
            this.reworkValuesToolStripMenuItem.Click += new System.EventHandler(this.reworkValuesToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of column";
            // 
            // txt_NbColumns
            // 
            this.txt_NbColumns.Location = new System.Drawing.Point(102, 0);
            this.txt_NbColumns.Name = "txt_NbColumns";
            this.txt_NbColumns.Size = new System.Drawing.Size(54, 20);
            this.txt_NbColumns.TabIndex = 2;
            this.txt_NbColumns.TextChanged += new System.EventHandler(this.txt_NbColumns_TextChanged);
            this.txt_NbColumns.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_NbColumns_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of line";
            // 
            // txt_NbLines
            // 
            this.txt_NbLines.Location = new System.Drawing.Point(252, 0);
            this.txt_NbLines.Name = "txt_NbLines";
            this.txt_NbLines.Size = new System.Drawing.Size(54, 20);
            this.txt_NbLines.TabIndex = 4;
            this.txt_NbLines.TextChanged += new System.EventHandler(this.txt_NbLines_TextChanged);
            this.txt_NbLines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_NbLines_KeyDown);
            // 
            // ChanBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_NbLines);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_NbColumns);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ChanBtn";
            this.Size = new System.Drawing.Size(405, 236);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSeveralRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reworkValuesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Max;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Text;
        private System.Windows.Forms.DataGridViewImageColumn col_Image;
        private System.Windows.Forms.DataGridViewLinkColumn col_Copy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_NbColumns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_NbLines;
    }
}
