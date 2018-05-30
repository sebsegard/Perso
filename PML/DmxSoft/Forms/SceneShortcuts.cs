using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Fixtures;

namespace DmxSoft.Forms
{
    public partial class SceneShortcuts : Form
    {
        public SceneShortcuts(FixtureButtonConfiguration pFixture)
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}