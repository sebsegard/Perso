using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DmxFramework.Fixtures;

namespace DmxCreator.Control
{

    public delegate void OnVirtualFixtureSelectedDelegate(VirtualFixture pFixture);
    public delegate void OnRealFixtureSelectedDelegate(RealFixture pFixture);


    public partial class WorkspaceTree : UserControl
    {
        #region members

        private TreeNode mSelectedNode;

        public event OnVirtualFixtureSelectedDelegate OnVirtualFixtureSelected;
        public event OnRealFixtureSelectedDelegate OnRealFixtureSelected;


        #endregion

        public WorkspaceTree()
        {
            InitializeComponent();
            this.treeView1.ImageList = new ImageList();
        }

        #region chargement

        public void Clear()
        {
            this.treeView1.Nodes.Clear();
        }

        public void LoadTree()
        {
            string FilePath = System.Environment.CurrentDirectory + "\\icons\\white.ico";
            Icon ico = new Icon(FilePath);
            this.treeView1.ImageList.Images.Add(ico);
            //foreach (Fixture fix in mFrameWork.Fixtures)
            this.treeView1.Nodes.Add(LoadFixture(DmxFramework.Framework.Fixtures));

            this.treeView1.ExpandAll();
        }

        private TreeNode LoadFixture(Fixture pFixture)
        {
            TreeNode Node = new TreeNode(pFixture.Name);
            Node.Tag = pFixture;
            if (pFixture.Type == FixtureType.Real)
            {
                string FilePath = System.Environment.CurrentDirectory + "\\" + ((RealFixture)pFixture).Image;

                if (File.Exists(FilePath))
                {
                    Image img = Image.FromFile(FilePath);
                    this.treeView1.ImageList.Images.Add(img);
                    Node.ImageIndex = this.treeView1.ImageList.Images.Count - 1;
                    Node.SelectedImageIndex = this.treeView1.ImageList.Images.Count - 1;
                }
            }
            else
            {
                Node.ImageIndex = 0;
                foreach (Fixture fix in ((VirtualFixture)pFixture).SubFixture)
                    Node.Nodes.Add(LoadFixture(fix));
            }
            return Node;
        }

        #endregion


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.mSelectedNode = e.Node;
            if (e.Button == MouseButtons.Left)
            {
                LeftClick(e);
            }
            else if(e.Button == MouseButtons.Right)
            {
                RightClick(e);
            }
        }

        private void LeftClick(TreeNodeMouseClickEventArgs e)
        {
            Fixture fix = (Fixture)mSelectedNode.Tag;
            if (fix.Type == FixtureType.Real && this.OnRealFixtureSelected!=null)
            {
                OnRealFixtureSelected((RealFixture)fix);
            }
            else if(fix.Type == FixtureType.Virtual && this.OnVirtualFixtureSelected!=null)
            {
                OnVirtualFixtureSelected((VirtualFixture)fix);
            }
        }

        private void RightClick(TreeNodeMouseClickEventArgs e)
        {
            Fixture fix = (Fixture)mSelectedNode.Tag;

            if (fix.Type == FixtureType.Real)
            {
                addToolStripMenuItem.Visible = false;
                AddVirtualStripMenuItem1.Visible = false;
            }
            else
            {
                addToolStripMenuItem.Visible = true;
                AddVirtualStripMenuItem1.Visible = true;
            }

            this.contextMenuStrip1.Show(this.treeView1, e.Location);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            Dialog.AddRealFixture dlg= new DmxCreator.Dialog.AddRealFixture();
            if (dlg.ShowDialog(this) == DialogResult.Cancel)
                return;

            if (dlg.Fixture == null)
                return;

           

            dlg.Fixture.Name = dlg.Fixture.LightName;
            //foreach(DmxFramework.Channels.ch

            VirtualFixture fix = (VirtualFixture)mSelectedNode.Tag;
            fix.AddFixture(dlg.Fixture);
            mSelectedNode.Nodes.Add(LoadFixture(dlg.Fixture));
            //DialogResult res = 
        }

        private void AddVirtualStripMenuItem1_Click(object sender, EventArgs e)
        {
            VirtualFixture fix = (VirtualFixture)mSelectedNode.Tag;


            VirtualFixture NewFixture = new VirtualFixture("New Virtual Fixture");
            fix.AddFixture(NewFixture);
            mSelectedNode.Nodes.Add(LoadFixture(NewFixture));
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixture fix = (Fixture)mSelectedNode.Tag;

            DialogResult res = MessageBox.Show(this, "Are you sur to delete " + fix.Path + " ??","Please confirm ...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.No)
                return;

            try
            {
                //first delete from the treeview
                this.treeView1.Nodes.Remove(mSelectedNode);

                VirtualFixture Parent = (VirtualFixture)fix.Parent;
                Parent.RemoveFixture(fix);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void ChangeFixture(Fixture pFixture)
        {
            ChangeFixtureInNode(this.treeView1.Nodes[0], pFixture);
        }

        private bool ChangeFixtureInNode(TreeNode pNode, Fixture pFixture)
        {
            if (pNode.Tag != null && pNode.Tag == pFixture)
            {
                pNode.Text = pFixture.Name;
                return true;
            }

            foreach (TreeNode node in pNode.Nodes)
            {
                if (ChangeFixtureInNode(node, pFixture))
                    return true;
            }
            return false;
        }


    }
}
