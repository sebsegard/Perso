using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DmxFramework.Fixtures;
using DmxFramework.Channels;

namespace DmxCreator.Control.Channels
{
    public partial class ChanBtn : UserControl
    {
        private Fixture mFixture;
        private Channel mChannel;
        private bool mLoading;
        //private bool mLastPath = "";

        public ChanBtn(Fixture pFixture, Channel pChannel)
        {
            InitializeComponent();
            mLoading = true;
            mFixture = pFixture;
            mChannel = pChannel;

            this.txt_NbColumns.Text = mChannel.ColumnCount.ToString();
            this.txt_NbLines.Text = mChannel.RowCount.ToString();

            if (pChannel.Function == ChannelFunction.List)
                this.dataGridView1.Columns["col_Image"].Visible = false;
            else
                this.dataGridView1.Columns["col_Image"].Visible = true;

            if (pChannel.Type == ChannelType.Virtual)
                this.dataGridView1.Columns["col_Copy"].Visible=true;
            else
                this.dataGridView1.Columns["col_Copy"].Visible = false;

            if (pChannel.DmxValues == null)
                pChannel.DmxValues = new System.Collections.ArrayList();

            foreach (DmxValue value in pChannel.DmxValues)
            {
                AddValueInGrid(value);
            }
            mLoading = false;
        }

        private void AddValueInGrid(DmxValue pValue)
        {
            int index = this.dataGridView1.Rows.Add(1);
            DataGridViewRow row = this.dataGridView1.Rows[index];
            row.Tag = pValue;
            row.Cells["col_Min"].Value = Convert.ToString(pValue.StartValue);
            row.Cells["col_Max"].Value = Convert.ToString(pValue.EndValue);
            row.Cells["col_Text"].Value = pValue.Text;
            row.Cells["col_Image"].ToolTipText = pValue.Image;
            if (pValue.Image!=null && pValue.Image != "")
                ((DataGridViewImageCell)(row.Cells["col_Image"])).Value = Image.FromFile(pValue.Image);

            if (mChannel.Type == ChannelType.Virtual)
                row.Cells["col_Copy"].Value = "Select ...";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex <0 || e.ColumnIndex<0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "col_Image")
            {
                string ImagePath = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText;

                Dialog.ImageBrowser Browser = new DmxCreator.Dialog.ImageBrowser(ImagePath);
                //Browser.SelectImage(ImagePath);
                DialogResult res = Browser.ShowDialog();
                if (res != DialogResult.OK)
                    return;

                string DestFile = Browser.SelectedImage;


                if (mFixture is RealFixture)
                {
                    FileInfo Info = new FileInfo(Browser.SelectedImage);
                    string DestDir = Constant.FixtureDir + "\\" + ((RealFixture)mFixture).LightConstructor + "\\" + ((RealFixture)mFixture).LightName + "\\img";
                    if (!Directory.Exists(DestDir))
                        Directory.CreateDirectory(DestDir);
                    DestFile = DestDir + "\\" + Info.Name;
                    if (!File.Exists(DestFile))
                        File.Copy(Browser.SelectedImage, DestFile);
                }
                else
                {
                    FileInfo Info = new FileInfo(Browser.SelectedImage);
                    DestFile = Constant.VirtualDir + "\\" + Info.Name;
                    if (!File.Exists(DestFile))
                        File.Copy(Browser.SelectedImage, DestFile);
                }

                DmxValue val = (DmxValue)this.dataGridView1.Rows[e.RowIndex].Tag;
                val.Image = DestFile;

                this.dataGridView1.Rows[e.RowIndex].Cells["col_Image"].ToolTipText = val.Image;
                if (val.Image != null && val.Image != "")
                    ((DataGridViewImageCell)(this.dataGridView1.Rows[e.RowIndex].Cells["col_Image"])).Value = Image.FromFile(val.Image);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "col_Copy")
            {
                SelectSubChannelDlg dlg = new SelectSubChannelDlg((VirtualFixture)mFixture, (VirtualChannel)mChannel, (DmxValue)dataGridView1.Rows[e.RowIndex].Tag);
                dlg.ShowDialog(this);
            }
       }

        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int index = this.dataGridView1.Rows.Add();
                 
            
            DmxValue val = new DmxValue();
            val.StartValue = GetNewAdress();
            val.Value = GetNewAdress();

            this.mChannel.DmxValues.Add(val);
            AddValueInGrid(val);
            

        }

        private void addSeveralRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSeveralValuesDlg dlg = new AddSeveralValuesDlg();
            dlg.StartValue = GetNewAdress();
            DialogResult res = dlg.ShowDialog(this);

            if (res != DialogResult.OK)
                return;

            int difference = GetDifference(dlg.StartValue, dlg.EndValue, dlg.Number);

            int startValue = dlg.StartValue;

            for (int i = 0; i < dlg.Number; i++)
            {
                DmxValue val = new DmxValue();
                val.StartValue = startValue;
                val.Value = startValue;
                val.EndValue = startValue + difference-1;

                val.Text = "Value " + this.mChannel.DmxValues.Count;

                this.mChannel.DmxValues.Add(val);
                AddValueInGrid(val);

                startValue = startValue + difference;
            }

        }

        private void reworkValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private int GetNewAdress()
        {
            int NewValue = 0;
            if (mChannel.DmxValues.Count != 0)
                NewValue = ((DmxValue)(mChannel.DmxValues[mChannel.DmxValues.Count - 1])).EndValue + 1;
            return NewValue;
    
        }

        private int GetDifference(int pStart, int pEnd, int pNumber)
        {
            return (pEnd - pStart) / pNumber;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                DmxValue value = (DmxValue)row.Tag;
                
                if (dataGridView1.Columns[e.ColumnIndex].Name == "col_Min")
                {
                    value.StartValue = Convert.ToInt32((string)row.Cells[e.ColumnIndex].Value);
                    value.Value = Convert.ToInt32((string)row.Cells[e.ColumnIndex].Value);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "col_Max")
                {
                    value.EndValue = Convert.ToInt32((string)row.Cells[e.ColumnIndex].Value);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "col_Text")
                {
                    value.Text = (string)row.Cells[e.ColumnIndex].Value;
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "col_Image")
                {
                    //value.Image
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this,ex.Message,"Exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //e.Row
            if(e.Row!=null && e.Row.Tag!=null && e.Row.Tag is DmxValue)
                this.mChannel.DmxValues.Remove(e.Row.Tag);
        }

        private void txt_NbLines_KeyDown(object sender, KeyEventArgs e)
        {
            SaveParamters();
        }

        private void txt_NbColumns_KeyDown(object sender, KeyEventArgs e)
        {
            SaveParamters();
        }

        private void txt_NbColumns_TextChanged(object sender, EventArgs e)
        {
            SaveParamters();
        }

        private void txt_NbLines_TextChanged(object sender, EventArgs e)
        {
            SaveParamters();
        }

        private void SaveParamters()
        {
            if (mLoading)
                return;

            try
            {
                this.mChannel.ColumnCount = Convert.ToInt32(this.txt_NbColumns.Text);
                this.mChannel.RowCount = Convert.ToInt32(this.txt_NbLines.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Error");
            }
        }
    }
}
