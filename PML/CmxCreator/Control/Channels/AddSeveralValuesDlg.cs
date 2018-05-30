using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmxCreator.Control.Channels
{
    public partial class AddSeveralValuesDlg : Form
    {
        #region members

        private int mNumber =0;
        private int mStartValue =0;
        private int mEndValue =255;

        #endregion

        #region constructor

        public AddSeveralValuesDlg()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region properties

        public int Number
        {
            get { return mNumber; }
        }

        public int StartValue
        {
            get { return mStartValue; }
            set
            {
                mStartValue = value;
                this.txt_Start.Text = mStartValue + "";
            }
        }

        public int EndValue
        {
            get { return mEndValue; }
        }

        #endregion

        #region User Events

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int Number = 0;
            int Start = 0;
            int End = 0;

            if (!int.TryParse(this.txt_Number.Text, out Number))
            {
                MessageBox.Show(this, "Number must be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!int.TryParse(this.txt_Start.Text, out Start))
            {
                MessageBox.Show(this, "Start must be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!int.TryParse(this.txt_End.Text, out End))
            {
                MessageBox.Show(this, "End must be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.mNumber = Number;
            this.mStartValue = Start;
            this.mEndValue = End;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}