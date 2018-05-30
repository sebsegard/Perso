using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Fixtures;
using DmxFramework.Channels;
using System.IO;

namespace DmxCreator.Control.Channels
{
    public partial class SelectSubChannelDlg : Form
    {
        VirtualFixture mFixture;
        VirtualChannel mChannel;
        DmxValue mDmxValue;

        private bool mLoading = false;
        public SelectSubChannelDlg(VirtualFixture pFixture, VirtualChannel pChannel)
        {
            mFixture = pFixture;
            mChannel = pChannel;
            
            InitializeComponent();

            this.treeView1.ImageList = new ImageList();
            string FilePath = System.Environment.CurrentDirectory + "\\icons\\white.ico";
            Icon ico = new Icon(FilePath);
            this.treeView1.ImageList.Images.Add(ico);

            LoadTree();
        }

        public SelectSubChannelDlg(VirtualFixture pFixture, VirtualChannel pChannel, DmxValue pDmxValue)
        {
            mFixture = pFixture;
            mChannel = pChannel;
            mDmxValue = pDmxValue;

            //mDmxValue.

            InitializeComponent();
            this.treeView1.ImageList = new ImageList();
            string FilePath = System.Environment.CurrentDirectory + "\\icons\\white.ico";
            Icon ico = new Icon(FilePath);
            this.treeView1.ImageList.Images.Add(ico);
            LoadTree();
        }

        private void LoadTree()
        {
            mLoading = true;
            TreeNode MainNode = new TreeNode(mFixture.Name);
            MainNode.Tag = mFixture;
            MainNode.NodeFont = new Font(treeView1.Font, FontStyle.Bold);
            MainNode.ImageIndex = 0;
            foreach (Fixture fix in mFixture.SubFixture)
            {
                TreeNode FixNode = new TreeNode(fix.Name);
                FixNode.Tag = fix;
                FixNode.NodeFont = new Font(treeView1.Font, FontStyle.Bold);
                FixNode.ImageIndex = 0;
                foreach (Channel chan in fix.Channels)
                {
                    TreeNode chanNode = new TreeNode(chan.Name);
                    chanNode.Tag = chan;
                    chanNode.ImageIndex = 0;
                    if (mChannel.VirtualType == VirtualChannelType.ByValue)
                    {
                        if (chan.DmxValues == null || chan.DmxValues.Count == 0)
                            continue;

                        foreach (DmxValue val in chan.DmxValues)
                        {
                            TreeNode valNode = new TreeNode(val.Text);
                            valNode.Tag = val;
                            valNode.Checked = HasToBeChecked(chan,val);
                            chanNode.Nodes.Add(valNode);

                            //img
                            if (File.Exists(val.Image))
                            {
                                Image img = Image.FromFile(val.Image);
                                this.treeView1.ImageList.Images.Add(img);
                                valNode.ImageIndex = this.treeView1.ImageList.Images.Count - 1;
                                valNode.SelectedImageIndex = this.treeView1.ImageList.Images.Count - 1;
                            }
                        }
                    }
                    else
                        chanNode.Checked = mChannel.CopyChannel.Contains(chan);
                    FixNode.Nodes.Add(chanNode);
                }
                MainNode.Nodes.Add(FixNode);
            }
            this.treeView1.Nodes.Add(MainNode);
            this.treeView1.ExpandAll();
            mLoading = false;
        }

        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (mLoading)
                return;

            if (e.Node.Tag == null)
            {
                e.Cancel = true;
                return;
            }
            if (e.Node.Tag is Fixture)
            {
                e.Cancel = true;
                return;
            }


            if (e.Node.Tag is Channel)
            {
                if( mChannel.VirtualType == VirtualChannelType.Copy)
                {
                    if (e.Node.Checked)
                        mChannel.CopyChannel.Remove(e.Node.Tag);
                    else
                        mChannel.CopyChannel.Add(e.Node.Tag);
                    return;
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }

            if (e.Node.Tag is DmxValue)
            {
                if (e.Node.Checked)
                {
                    mDmxValue.SubDmxValues.Remove(e.Node.Tag);
                    mDmxValue.SubChannels.Remove(e.Node.Parent.Tag);
                }
                else
                {
                    mDmxValue.SubDmxValues.Add(e.Node.Tag);
                    mDmxValue.SubChannels.Add(e.Node.Parent.Tag);
                }
                return;
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool HasToBeChecked(Channel pChannel, DmxValue pValue)
        {
            return mDmxValue.SubChannels.Contains(pChannel) && mDmxValue.SubDmxValues.Contains(pValue);
        }
    }
}