using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Fixtures;

namespace DmxCreator.Dialog
{
    public partial class AddRealFixture : Form
    {
        private RealFixture mFixture = null;
        
        public AddRealFixture()
        {
            InitializeComponent();
          
            this.fixtureTree1.LoadTree();
        }

        public RealFixture Fixture
        { get { return mFixture; } }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_AddFixture_Click(object sender, EventArgs e)
        {
             this.DialogResult = DialogResult.OK;
             Close();
        }

        private void fixtureTree1_OnRealFixtureSelected(RealFixture pFixture)
        {
            mFixture = pFixture;
        }
    }
}