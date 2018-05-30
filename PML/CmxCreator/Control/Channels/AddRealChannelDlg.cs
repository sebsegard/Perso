using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DmxFramework;
using DmxFramework.Fixtures;
using DmxFramework.Channels;

namespace DmxCreator.Control.Channels
{
    public partial class AddRealChannelDlg : Form
    {
        private Channel mChannel = null;
        private bool mReal = true;


        public AddRealChannelDlg(bool pReal)
        {
            mReal = pReal;
            InitializeComponent();

            this.cmb_Type.Items.Add(ChannelFunction.Basic.ToString());
            this.cmb_Type.Items.Add(ChannelFunction.Pan.ToString());
            this.cmb_Type.Items.Add(ChannelFunction.Tilt.ToString());
            this.cmb_Type.Items.Add(ChannelFunction.Btn.ToString());
            this.cmb_Type.Items.Add(ChannelFunction.List.ToString());
            this.cmb_Type.SelectedIndex = 0;
            this.lbl_Number.Visible = pReal;
            this.txt_Number.Visible = pReal;
            this.DialogResult = DialogResult.Cancel;
        }

        public AddRealChannelDlg(bool pReal, int pNumber)
        {
            mReal = pReal;
            InitializeComponent();

            this.cmb_Type.Items.Add(ChannelFunction.Basic.ToString());
            this.cmb_Type.Items.Add(ChannelFunction.Pan.ToString());
            this.cmb_Type.Items.Add(ChannelFunction.Tilt.ToString());
            this.cmb_Type.Items.Add(ChannelFunction.Btn.ToString());
            this.cmb_Type.Items.Add(ChannelFunction.List.ToString());
            this.cmb_Type.SelectedIndex = 0;
            this.lbl_Number.Visible = pReal;
            this.txt_Number.Visible = pReal;
            this.txt_Number.Text = pNumber.ToString();
            this.DialogResult = DialogResult.Cancel;
        }

        public Channel NewChannel
        {
            get { return mChannel; }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int Number=0;

            if (mReal)
            {

                if (this.txt_Name.Text == "" || this.txt_Number.Text == "" || this.cmb_Type.SelectedIndex == -1)
                {
                    MessageBox.Show("Every thing is mandatory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(this.txt_Number.Text, out Number))
                {
                    MessageBox.Show("Number have to be a number ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mChannel = new RealChannel(this.txt_Name.Text, Number, this.cmb_Type.Text);
            }
            else
            {
                if (this.txt_Name.Text == "" || this.cmb_Type.SelectedIndex == -1)
                {
                    MessageBox.Show("Every thing is mandatory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mChannel = new VirtualChannel(this.txt_Name.Text,this.cmb_Type.Text);

            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}