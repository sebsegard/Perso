using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DmxFramework;
using DmxFramework.Fixtures;
using DmxFramework.Channels;

namespace DmxSoft.Forms
{
    public partial class AdvancedForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        Fixture mFixture;
        bool mWasVisible;
        Color mDefaultBtnColor;

        public delegate void delegate_AutModeoStateChanged(bool pBewState);

        private delegate_AutModeoStateChanged MyAutomodeStateChangedDelegate;

        public delegate void delegate_SoundModeStateChanged(bool pBewState);

        private delegate_SoundModeStateChanged MySoundModeStateChangedDelegate;


        public AdvancedForm(Fixture pFixture)
        {
            mFixture = pFixture;
            InitializeComponent();
            MySoundModeStateChangedDelegate = new delegate_SoundModeStateChanged(SoundModeChanged);
            if (mFixture.Channels == null || mFixture.Channels.Count == 0)
                return;

            mWasVisible = false;

            mDefaultBtnColor = this.btn_Music.BackColor;


            this.TabText = pFixture.Name;
            this.Text = pFixture.Name;

            //reset layout
            this.tableLayoutPanel1.Controls.Clear();
            this.tableLayoutPanel1.ColumnCount = 0;
            this.tableLayoutPanel1.ColumnStyles.Clear();

            Channel Pan = mFixture.PanChannel;
            Channel Tilt = mFixture.TiltChannel;

            bool HasPanTilt = (Pan != null && Tilt != null);

            if (HasPanTilt)
                this.tableLayoutPanel1.ColumnCount = pFixture.Channels.Count - 1;
            else
                this.tableLayoutPanel1.ColumnCount = pFixture.Channels.Count;

            float width = 100 / pFixture.Channels.Count;

            if (HasPanTilt)
            {
                Control.PanTiltCtrl pan = new DmxSoft.Control.PanTiltCtrl();
                pan.Dock = DockStyle.Fill;
                pan.SetChannel(Pan, Tilt);
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, width));
                this.tableLayoutPanel1.Controls.Add(pan);
                
            }
            else
            {
                this.btn_Automatic.Visible = false;
                this.btn_Music.Visible = false;
                this.btn_PresetAuto1.Visible = false;
                this.btn_PresetAuto2.Visible = false;
            }

            //determine if the fixture has a pan/tilt ...
            foreach (Channel chan in mFixture.Channels)
            {
                if (HasPanTilt && (chan.Function == ChannelFunction.Pan || chan.Function == ChannelFunction.Tilt))
                    continue;

                if (chan.Function == ChannelFunction.Btn)
                {
                    Control.ChannelButtonCtrl ctrl = new DmxSoft.Control.ChannelButtonCtrl();
                    ctrl.SetChannel(chan);
                    ctrl.Dock = DockStyle.Fill;
                    this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, width));
                    this.tableLayoutPanel1.Controls.Add(ctrl);

                }
                else if (chan.Function == ChannelFunction.List)
                {
                    Control.ListCtrl ctrl = new DmxSoft.Control.ListCtrl();
                    ctrl.SetChannel(chan);
                    ctrl.Dock = DockStyle.Fill;
                    this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, width));
                    this.tableLayoutPanel1.Controls.Add(ctrl);

                }
                else
                {
                    Control.DmxOutputCtrl ctrl = new DmxSoft.Control.DmxOutputCtrl(chan);
                    ctrl.Dock = DockStyle.Fill;
                    this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, ctrl.MinimumSize.Width));
                    this.tableLayoutPanel1.Controls.Add(ctrl);
                }
            }

            if (mFixture.Type == FixtureType.Virtual)
            {
                this.btn_Poursuit.Visible = false;
            }
            else
            {
                if(((RealFixture)mFixture).Poursuite.IsActive)
                    this.btn_Poursuit.BackColor = Color.NavajoWhite;
            }


            if (mFixture.IsMusicalDetection)
                this.btn_Music.BackColor = Color.NavajoWhite;

            mFixture.OnBeatDetectionStateChanged += new OnBeatDetectionStateChangedHandler(mFixture_OnBeatDetectionStateChanged);

            if (mFixture.IsAutoMode)
                this.btn_Automatic.BackColor = Color.NavajoWhite;

            mFixture.OnAutoModeStateChanged += new OnAutoModeStateChangedHandler(mFixture_OnAutoModeStateChanged); ;

        }

        void mFixture_OnBeatDetectionStateChanged(bool pNewState)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(MySoundModeStateChangedDelegate, pNewState);
            else
                SoundModeChanged(pNewState);
        }


        void SoundModeChanged(bool pNewState)
        {
            if (pNewState)
                this.btn_Music.BackColor = Color.NavajoWhite;
            else
                this.btn_Music.BackColor = mDefaultBtnColor;
        }




        void mFixture_OnAutoModeStateChanged(bool pNewState)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(MyAutomodeStateChangedDelegate, pNewState);
            else
                AutoModeChanged(pNewState);
        }

        void AutoModeChanged(bool pNewState)
        {
            if (pNewState)
                this.btn_Automatic.BackColor = Color.NavajoWhite;
            else
                this.btn_Automatic.BackColor = mDefaultBtnColor;
        }


        /*Channel GetPan()
        {
            foreach (Channel chan in mFixture.Channels)
                if (chan.Function == ChannelFunction.Pan)
                    return chan;
            return null;
        }

        Channel GetTilt()
        {
            foreach (Channel chan in mFixture.Channels)
                if (chan.Function == ChannelFunction.Tilt)
                    return chan;
            return null;
        }*/

        private void AdvancedForm_VisibleChanged(object sender, EventArgs e)
        {
            if (mWasVisible && !this.Visible)
            {
                
            }
            else if (!mWasVisible && this.Visible)
            {

            }
        }

        private void btn_Scene_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.ScenePlayer dlg = new ScenePlayer(mFixture);
                dlg.DockPanel = this.DockPanel;
                dlg.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Float;
                dlg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error",ex.Message,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_Poursuit_Click(object sender, EventArgs e)
        {

        }

        private void btn_Music_Click(object sender, EventArgs e)
        {
            if (mFixture.IsMusicalDetection)
                mFixture.StopMusicalDetection();
            else
                mFixture.StartMusicalDetection();
        }

        private void btn_Automatic_Click(object sender, EventArgs e)
        {
            if (mFixture.IsAutoMode)
                mFixture.StopAutomaticMode();
            else
                mFixture.StartAutomaticMode();
        }

      
        protected override string GetPersistString()
        {
            return this.GetType().ToString()+","+this.mFixture.Path;
        }

        private void btn_PresetAuto1_Click(object sender, EventArgs e)
        {
            DmxFramework.AutoMode.AutoMode mode = DmxFramework.Framework.AutomaticMode[mFixture.AutoModeNum];
            mode.SetPreset(mode.Preset1);
            if (!mFixture.IsAutoMode)
                mFixture.StartAutomaticMode();
        }

        private void btn_PresetAuto2_Click(object sender, EventArgs e)
        {
            DmxFramework.AutoMode.AutoMode mode = DmxFramework.Framework.AutomaticMode[mFixture.AutoModeNum];
            mode.SetPreset(mode.Preset2);
            if (!mFixture.IsAutoMode)
                mFixture.StartAutomaticMode();
        }

    }
}