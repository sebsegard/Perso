using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework;
using DmxFramework.Midi;

namespace DmxSoft.Forms.Midi
{
    public delegate void OnActionListSelectedEvent(DmxFramework.Midi.Action.ActionList pAction);
    
    public partial class KeyListCtrl : UserControl
    {
        public event OnActionListSelectedEvent OnActionListSelected;

        private string mDeviceName = "";
        private string mCommand;
        private int mMidiChannel;
        private int mData1;
        private int mData2;
        Device mDevice;
        
        public KeyListCtrl()
        {
            InitializeComponent();

            FillDataGrid();
        }

        void FillDataGrid()
        {
            foreach (DmxFramework.Midi.Action.ActionList act in Framework.MidiDriver.ActionTable.Values)
                AddRow(act);
        }

        void AddRow(DmxFramework.Midi.Action.ActionList pAction)
        {
            DataGridViewRow row;

            int RowIndex = dataGridView1.Rows.Add();
            row = dataGridView1.Rows[RowIndex];

            row.Cells[0].Value = pAction.DeviceName;
            row.Cells[1].Value = pAction.Command;
            row.Cells[2].Value = pAction.MidiChannel;
            row.Cells[3].Value = pAction.Data1;
            row.Cells[4].Value = pAction.Description;
            row.Cells[5].Value = "Delete";

            row.Tag = pAction;

            pAction.OnActionListDescriptionChanged += new DmxFramework.Midi.Action.OnActionListDescriptionChangedEvent(pAction_OnActionListDescriptionChanged);

        }

        void pAction_OnActionListDescriptionChanged(DmxFramework.Midi.Action.ActionList pActionList, string pDescription)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Tag == pActionList)
                    row.Cells[4].Value = pDescription;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DmxFramework.Midi.Action.ActionList Action = (DmxFramework.Midi.Action.ActionList)dataGridView1.Rows[e.RowIndex].Tag;
            if (e.ColumnIndex == 5)
            {
                DialogResult res = MessageBox.Show(this, "Are you sur to delete this row ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.OK)
                {
                    Framework.MidiDriver.ActionTable.Remove(Action.Key);
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
            else
            {
                if (OnActionListSelected != null)
                    OnActionListSelected(Action);
            }

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mDeviceName == "")
            {
                MessageBox.Show(this, "You must to select a midi usng your midi device to add an action", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DmxFramework.Midi.Action.ActionList Action = new DmxFramework.Midi.Action.ActionList(mDeviceName, mCommand, mMidiChannel, mData1);
            if (Framework.MidiDriver.ActionTable.ContainsKey(Action.Key))
            {
                MessageBox.Show(this, "this action is already set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Framework.MidiDriver.ActionTable.Add(Action.Key, Action);
            AddRow(Action);

            if (OnActionListSelected != null)
                OnActionListSelected(Action);

        }


        public void SetValue(string pName, string Command, int pMidiChannel, int pData1, int pData2)
        {
            mDeviceName = pName;
            mCommand = Command;
            mMidiChannel = pMidiChannel;
            mData1 = pData1;
            mData2 = pData2;
        }


    }
}
