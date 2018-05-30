using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Channels;
using DmxFramework.Midi.Action;

namespace DmxSoft.Forms.Midi.ActionCtrl
{
    public partial class CopyCtrl : UserControl
    {
        ChangeDmxValue mValue;
        
        public CopyCtrl()
        {
            InitializeComponent();
            this.fullTreeCtrl1.OnChannelSelected += new DmxSoft.Control.OnChannelSelectedEvent(fullTreeCtrl1_OnChannelSelected);
        }

        void fullTreeCtrl1_OnChannelSelected(Channel pChannel)
        {
            if (pChannel != null)
                this.txt_Path.Text = pChannel.Path;
            else
                this.txt_Path.Text = "";
        }

        public void SetAction(ChangeDmxValue pValue)
        {
            mValue = pValue;
            this.fullTreeCtrl1.Reset();
            this.fullTreeCtrl1.SelectedChannel = mValue.Channel;
            this.fullTreeCtrl1.LoadTree();
            if (mValue.Channel != null)
                this.txt_Path.Text = mValue.Channel.Path;
            else
                this.txt_Path.Text = "";
            this.txt_DmxMin.Text = mValue.MinDmx.ToString();
            this.txt_DmxMax.Text = mValue.MaxDmx.ToString();
            this.txt_MidiMin.Text = mValue.MinMidi.ToString();
            this.txt_MidiMax.Text = mValue.MaxMidi.ToString();

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int DmxMin = 0;
            int DmxMax = 0;
            int MidiMin = 0;
            int MidiMax = 0;

            if (fullTreeCtrl1.SelectedChannel == null)
            {
                MessageBox.Show("Channel must be selected");
                return;
            }

            if (!int.TryParse(this.txt_MidiMin.Text, out MidiMin))
            {
                MessageBox.Show("Midi min must be an integer");
                return;
            }

            if (!int.TryParse(this.txt_MidiMax.Text, out MidiMax))
            {
                MessageBox.Show("Midi max must be an integer");
                return;
            }

            if (!int.TryParse(this.txt_DmxMin.Text, out DmxMin))
            {
                MessageBox.Show("Dmx min must be an integer");
                return;
            }

            if (!int.TryParse(this.txt_DmxMax.Text, out DmxMax))
            {
                MessageBox.Show("Dmx max must be an integer");
                return;
            }

            try
            {
                mValue.MaxDmx = DmxMax;
                mValue.MinDmx = DmxMin;
                mValue.MinMidi = MidiMin;
                mValue.MaxMidi = MidiMax;
                mValue.Channel = fullTreeCtrl1.SelectedChannel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
    }
}
