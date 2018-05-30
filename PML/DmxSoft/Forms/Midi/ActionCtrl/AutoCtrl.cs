using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Midi.Action;

namespace DmxSoft.Forms.Midi.ActionCtrl
{
    public partial class AutoCtrl : UserControl
    {
        AutoPress mAutoPress = null;
        AutoSpeed mAutoSpeed = null;
        
        public AutoCtrl()
        {
            InitializeComponent();
        }

        public void LoadPresetBtn(AutoPress pAutoPress)
        {
            mAutoPress = pAutoPress;
            mAutoSpeed = null;
            this.grp_Preset.Visible = true;
            LoadCombo();
            this.comboBox1.SelectedIndex = mAutoPress.AutoModeNum;
            this.radio_1.Checked = (mAutoPress.PresetNum == 0);
            this.radio_2.Checked = (mAutoPress.PresetNum == 1);
        }

        public void LoadTime(AutoSpeed pAutoSpeed)
        {
            mAutoPress = null;
            mAutoSpeed = pAutoSpeed;
            this.grp_Preset.Visible = false;
            LoadCombo();
            this.comboBox1.SelectedIndex = mAutoSpeed.AutoModeNum;
        }

        private void LoadCombo()
        {
            this.comboBox1.Items.Clear();
            for (int i = 0; i < DmxFramework.Framework.AutomaticMode.Count; i++)
                this.comboBox1.Items.Add("Auto mode " + i);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (mAutoPress != null)
                {
                    mAutoPress.AutoModeNum = this.comboBox1.SelectedIndex;
                    if (this.radio_1.Checked)
                        mAutoPress.PresetNum = 0;
                    else
                        mAutoPress.PresetNum = 1;
                }
                else if (mAutoSpeed != null)
                {
                    mAutoSpeed.AutoModeNum = this.comboBox1.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
