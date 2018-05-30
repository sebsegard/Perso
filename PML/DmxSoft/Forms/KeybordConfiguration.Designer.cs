namespace DmxSoft.Forms
{
    partial class KeybordConfiguration
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.KeyCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SceneNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DeleteCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboKey = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_KeyStep = new System.Windows.Forms.TextBox();
            this.btn_KeyStep = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_detect = new System.Windows.Forms.Button();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sceneBrowserCtrl1 = new DmxSoft.Control.SceneBrowserCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyCodeCol,
            this.KeyValueCol,
            this.SceneNameCol,
            this.StopCol,
            this.DeleteCol});
            this.dataGridView1.Location = new System.Drawing.Point(3, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(388, 342);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // KeyCodeCol
            // 
            this.KeyCodeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KeyCodeCol.HeaderText = "Key Code";
            this.KeyCodeCol.Name = "KeyCodeCol";
            this.KeyCodeCol.Visible = false;
            // 
            // KeyValueCol
            // 
            this.KeyValueCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KeyValueCol.HeaderText = "Key value";
            this.KeyValueCol.Name = "KeyValueCol";
            this.KeyValueCol.Visible = false;
            // 
            // SceneNameCol
            // 
            this.SceneNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SceneNameCol.HeaderText = "Scene Name";
            this.SceneNameCol.Name = "SceneNameCol";
            // 
            // StopCol
            // 
            this.StopCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StopCol.HeaderText = "Stop On Key Up";
            this.StopCol.Name = "StopCol";
            this.StopCol.Width = 69;
            // 
            // DeleteCol
            // 
            this.DeleteCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeleteCol.HeaderText = "";
            this.DeleteCol.Name = "DeleteCol";
            this.DeleteCol.Width = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboKey);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(352, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 395);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assigned keys";
            // 
            // comboKey
            // 
            this.comboKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboKey.FormattingEnabled = true;
            this.comboKey.Location = new System.Drawing.Point(6, 19);
            this.comboKey.Name = "comboKey";
            this.comboKey.Size = new System.Drawing.Size(382, 21);
            this.comboKey.TabIndex = 1;
            this.comboKey.SelectedIndexChanged += new System.EventHandler(this.comboKey_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 395);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add key";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_KeyStep);
            this.groupBox5.Controls.Add(this.btn_KeyStep);
            this.groupBox5.Location = new System.Drawing.Point(9, 342);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(322, 47);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Scene Key step";
            // 
            // txt_KeyStep
            // 
            this.txt_KeyStep.Location = new System.Drawing.Point(53, 18);
            this.txt_KeyStep.Name = "txt_KeyStep";
            this.txt_KeyStep.ReadOnly = true;
            this.txt_KeyStep.Size = new System.Drawing.Size(100, 20);
            this.txt_KeyStep.TabIndex = 4;
            // 
            // btn_KeyStep
            // 
            this.btn_KeyStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_KeyStep.Location = new System.Drawing.Point(204, 18);
            this.btn_KeyStep.Name = "btn_KeyStep";
            this.btn_KeyStep.Size = new System.Drawing.Size(75, 23);
            this.btn_KeyStep.TabIndex = 3;
            this.btn_KeyStep.Text = "Replace";
            this.btn_KeyStep.UseVisualStyleBackColor = true;
            this.btn_KeyStep.Click += new System.EventHandler(this.btn_KeyStep_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.btn_add);
            this.groupBox4.Controls.Add(this.btn_detect);
            this.groupBox4.Controls.Add(this.txt_value);
            this.groupBox4.Controls.Add(this.txt_code);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(9, 269);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(322, 67);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Key Detection";
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.Location = new System.Drawing.Point(204, 32);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "Add hot key";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_detect
            // 
            this.btn_detect.Location = new System.Drawing.Point(204, 10);
            this.btn_detect.Name = "btn_detect";
            this.btn_detect.Size = new System.Drawing.Size(75, 23);
            this.btn_detect.TabIndex = 4;
            this.btn_detect.Text = "Detect";
            this.btn_detect.UseVisualStyleBackColor = true;
            this.btn_detect.Click += new System.EventHandler(this.btn_detect_Click);
            this.btn_detect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_detect_KeyDown);
            // 
            // txt_value
            // 
            this.txt_value.Location = new System.Drawing.Point(53, 39);
            this.txt_value.Name = "txt_value";
            this.txt_value.ReadOnly = true;
            this.txt_value.Size = new System.Drawing.Size(100, 20);
            this.txt_value.TabIndex = 3;
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(53, 13);
            this.txt_code.Name = "txt_code";
            this.txt_code.ReadOnly = true;
            this.txt_code.Size = new System.Drawing.Size(100, 20);
            this.txt_code.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.sceneBrowserCtrl1);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 244);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scene selection";
            // 
            // sceneBrowserCtrl1
            // 
            this.sceneBrowserCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneBrowserCtrl1.Location = new System.Drawing.Point(3, 16);
            this.sceneBrowserCtrl1.Name = "sceneBrowserCtrl1";
            this.sceneBrowserCtrl1.Size = new System.Drawing.Size(316, 225);
            this.sceneBrowserCtrl1.TabIndex = 0;
            // 
            // KeybordConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 419);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "KeybordConfiguration";
            this.Text = "Keybord Configuration";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeybordConfiguration_KeyPress);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeybordConfiguration_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_detect;
        private DmxSoft.Control.SceneBrowserCtrl sceneBrowserCtrl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyCodeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyValueCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SceneNameCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn StopCol;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteCol;
        private System.Windows.Forms.ComboBox comboKey;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_KeyStep;
        private System.Windows.Forms.Button btn_KeyStep;
    }
}