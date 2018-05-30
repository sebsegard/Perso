using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Midi;

namespace DmxSoft.Forms.Midi
{
    public delegate void OnDeviceSelectedEvent(Device pDev);
    
    public partial class MidiDeviceCtrl : UserControl
    {
        public event OnDeviceSelectedEvent OnDeviceSelected;
        
        public MidiDeviceCtrl()
        {
            InitializeComponent();
        }

        public void SetDevice()
        {
            //DmxFramework.Framework.MidiDriver.RefreshDevices();
            this.comboBox1.Items.Clear();

            foreach (Device dev in DmxFramework.Framework.Bcf2000.DeviceList)
            {
                this.comboBox1.Items.Add(dev);
            }
            if(this.comboBox1.Items.Count>0)
                 this.comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnDeviceSelected != null)
                OnDeviceSelected((Device)this.comboBox1.SelectedItem);
        }
    }
}
