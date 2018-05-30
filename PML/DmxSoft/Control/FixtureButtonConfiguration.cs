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
using DmxFramework.Scene;

namespace DmxSoft.Forms
{
    public partial class FixtureButtonConfiguration : UserControl
    {
        private Fixture mFixture;

        public FixtureButtonConfiguration()
        {
            InitializeComponent();
        }

        public void SetFixture(Fixture pFixture)
        {
            mFixture = pFixture;
            this.txt_col.Text = pFixture.Manager.ColumnCount+"";
            this.txt_row.Text = pFixture.Manager.RowCount+"";
            LoadTable();
        }



        private void btn_apply_Click(object sender, EventArgs e)
        {
            try
            {
                mFixture.Manager.ColumnCount = Convert.ToInt32(this.txt_col.Text);
                mFixture.Manager.RowCount = Convert.ToInt32(this.txt_row.Text);
                LoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTable()
        {
            if (mFixture.Manager.RowCount == 0 || mFixture.Manager.ColumnCount == 0)
                return;
            
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();

            for (int i = 0; i < mFixture.Manager.ColumnCount; i++)
                this.dataGridView1.Columns.Add(i+"", "" + (i + 1));

            this.dataGridView1.Rows.Add(mFixture.Manager.RowCount);


            foreach (Scene scene in mFixture.Manager.Scenes)
            {
                if (scene.BtnX <=0 || scene.BtnY <= 0 || scene.BtnX > mFixture.Manager.ColumnCount || scene.BtnY > mFixture.Manager.RowCount)
                    continue;

                this.dataGridView1.Rows[scene.BtnY - 1].Cells[scene.BtnX - 1].Tag = scene;
                this.dataGridView1.Rows[scene.BtnY - 1].Cells[scene.BtnX - 1].Value = scene.Category + " / " + scene.Name;

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Scene scene = (Scene)this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
            Forms.SceneSelectionDlg dlg = new SceneSelectionDlg(mFixture, scene);
            DialogResult res = dlg.ShowDialog(this);
            if (res != DialogResult.OK)
                return;

            if (scene != null)
            {
                scene.BtnX = -1;
                scene.BtnY = -1;
            }

            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = dlg.SelectedScene;
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dlg.SelectedScene.Category + " / " + dlg.SelectedScene.Name;

            dlg.SelectedScene.BtnX = e.ColumnIndex+1;
            dlg.SelectedScene.BtnY = e.RowIndex+1;
        }
    }
}
