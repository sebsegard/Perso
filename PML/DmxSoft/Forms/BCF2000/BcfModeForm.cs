using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DmxFramework;

namespace DmxSoft.Forms.BCF2000
{
    public partial class BcfModeForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public BcfModeForm()
        {
            InitializeComponent();
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(Framework.Bcf2000.BcfMode.ToArray());
            this.comboBox1.SelectedIndex = DmxFramework.Midi.Bcf2000.CurrentMode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Max = this.comboBox1.Items.Count;
            int Current = this.comboBox1.SelectedIndex;

            Current--;
            if (Current < 0)
                Current = Max - 1;
            this.comboBox1.SelectedIndex = Current;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Max = this.comboBox1.Items.Count;
            int Current = this.comboBox1.SelectedIndex;
            Current++;
            if (Current >= Max)
                Current = 0;
            this.comboBox1.SelectedIndex = Current;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DmxFramework.Midi.Bcf2000.CurrentMode = this.comboBox1.SelectedIndex;
        }
    }
}
