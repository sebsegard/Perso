using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DmxFramework.Workspace;

namespace DmxCreator.Dialog
{
    public partial class OpenWorkspaceDlg : Form
    {
        private Workspace mSelectedWorkspace;

        
        
        public OpenWorkspaceDlg()
        {
            InitializeComponent();
            List<Workspace> wkpList = Manager.GetWorkspaceList();
            foreach (Workspace wkp in wkpList)
                this.listBox1.Items.Add(wkp);

            this.DialogResult = DialogResult.Cancel;
        }

        public Workspace SelectedWorkspace
        {
            get { return mSelectedWorkspace; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (this.listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a workspace to load");
                return;
            }
            this.DialogResult = DialogResult.OK;
            mSelectedWorkspace = (Workspace)this.listBox1.SelectedItem;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}