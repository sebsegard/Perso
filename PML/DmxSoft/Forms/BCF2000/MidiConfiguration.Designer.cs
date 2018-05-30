namespace DmxSoft.Forms.BCF2000
{
    partial class MidiConfiguration
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
            this.ChanMidiValue = new DmxSoft.Forms.Midi.LastMidiChangeCtrl();
            this.CtrlMidiValues = new DmxSoft.Forms.Midi.LastMidiChangeCtrl();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChanMidiValue
            // 
            this.ChanMidiValue.Location = new System.Drawing.Point(12, 108);
            this.ChanMidiValue.Name = "ChanMidiValue";
            this.ChanMidiValue.Size = new System.Drawing.Size(464, 80);
            this.ChanMidiValue.TabIndex = 0;
            // 
            // CtrlMidiValues
            // 
            this.CtrlMidiValues.Location = new System.Drawing.Point(12, 12);
            this.CtrlMidiValues.Name = "CtrlMidiValues";
            this.CtrlMidiValues.Size = new System.Drawing.Size(464, 80);
            this.CtrlMidiValues.TabIndex = 1;
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(482, 124);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(86, 52);
            this.btn_Apply.TabIndex = 2;
            this.btn_Apply.Text = "Use these values";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(401, 229);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(482, 229);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // MidiConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 264);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.CtrlMidiValues);
            this.Controls.Add(this.ChanMidiValue);
            this.Name = "MidiConfiguration";
            this.Text = "MidiConfiguration";
            this.ResumeLayout(false);

        }

        #endregion

        private DmxSoft.Forms.Midi.LastMidiChangeCtrl ChanMidiValue;
        private DmxSoft.Forms.Midi.LastMidiChangeCtrl CtrlMidiValues;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_Cancel;
    }
}