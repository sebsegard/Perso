using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Channels;
using DmxFramework.Scene;
using DmxFramework.Fixtures;

namespace DmxSoft.Control
{
    public delegate void OnChannelSelectedEvent(Channel pChannel);
    public delegate void OnSceneSelectedEvent(Scene pScene);
    
    public partial class FullTreeCtrl : UserControl
    {
        private bool mLoadScene;
        private bool mLoadChannel;
        private bool mHideNonBtnChannel;
        private bool mMultiSelection;
        private bool mLoading;
        private TreeNode mSelectedNode;

        private Channel mSelectedChannel;
        private Scene mSelectedScene;

        private List<Channel> mCheckedChannels;
        private List<Scene> mCheckedScenes;



        public event OnChannelSelectedEvent OnChannelSelected;
        public event OnSceneSelectedEvent OnSceneSelected;

       
	
        
        public FullTreeCtrl()
        {
            InitializeComponent();
            mMultiSelection = false;
            this.treeView1.CheckBoxes = mMultiSelection;
        }

        #region Properties
        public bool LoadScene
        {
            get { return mLoadScene; }
            set { mLoadScene = value; }
        }


        public bool LoadChannel
        {
            get { return mLoadChannel; }
            set { mLoadChannel = value; }
        }

        public bool HideNonBtnChannel
        {
            get { return mHideNonBtnChannel; }
            set { mHideNonBtnChannel = value; }
        }

        public bool MultiSelection
        {
            get { return mMultiSelection; }
            set { mMultiSelection = value; }
        }


        public Channel SelectedChannel
        {
            get { return mSelectedChannel; }
            set { mSelectedChannel = value; }
        }

        public Scene SelectedScene
        {
            get { return mSelectedScene; }
            set { mSelectedScene = value; }
        }

        public List<Channel> CheckedChannels
        {
            get { return mCheckedChannels; }
            set { mCheckedChannels = value; }
        }

        public List<Scene> CheckedScenes
        {
            get { return mCheckedScenes; }
            set { mCheckedScenes = value; }
        }


        #endregion


        public void Reset()
        {
            this.treeView1.Nodes.Clear();
            mSelectedChannel = null;
            mSelectedScene = null;
            mCheckedChannels = new List<Channel>();
            mCheckedScenes = new List<Scene>();
        }

        public void LoadTree()
        {
            mLoading = true;
            TreeNode RootNode = new TreeNode("Pimp my lights");
            LoadFixtureNode(DmxFramework.Framework.Fixtures, RootNode);


            this.treeView1.Nodes.Add(RootNode);
            RootNode.Expand();
            mLoading = false;

            this.treeView1.SelectedNode = mSelectedNode;
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

            if (mLoadChannel)
                LoadChannelMode(pFixture, pNode);

            if(mLoadScene)
                LoadSceneNode(pFixture, pNode);
            
        }

        private void LoadChannelMode(Fixture pFixture, TreeNode pNode)
        {
            TreeNode GeneralBtnNode = new TreeNode("Channel");
            GeneralBtnNode.NodeFont = new Font(treeView1.Font, FontStyle.Bold);
            GeneralBtnNode.ForeColor = Color.Orange;
            foreach (Channel chan in pFixture.Channels)
            {
                if (chan.Function != ChannelFunction.Btn && mHideNonBtnChannel)
                    continue;

                TreeNode ChanNode = new TreeNode(chan.Name);
                ChanNode.Tag = chan;
                ChanNode.ForeColor = Color.Orange;

                if (mHideNonBtnChannel)
                {
                    foreach (DmxFramework.Channels.DmxValue val in chan.DmxValues)
                    {
                        TreeNode valNode = new TreeNode(val.Text);
                        valNode.ForeColor = Color.Orange;
                        valNode.Tag = val;
                        ChanNode.Nodes.Add(valNode);
                    }
                }

                if (chan == mSelectedChannel)
                    mSelectedNode = ChanNode;

                if (mCheckedChannels.Contains(chan))
                    ChanNode.Checked = true;

                GeneralBtnNode.Nodes.Add(ChanNode);


            }
            if (GeneralBtnNode.Nodes.Count != 0)
                pNode.Nodes.Add(GeneralBtnNode);
        }

        private void LoadSceneNode(Fixture pFixture, TreeNode pNode)
        {
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

                if (scene == mSelectedScene)
                    mSelectedNode = SceneNode;

                if (mCheckedScenes.Contains(scene))
                    SceneNode.Checked = true;
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
            return CatNode;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (mLoading)
                return;

            if (e.Node.Tag == null)
            {
                SelectScene(null);
                SelectChannel(null);
            }
            else if (e.Node.Tag is Channel)
            {
                SelectChannel((Channel)e.Node.Tag);
                SelectScene(null);
            }
            else if (e.Node.Tag is Scene)
            {
                SelectChannel(null);
                SelectScene((Scene)e.Node.Tag);
            }


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

            if (e.Node.Tag is Channel)
            {
                Channel chan = (Channel)e.Node.Tag;
                if (!mCheckedChannels.Contains(chan))
                    mCheckedChannels.Add(chan);
                else
                    mCheckedChannels.Remove(chan);
            }
            else if (e.Node.Tag is Scene)
            {
                Scene scene = (Scene)e.Node.Tag;
                if (!mCheckedScenes.Contains(scene))
                    mCheckedScenes.Add(scene);
                else
                    mCheckedScenes.Remove(scene);
            }
        }

        private void SelectScene(Scene pScene)
        {
            if (mSelectedScene == pScene)
                return;

            mSelectedScene = pScene;
            if (OnSceneSelected != null)
                OnSceneSelected(mSelectedScene);
        }

        private void SelectChannel(Channel  pChannel)
        {
            if (mSelectedChannel == pChannel)
                return;

            mSelectedChannel = pChannel;
            if (OnChannelSelected != null)
                OnChannelSelected(mSelectedChannel);
        }
    
    
    
    
    }
}
