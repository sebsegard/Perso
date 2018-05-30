using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Forms
{
    public partial class BeatDetectionConfiguration : Form
    {
        DmxFramework.Sound.BeatDetection mBeatDetection;
        
        public BeatDetectionConfiguration(DmxFramework.Sound.BeatDetection pBeatDetection)
        {
            
            InitializeComponent();
            
            mBeatDetection = pBeatDetection;
            trackBar1.Value = mBeatDetection.Value;
            mBeatDetection.waveMeter.OnVolumeChanged += new DmxFramework.Sound.OnVolumeChangedHandler(mWaveMeter_OnVolumeChanged);
            mBeatDetection.OnBeatChanged += new DmxFramework.Sound.OnBeatChangedHandler(mBeatDetection_OnBeatChanged);
            mBeatDetection.Start();

            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(mBeatDetection.waveMeter.Interfaces);
            this.comboBox1.SelectedIndex = mBeatDetection.waveMeter.SelectedInterface;

        }

        void mWaveMeter_OnVolumeChanged(int pValue)
        {
            this.progressBar1.Value = pValue;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            mBeatDetection.Value = trackBar1.Value;
        }

        void mBeatDetection_OnBeatChanged(bool pActive)
        {
            if (pActive)
                this.lbl_Beat.BackColor = Color.Red;
            else
                this.lbl_Beat.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control) ;
        }

        private void BeatDetectionConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            mBeatDetection.Stop();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == mBeatDetection.waveMeter.SelectedInterface)
                return;

            mBeatDetection.waveMeter.SelectedInterface = this.comboBox1.SelectedIndex;

        }
    }
}