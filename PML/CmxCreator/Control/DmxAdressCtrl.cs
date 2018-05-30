using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmxCreator.Control
{
    public partial class DmxAdressCtrl : UserControl
    {
        public DmxAdressCtrl()
        {
            InitializeComponent();
           
        }

        public void SetAdress(int pAdress)
        {
            if (pAdress == 0)
                return;

            try
            {
                if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count != 0)
                {
                    foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                        row.Selected = false;
                }
                this.dataGridView1.Rows[pAdress - 1].Selected = true;
                this.dataGridView1.FirstDisplayedScrollingRowIndex = pAdress - 1;
            }
            catch { }
        }

        public void RefreshAddress()
        {
            DmxFramework.Framework.RealFixtureList.Sort(new RealFixtureSorter());
            RefreshAddresses(); 
        }

        void RefreshAddresses()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Rows.Add(255);
            for (int i = 0; i < 255; i++)
            {
                this.dataGridView1.Rows[i].Cells[0].Value = i + 1;
                this.dataGridView1.Rows[i].Cells[1].Value = IntToBinString(i + 1);
            }

            bool color = false;
            foreach (DmxFramework.Fixtures.RealFixture fix in DmxFramework.Framework.RealFixtureList)
            {
                color = !color;
                for (int i = 0; i < fix.Channels.Count; i++)
                {
                    int rowIndex = (fix.StartAddress - 1) + i;
                    if (rowIndex < 0 || rowIndex > 255)
                        continue;

                    this.dataGridView1.Rows[rowIndex].Cells[2].Value = fix.Name + " : " + ((DmxFramework.Channels.Channel)fix.Channels[i]).Name;
                    this.dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = color?Color.LightBlue:Color.LightGreen;
                }
            }
        }

        string IntToBinString(int pValue)
        {
            int val = 0;
            string strToReturn = "";
            for (int i = 7; i >= 0; i--)
            {
                if (Math.Pow(2, i) + val <= pValue)
                {
                    strToReturn += "1";
                    val += (int)Math.Pow(2, i);
                }
                else
                    strToReturn += "0";
            }
            if (val != pValue)
                throw new Exception("unexpected ...");
            return strToReturn;
        }
    }

    public class RealFixtureSorter : IComparer<DmxFramework.Fixtures.RealFixture>
    {

        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(DmxFramework.Fixtures.RealFixture x, DmxFramework.Fixtures.RealFixture y)
        {
            return (x.StartAddress - y.StartAddress);
        }

    }


}
