using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DmxFramework;
using DmxFramework.Fixtures;
using DmxFramework.Scene;

namespace DmxSoft.Forms
{
    public partial class SceneExplorer : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        
        Fixture mMainFixture;
        //TreeNode mSelectedNode = null;
        
        #region constructor

        public SceneExplorer(Framework pFrameWork)
        {

            InitializeComponent();
            mMainFixture = DmxFramework.Framework.Fixtures;
            LoadTree();   
        }

        public SceneExplorer(Fixture pFixture)
        {
            InitializeComponent();
            mMainFixture = pFixture;
            LoadTree();
        }

        #endregion

        #region LoadExplorer

        private void LoadTree()
        {
            
            //foreach (Fixture fix in mFrameWork.Fixtures)
            this.treeView1.Nodes.Add(LoadFixture(mMainFixture));
            this.treeView1.Nodes[0].Expand();
        }

        private TreeNode LoadFixture(Fixture pFixture)
        {
           

            TreeNode Node = new TreeNode(pFixture.Name);
            Node.NodeFont = new Font(treeView1.Font, FontStyle.Bold); ;
            Node.Tag = pFixture.Manager;
            pFixture.Manager.HmiObject = Node;
            Color ForeColor = Color.Black;
            if (pFixture.Manager.State == SceneManagerState.Paused)
                ForeColor = Color.Orange;
            Node.ForeColor = ForeColor;
            pFixture.Manager.OnSceneManagerStateChanged += new OnSceneManagerStateChangedHandler(Manager_OnSceneManagerStateChanged);

            if (pFixture.Type == FixtureType.Real)
            {
               
            }
            else
            {
                
                TreeNode FixtureNode = new TreeNode("Fixtures");
                FixtureNode.ForeColor = ForeColor;

                foreach (Fixture fix in ((VirtualFixture)pFixture).SubFixture)
                    FixtureNode.Nodes.Add(LoadFixture(fix));

                Node.Nodes.Add(FixtureNode);
                Node.Expand();
            }

            foreach (Scene scene in pFixture.Manager.Scenes)
            {
                TreeNode CatNode = GetSceneCategoryNode(Node, scene.Category);
                CatNode.ForeColor = ForeColor;

                TreeNode SceneNode = new TreeNode(scene.Name);
                SceneNode.ForeColor = ForeColor;
                if (scene.State != SceneState.Nothing)
                    SceneNode.BackColor = Color.Green;
                SceneNode.Tag = scene;
                scene.OnSceneStateChanged += new OnSceneStateChangeHandler(scene_OnSceneStateChanged);
                scene.HmiObject = SceneNode;
                CatNode.Nodes.Add(SceneNode);
            }


            return Node;
        }

        

       

      

        private TreeNode GetSceneCategoryNode(TreeNode pNode, string pCategoryNode)
        {
            foreach (TreeNode node in pNode.Nodes)
            {
                if (node.Text == pCategoryNode)
                    return node;
            }
            TreeNode CatNode = new TreeNode(pCategoryNode);
            CatNode.Tag = null;
            pNode.Nodes.Add(CatNode);
            return CatNode;
        }

        #endregion

        #region explorer event
        private void Explorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        #endregion

        #region user event

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag is Scene)
            {
                Scene scene = ((Scene)(e.Node.Tag));

                if (scene.State != SceneState.Nothing)
                    scene.Remove();
                else
                    scene.Play();
            }
        }

        #endregion

        void Manager_OnSceneManagerStateChanged(SceneManager pManager, SceneManagerState pState)
        {
            TreeNode FixNode = (TreeNode)pManager.HmiObject;
            if (pState == SceneManagerState.Paused)
            {
                if (FixNode.Parent != null)
                {
                    FixNode.Parent.ForeColor = Color.Orange;
                    SetColorToNode(FixNode, Color.Orange);
                }
            }
            else
            {
                if (FixNode.Parent != null)
                {
                    FixNode.Parent.ForeColor = Color.Orange;
                    SetColorToNode(FixNode, Color.Black);
                }
            }
        }

        void scene_OnSceneStateChanged(Scene pScene, SceneState pState)
        {
            TreeNode SceneNode = (TreeNode)pScene.HmiObject;
            if (pState == SceneState.PlayingExclusive)
            {
                SceneNode.BackColor = Color.Green;
            }
            else if (pState == SceneState.Nothing)
            {
                SceneNode.BackColor = Color.White;
            }
            
        }


        void SetColorToNode(TreeNode pNode, Color pColor)
        {
            pNode.ForeColor = pColor;
            foreach (TreeNode node in pNode.Nodes)
                SetColorToNode(node, pColor);
        }

        protected override string GetPersistString()
        {
            return this.GetType().ToString() + "," + this.mMainFixture.Path;
        }

        
        
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            LoadTree();
        }
    }
}