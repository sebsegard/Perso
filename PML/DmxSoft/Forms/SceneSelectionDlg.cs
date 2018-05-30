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
using DmxFramework.Scene;


namespace DmxSoft.Forms
{
    public partial class SceneSelectionDlg : Form
    {
        Scene mSelectedScene;

        #region constructor

        public SceneSelectionDlg(Fixture pFixture, Scene pScene)
        {
            InitializeComponent();

            LoadTree(pFixture, pScene);
        }

        #endregion


        #region properties

        public Scene SelectedScene
        {
            get { return mSelectedScene; }
        }

        #endregion

        #region private methods

        private void LoadTree(Fixture pFixture, Scene pScene)
        {
            foreach (Scene scene in pFixture.Manager.Scenes)
            {
                TreeNode CategoryNode = GetCategoryNode(scene.Category);
                TreeNode node = new TreeNode(scene.Name);
                node.Tag = scene;
                CategoryNode.Nodes.Add(node);

                if (scene == pScene)
                {
                    CategoryNode.Expand();
                    this.treeView1.SelectedNode = node;
                }
            }
        }



        private TreeNode GetCategoryNode(string pCategoryName)
        {
            foreach (TreeNode node in this.treeView1.Nodes)
            {
                if (node.Text == pCategoryName)
                    return node;
            }
            TreeNode CatNode = new TreeNode(pCategoryName);
            CatNode.Tag = null;
            this.treeView1.Nodes.Add(CatNode);
            return CatNode;
        }


        #endregion


        #region events
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
                return;

            mSelectedScene = (Scene)e.Node.Tag;

            this.DialogResult = DialogResult.OK;

            Close(); 
        }

        #endregion


    }
}