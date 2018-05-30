using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Control
{
    public partial class ListCtrl : UserControl
    {
        DmxFramework.Channels.Channel mChannel;
        DmxFramework.Channels.DmxValue mSelectedValue;

        public ListCtrl()
        {
            InitializeComponent();
        }

        public void SetChannel(DmxFramework.Channels.Channel pChannel)
        {
            mChannel = pChannel;

            this.checkBox1.Text = mChannel.Name;
            this.checkBox1.Checked = mChannel.IsForced;
            this.listBox1.Items.Clear();
            foreach (DmxFramework.Channels.DmxValue val in mChannel.DmxValues)
            {
                this.listBox1.Items.Add(val);
                if (pChannel.Value >= val.StartValue && pChannel.Value < val.EndValue)
                {
                    mSelectedValue = val;
                    this.listBox1.SelectedItem = val;
                }
            }

            if (Main.Options.Visualize)
                mChannel.OnValueChanged += new DmxFramework.Channels.OnValueChangedHandler(mChannel_OnValueChanged);
            mChannel.OnForcedStateChanged += new DmxFramework.Channels.OnForcedStateChangedHandler(mChannel_OnForcedStateChanged);
        }

        void mChannel_OnForcedStateChanged(DmxFramework.Channels.Channel pChannel, bool pIsForced)
        {
            this.checkBox1.Checked = pIsForced;
        }

        void mChannel_OnValueChanged(DmxFramework.Channels.Channel pChannel, int pValue)
        {

            if (mSelectedValue != null)
            {
                if (pValue >= mSelectedValue.StartValue && pValue < mSelectedValue.EndValue)
                    return;
            }

            foreach (DmxFramework.Channels.DmxValue val in mChannel.DmxValues)
            {
                if (pValue >= val.StartValue && pValue < val.EndValue)
                {
                    mSelectedValue = val;
                    this.listBox1.SelectedItem = val;
                    return;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DmxFramework.Channels.DmxValue val = (DmxFramework.Channels.DmxValue)this.listBox1.SelectedItem;

            if (val != mSelectedValue)
            {
                mSelectedValue = val;
                mChannel.ForceValue(mSelectedValue.Value, DmxFramework.Channels.ChangeOrigin.User);
            } 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBox1.Checked && this.mChannel.IsForced)
                mChannel.UnforceValue();
        }
    }
}

