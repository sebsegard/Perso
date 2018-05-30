using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Control
{
    public partial class ChannelButtonCtrl : UserControl
    {
        DmxFramework.Channels.Channel mChannel;

        public delegate void delegate_ChannelValueChanged(DmxFramework.Channels.Channel pChannel, int  pValue);
        public delegate void delegate_ForcedStateChange(DmxFramework.Channels.Channel pChannel, bool pIsForced);


        public delegate_ForcedStateChange myForceStateDelegate;
        public delegate_ChannelValueChanged myChannelValueChangedDelegate;
        
        public ChannelButtonCtrl()
        {           
            InitializeComponent();
            myForceStateDelegate = new delegate_ForcedStateChange(ChangeForcedState);
            myChannelValueChangedDelegate = new delegate_ChannelValueChanged(ChangeChannelValue);
        }

        public void SetChannel(DmxFramework.Channels.Channel pChannel)
        {
            
            float pourcentage = 0;
            mChannel = pChannel;
            this.checkBox1.Checked = mChannel.IsForced;
            this.checkBox1.Text = mChannel.Name;
            this.tableLayoutPanel1.Controls.Clear();
            this.tableLayoutPanel1.RowCount = 0;
            this.tableLayoutPanel1.ColumnCount = 0;

            //set row ...
            pourcentage = 100 / mChannel.RowCount;
            this.tableLayoutPanel1.RowStyles.Clear();
            this.tableLayoutPanel1.RowCount = mChannel.RowCount;
            for (int i = 0; i < mChannel.RowCount; i++)
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, pourcentage));

            //set columns ...
            pourcentage = 100 / mChannel.ColumnCount;
            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.ColumnCount = mChannel.ColumnCount;
            for (int i = 0; i < mChannel.ColumnCount; i++)
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, pourcentage));


            int count = 0;
            for (int i = 0; i < mChannel.RowCount; i++)
            {
                for (int j = 0; j < mChannel.ColumnCount; j++)
                {
                    if (count >= mChannel.DmxValues.Count)
                        break;
                    ValueButton btn = new ValueButton((DmxFramework.Channels.DmxValue)mChannel.DmxValues[count]);
                    btn.OnNewBtnValue += new OnNewBtnValueHandler(btn_OnNewBtnValue);

                    btn.Dock = System.Windows.Forms.DockStyle.Fill;
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                    
                    this.tableLayoutPanel1.Controls.Add(btn, j, i);
                    count++;
                }
            }
            mChannel_OnValueChanged(mChannel, mChannel.Value);

            if (Main.Options.Visualize)
                mChannel.OnValueChanged += new DmxFramework.Channels.OnValueChangedHandler(mChannel_OnValueChanged);
            mChannel.OnForcedStateChanged += new DmxFramework.Channels.OnForcedStateChangedHandler(mChannel_OnForcedStateChanged);
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
            for(int i=0;i<this.tableLayoutPanel1.Controls.Count;i++)
            {
                ValueButton btn = (ValueButton)this.tableLayoutPanel1.Controls[i];
                if(btn.IsConcerned(pValue))
                    btn.SetSelectedMode(true);
                else
                    btn.SetSelectedMode(false);
            }
        }

        void btn_OnNewBtnValue(int pValue)
        {
            mChannel.ForceValue(pValue, DmxFramework.Channels.ChangeOrigin.User);
            if(!Main.Options.Visualize)
                mChannel_OnValueChanged(null, pValue);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBox1.Checked && this.mChannel.IsForced)
                mChannel.UnforceValue();
        }
    }
}
