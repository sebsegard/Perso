using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DmxFramework;
using DmxFramework.Midi;

namespace DmxSoft.Forms.Midi
{
    public partial class LastMidiChangeCtrl : UserControl
    {
       



        public LastMidiChangeCtrl()
        {
            InitializeComponent();

        }

        

        public void SetValue(string pName, string Command, int pMidiChannel, int pData1, int pData2)
        {
            this.txt_Channel.Text = pMidiChannel.ToString();
            this.txt_Data1.Text = pData1.ToString();
            this.txt_Device.Text = pName;
            this.txt_TYpe.Text = Command;
            this.txt_Data2.Text = pData2.ToString();
        }

        public void SetTitle(string pText)
        {
            this.groupBox1.Text = pText;
        }

        //#region Properties
        //public string DeviceName
        //{
        //    get { return mDeviceName; }
        //}

        //public string Command
        //{
        //    get { return mCommand; }
        //}

        //public int MidiChannel
        //{
        //    get { return mMidiChannel; }
        //}

        //public int Data1
        //{
        //    get { return mData1; }
        //}

        //public int Data2
        //{
        //    get { return mData2; }
        //}

        //#endregion
    }
}
