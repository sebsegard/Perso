using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmxCreator.Dialog
{
    public partial class AddCompanie : Form
    {
        string mCompanieName;
        
        public AddCompanie()
        {
            InitializeComponent();
        }

        public string CompanieName
        {
            get { return mCompanieName; }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (ValidateText())
                Close();
        }

        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                if (ValidateText())
                    Close();
        }

        private bool ValidateText()
        {
            if (this.txt_Name.Text == "")
                return false;

            mCompanieName = this.txt_Name.Text;
            this.DialogResult = DialogResult.OK;
            return true;
        }

        
    }
}