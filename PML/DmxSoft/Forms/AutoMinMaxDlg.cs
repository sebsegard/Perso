using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Forms
{
    public partial class AutoMinMaxDlg : Form
    {
        public AutoMinMaxDlg()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            /*if (!Check(this.txt_PanMin.Text))
            {
                Messa
            }*/
            




        }

        private bool Check(string pText)
        {
            int val = 0;

            if (int.TryParse(pText, out val))
            {
                if (val >= 0 && val <= 255)
                    return true;
            }
            return false;
        }
      
    }
}