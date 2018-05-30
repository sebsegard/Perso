using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Fixtures;

namespace DmxCreator.Control
{
    public partial class FixtureConfCtrl : UserControl
    {
        RealFixture mFixture;
        public event OnFixtureChangedEvent OnFixtureChanged;

        public FixtureConfCtrl()
        {
            InitializeComponent();
            
        }

        public void RefreshAdress()
        {
            this.dmxAdressCtrl1.RefreshAddress();
        }

        public void SetFixture(RealFixture pFixture)
        {
            mFixture = pFixture;
            this.txt_Address.Text = pFixture.StartAddress + "";
            this.txt_Constructor.Text = pFixture.LightConstructor;
            this.txt_Product.Text = pFixture.LightName;
            this.txt_Name.Text = pFixture.Name;

            dmxAdressCtrl1.SetAdress(pFixture.StartAddress);
            
        }

        private void txt_Address_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!CheckAddress(this.txt_Address.Text))
                {
                    this.txt_Address.Text = mFixture.StartAddress + "";
                }
            }

        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            if (CheckAddress(this.txt_Address.Text))
            {
                MessageBox.Show("Address OK");
            }
            else
            {
                this.txt_Address.Text = mFixture.StartAddress + "";
            }

        }

        private bool CheckAddress(string pValue)
        {
            int Value =0;
            int Max = 0;
            if (!int.TryParse(pValue, out Value))
            {
                MessageBox.Show(this, "Value must be an integer > 0 and <512", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Value < 1 || Value > 511)
            {
                MessageBox.Show(this,"Value must be an integer > 0 and <512","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            Max = Value + mFixture.Channels.Count;

            foreach (DmxFramework.Fixtures.RealFixture fix in DmxFramework.Framework.RealFixtureList)
            {
                if (fix == mFixture)
                    continue;

                if (Value < fix.StartAddress)
                {
                    if (Max <= fix.StartAddress)
                        continue;
                }
                else if (Max >= fix.StartAddress+fix.Channels.Count && Value>=fix.StartAddress+fix.Channels.Count)
                    continue;

                MessageBox.Show(this, "Address collission with "+fix.Name, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(Value == mFixture.StartAddress)
                return true;

            mFixture.StartAddress = Value;

            this.dmxAdressCtrl1.RefreshAddress();
            dmxAdressCtrl1.SetAdress(mFixture.StartAddress);

            return true;

        }

        private void txt_Name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mFixture.Name = this.txt_Name.Text;
                if (OnFixtureChanged != null)
                    OnFixtureChanged(mFixture);
            }

        }
    }
}
