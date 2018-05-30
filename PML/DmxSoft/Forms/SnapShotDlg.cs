using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Channels;

namespace DmxSoft.Forms
{
    public partial class SnapShotDlg : Form
    {
        public SnapShotDlg()
        {
            InitializeComponent();

            foreach (SnapShot snap in SnapShot.List)
                this.listSnap.Items.Add(snap);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SnapShot snap = (SnapShot)this.listSnap.SelectedItem;
            if (snap == null)
                return;

            SnapShot.List.Remove(snap);
            this.listSnap.SelectedIndex = -1;
            this.listSnap.Items.Remove(snap);
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            SnapShot snap = (SnapShot)this.listSnap.SelectedItem;
            if (snap == null)
                return;

            snap.Apply();
        }

        private void btn_Take_Click(object sender, EventArgs e)
        {
            if (this.txt_Name.Text == "")
            {
                return;
            }

            SnapShot snap = new SnapShot(this.txt_Name.Text);
            snap.Take();
            this.listSnap.Items.Add(snap);
        }
    }
}