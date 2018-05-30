namespace DmxSoft.Control
{
    partial class SceneEditorCtrlr
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Properties = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chk_loop = new System.Windows.Forms.CheckBox();
            this.chk_PlayAttStart = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_Musical = new System.Windows.Forms.RadioButton();
            this.chk_Manual = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Category = new System.Windows.Forms.TextBox();
            this.txt_WaitTime = new System.Windows.Forms.TextBox();
            this.txt_StepTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_SceneName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tab_Step2 = new System.Windows.Forms.TabPage();
            this.stepEditorCtrl1 = new DmxSoft.Control.StepEditorCtrl();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.chk_KeyBeat = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tab_Properties.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tab_Step2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Properties);
            this.tabControl1.Controls.Add(this.tab_Step2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(539, 405);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_Properties
            // 
            this.tab_Properties.Controls.Add(this.groupBox4);
            this.tab_Properties.Controls.Add(this.groupBox3);
            this.tab_Properties.Controls.Add(this.groupBox2);
            this.tab_Properties.Controls.Add(this.groupBox1);
            this.tab_Properties.Location = new System.Drawing.Point(4, 22);
            this.tab_Properties.Name = "tab_Properties";
            this.tab_Properties.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Properties.Size = new System.Drawing.Size(531, 379);
            this.tab_Properties.TabIndex = 0;
            this.tab_Properties.Text = "Properties";
            this.tab_Properties.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.chk_loop);
            this.groupBox4.Controls.Add(this.chk_PlayAttStart);
            this.groupBox4.Location = new System.Drawing.Point(312, 73);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 73);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Start ";
            // 
            // chk_loop
            // 
            this.chk_loop.AutoSize = true;
            this.chk_loop.Location = new System.Drawing.Point(21, 42);
            this.chk_loop.Name = "chk_loop";
            this.chk_loop.Size = new System.Drawing.Size(50, 17);
            this.chk_loop.TabIndex = 8;
            this.chk_loop.Text = "Loop";
            this.chk_loop.UseVisualStyleBackColor = true;
            this.chk_loop.CheckedChanged += new System.EventHandler(this.chk_loop_CheckedChanged);
            // 
            // chk_PlayAttStart
            // 
            this.chk_PlayAttStart.AutoSize = true;
            this.chk_PlayAttStart.Location = new System.Drawing.Point(21, 20);
            this.chk_PlayAttStart.Name = "chk_PlayAttStart";
            this.chk_PlayAttStart.Size = new System.Drawing.Size(144, 17);
            this.chk_PlayAttStart.TabIndex = 0;
            this.chk_PlayAttStart.Text = "Play at pimp my light start";
            this.chk_PlayAttStart.UseVisualStyleBackColor = true;
            this.chk_PlayAttStart.CheckedChanged += new System.EventHandler(this.chk_PlayAttStart_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.treeView1);
            this.groupBox3.Location = new System.Drawing.Point(6, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(519, 221);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Channels";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(3, 16);
            this.treeView1.Name = "treeView1";
            this.treeView1.PathSeparator = "/";
            this.treeView1.Size = new System.Drawing.Size(513, 202);
            this.treeView1.TabIndex = 2;
            this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(312, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 62);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(132, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Play";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chk_KeyBeat);
            this.groupBox1.Controls.Add(this.chk_Musical);
            this.groupBox1.Controls.Add(this.chk_Manual);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_Category);
            this.groupBox1.Controls.Add(this.txt_WaitTime);
            this.groupBox1.Controls.Add(this.txt_StepTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_SceneName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // chk_Musical
            // 
            this.chk_Musical.AutoSize = true;
            this.chk_Musical.Location = new System.Drawing.Point(93, 64);
            this.chk_Musical.Name = "chk_Musical";
            this.chk_Musical.Size = new System.Drawing.Size(78, 17);
            this.chk_Musical.TabIndex = 9;
            this.chk_Musical.TabStop = true;
            this.chk_Musical.Text = "Music Beat";
            this.chk_Musical.UseVisualStyleBackColor = true;
            this.chk_Musical.CheckedChanged += new System.EventHandler(this.chk_Musical_CheckedChanged);
            // 
            // chk_Manual
            // 
            this.chk_Manual.AutoSize = true;
            this.chk_Manual.Location = new System.Drawing.Point(188, 65);
            this.chk_Manual.Name = "chk_Manual";
            this.chk_Manual.Size = new System.Drawing.Size(60, 17);
            this.chk_Manual.TabIndex = 8;
            this.chk_Manual.TabStop = true;
            this.chk_Manual.Text = "Manual";
            this.chk_Manual.UseVisualStyleBackColor = true;
            this.chk_Manual.CheckedChanged += new System.EventHandler(this.chk_Manual_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Category";
            // 
            // txt_Category
            // 
            this.txt_Category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Category.Location = new System.Drawing.Point(65, 42);
            this.txt_Category.Name = "txt_Category";
            this.txt_Category.Size = new System.Drawing.Size(229, 20);
            this.txt_Category.TabIndex = 6;
            this.txt_Category.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Category_KeyDown);
            this.txt_Category.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // txt_WaitTime
            // 
            this.txt_WaitTime.Location = new System.Drawing.Point(216, 114);
            this.txt_WaitTime.Name = "txt_WaitTime";
            this.txt_WaitTime.Size = new System.Drawing.Size(46, 20);
            this.txt_WaitTime.TabIndex = 5;
            this.txt_WaitTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_WaitTime_KeyDown);
            this.txt_WaitTime.Leave += new System.EventHandler(this.txt_WaitTime_Leave);
            // 
            // txt_StepTime
            // 
            this.txt_StepTime.Location = new System.Drawing.Point(216, 88);
            this.txt_StepTime.Name = "txt_StepTime";
            this.txt_StepTime.Size = new System.Drawing.Size(46, 20);
            this.txt_StepTime.TabIndex = 4;
            this.txt_StepTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_StepTime_KeyDown);
            this.txt_StepTime.Leave += new System.EventHandler(this.txt_StepTime_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Step time";
            // 
            // txt_SceneName
            // 
            this.txt_SceneName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SceneName.Location = new System.Drawing.Point(65, 16);
            this.txt_SceneName.Name = "txt_SceneName";
            this.txt_SceneName.Size = new System.Drawing.Size(229, 20);
            this.txt_SceneName.TabIndex = 1;
            this.txt_SceneName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SceneName_KeyDown);
            this.txt_SceneName.Leave += new System.EventHandler(this.txt_SceneName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Wait time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name ";
            // 
            // tab_Step2
            // 
            this.tab_Step2.Controls.Add(this.stepEditorCtrl1);
            this.tab_Step2.Controls.Add(this.dataGridView2);
            this.tab_Step2.Location = new System.Drawing.Point(4, 22);
            this.tab_Step2.Name = "tab_Step2";
            this.tab_Step2.Size = new System.Drawing.Size(531, 379);
            this.tab_Step2.TabIndex = 2;
            this.tab_Step2.Text = "Step";
            this.tab_Step2.UseVisualStyleBackColor = true;
            // 
            // stepEditorCtrl1
            // 
            this.stepEditorCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepEditorCtrl1.Location = new System.Drawing.Point(0, 0);
            this.stepEditorCtrl1.Name = "stepEditorCtrl1";
            this.stepEditorCtrl1.Size = new System.Drawing.Size(531, 379);
            this.stepEditorCtrl1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Size = new System.Drawing.Size(531, 379);
            this.dataGridView2.TabIndex = 0;
            // 
            // chk_KeyBeat
            // 
            this.chk_KeyBeat.AutoSize = true;
            this.chk_KeyBeat.Location = new System.Drawing.Point(9, 64);
            this.chk_KeyBeat.Name = "chk_KeyBeat";
            this.chk_KeyBeat.Size = new System.Drawing.Size(68, 17);
            this.chk_KeyBeat.TabIndex = 10;
            this.chk_KeyBeat.TabStop = true;
            this.chk_KeyBeat.Text = "Key Beat";
            this.chk_KeyBeat.UseVisualStyleBackColor = true;
            this.chk_KeyBeat.CheckedChanged += new System.EventHandler(this.chk_KeyBeat_CheckedChanged);
            // 
            // SceneEditorCtrlr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "SceneEditorCtrlr";
            this.Size = new System.Drawing.Size(539, 405);
            this.tabControl1.ResumeLayout(false);
            this.tab_Properties.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tab_Step2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Properties;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_WaitTime;
        private System.Windows.Forms.TextBox txt_StepTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SceneName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tab_Step2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Category;
        private StepEditorCtrl stepEditorCtrl1;
        private System.Windows.Forms.CheckBox chk_loop;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chk_PlayAttStart;
        private System.Windows.Forms.RadioButton chk_Manual;
        private System.Windows.Forms.RadioButton chk_Musical;
        private System.Windows.Forms.RadioButton chk_KeyBeat;
    }
}
