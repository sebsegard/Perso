using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Control
{
    public partial class PanTiltCtrl : UserControl
    {
        DmxFramework.Channels.Channel mPanChannel;
        DmxFramework.Channels.Channel mTiltChannel;
        bool mIsMoving;
        
        public PanTiltCtrl()
        {           
            InitializeComponent();
            myChanPanDelegate = new delegate_ChangePanValue(ChangePanValue);
            myChanTiltDelegate = new delegate_ChangeTiltValue(ChangeTiltValue);
            myForceStateDelegate = new delegate_ForcedStateChange(ChangeForcedState);
        }

        public void SetChannel(DmxFramework.Channels.Channel pPan,DmxFramework.Channels.Channel pTilt)
        {
            mPanChannel = pPan;
            mTiltChannel = pTilt;

            if (mPanChannel.IsForced || mTiltChannel.IsForced)
                this.checkBox1.Checked = true;
            else
                this.checkBox1.Checked = false;

            mPanChannel_OnValueChanged(mPanChannel, mPanChannel.Value);
            mTiltChannel_OnValueChanged(mTiltChannel, mTiltChannel.Value);

            if (Main.Options.Visualize)
            {
                mPanChannel.OnValueChanged += new DmxFramework.Channels.OnValueChangedHandler(mPanChannel_OnValueChanged);
                mTiltChannel.OnValueChanged += new DmxFramework.Channels.OnValueChangedHandler(mTiltChannel_OnValueChanged);
            }
            mPanChannel.OnForcedStateChanged += new DmxFramework.Channels.OnForcedStateChangedHandler(mChannel_OnForcedStateChanged);
            mTiltChannel.OnForcedStateChanged += new DmxFramework.Channels.OnForcedStateChangedHandler(mChannel_OnForcedStateChanged);
        }

        void mChannel_OnForcedStateChanged(DmxFramework.Channels.Channel pChannel, bool pIsForced)
        {
            if(this.InvokeRequired)
                this.BeginInvoke(myForceStateDelegate, pChannel, pIsForced);
            else
                ChangeForcedState(pChannel,pIsForced);
        }

        void ChangeForcedState(DmxFramework.Channels.Channel pChannel, bool pIsForced)
        {
            if (mPanChannel.IsForced || mTiltChannel.IsForced)
                this.checkBox1.Checked = true;
            else
                this.checkBox1.Checked = false;
        }


        public delegate void delegate_ChangePanValue(DmxFramework.Channels.Channel pChannel, int pValue);
        public delegate void delegate_ForcedStateChange(DmxFramework.Channels.Channel pChannel, bool pIsForced);
        public delegate_ForcedStateChange myForceStateDelegate;
        public delegate_ChangePanValue myChanPanDelegate;

        public delegate void delegate_ChangeTiltValue(DmxFramework.Channels.Channel pChannel, int pValue);

        public delegate_ChangeTiltValue myChanTiltDelegate;

        void mPanChannel_OnValueChanged(DmxFramework.Channels.Channel pChannel, int pValue)
        {
           if(this.InvokeRequired)
            this.BeginInvoke(this.myChanPanDelegate, pChannel, pValue);
           else
               ChangePanValue(pChannel, pValue);
            
        }

        void ChangePanValue(DmxFramework.Channels.Channel pChannel, int pValue)
        {
            this.label1.Left = (pValue * this.panel1.Width) / 255 - (this.label1.Width) / 2;
        }

        void mTiltChannel_OnValueChanged(DmxFramework.Channels.Channel pChannel, int pValue)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(this.myChanTiltDelegate, pChannel, pValue);
            else
                ChangeTiltValue(pChannel, pValue);

        }

        void ChangeTiltValue(DmxFramework.Channels.Channel pChannel, int pValue)
        {
             this.label1.Top = (pValue * this.panel1.Height) / 255 - (this.label1.Height) / 2;
            
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point loc = e.Location;
            int Xdmx = loc.X * 255 / this.panel1.Width;
            int Ydmx = loc.Y * 255 / this.panel1.Height;

            mPanChannel.ForceValue(Xdmx, DmxFramework.Channels.ChangeOrigin.User);
            mTiltChannel.ForceValue(Ydmx, DmxFramework.Channels.ChangeOrigin.User);

            if (!Main.Options.Visualize)
            {
                mPanChannel_OnValueChanged(null, Xdmx);
                mTiltChannel_OnValueChanged(null, Ydmx);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mIsMoving = true;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            mIsMoving = false;
        }

        

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!mIsMoving)
                return;
            

            int Xdmx = mPanChannel.Value + e.X * 255 / this.panel1.Width;
            int Ydmx = mTiltChannel.Value + e.Y * 255 / this.panel1.Height;

            if (Xdmx > 0 && Xdmx < 256 && mPanChannel.Value != Xdmx)
            {
                mPanChannel.ForceValue(Xdmx, DmxFramework.Channels.ChangeOrigin.User);

                if (!Main.Options.Visualize)
                    mPanChannel_OnValueChanged(null, Xdmx);
            }
            if (Ydmx > 0 && Ydmx < 256 && mTiltChannel.Value != Ydmx)
            {
                mTiltChannel.ForceValue(Ydmx, DmxFramework.Channels.ChangeOrigin.User);
                if (!Main.Options.Visualize)
                    mTiltChannel_OnValueChanged(null, Ydmx);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
                return;

            mPanChannel.UnforceValue();
            mTiltChannel.UnforceValue();
        }      
    }
}
