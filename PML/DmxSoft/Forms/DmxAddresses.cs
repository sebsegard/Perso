using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Forms
{
   
    
    public partial class DmxAddresses : Form
    {
        public DmxAddresses()
        {
            InitializeComponent();

            DmxFramework.Framework.RealFixtureList.Sort(new RealFixtureSorter());
            RefreshAddresses();
            
        }

        void RefreshAddresses()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Rows.Add(511);
            for (int i = 0; i < 511; i++)
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
                    if (rowIndex < 0 || rowIndex > 511)
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
            for (int i = 8; i >= 0; i--)
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