namespace DmxSoft.Forms.Midi
{
    partial class ConfForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.keyListCtrl1 = new DmxSoft.Forms.Midi.KeyListCtrl();
            this.lastMidiChangeCtrl1 = new DmxSoft.Forms.Midi.LastMidiChangeCtrl();
            this.midiDeviceCtrl1 = new DmxSoft.Forms.Midi.MidiDeviceCtrl();
            this.atctionListCtrl1 = new DmxSoft.Forms.Midi.AtctionListCtrl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.keyListCtrl1);
            this.splitContainer1.Panel1.Controls.Add(this.lastMidiChangeCtrl1);
            this.splitContainer1.Panel1.Controls.Add(this.midiDeviceCtrl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.atctionListCtrl1);
            this.splitContainer1.Size = new System.Drawing.Size(802, 516);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.TabIndex = 1;
            // 
            // keyListCtrl1
            // 
            this.keyListCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.keyListCtrl1.Location = new System.Drawing.Point(3, 69);
            this.keyListCtrl1.Name = "keyListCtrl1";
            this.keyListCtrl1.Size = new System.Drawing.Size(796, 250);
            this.keyListCtrl1.TabIndex = 2;
            // 
            // lastMidiChangeCtrl1
            // 
            this.lastMidiChangeCtrl1.Location = new System.Drawing.Point(264, 3);
            this.lastMidiChangeCtrl1.Name = "lastMidiChangeCtrl1";
            this.lastMidiChangeCtrl1.Size = new System.Drawing.Size(459, 60);
            this.lastMidiChangeCtrl1.TabIndex = 1;
            // 
            // midiDeviceCtrl1
            // 
            this.midiDeviceCtrl1.Location = new System.Drawing.Point(3, 3);
            this.midiDeviceCtrl1.Name = "midiDeviceCtrl1";
            this.midiDeviceCtrl1.Size = new System.Drawing.Size(255, 60);
            this.midiDeviceCtrl1.TabIndex = 0;
            // 
            // atctionListCtrl1
            // 
            this.atctionListCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.atctionListCtrl1.Location = new System.Drawing.Point(0, 0);
            this.atctionListCtrl1.Name = "atctionListCtrl1";
            this.atctionListCtrl1.Size = new System.Drawing.Size(802, 190);
            this.atctionListCtrl1.TabIndex = 0;
            this.atctionListCtrl1.Visible = false;
            // 
            // ConfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 516);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConfForm";
            this.Text = "Midi";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MidiDeviceCtrl midiDeviceCtrl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private LastMidiChangeCtrl lastMidiChangeCtrl1;
        private KeyListCtrl keyListCtrl1;
        private AtctionListCtrl atctionListCtrl1;

    }
}