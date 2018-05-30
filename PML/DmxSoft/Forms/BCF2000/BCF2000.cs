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

namespace DmxSoft.Forms.BCF2000
{
    public partial class BCF2000 : Form
    {
        private string mDeviceName;
        private string mCommand;
        private int mMidiChannel;
        private int mData1;
        private int mData2;
        Device mDevice;
        private SynchronizationContext mCOntext;
        
        public BCF2000()
        {
            InitializeComponent();

            mCOntext = SynchronizationContext.Current;
            this.midiDeviceCtrl1.SetDevice();
            this.midiDeviceCtrl1.OnDeviceSelected+=new Midi.OnDeviceSelectedEvent(midiDeviceCtrl1_OnDeviceSelected);
            //this.keyListCtrl1.OnActionListSelected += new OnActionListSelectedEvent(keyListCtrl1_OnActionListSelected);
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
                    //this.keyListCtrl1.SetValue(pName, Command, pMidiChannel, pData1, pData2);

                }), null);
        }

        public void DoLoad()
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(Framework.Bcf2000.BcfMode.ToArray());
            this.comboBox1.SelectedIndex = 0;
            LoadConfPanel();
            LoadAssignementPanel();
        }

        public void LoadConfPanel()
        {
            foreach (DmxFramework.Midi.BcfControl ctrl in DmxFramework.Framework.Bcf2000.AllControls)
            {
                int Rowindex = this.dataGridView_Conf.Rows.Add();
                this.dataGridView_Conf.Rows[Rowindex].Cells[colControl.Index].Value = ctrl.Name;
                this.dataGridView_Conf.Rows[Rowindex].Cells[colDevice.Index].Value = ctrl.BcfAction.DeviceName;
                this.dataGridView_Conf.Rows[Rowindex].Cells[colCommmand.Index].Value = ctrl.BcfAction.Command;
                this.dataGridView_Conf.Rows[Rowindex].Cells[colChannel.Index].Value = ctrl.BcfAction.MidiChannel;
                this.dataGridView_Conf.Rows[Rowindex].Cells[colData1.Index].Value = ctrl.BcfAction.Data1;
                this.dataGridView_Conf.Rows[Rowindex].Cells[colSet.Index].Value = "Set";
                this.dataGridView_Conf.Rows[Rowindex].Tag = ctrl;
            }


        }

        public void LoadAssignementPanel()
        {
            this.dataGridAssign.Rows.Clear();
            foreach (DmxFramework.Midi.BcfControl ctrl in DmxFramework.Framework.Bcf2000.AllControls)
            {
                int Rowindex = this.dataGridAssign.Rows.Add();
                this.dataGridAssign.Rows[Rowindex].Cells[colAControl.Index].Value = ctrl.Name;
                this.dataGridAssign.Rows[Rowindex].Cells[colADesc.Index].Value = ctrl.BcfAction.CurrentActionList.Description;
                this.dataGridAssign.Rows[Rowindex].Cells[colASet.Index].Value = "Select";
                this.dataGridAssign.Rows[Rowindex].Tag = ctrl.BcfAction.CurrentActionList;
                ctrl.BcfAction.CurrentActionList.OnActionListDescriptionChanged += new DmxFramework.Midi.Action.OnBcfActionListDescriptionChangedEvent(CurrentActionList_OnActionListDescriptionChanged);
            }
        }

        void CurrentActionList_OnActionListDescriptionChanged(DmxFramework.Midi.Action.BcfActionList pActionList, string pDescription)
        {
            for(int i=0; i<this.dataGridAssign.Rows.Count;i++)
            {
               DmxFramework.Midi.Action.BcfActionList ctrl =this.dataGridAssign.Rows[i].Tag as DmxFramework.Midi.Action.BcfActionList; 
                if(ctrl == pActionList)
                    this.dataGridAssign.Rows[i].Cells[colADesc.Index].Value = pDescription;
 
            }
        }

        private void bcfFader1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridAssign_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colASet.Index || e.RowIndex < 0)
                return;

            atctionListCtrl1.Visible=true;
            this.atctionListCtrl1.SetAction(this.dataGridAssign.Rows[e.RowIndex].Tag as DmxFramework.Midi.Action.BcfActionList);
           

        }

        private void dataGridView_Conf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colSet.Index || e.RowIndex < 0)
                return;

            DmxFramework.Midi.BcfControl ctrl = this.dataGridView_Conf.Rows[e.RowIndex].Tag as DmxFramework.Midi.BcfControl;
            try
            {

                ctrl.BcfAction.SetMidiConfiguration(mDeviceName, mCommand, mMidiChannel, mData1);
                this.dataGridView_Conf.Rows[e.RowIndex].Cells[colDevice.Index].Value = ctrl.BcfAction.DeviceName;
                this.dataGridView_Conf.Rows[e.RowIndex].Cells[colCommmand.Index].Value = ctrl.BcfAction.Command;
                this.dataGridView_Conf.Rows[e.RowIndex].Cells[colChannel.Index].Value = ctrl.BcfAction.MidiChannel;
                this.dataGridView_Conf.Rows[e.RowIndex].Cells[colData1.Index].Value = ctrl.BcfAction.Data1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DmxFramework.Midi.Bcf2000.CurrentMode = this.comboBox1.SelectedIndex;
            LoadAssignementPanel();
            atctionListCtrl1.Visible=false;
        }
    }
}