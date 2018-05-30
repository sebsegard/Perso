using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DmxFramework;
using DmxFramework.Midi;
namespace DmxSoft.Forms.Midi
{
    public partial class ConfForm : Form
    {
        private string mDeviceName;
        private string mCommand;
        private int mMidiChannel;
        private int mData1;
        private int mData2;
        Device mDevice;
        private SynchronizationContext mCOntext;
        
        public ConfForm()
        {
            InitializeComponent();
            mCOntext = SynchronizationContext.Current;
            this.midiDeviceCtrl1.SetDevice();
            this.midiDeviceCtrl1.OnDeviceSelected += new OnDeviceSelectedEvent(midiDeviceCtrl1_OnDeviceSelected);
            this.keyListCtrl1.OnActionListSelected += new OnActionListSelectedEvent(keyListCtrl1_OnActionListSelected);
        }

        void keyListCtrl1_OnActionListSelected(DmxFramework.Midi.Action.ActionList pAction)
        {
            //this.atctionListCtrl1.SetAction(pAction);
            this.atctionListCtrl1.Visible = true;
        }

        void midiDeviceCtrl1_OnDeviceSelected(DmxFramework.Midi.Device pDev)
        {
            if (mDevice != null)
            {
                mDevice.Stop();
                mDevice.OnMidiValueChanged -= this.mDevice_OnMidiValueChanged;

            }
            mDevice = pDev;
            mDevice.Subscribe();
            mDevice.Start();
            mDevice.OnMidiValueChanged += new OnMidiValueChangedDelegate(mDevice_OnMidiValueChanged);
        }

        void mDevice_OnMidiValueChanged(string pName, string Command, int pMidiChannel, int pData1, int pData2)
        {
            mCOntext.Post(new SendOrPostCallback(
                delegate
                {
                    mDeviceName = pName;
                    mCommand = Command;
                    mMidiChannel = pMidiChannel;
                    mData1 = pData1;
                    mData2 = pData2;

                    this.lastMidiChangeCtrl1.SetValue(pName, Command, pMidiChannel, pData1, pData2);
                    this.keyListCtrl1.SetValue(pName, Command, pMidiChannel, pData1, pData2);

                }), null);
        }
    }
}