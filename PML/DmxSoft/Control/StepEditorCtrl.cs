using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework;
using DmxFramework.Fixtures;
using DmxFramework.Channels;
using DmxFramework.Scene;

namespace DmxSoft.Control
{
    public partial class StepEditorCtrl : UserControl
    {
        int mSelectedRow = 0;
        bool mColumnOrderChanged;
        bool mToSave;
        Scene mScene;

        public StepEditorCtrl()
        {
            InitializeComponent();
            mToSave = false;
            mColumnOrderChanged = false;
        }

        void StepEditorCtrl_LostFocus(object sender, EventArgs e)
        {
            if (mToSave)
            {
                DialogResult res = MessageBox.Show(this, "Do you want to save the scene ?", "Scene not saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    Save();
            }
        }

        

        public void SetScene(Fixture pFixture, Scene pScene)
        {
            mColumnOrderChanged = false;
            mScene = pScene;
            mSelectedRow = -1;
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();

            if (pScene.Channels.Count == 0)
                return;

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = 1;
            //int num = 1;
            foreach (string chan in pScene.ChannelNames)
            {
                int index = this.dataGridView1.Columns.Add(chan, GetChannelShortName(chan));
                
                
                this.dataGridView1.Columns[index].ToolTipText = chan;

                //num++;
            }

            foreach (Step step in pScene.Steps)
            {
                int index = this.dataGridView1.Rows.Add();
                
                DataGridViewRow row = this.dataGridView1.Rows[index];
                for (int i = 0; (i < step.Values.Length && i< row.Cells.Count); i++)
                    row.Cells[i].Value = step.Values[i];
            }

            this.tableLayoutPanel1.AutoScroll = true; ;
            for (int i = 0; i < pScene.Channels.Count; i++)
            {


                Control.DmxOutputCtrl ctrl = new DmxSoft.Control.DmxOutputCtrl((Channel)pScene.Channels[i]);
                ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
                ctrl.MaximumSize = new System.Drawing.Size(49, 0);
                ctrl.MinimumSize = new System.Drawing.Size(49, 100);
                ctrl.Name = "dmxOutputCtrl" + i;
                ctrl.Size = new System.Drawing.Size(49, 100);
                ctrl.TabIndex = i;
                tableLayoutPanel1.Controls.Add(ctrl);

                this.tableLayoutPanel1.ColumnCount++;
            }

            if(pScene.Steps.Count!=0)
                LoadStep(0);

        }


        #region menu & toolbox

        

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mSelectedRow == -1)
                return;

            int[] values = new int[this.dataGridView1.ColumnCount];
            if (dataGridView1.Rows.Count == 0 && mSelectedRow ==0)
            {

                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                    values[i] = ((Channel)mScene.Channels[i]).Value;
            }
            else
            {
                DataGridViewRow prow = this.dataGridView1.Rows[mSelectedRow];
                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                    values[i] = Convert.ToInt16(prow.Cells[i].Value);
            }


            this.dataGridView1.Rows.Insert(mSelectedRow, 1);

            for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                this.dataGridView1.Rows[mSelectedRow].Cells[i].Value = values[i];
            /*if (rowIndex > 0)
            {
                DataGridViewRow prow = this.dataGridView1.Rows[rowIndex - 1];
                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                    row.Cells[i].Value = prow.Cells[i].Value;
            }
            else
            {
                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                    row.Cells[i].Value = ((Channel)mScene.Channels[i]).Value;
            }*/
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int rowIndex = this.dataGridView1.Rows.Add();
            //DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
            /*if (rowIndex > 0)
            {
                DataGridViewRow prow = this.dataGridView1.Rows[rowIndex-1];
                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                    row.Cells[i].Value = prow.Cells[i].Value;
            }
            else
                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                {
                    row.Cells[i].Value = ((Channel)mScene.Channels[i]).Value;
                }*/

            int[] values = new int[this.dataGridView1.ColumnCount];
            if (dataGridView1.Rows.Count == 0)
            {

                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                    values[i] = ((Channel)mScene.Channels[i]).Value;
            }
            else
            {
                DataGridViewRow prow = this.dataGridView1.Rows[dataGridView1.Rows.Count-1];
                for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                {
                    values[i] = Convert.ToInt32(prow.Cells[i].Value);
                }
            }


            int index = this.dataGridView1.Rows.Add();
            for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
                this.dataGridView1.Rows[index].Cells[i].Value = values[i];

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.RemoveAt(mSelectedRow);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            mSelectedRow = e.RowIndex;
            LoadStep(mSelectedRow);
            if(e.Button == MouseButtons.Right)
                this.contextMenuStrip1.Show(MousePosition.X,MousePosition.Y);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            addToolStripMenuItem_Click(null, null);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }
        
        private void setDmxValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mSelectedRow == -1)
                return;
            DataGridViewRow row = this.dataGridView1.Rows[mSelectedRow];
            for (int i = 0; i < mScene.Channels.Count; i++)
                row.Cells[i].Value = ((Channel)mScene.Channels[i]).Value;
        }

        private void importStripButton2_Click(object sender, EventArgs e)
        {
            setDmxValuesToolStripMenuItem_Click(null, null);
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentCell != null)
            {
                mSelectedRow = this.dataGridView1.CurrentCell.RowIndex;
                try
                {
                    LoadStep(mSelectedRow);
                }
                catch { }
            }
        }

        private void LoadStep(int pRowIndex)
        {
            DataGridViewRow row = this.dataGridView1.Rows[pRowIndex];
            for (int i = 0; i < mScene.Channels.Count; i++)
                ((Channel)mScene.Channels[i]).ForceValue(Convert.ToInt32(row.Cells[i].Value), DmxFramework.Channels.ChangeOrigin.User);
        }

        

        #endregion


        public void Save()
        {
            mToSave = false;

            this.mScene.Steps.Clear();

            if (mColumnOrderChanged)
            {
                ArrayList ChannelList = (ArrayList)mScene.Channels.Clone();
                ArrayList ChannelNameList = (ArrayList)mScene.ChannelNames.Clone();

                mScene.Channels = new ArrayList(ChannelList.Count);
                mScene.ChannelNames = new ArrayList(ChannelNameList.Count);


                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                    {
                        int DisplayIndex = this.dataGridView1.Columns[j].DisplayIndex;

                        if (i == DisplayIndex)
                        {
                            mScene.Channels.Add(ChannelList[j]);
                            mScene.ChannelNames.Add(ChannelNameList[j]);
                            break;
                        }
                    }
                }
                mColumnOrderChanged = false;
            }

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                Step step = new Step(mScene.Channels);

               /* for (int i = 0; i < mScene.Channels.Count; i++)
                    step.Values[i] = Convert.ToInt32(row.Cells[this.dataGridView1.Columns[i].DisplayIndex].Value);*/

                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                    {
                        int DisplayIndex = this.dataGridView1.Columns[j].DisplayIndex;

                        if (i == DisplayIndex)
                        {
                            step.Values[i] = Convert.ToInt32(row.Cells[j].Value);
                            break;
                        }
                    }
                }

                mScene.Steps.Add(step);
            }
        }



        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            mToSave = true;
        }

        private void dataGridView1_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            mColumnOrderChanged = true;
        }



        private string GetChannelShortName(string pString)
        {
            string[] split = pString.Split(new char[] {'/'});
            int length = split.Length;
            if(length == 0)
                return "";
            if(length == 1)
                return split[0];
            return split[length - 2] + "/" + split[length - 1];
        }





    }
}
