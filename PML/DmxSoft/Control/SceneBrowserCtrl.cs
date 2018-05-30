using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework;
using DmxFramework.Fixtures;
using DmxFramework.Scene;
using DmxFramework.Channels;

namespace DmxSoft.Control
{
    public delegate void OnDoubleClickEvent(DmxFramework.Keyboard.Action pAction);
    
    public partial class SceneBrowserCtrl : UserControl
    {
        //private DmxFramework.Scene.Scene mSeleted = null;
        private DmxFramework.Keyboard.Action mAction=null;

        public event OnDoubleClickEvent OnDoubleClicked = null;
        
        public SceneBrowserCtrl()
        {
            InitializeComponent();
        }

        public DmxFramework.Keyboard.Action Action
        {
            get { return mAction; }
        }



        public void LoadTree()
        {
            TreeNode RootNode = new TreeNode("Pimp my lights");
            LoadFixtureNode(DmxFramework.Framework.Fixtures, RootNode);


            this.treeView1.Nodes.Add(RootNode);
            RootNode.Expand();
        }

        private void LoadFixtureNode(Fixture pFixture, TreeNode pNode)
        {
            pNode.NodeFont = new Font(treeView1.Font, FontStyle.Bold); ;
            if (pFixture.Type == FixtureType.Virtual)
            {
                foreach (Fixture fix in ((VirtualFixture)pFixture).SubFixture)
                {
                    TreeNode node = new TreeNode(fix.Name);

                    LoadFixtureNode(fix, node);
                    pNode.Nodes.Add(node);
                    pNode.Tag = null;
                }            
            }

            TreeNode GeneralBtnNode = new TreeNode("Button");
            GeneralBtnNode.NodeFont = new Font(treeView1.Font, FontStyle.Bold);
            GeneralBtnNode.ForeColor = Color.Orange;
            foreach (Channel chan in pFixture.Channels)
            {
                if (chan.Function != ChannelFunction.Btn && chan.Function!= ChannelFunction.List)
                    continue;

                TreeNode ChanNode = new TreeNode(chan.Name);
                ChanNode.Tag = chan;
                ChanNode.ForeColor = Color.Orange;
                foreach (DmxFramework.Channels.DmxValue val in chan.DmxValues)
                {
                    TreeNode valNode = new TreeNode(val.Text);
                    valNode.ForeColor = Color.Orange;
                    valNode.Tag = val;
                    ChanNode.Nodes.Add(valNode);
                }

                GeneralBtnNode.Nodes.Add(ChanNode);
            }
            if (GeneralBtnNode.Nodes.Count != 0)
                pNode.Nodes.Add(GeneralBtnNode);
            
            TreeNode GeneralSceneNode = new TreeNode("Scene");
            GeneralSceneNode.NodeFont = new Font(treeView1.Font, FontStyle.Bold);
            GeneralSceneNode.ForeColor = Color.Blue;
            foreach (Scene scene in pFixture.Manager.Scenes)
            {
                TreeNode CatNode = GetSceneCategoryNode(GeneralSceneNode, scene.Category);
                GeneralSceneNode.ForeColor = Color.Blue;
                TreeNode SceneNode = new TreeNode(scene.Name);
                SceneNode.ForeColor = Color.Blue;
                SceneNode.Tag = scene;
                CatNode.Nodes.Add(SceneNode); 
            }
            if (GeneralSceneNode.Nodes.Count != 0)
                pNode.Nodes.Add(GeneralSceneNode);
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
            return CatNode ;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag is DmxFramework.Scene.Scene)
            {
                this.mAction = new DmxFramework.Keyboard.Action((DmxFramework.Scene.Scene)e.Node.Tag);
                this.mAction.Path = e.Node.FullPath;
            }
            else if (e.Node.Tag != null && (e.Node.Tag is DmxFramework.Channels.DmxValue))
            {
                this.mAction = new DmxFramework.Keyboard.Action((DmxFramework.Channels.Channel)e.Node.Parent.Tag, (DmxFramework.Channels.DmxValue)e.Node.Tag);
                this.mAction.Path = e.Node.FullPath;
            }
            else
            {
                this.mAction = null;
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag is DmxFramework.Scene.Scene)
            {
                this.mAction = new DmxFramework.Keyboard.Action((DmxFramework.Scene.Scene)e.Node.Tag);
                this.mAction.Path = e.Node.FullPath;
            }
            else if (e.Node.Tag != null && (e.Node.Tag is DmxFramework.Channels.DmxValue))
            {
                this.mAction = new DmxFramework.Keyboard.Action((DmxFramework.Channels.Channel)e.Node.Parent.Tag, (DmxFramework.Channels.DmxValue)e.Node.Tag);
                this.mAction.Path = e.Node.FullPath;
            }
            else
            {
                this.mAction = null;
            }

            if (mAction != null && OnDoubleClicked != null)
                OnDoubleClicked(mAction);
        }


    }
}
