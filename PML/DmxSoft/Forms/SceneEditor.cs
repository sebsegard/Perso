using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DmxFramework.Fixtures;
using DmxFramework.Scene;
using System.Windows.Forms;

namespace DmxSoft.Forms
{
    public partial class SceneEditor : Form
    {
        Fixture mFixture;
        TreeNode mRootNode;
        TreeNode mSelectedNode;
        Scene mCurrentScene = null;
        Scene mCopiedScene;

        public SceneEditor(Fixture pFixture)
        {
            mFixture = pFixture;
            InitializeComponent();

            this.Text = pFixture.Name + " scene editor";
            this.sceneEditorCtrlr1.Visible = false;
            //this.fixtureButtonConfiguration1.Visible = false;
            this.treeView1.Nodes.Add(mFixture.Name);
            mRootNode = this.treeView1.Nodes[0];
            LoadTree();
            this.treeView1.Sort();
            mCopiedScene = null;

            mRootNode.Expand();
            this.sceneEditorCtrlr1.OnScenePropertiesChanged += new DmxSoft.Control.OnScenePropertiesChangedHandler(sceneEditorCtrlr1_OnScenePropertiesChanged);
            this.fixtureButtonConfiguration1.SetFixture(mFixture);
        }

        void sceneEditorCtrlr1_OnScenePropertiesChanged()
        {
            RefreshTree();
        }

        private void LoadTree()
        {
            foreach (Scene scene in mFixture.Manager.Scenes)
            {
                TreeNode CategoryNode = GetCategoryNode(scene.Category);
                TreeNode node = new TreeNode(scene.Name);
                node.Tag = scene;
                CategoryNode.Nodes.Add(node);
                if (scene == mCurrentScene)
                    this.treeView1.SelectedNode = node;
            }
        }

        private TreeNode GetCategoryNode(string pCategoryName)
        {

            foreach (TreeNode node in mRootNode.Nodes)
            {
                if (node.Text == pCategoryName)
                    return node;
            }
            TreeNode CatNode = new TreeNode(pCategoryName);
            CatNode.Tag = null;
            mRootNode.Nodes.Add(CatNode);
            return CatNode;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.mSelectedNode = e.Node;

            if (e.Button == MouseButtons.Left)
            {
                if (mSelectedNode.Tag != null)
                {
                    this.fixtureButtonConfiguration1.Visible = false;
                    mCurrentScene = (Scene)mSelectedNode.Tag;
                    this.sceneEditorCtrlr1.SetScene(mFixture, (Scene)mSelectedNode.Tag);
                    this.sceneEditorCtrlr1.Visible = true;
                }
                else if (mSelectedNode == mRootNode)
                {
                    this.fixtureButtonConfiguration1.Visible = true;
                    mCurrentScene = null;
                }
                else
                {
                    this.sceneEditorCtrlr1.Visible = false;
                    this.fixtureButtonConfiguration1.Visible = false;
                    mCurrentScene = null;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DmxFramework.Scene.Scene scene = new Scene();
            scene.Name = "New Scene";
            scene.Category = "New Category";

            //mFixture.Manager.Scenes.Add(scene);
            mFixture.Manager.AddScene(scene);
            mCurrentScene = scene;
            RefreshTree();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode == null || this.treeView1.SelectedNode.Tag == null)
                return;


            DialogResult res = MessageBox.Show("Are you sur to delete " + this.treeView1.SelectedNode.FullPath + " ??3", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                DmxFramework.Scene.Scene scene = (DmxFramework.Scene.Scene)this.treeView1.SelectedNode.Tag;

                mFixture.Manager.Scenes.Remove(scene);
                mCurrentScene = null;
                RefreshTree();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshTree();
        }

        private void RefreshTree()
        {
            mRootNode.Nodes.Clear();
            LoadTree();
            this.treeView1.Sort();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            /*if (this.treeView1.SelectedNode == null)
            {
                refreshToolStripMenuItem.Enabled = true;
                addToolStripMenuItem.Enabled = true;
                removeToolStripMenuItem.Enabled = false;
            }
            else if (this.treeView1.SelectedNode.Tag == null)
            {
                refreshToolStripMenuItem.Enabled = true;
                addToolStripMenuItem.Enabled = true;
                removeToolStripMenuItem.Enabled = false;
            }
            else if (this.treeView1.SelectedNode.Tag == null)
            {
                refreshToolStripMenuItem.Enabled = true;
                addToolStripMenuItem.Enabled = false;
                removeToolStripMenuItem.Enabled = true;
            }*/
            if (mCopiedScene == null)
                pasteToolStripMenuItem.Enabled = false;
            else
                pasteToolStripMenuItem.Enabled = true;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.mSelectedNode!= null && this.mSelectedNode.Tag!=null)
                mCopiedScene = (Scene)this.mSelectedNode.Tag;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scene scene = mCopiedScene.Clone();
            mFixture.Manager.AddScene(scene);
            mCurrentScene = scene;
            RefreshTree();
        }

        
    }
}