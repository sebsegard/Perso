namespace DmxSoft.Forms
{
    partial class AdvancedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.channelButtonCtrl1 = new DmxSoft.Control.ChannelButtonCtrl();
            this.channelButtonCtrl2 = new DmxSoft.Control.ChannelButtonCtrl();
            this.panTiltCtrl1 = new DmxSoft.Control.PanTiltCtrl();
            this.btn_Scene = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Single = new System.Windows.Forms.ToolStripButton();
            this.btn_Music = new System.Windows.Forms.ToolStripButton();
            this.btn_Automatic = new System.Windows.Forms.ToolStripButton();
            this.btn_Poursuit = new System.Windows.Forms.ToolStripButton();
            this.lbl_status = new System.Windows.Forms.ToolStripLabel();
            this.btn_PresetAuto1 = new System.Windows.Forms.ToolStripButton();
            this.btn_PresetAuto2 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.channelButtonCtrl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.channelButtonCtrl2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panTiltCtrl1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 194);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // channelButtonCtrl1
            // 
            this.channelButtonCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channelButtonCtrl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.channelButtonCtrl1.Location = new System.Drawing.Point(151, 3);
            this.channelButtonCtrl1.Name = "channelButtonCtrl1";
            this.channelButtonCtrl1.Size = new System.Drawing.Size(142, 188);
            this.channelButtonCtrl1.TabIndex = 0;
            // 
            // channelButtonCtrl2
            // 
            this.channelButtonCtrl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channelButtonCtrl2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.channelButtonCtrl2.Location = new System.Drawing.Point(299, 3);
            this.channelButtonCtrl2.Name = "channelButtonCtrl2";
            this.channelButtonCtrl2.Size = new System.Drawing.Size(144, 188);
            this.channelButtonCtrl2.TabIndex = 1;
            // 
            // panTiltCtrl1
            // 
            this.panTiltCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTiltCtrl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panTiltCtrl1.Location = new System.Drawing.Point(3, 3);
            this.panTiltCtrl1.Name = "panTiltCtrl1";
            this.panTiltCtrl1.Size = new System.Drawing.Size(142, 188);
            this.panTiltCtrl1.TabIndex = 2;
            // 
            // btn_Scene
            // 
            this.btn_Scene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Scene.Image = ((System.Drawing.Image)(resources.GetObject("btn_Scene.Image")));
            this.btn_Scene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Scene.Name = "btn_Scene";
            this.btn_Scene.Size = new System.Drawing.Size(45, 22);
            this.btn_Scene.Text = "Scenes";
            this.btn_Scene.Click += new System.EventHandler(this.btn_Scene_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Scene,
            this.btn_Single,
            this.btn_Music,
            this.btn_Automatic,
            this.btn_PresetAuto1,
            this.btn_PresetAuto2,
            this.btn_Poursuit,
            this.lbl_status});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(446, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Single
            // 
            this.btn_Single.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Single.Image = ((System.Drawing.Image)(resources.GetObject("btn_Single.Image")));
            this.btn_Single.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Single.Name = "btn_Single";
            this.btn_Single.Size = new System.Drawing.Size(39, 22);
            this.btn_Single.Text = "Single";
            // 
            // btn_Music
            // 
            this.btn_Music.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Music.Image = ((System.Drawing.Image)(resources.GetObject("btn_Music.Image")));
            this.btn_Music.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Music.Name = "btn_Music";
            this.btn_Music.Size = new System.Drawing.Size(66, 22);
            this.btn_Music.Text = "Music mode";
            this.btn_Music.Click += new System.EventHandler(this.btn_Music_Click);
            // 
            // btn_Automatic
            // 
            this.btn_Automatic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Automatic.Image = ((System.Drawing.Image)(resources.GetObject("btn_Automatic.Image")));
            this.btn_Automatic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Automatic.Name = "btn_Automatic";
            this.btn_Automatic.Size = new System.Drawing.Size(59, 22);
            this.btn_Automatic.Text = "Automatic";
            this.btn_Automatic.Click += new System.EventHandler(this.btn_Automatic_Click);
            // 
            // btn_Poursuit
            // 
            this.btn_Poursuit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Poursuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Poursuit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Poursuit.Image")));
            this.btn_Poursuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Poursuit.Name = "btn_Poursuit";
            this.btn_Poursuit.Size = new System.Drawing.Size(50, 22);
            this.btn_Poursuit.Text = "Poursuit";
            this.btn_Poursuit.Click += new System.EventHandler(this.btn_Poursuit_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(37, 22);
            this.lbl_status.Text = "status";
            this.lbl_status.Visible = false;
            // 
            // btn_PresetAuto1
            // 
            this.btn_PresetAuto1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_PresetAuto1.Image = ((System.Drawing.Image)(resources.GetObject("btn_PresetAuto1.Image")));
            this.btn_PresetAuto1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_PresetAuto1.Name = "btn_PresetAuto1";
            this.btn_PresetAuto1.Size = new System.Drawing.Size(23, 22);
            this.btn_PresetAuto1.Text = "1";
            this.btn_PresetAuto1.ToolTipText = "Preset 1";
            this.btn_PresetAuto1.Click += new System.EventHandler(this.btn_PresetAuto1_Click);
            // 
            // btn_PresetAuto2
            // 
            this.btn_PresetAuto2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_PresetAuto2.Image = ((System.Drawing.Image)(resources.GetObject("btn_PresetAuto2.Image")));
            this.btn_PresetAuto2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_PresetAuto2.Name = "btn_PresetAuto2";
            this.btn_PresetAuto2.Size = new System.Drawing.Size(23, 22);
            this.btn_PresetAuto2.Text = "2";
            this.btn_PresetAuto2.ToolTipText = "Automatic preset 2";
            this.btn_PresetAuto2.Click += new System.EventHandler(this.btn_PresetAuto2_Click);
            // 
            // AdvancedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 222);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedForm";
            this.TabText = "AdvancedForm";
            this.Text = "AdvancedForm";
            this.VisibleChanged += new System.EventHandler(this.AdvancedForm_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DmxSoft.Control.ChannelButtonCtrl channelButtonCtrl1;
        private DmxSoft.Control.ChannelButtonCtrl channelButtonCtrl2;
        private DmxSoft.Control.PanTiltCtrl panTiltCtrl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripButton btn_Scene;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Single;
        private System.Windows.Forms.ToolStripButton btn_Music;
        private System.Windows.Forms.ToolStripButton btn_Poursuit;
        private System.Windows.Forms.ToolStripLabel lbl_status;
        private System.Windows.Forms.ToolStripButton btn_Automatic;
        private System.Windows.Forms.ToolStripButton btn_PresetAuto1;
        private System.Windows.Forms.ToolStripButton btn_PresetAuto2;
    }
}