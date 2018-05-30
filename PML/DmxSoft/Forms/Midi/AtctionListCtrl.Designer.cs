namespace DmxSoft.Forms.Midi
{
    partial class AtctionListCtrl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.list_Action = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.cmb_AddAction = new System.Windows.Forms.ComboBox();
            this.actionDescriptionCtrl1 = new DmxSoft.Forms.Midi.ActionDescriptionCtrl();
            this.autoCtrl1 = new DmxSoft.Forms.Midi.ActionCtrl.AutoCtrl();
            this.scenePlyerCtrl1 = new DmxSoft.Forms.Midi.ActionCtrl.ScenePlyerCtrl();
            this.copyCtrl1 = new DmxSoft.Forms.Midi.ActionCtrl.CopyCtrl();
            this.btn_uRemoveSelected = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.actionDescriptionCtrl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.autoCtrl1);
            this.splitContainer1.Panel2.Controls.Add(this.scenePlyerCtrl1);
            this.splitContainer1.Panel2.Controls.Add(this.copyCtrl1);
            this.splitContainer1.Size = new System.Drawing.Size(780, 377);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.list_Action);
            this.groupBox2.Location = new System.Drawing.Point(7, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 241);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action list";
            // 
            // list_Action
            // 
            this.list_Action.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Action.FormattingEnabled = true;
            this.list_Action.Location = new System.Drawing.Point(3, 16);
            this.list_Action.Name = "list_Action";
            this.list_Action.Size = new System.Drawing.Size(194, 222);
            this.list_Action.TabIndex = 0;
            this.list_Action.SelectedIndexChanged += new System.EventHandler(this.list_Action_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_uRemoveSelected);
            this.groupBox1.Controls.Add(this.btn_Add);
            this.groupBox1.Controls.Add(this.cmb_AddAction);
            this.groupBox1.Location = new System.Drawing.Point(7, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Action";
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.Location = new System.Drawing.Point(119, 44);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // cmb_AddAction
            // 
            this.cmb_AddAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_AddAction.FormattingEnabled = true;
            this.cmb_AddAction.Location = new System.Drawing.Point(3, 19);
            this.cmb_AddAction.Name = "cmb_AddAction";
            this.cmb_AddAction.Size = new System.Drawing.Size(194, 21);
            this.cmb_AddAction.TabIndex = 0;
            // 
            // actionDescriptionCtrl1
            // 
            this.actionDescriptionCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.actionDescriptionCtrl1.Location = new System.Drawing.Point(7, 3);
            this.actionDescriptionCtrl1.Name = "actionDescriptionCtrl1";
            this.actionDescriptionCtrl1.Size = new System.Drawing.Size(200, 46);
            this.actionDescriptionCtrl1.TabIndex = 0;
            // 
            // autoCtrl1
            // 
            this.autoCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoCtrl1.Location = new System.Drawing.Point(0, 0);
            this.autoCtrl1.Name = "autoCtrl1";
            this.autoCtrl1.Size = new System.Drawing.Size(566, 377);
            this.autoCtrl1.TabIndex = 2;
            this.autoCtrl1.Visible = false;
            // 
            // scenePlyerCtrl1
            // 
            this.scenePlyerCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scenePlyerCtrl1.Location = new System.Drawing.Point(0, 0);
            this.scenePlyerCtrl1.Name = "scenePlyerCtrl1";
            this.scenePlyerCtrl1.Size = new System.Drawing.Size(566, 377);
            this.scenePlyerCtrl1.TabIndex = 1;
            this.scenePlyerCtrl1.Visible = false;
            // 
            // copyCtrl1
            // 
            this.copyCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyCtrl1.Location = new System.Drawing.Point(0, 0);
            this.copyCtrl1.Name = "copyCtrl1";
            this.copyCtrl1.Size = new System.Drawing.Size(566, 377);
            this.copyCtrl1.TabIndex = 0;
            this.copyCtrl1.Visible = false;
            // 
            // btn_uRemoveSelected
            // 
            this.btn_uRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_uRemoveSelected.Location = new System.Drawing.Point(6, 43);
            this.btn_uRemoveSelected.Name = "btn_uRemoveSelected";
            this.btn_uRemoveSelected.Size = new System.Drawing.Size(75, 23);
            this.btn_uRemoveSelected.TabIndex = 1;
            this.btn_uRemoveSelected.Text = "Remove";
            this.btn_uRemoveSelected.UseVisualStyleBackColor = true;
            this.btn_uRemoveSelected.Click += new System.EventHandler(this.btn_uRemoveSelected_Click);
            // 
            // AtctionListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "AtctionListCtrl";
            this.Size = new System.Drawing.Size(780, 377);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ActionDescriptionCtrl actionDescriptionCtrl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox list_Action;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ComboBox cmb_AddAction;
        private DmxSoft.Forms.Midi.ActionCtrl.CopyCtrl copyCtrl1;
        private DmxSoft.Forms.Midi.ActionCtrl.ScenePlyerCtrl scenePlyerCtrl1;
        private DmxSoft.Forms.Midi.ActionCtrl.AutoCtrl autoCtrl1;
        private System.Windows.Forms.Button btn_uRemoveSelected;
    }
}
