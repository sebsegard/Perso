namespace DmxSoft.Control
{
    partial class AutoModeConfigCtrl
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_go = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_set = new System.Windows.Forms.Button();
            this.txt_bpmSet = new System.Windows.Forms.TextBox();
            this.txt_bpm = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radio_Progressive = new System.Windows.Forms.RadioButton();
            this.radio_Normal = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btn_SavePreset = new System.Windows.Forms.Button();
            this.btn_Preset1 = new System.Windows.Forms.Button();
            this.btn_Preset2 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_EnableLimit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TiltMax = new System.Windows.Forms.TextBox();
            this.txt_TiltMin = new System.Windows.Forms.TextBox();
            this.txt_PanMax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_PanMin = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_go);
            this.groupBox4.Location = new System.Drawing.Point(303, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(84, 46);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reset";
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(6, 16);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(75, 23);
            this.btn_go.TabIndex = 0;
            this.btn_go.Text = "Go";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_set);
            this.groupBox3.Controls.Add(this.txt_bpmSet);
            this.groupBox3.Controls.Add(this.txt_bpm);
            this.groupBox3.Location = new System.Drawing.Point(172, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(125, 47);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BPM";
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(78, 17);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(39, 23);
            this.btn_set.TabIndex = 2;
            this.btn_set.Text = "Set";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // txt_bpmSet
            // 
            this.txt_bpmSet.Location = new System.Drawing.Point(43, 19);
            this.txt_bpmSet.MaxLength = 3;
            this.txt_bpmSet.Name = "txt_bpmSet";
            this.txt_bpmSet.Size = new System.Drawing.Size(29, 20);
            this.txt_bpmSet.TabIndex = 1;
            this.txt_bpmSet.Text = "123";
            // 
            // txt_bpm
            // 
            this.txt_bpm.Location = new System.Drawing.Point(6, 19);
            this.txt_bpm.Name = "txt_bpm";
            this.txt_bpm.ReadOnly = true;
            this.txt_bpm.Size = new System.Drawing.Size(31, 20);
            this.txt_bpm.TabIndex = 0;
            this.txt_bpm.Text = "123";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radio_Progressive);
            this.groupBox2.Controls.Add(this.radio_Normal);
            this.groupBox2.Location = new System.Drawing.Point(6, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 47);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // radio_Progressive
            // 
            this.radio_Progressive.AutoSize = true;
            this.radio_Progressive.Location = new System.Drawing.Point(71, 21);
            this.radio_Progressive.Name = "radio_Progressive";
            this.radio_Progressive.Size = new System.Drawing.Size(80, 17);
            this.radio_Progressive.TabIndex = 1;
            this.radio_Progressive.Text = "Progressive";
            this.radio_Progressive.UseVisualStyleBackColor = true;
            this.radio_Progressive.CheckedChanged += new System.EventHandler(this.radio_Progressive_CheckedChanged);
            // 
            // radio_Normal
            // 
            this.radio_Normal.AutoSize = true;
            this.radio_Normal.Checked = true;
            this.radio_Normal.Location = new System.Drawing.Point(7, 21);
            this.radio_Normal.Name = "radio_Normal";
            this.radio_Normal.Size = new System.Drawing.Size(58, 17);
            this.radio_Normal.TabIndex = 0;
            this.radio_Normal.TabStop = true;
            this.radio_Normal.Text = "Normal";
            this.radio_Normal.UseVisualStyleBackColor = true;
            this.radio_Normal.CheckedChanged += new System.EventHandler(this.radio_Normal_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Speed";
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(3, 16);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(378, 33);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 10;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // btn_SavePreset
            // 
            this.btn_SavePreset.Location = new System.Drawing.Point(6, 19);
            this.btn_SavePreset.Name = "btn_SavePreset";
            this.btn_SavePreset.Size = new System.Drawing.Size(48, 23);
            this.btn_SavePreset.TabIndex = 8;
            this.btn_SavePreset.Text = "Save";
            this.btn_SavePreset.UseVisualStyleBackColor = true;
            this.btn_SavePreset.Click += new System.EventHandler(this.btn_SavePreset_Click);
            // 
            // btn_Preset1
            // 
            this.btn_Preset1.Location = new System.Drawing.Point(60, 19);
            this.btn_Preset1.Name = "btn_Preset1";
            this.btn_Preset1.Size = new System.Drawing.Size(29, 23);
            this.btn_Preset1.TabIndex = 9;
            this.btn_Preset1.Text = "1";
            this.btn_Preset1.UseVisualStyleBackColor = true;
            this.btn_Preset1.Click += new System.EventHandler(this.btn_Preset1_Click);
            // 
            // btn_Preset2
            // 
            this.btn_Preset2.Location = new System.Drawing.Point(95, 19);
            this.btn_Preset2.Name = "btn_Preset2";
            this.btn_Preset2.Size = new System.Drawing.Size(27, 23);
            this.btn_Preset2.TabIndex = 10;
            this.btn_Preset2.Text = "2";
            this.btn_Preset2.UseVisualStyleBackColor = true;
            this.btn_Preset2.Click += new System.EventHandler(this.btn_Preset2_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_Preset2);
            this.groupBox5.Controls.Add(this.btn_SavePreset);
            this.groupBox5.Controls.Add(this.btn_Preset1);
            this.groupBox5.Location = new System.Drawing.Point(260, 114);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(127, 53);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Preset";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_EnableLimit);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.txt_TiltMax);
            this.groupBox6.Controls.Add(this.txt_TiltMin);
            this.groupBox6.Controls.Add(this.txt_PanMax);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.txt_PanMin);
            this.groupBox6.Location = new System.Drawing.Point(6, 112);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(248, 52);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Limit";
            // 
            // btn_EnableLimit
            // 
            this.btn_EnableLimit.Location = new System.Drawing.Point(181, 21);
            this.btn_EnableLimit.Name = "btn_EnableLimit";
            this.btn_EnableLimit.Size = new System.Drawing.Size(61, 23);
            this.btn_EnableLimit.TabIndex = 11;
            this.btn_EnableLimit.Text = "Enable";
            this.btn_EnableLimit.UseVisualStyleBackColor = true;
            this.btn_EnableLimit.Click += new System.EventHandler(this.btn_EnableLimit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tilt Max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tilt Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pan Max";
            // 
            // txt_TiltMax
            // 
            this.txt_TiltMax.Location = new System.Drawing.Point(131, 31);
            this.txt_TiltMax.Name = "txt_TiltMax";
            this.txt_TiltMax.Size = new System.Drawing.Size(31, 20);
            this.txt_TiltMax.TabIndex = 4;
            this.txt_TiltMax.Text = "255";
            this.txt_TiltMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_TiltMax_KeyUp);
            // 
            // txt_TiltMin
            // 
            this.txt_TiltMin.Location = new System.Drawing.Point(131, 10);
            this.txt_TiltMin.Name = "txt_TiltMin";
            this.txt_TiltMin.Size = new System.Drawing.Size(31, 20);
            this.txt_TiltMin.TabIndex = 3;
            this.txt_TiltMin.Text = "0";
            this.txt_TiltMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_TiltMin_KeyUp);
            // 
            // txt_PanMax
            // 
            this.txt_PanMax.Location = new System.Drawing.Point(52, 31);
            this.txt_PanMax.Name = "txt_PanMax";
            this.txt_PanMax.Size = new System.Drawing.Size(31, 20);
            this.txt_PanMax.TabIndex = 2;
            this.txt_PanMax.Text = "255";
            this.txt_PanMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_PanMax_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pan Min";
            // 
            // txt_PanMin
            // 
            this.txt_PanMin.Location = new System.Drawing.Point(52, 10);
            this.txt_PanMin.Name = "txt_PanMin";
            this.txt_PanMin.Size = new System.Drawing.Size(31, 20);
            this.txt_PanMin.TabIndex = 0;
            this.txt_PanMin.Text = "0";
            this.txt_PanMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_PanMin_KeyUp);
            // 
            // AutoModeConfigCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AutoModeConfigCtrl";
            this.Size = new System.Drawing.Size(395, 170);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.TextBox txt_bpmSet;
        private System.Windows.Forms.TextBox txt_bpm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radio_Progressive;
        private System.Windows.Forms.RadioButton radio_Normal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btn_SavePreset;
        private System.Windows.Forms.Button btn_Preset1;
        private System.Windows.Forms.Button btn_Preset2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TiltMax;
        private System.Windows.Forms.TextBox txt_TiltMin;
        private System.Windows.Forms.TextBox txt_PanMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PanMin;
        private System.Windows.Forms.Button btn_EnableLimit;
    }
}
