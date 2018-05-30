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
    //public delegate void OnRealFixtureSelectedEvent(DirectoryInfo pFolder, string pConstructor, string pLightName);
    public delegate void OnRealFixtureSelectedEvent(RealFixture pFixture);
    
    public partial class FixtureTree : UserControl
    {
        //private Point mLastLocation;

        public event OnRealFixtureSelectedEvent OnRealFixtureSelected = null;
        
        public FixtureTree()
        {
            InitializeComponent();
        }

        public void LoadTree()
        {
            this.treeView1.Nodes.Clear();
            DirectoryInfo Root = new DirectoryInfo(Constant.FixtureDir);
            DirectoryInfo[] Companies = Root.GetDirectories();
            foreach (DirectoryInfo Company in Companies)
            {
                TreeNode CompanyNode = new TreeNode(Company.Name);

               
                CompanyNode.NodeFont = new Font(treeView1.Font, FontStyle.Bold); ;

                DirectoryInfo[] fixtures = Company.GetDirectories();


                foreach (DirectoryInfo fixture in fixtures)
                {
                    TreeNode FixtureNode = new TreeNode(fixture.Name);
                    FixtureNode.Tag = null;
                    CompanyNode.Nodes.Add(FixtureNode);
                }
                this.treeView1.Nodes.Add(CompanyNode);
            }
            this.treeView1.Sort();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.treeView1.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.Parent == null)
                {
                    this.contextMenuStrip1.Show(this.treeView1, e.Location);
                }
                else
                    this.contextMenuStrip2.Show(this.treeView1, e.Location);
                
            }
            else
            {
                if (e.Node.Parent == null)
                    return;

                if (e.Node.Tag != null)
                {
                    /*string ConstructorName = e.Node.Parent.Text;
                    string LightName = e.Node.Text;


                  
                    /*if (OnRealFixtureSelected != null)*/
                    RealFixture fix = (RealFixture)e.Node.Tag;
                  
                    OnRealFixtureSelected(fix);
                }
                else
                {
                    string ConstructorName = e.Node.Parent.Text;
                    string LightName = e.Node.Text;
                   
                    RealFixture fix = new RealFixture(ConstructorName, LightName);
                    e.Node.Tag = fix;
                    OnRealFixtureSelected(fix);
                }
            }


        }

        public void AddCompanie(string pCompanieName)
        {
            DirectoryInfo Root = new DirectoryInfo(Constant.FixtureDir);
            Root.CreateSubdirectory(pCompanieName);
            LoadTree();
        }


        public void Save()
        {
            foreach (TreeNode CompanyNode in this.treeView1.Nodes)
            {
                foreach (TreeNode FictureNode in CompanyNode.Nodes)
                {
                    RealFixture fix = (RealFixture)FictureNode.Tag;
                    if (fix == null)
                        continue;
                    if (fix.ToSave)
                        fix.Save();
                }
            }
        }

        private void addFixtureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog.AddFixture dlg = new DmxCreator.Dialog.AddFixture();
            DialogResult res =  dlg.ShowDialog(this);
            if (res == DialogResult.OK && dlg.FixtureName!=null && dlg.FixtureName!="")
            {
                 RealFixture fix =new RealFixture(this.treeView1.SelectedNode.Text,dlg.FixtureName);
                 TreeNode node = new TreeNode(fix.LightName);
                 node.Tag = fix;

                 DirectoryInfo Root = new DirectoryInfo(Constant.FixtureDir + "/" + this.treeView1.SelectedNode.Text);

                 if (!Directory.Exists(Constant.FixtureDir + "/" + this.treeView1.SelectedNode.Text + "/" + dlg.FixtureName))
                    Root.CreateSubdirectory(dlg.FixtureName);
                 
                 
                 this.treeView1.SelectedNode.Nodes.Add(node);
                 this.treeView1.SelectedNode.Expand();
                 this.treeView1.SelectedNode = node;
            }
        }

        private void applyChangeInWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode.Tag == null)
                return;

            RealFixture fix = (RealFixture)this.treeView1.SelectedNode.Tag;

            DmxFramework.Framework.Fixtures.RefreshFixture(fix);

        }
 


    }
}
