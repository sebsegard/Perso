using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Fixtures;
using DmxFramework.Channels;

namespace DmxSoft.Forms
{
    public partial class FixtureParameters : Form
    {
        private bool mLoading = true;
        Fixture mFixture;

        public FixtureParameters(Fixture pFixture )
        {

            mFixture = pFixture;

            
            InitializeComponent();
            this.Text = mFixture.Name + " parameters";
            mLoading = true;
            LoadParametersTab();
            LoadAutoTab();
            mLoading=false;
           
        }

        private void LoadParametersTab()
        {
            if (mFixture.Type == FixtureType.Virtual)
            {
                this.tabControl.TabPages.Remove(this.tabChannelParameters);
            }
            else
            {
                foreach (RealChannel chan in mFixture.Channels)
                {
                    this.listChannel.Items.Add(chan);
                }
            }
        }

        private void LoadAutoTab()
        {
            if (mFixture.PanChannel == null && mFixture.TiltChannel == null)
                this.tabControl.TabPages.Remove(this.tabAutoMode);
            else
            {
                for (int i = 0; i < DmxFramework.Framework.AutomaticMode.Count; i++)
                {
                    this.listAutoMode.Items.Add("Auto Mode " + (i + 1));
                }

                if (mFixture.AutoModeNum >= this.listAutoMode.Items.Count)
                    mFixture.AutoModeNum = 0;
                this.listAutoMode.SelectedIndex = mFixture.AutoModeNum;

                this.chk_Pan.Checked = mFixture.PanChannel.InvertedInAutoMode;
                this.chk_Tilt.Checked = mFixture.TiltChannel.InvertedInAutoMode;
            }
        }



        private void listChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listChannel.SelectedItem == null)
                return;

            RealChannelParameter param = new RealChannelParameter((RealChannel)this.listChannel.SelectedItem);
            this.propertyGridChannel.SelectedObject = param;

        }

        private void listAutoMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mLoading) return;

            bool AutoRunning = mFixture.IsAutoMode;

            //Stop previous automatic mode if running
            if (AutoRunning)
                mFixture.StopAutomaticMode();

            //change the group
            mFixture.AutoModeNum = this.listAutoMode.SelectedIndex;

            if(AutoRunning)
                mFixture.StartAutomaticMode();
        }

        private void chk_Pan_CheckedChanged(object sender, EventArgs e)
        {
            if (mLoading) return;

            mFixture.PanChannel.InvertedInAutoMode = this.chk_Pan.Checked;
        }

        private void chk_Tilt_CheckedChanged(object sender, EventArgs e)
        {
            if (mLoading) return;

            mFixture.TiltChannel.InvertedInAutoMode = this.chk_Tilt.Checked;
        }
    }
}