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


namespace DmxCreator.Control.Channels
{
    public delegate void OnChannelChangedEvent();


    public partial class ChanMain : UserControl
    {
        public Fixture mFixture;
        public event OnChannelChangedEvent OnChannelChanged = null;
        //private bool mConfiguration;


        public ChanMain()
        {
            InitializeComponent();
            this.col_ChanType.Items.Clear();

            this.col_ChanType.Items.Add(ChannelFunction.Basic.ToString());
            this.col_ChanType.Items.Add(ChannelFunction.Pan.ToString());
            this.col_ChanType.Items.Add(ChannelFunction.Tilt.ToString());
            this.col_ChanType.Items.Add(ChannelFunction.Btn.ToString());
            this.col_ChanType.Items.Add(ChannelFunction.List.ToString());
        }

        public void LoadFixture(Fixture pFixture)
        {
            //mConfiguration = true;
            mFixture = pFixture;
            this.dataGridView1.Rows.Clear();

            if (pFixture.Type == FixtureType.Real)
            {
                this.col_ChannelNum.Visible = true;
                this.col_Copy.Visible = false;
            }
            else
            {
                this.col_ChannelNum.Visible = false;
                this.col_Copy.Visible = true;
            }
            foreach (Channel pChannel in mFixture.Channels)
                AddChannel(pChannel);
            //mConfiguration = false;
        }

        public void AddChannel(Channel pChannel)
        {
            int index = this.dataGridView1.Rows.Add();
            DataGridViewRow row = this.dataGridView1.Rows[index];
            row.Tag = pChannel;
            if(pChannel.Type == ChannelType.Real)
                row.Cells["col_ChannelNum"].Value = pChannel.Number.ToString();
            row.Cells["chan_Name"].Value = (string)pChannel.Name;

            ((DataGridViewComboBoxCell)(row.Cells["col_ChanType"])).Value = pChannel.Function.ToString();

            if (pChannel.Type == ChannelType.Virtual)
            {
                if (((VirtualChannel)pChannel).VirtualType == VirtualChannelType.Copy)
                {
                    row.Cells["col_Copy"].Value = "Select sub channel...";
                }
            }
        }

        private void addChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Channel NewChannel=null;
            AddRealChannelDlg dlg = new AddRealChannelDlg((mFixture.Type == FixtureType.Real), this.dataGridView1.Rows.Count+1);

            DialogResult res = dlg.ShowDialog();
            if (res != DialogResult.OK)
                return;
            NewChannel = dlg.NewChannel;
            if(NewChannel!=null)
            {
                mFixture.Channels.Add(NewChannel);
                NewChannel.Fixture = mFixture;
                AddChannel(NewChannel);

                if (OnChannelChanged != null)
                    OnChannelChanged();
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string ChannelName = ((Channel)(e.Row.Tag)).Name;
            DialogResult res = MessageBox.Show(this, "Are you sur to remove channel " + ChannelName + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = true;
            if (res == DialogResult.Yes)
            {
                e.Cancel = false;

                mFixture.Channels.Remove((Channel)e.Row.Tag);

                if (OnChannelChanged != null)
                    OnChannelChanged();
            }
        }

  

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex<0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "col_Copy")
            {
                VirtualChannel chan = (VirtualChannel)dataGridView1.Rows[e.RowIndex].Tag;
                if (chan.VirtualType == VirtualChannelType.Copy)
                {
                    SelectSubChannelDlg dlg = new SelectSubChannelDlg((VirtualFixture)mFixture, chan);
                    dlg.ShowDialog(this);
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                Channel chan = (Channel)row.Tag;

                if (dataGridView1.Columns[e.ColumnIndex].Name == "col_ChannelNum")
                {
                    ((RealChannel)chan).Number = Convert.ToInt32(row.Cells[e.ColumnIndex].Value);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "chan_Name")
                {
                    chan.Name = (string)row.Cells[e.ColumnIndex].Value;
                    OnChannelChanged();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "col_ChanType")
                {
                    chan.Function = Channel.StringToFunction((string)row.Cells[e.ColumnIndex].Value);
                    OnChannelChanged();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

    }
}
