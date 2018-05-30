using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Control
{
    public partial class DmxOutputCtrl : UserControl
    {
        DmxFramework.Channels.Channel mChannel;
        bool mFromFramework = false;

        public delegate void delegate_ChannelValueChanged(DmxFramework.Channels.Channel pChannel, int pValue);
        public delegate void delegate_ForcedStateChange(DmxFramework.Channels.Channel pChannel, bool pIsForced);


        public delegate_ForcedStateChange myForceStateDelegate;
        public delegate_ChannelValueChanged myChannelValueChangedDelegate;

        public DmxOutputCtrl(int pNum)
        {
            InitializeComponent();
            mChannel = null;
            this.label1.Text = pNum + "";
            myForceStateDelegate = new delegate_ForcedStateChange(ChangeForcedState);
            myChannelValueChangedDelegate = new delegate_ChannelValueChanged(ChangeChannelValue);
        }

        public DmxOutputCtrl(DmxFramework.Channels.Channel pChannel)
        {
            mChannel = pChannel;
            InitializeComponent();
            mFromFramework = true;
            this.label1.Text = mChannel.Name ;
            this.trackBar1.Value = pChannel.Value;


            this.checkBox1.Checked = mChannel.IsForced;
            mChannel_OnValueChanged(null, mChannel.Value);

            mChannel.OnForcedStateChanged += new DmxFramework.Channels.OnForcedStateChangedHandler(mChannel_OnForcedStateChanged);
            mChannel.OnValueChanged += new DmxFramework.Channels.OnValueChangedHandler(mChannel_OnValueChanged);

        }

        void mChannel_OnForcedStateChanged(DmxFramework.Channels.Channel pChannel, bool pIsForced)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(myForceStateDelegate, pChannel, pIsForced);
            else
                ChangeForcedState(pChannel, pIsForced);
        }

        void ChangeForcedState(DmxFramework.Channels.Channel pChannel, bool pIsForced)
        {
            this.checkBox1.Checked = pIsForced;
        }


        void mChannel_OnValueChanged(DmxFramework.Channels.Channel pChannel, int pValue)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(myChannelValueChangedDelegate, pChannel, pValue);
            else
                ChangeChannelValue(pChannel, pValue);
        }



        void ChangeChannelValue(DmxFramework.Channels.Channel pChannel, int pValue)
        {
            try
            {
                mFromFramework = true;
                this.textBox1.Text = pValue.ToString();
                this.trackBar1.Value = pValue;
            }
            catch
            { }
        }

        
      

        private void DmxOutputCtrl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.mChannel == null)
                return;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /*if (sender == this)
                return;*/

            if (!this.checkBox1.Checked && this.mChannel.IsForced)
                mChannel.UnforceValue();
        }

        

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int result = 0;
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(this.textBox1.Text, out result))
                    mChannel.ForceValue(result, DmxFramework.Channels.ChangeOrigin.User);
                else
                    MessageBox.Show(this, "Error", "Please put an integer value between 0 and 255", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (mFromFramework)
            {
                mFromFramework = false;
                return;
            }

            int value = trackBar1.Value;
            if (value != mChannel.Value)
            {
                mChannel.ForceValue(trackBar1.Value, DmxFramework.Channels.ChangeOrigin.User);
            }
        }


    }
}
