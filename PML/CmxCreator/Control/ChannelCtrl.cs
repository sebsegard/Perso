using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework;
using DmxFramework.Fixtures;
using DmxFramework.Channels;

namespace DmxCreator.Control
{
    public partial class ChannelCtrl : UserControl
    {
        private Fixture mFixture = null;
        private bool mLoading;
        
        public ChannelCtrl()
        {
            InitializeComponent();
            mLoading = false;

            
            
            this.chanMain1.OnChannelChanged += new DmxCreator.Control.Channels.OnChannelChangedEvent(chanMain1_OnChannelChanged);
            
        }

        void chanMain1_OnChannelChanged()
        {
            if (mLoading)
                return;
            RefreshChannels(false);
        }

        public void SetFixture(Fixture pFixture)
        {
            mLoading = true;
            mFixture = pFixture;
            RefreshChannels(true);
            mLoading = false;
        }

        private void RefreshChannels(bool pRefreshGrid)
        {
            if (mFixture == null)
                return;
            
            if (pRefreshGrid)
                this.chanMain1.LoadFixture(mFixture);

            while (this.tabControl1.TabCount > 1)
                this.tabControl1.TabPages.RemoveAt(1);

           

            foreach (Channel chan in mFixture.Channels)
                AddChannel(chan);
        }

        private void AddChannel(Channel pChannel)
        {
            switch (pChannel.Function)
            {
                case ChannelFunction.Btn :
                case ChannelFunction.List:
                    AddTab(pChannel.Name, new Channels.ChanBtn(mFixture, pChannel));
                    break;
                default: break;
            }
        }

        private void AddTab(string pName,UserControl pCtrl)
        {
            pCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            pCtrl.Location = new System.Drawing.Point(3, 3);
            pCtrl.Name = pName;
            pCtrl.Size = new System.Drawing.Size(564, 325);
            pCtrl.TabIndex = 0;

            System.Windows.Forms.TabPage tab = new TabPage(pName);
            tab.Controls.Add(pCtrl);
            tab.Location = new System.Drawing.Point(4, 22);
            tab.Name = "tab_Channels";
            tab.Padding = new System.Windows.Forms.Padding(3);
            tab.Size = new System.Drawing.Size(570, 331);
            tab.TabIndex = this.tab_Channels.Controls.Count - 1;
            tab.Text = pName;
            tab.UseVisualStyleBackColor = true;

            this.tabControl1.Controls.Add(tab);
            
        }

       
    }
}
