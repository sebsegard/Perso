using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Control
{
    public partial class AutoModeConfigCtrl : UserControl
    {
        DmxFramework.AutoMode.AutoMode mAutoMode;
        bool mSavePreset = false;
        bool mLoading = false;
        
        public AutoModeConfigCtrl()
        {
            InitializeComponent();
        }

        public void SetAutoMode(DmxFramework.AutoMode.AutoMode pAutoMode)
        {
            mAutoMode = pAutoMode;
            mLoading = true;
            this.trackBar1.Minimum = DmxFramework.AutoMode.AutoMode.MinTime / 100;
            this.trackBar1.Maximum = DmxFramework.AutoMode.AutoMode.MaxTime / 100;
            this.trackBar1.Value = mAutoMode.Time / 100;
            this.radio_Progressive.Checked = mAutoMode.Progressive;

            this.txt_PanMin.Text = mAutoMode.PanMin.ToString();
            this.txt_PanMax.Text = mAutoMode.PanMax.ToString();
            this.txt_TiltMin.Text = mAutoMode.TiltMin.ToString();
            this.txt_TiltMax.Text = mAutoMode.TiltMax.ToString();

            if (mAutoMode.LimitEnabled)
                this.btn_EnableLimit.Text = "Disable";
            else
                this.btn_EnableLimit.Text = "Enable";

            mLoading = false;


            mAutoMode.OnAutoModePresetStateChanged += new DmxFramework.AutoMode.OnAutoModePresetStateChangedEvent(mAutoMode_OnAutoModePresetStateChanged);
   
        }

        void mAutoMode_OnAutoModePresetStateChanged(DmxFramework.AutoMode.AutoMode pAutoMode, DmxFramework.AutoMode.AutoPreset pAutoPreset, bool pEnabled)
        {
            if (pAutoMode == mAutoMode)
                SetPreset(pAutoPreset);
        }

        private void radio_Progressive_CheckedChanged(object sender, EventArgs e)
        {
            if (mLoading)
                return;
            
            if (radio_Progressive.Checked && !mAutoMode.Progressive)
                mAutoMode.Progressive = true;
        }

        private void radio_Normal_CheckedChanged(object sender, EventArgs e)
        {
            if (mLoading)
                return;

            if (radio_Normal.Checked && mAutoMode.Progressive)
                mAutoMode.Progressive = false;

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (mLoading)
                return;
            
            mAutoMode.Time = this.trackBar1.Value * 100;

            int bpm = (60000 / mAutoMode.Time);
            this.txt_bpm.Text = bpm + "";

        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            SetBpm();
        }

        private void SetBpm()
        {
            int bpm = 0;
            if (!int.TryParse(this.txt_bpmSet.Text, out bpm))
                return;


            mAutoMode.Time = 60000 / bpm;
            bpm = (60000 / mAutoMode.Time);
            this.txt_bpm.Text = bpm + "";

            mLoading = true;

            this.trackBar1.Value = mAutoMode.Time / 100;
            mLoading = false;

        }

        private void txt_bpmSet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SetBpm();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            mAutoMode.Reset();
        }

        private void btn_EnableLimit_Click(object sender, EventArgs e)
        {
            if (mAutoMode.LimitEnabled)
            {
                mAutoMode.LimitEnabled = false;
                btn_EnableLimit.Text = "Enable";
            }
            else
            {
                mAutoMode.LimitEnabled = true;
                btn_EnableLimit.Text = "Disable";
            }
        }

        private void txt_PanMin_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                    mAutoMode.PanMin = Convert.ToInt16(this.txt_PanMin.Text);
            }
            catch { }
        }

        private void txt_TiltMin_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                    mAutoMode.TiltMin = Convert.ToInt16(this.txt_TiltMin.Text);
            }
            catch { }
        }

        private void txt_PanMax_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                    mAutoMode.PanMax = Convert.ToInt16(this.txt_PanMax.Text);
            }
            catch { }
        }

        private void txt_TiltMax_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                    mAutoMode.TiltMax = Convert.ToInt16(this.txt_TiltMax.Text);
            }
            catch { }
        }

        private void btn_SavePreset_Click(object sender, EventArgs e)
        {
            mSavePreset = true;
        }

        private void btn_Preset1_Click(object sender, EventArgs e)
        {
            if (mSavePreset)
            {
                mSavePreset = false;
                mAutoMode.Preset1.Progressive = mAutoMode.Progressive;
                mAutoMode.Preset1.Time = mAutoMode.Time;
            }
            else
            {
                mLoading = true;

                //SetPreset(mAutoMode.Preset1);
                mAutoMode.SetPreset(mAutoMode.Preset1);

                mLoading = false;
            }

        }

        private void btn_Preset2_Click(object sender, EventArgs e)
        {
            if (mSavePreset)
            {
                mSavePreset = false;
                mAutoMode.Preset2.Progressive = mAutoMode.Progressive;
                mAutoMode.Preset2.Time = mAutoMode.Time;
            }
            else
            {
                //SetPreset(mAutoMode.Preset2);
                mAutoMode.SetPreset(mAutoMode.Preset2);
            }
        }

        void SetPreset(DmxFramework.AutoMode.AutoPreset pPreset)
        {
            

            mLoading = true;
            this.trackBar1.Value = mAutoMode.Time / 100;
            this.radio_Progressive.Checked = mAutoMode.Progressive;
            this.radio_Normal.Checked = !mAutoMode.Progressive;
            int bpm = (60000 / mAutoMode.Time);
            this.txt_bpm.Text = bpm.ToString();
            mLoading = false;
        }
    }
}
