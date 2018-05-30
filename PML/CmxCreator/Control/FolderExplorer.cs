using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DmxCreator.Control
{
     public delegate void OnPathSelectedEvent(string Path);

    public partial class FolderExplorer : UserControl
    {
        public event OnPathSelectedEvent OnPathSelected;
        
        public FolderExplorer()
        {
            InitializeComponent();

        }

        public void LoadPath(string Path)
        {
            DirectoryInfo inf = new DirectoryInfo(Path);
            this.textBox1.Text = inf.FullName;

            
            //inf.Parent
            TreeNode PathNode = new TreeNode(inf.Name);
            //node.sele
            TreeNode ChildNode = PathNode;
            PathNode.Tag = inf;

            DirectoryInfo[] SubInf = inf.GetDirectories();
            for (int i = 0; i < SubInf.Length; i++)
            {
                TreeNode SubNode = new TreeNode(SubInf[i].Name);
                SubNode.Tag = SubInf[i];
                DirectoryInfo[] SubInf2 = SubInf[i].GetDirectories();
                for (int j = 0; j < SubInf2.Length; j++)
                {
                    TreeNode node = new TreeNode(SubInf2[j].Name);
                    node.Tag = SubInf2[j];
                    SubNode.Nodes.Add(node);
                }
                PathNode.Nodes.Add(SubNode);
                
            }
            PathNode.Expand();
            while (inf.Parent != null)
            {
                inf = inf.Parent;

                TreeNode MainNode = new TreeNode(inf.Name);
                MainNode.Expand();
                MainNode.Tag = inf;
                SubInf = inf.GetDirectories();
                for (int i = 0; i < SubInf.Length; i++)
                {
                    if (SubInf[i].Name == ChildNode.Text)
                        MainNode.Nodes.Add(ChildNode);
                    else
                    {
                        try
                        {
                            TreeNode SubNode = new TreeNode(SubInf[i].Name);
                            SubNode.Tag = SubInf[i];
                            
                            DirectoryInfo[] SubInf2 = SubInf[i].GetDirectories();
                            for (int j = 0; j < SubInf2.Length; j++)
                            {
                                TreeNode node = new TreeNode(SubInf2[j].Name);
                                node.Tag = SubInf2[j];
                                SubNode.Nodes.Add(node);
                            }
                            MainNode.Nodes.Add(SubNode);
                        }
                        catch { }
                    }
                }
                ChildNode = MainNode;
            }
            

            this.treeView1.Nodes.Add(ChildNode);
            //LoadTree()
            this.treeView1.SelectedNode = PathNode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (OnPathSelected != null)
                OnPathSelected(((DirectoryInfo)e.Node.Tag).FullName);

            this.textBox1.Text = ((DirectoryInfo)e.Node.Tag).FullName;
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                if (node.Nodes.Count != 0)
                    continue;

                DirectoryInfo inf = (DirectoryInfo)node.Tag;
                DirectoryInfo[] SubInf = inf.GetDirectories();
                for (int i = 0; i < SubInf.Length; i++)
                {
                    TreeNode newNode = new TreeNode(SubInf[i].Name);
                    newNode.Tag = SubInf[i];
                    node.Nodes.Add(newNode);
                }
            }
        }


    }
}
