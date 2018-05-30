namespace DmxSoft.Forms.Midi.ActionCtrl
{
    partial class AutoCtrl
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grp_Preset = new System.Windows.Forms.GroupBox();
            this.radio_1 = new System.Windows.Forms.RadioButton();
            this.radio_2 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.grp_Preset.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automatic mode";
            // 
            // grp_Preset
            // 
            this.grp_Preset.Controls.Add(this.radio_2);
            this.grp_Preset.Controls.Add(this.radio_1);
            this.grp_Preset.Location = new System.Drawing.Point(3, 70);
            this.grp_Preset.Name = "grp_Preset";
            this.grp_Preset.Size = new System.Drawing.Size(266, 65);
            this.grp_Preset.TabIndex = 2;
            this.grp_Preset.TabStop = false;
            this.grp_Preset.Text = "Preset";
            // 
            // radio_1
            // 
            this.radio_1.AutoSize = true;
            this.radio_1.Location = new System.Drawing.Point(56, 19);
            this.radio_1.Name = "radio_1";
            this.radio_1.Size = new System.Drawing.Size(64, 17);
            this.radio_1.TabIndex = 0;
            this.radio_1.TabStop = true;
            this.radio_1.Text = "Preset 1";
            this.radio_1.UseVisualStyleBackColor = true;
            // 
            // radio_2
            // 
            this.radio_2.AutoSize = true;
            this.radio_2.Location = new System.Drawing.Point(56, 42);
            this.radio_2.Name = "radio_2";
            this.radio_2.Size = new System.Drawing.Size(64, 17);
            this.radio_2.TabIndex = 1;
            this.radio_2.TabStop = true;
            this.radio_2.Text = "Preset 2";
            this.radio_2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(254, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // AutoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grp_Preset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "AutoCtrl";
            this.Size = new System.Drawing.Size(272, 205);
            this.groupBox1.ResumeLayout(false);
            this.grp_Preset.ResumeLayout(false);
            this.grp_Preset.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grp_Preset;
        private System.Windows.Forms.RadioButton radio_2;
        private System.Windows.Forms.RadioButton radio_1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
