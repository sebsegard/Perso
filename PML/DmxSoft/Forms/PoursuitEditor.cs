using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Forms
{
    public partial class PoursuitEditor : Form
    {
        DmxFramework.Fixtures.RealFixture mFixture;
        DmxFramework.Channels.Channel mPanCHannel;
        DmxFramework.Channels.Channel mTiltChannel;

        public PoursuitEditor(DmxFramework.Fixtures.RealFixture pRealFixture)
        {
            mFixture = pRealFixture;

            foreach (DmxFramework.Channels.Channel chan in pRealFixture.Channels)
            {
                if (chan.Function == DmxFramework.Channels.ChannelFunction.Pan)
                    mPanCHannel = chan;
                else if (chan.Function == DmxFramework.Channels.ChannelFunction.Tilt)
                    mTiltChannel = chan;
            }

            InitializeComponent();


            this.txt_A_X.Text = "" + mFixture.Poursuite.PointA.iX;
            this.txt_A_Y.Text = "" + mFixture.Poursuite.PointA.iY;

            this.txt_B_X.Text = "" + mFixture.Poursuite.PointB.iX;
            this.txt_B_Y.Text = "" + mFixture.Poursuite.PointB.iY;

            this.txt_C_X.Text = "" + mFixture.Poursuite.PointC.iX;
            this.txt_C_Y.Text = "" + mFixture.Poursuite.PointC.iY;

            this.txt_D_X.Text = "" + mFixture.Poursuite.PointD.iX;
            this.txt_D_Y.Text = "" + mFixture.Poursuite.PointD.iY;

            this.txt_intersection_X.Text = "" + mFixture.Poursuite.PointIntersection.iX;
            this.txt_intersection_Y.Text = "" + mFixture.Poursuite.PointIntersection.iY;
            
            this.chk_Enabled.Checked = mFixture.Poursuite.IsActive;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            btn_Apply_Click(null, null);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            mFixture.Poursuite.PointA.iX = Convert.ToInt32(this.txt_A_X.Text);
            mFixture.Poursuite.PointA.iY = Convert.ToInt32(this.txt_A_Y.Text);

            mFixture.Poursuite.PointB.iX = Convert.ToInt32(this.txt_B_X.Text);
            mFixture.Poursuite.PointB.iY = Convert.ToInt32(this.txt_B_Y.Text);

            mFixture.Poursuite.PointC.iX = Convert.ToInt32(this.txt_C_X.Text);
            mFixture.Poursuite.PointC.iY = Convert.ToInt32(this.txt_C_Y.Text);
            
            mFixture.Poursuite.PointD.iX = Convert.ToInt32(this.txt_D_X.Text);
            mFixture.Poursuite.PointD.iY = Convert.ToInt32(this.txt_D_Y.Text);

            mFixture.Poursuite.ComputeIntersection();
            this.txt_intersection_X.Text = "" + mFixture.Poursuite.PointIntersection.iX;
            this.txt_intersection_Y.Text = "" + mFixture.Poursuite.PointIntersection.iY;


            mFixture.Poursuite.IsActive = this.chk_Enabled.Checked;

        }

        private void btn_D_Click(object sender, EventArgs e)
        {
            this.txt_D_X.Text = mPanCHannel.Value + "";
            this.txt_D_Y.Text = mTiltChannel.Value + "";
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            this.txt_C_X.Text = mPanCHannel.Value + "";
            this.txt_C_Y.Text = mTiltChannel.Value + "";
        }

        private void btn_B_Click(object sender, EventArgs e)
        {
            this.txt_B_X.Text = mPanCHannel.Value + "";
            this.txt_B_Y.Text = mTiltChannel.Value + "";
        }

        private void btn_A_Click(object sender, EventArgs e)
        {
            this.txt_A_X.Text = mPanCHannel.Value+"";
            this.txt_A_Y.Text = mTiltChannel.Value + "";
        }
    }
}