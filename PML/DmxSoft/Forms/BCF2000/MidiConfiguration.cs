using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Forms.BCF2000
{
    public partial class MidiConfiguration : Form
    {
        public MidiConfiguration()
        {
            InitializeComponent();
        }

        public void SetBcfControl(DmxFramework.Midi.Bcf2000 pBcf,DmxFramework.Midi.BcfControl pControl)
        {
            /*
            this.CtrlMidiValues.SetValue(pControl.Action.DeviceName,
                pControl.Action.Command,
                pControl.Action.MidiChannel,
                pControl.Action.Data1,
                0);*/

            pBcf.Device.OnMidiValueChanged += new DmxFramework.Midi.OnMidiValueChangedDelegate(Device_OnMidiValueChanged);
        }

        void Device_OnMidiValueChanged(string pName, string Command, int pMidiChannel, int pData1, int pData2)
        {
            this.ChanMidiValue.SetValue(pName, Command, pMidiChannel, pData1, pData2);
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}