using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Fixtures;
using DmxFramework.Scene;

namespace DmxSoft.Forms
{
    public partial class QuickScene : Form
    {
        Fixture mFixture;
        
        public QuickScene(Fixture pFixture)
        {
            InitializeComponent();
            mFixture = pFixture;
        }

        

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_Categorie.Text))
                return;

            if (string.IsNullOrEmpty(this.txt_Name.Text))
                return;

            mFixture.Manager.AddQuickScene(this.txt_Categorie.Text, this.txt_Name.Text);


            this.Close();
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}