using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Xml;
using System.Text;

namespace DmxFramework.Scene
{
    public enum SceneManagerState
    {
        Paused,
        Running
    }

    public delegate void OnSceneManagerStateChangedHandler(SceneManager pManager,SceneManagerState pState);

    public class SceneManager
    {
        
        Fixtures.Fixture mFixture;
        ArrayList mSubSceneManager;
        ArrayList mScene;
        ArrayList mCurrentScene;
        int mRowCount = 0;
        int mColumnCount = 0;
        int mCurrentSceneIndex = 0;
        Timer mTimer;
        SceneManagerState mState;
        public object HmiObject = null;

        public event OnSceneManagerStateChangedHandler OnSceneManagerStateChanged;

        #region constructors

        public SceneManager()
        {
            mScene = new ArrayList();
            mTimer = new Timer(Framework.Tick);
            mTimer.Enabled = false;
            mTimer.Elapsed += new ElapsedEventHandler(mTimer_Elapsed);
            mCurrentScene = new ArrayList();

            mState = SceneManagerState.Running;
            mSubSceneManager = null;


        }

       
        #endregion


        #region Properties

        public ArrayList Scenes
        {
            get { return mScene; }
            set { mScene = value; }
        }

        public Fixtures.Fixture Fixture
        {
            get { return mFixture; }
            set { mFixture = value; }
        }

        public int RowCount
        {
            get { return mRowCount; }
            set { mRowCount = value; }
        }

        public int ColumnCount
        {
            get { return mColumnCount; }
            set { mColumnCount = value; }
        }

        public SceneManagerState State
        { get{return mState;}}

        public bool IsRunning
        { get { return (mCurrentScene.Count != 0); } }

        internal ArrayList SubSceneManager
        { get { return mSubSceneManager; } }

        #endregion

        #region Xml
        private void InitSubManagerList()
        {
            //real fixture, so no subfixture with manager
            if (mFixture.Type == DmxFramework.Fixtures.FixtureType.Real)
                return;

            mSubSceneManager = new ArrayList();

            Fixtures.VirtualFixture vfixture = (Fixtures.VirtualFixture)mFixture;

            foreach (Fixtures.Fixture fix in vfixture.SubFixture)
                mSubSceneManager.Add(fix.Manager);
        }

        internal void Load(XmlNode pNode)
        {
            InitSubManagerList();
            
            if (pNode.Name != "Scenes" || pNode.ChildNodes == null || pNode.ChildNodes.Count == 0)
                return;

            mRowCount = Convert.ToInt32(pNode.Attributes["RowCount"].InnerText);
            mColumnCount = Convert.ToInt32(pNode.Attributes["ColumnCount"].InnerText);

            foreach (XmlNode node in pNode.ChildNodes)
                mScene.Add(new Scene(mFixture, node));

            foreach (Scene sce in mScene)
            {
                sce.OnSceneAdded += new OnSceneAddedHandler(sce_OnSceneAdded);
                sce.OnSceneRemoved += new OnSceneRemovedHandler(sce_OnSceneRemoved);
                sce.OnScenePlayed += new OnScenePlayedHandler(sce_OnScenePlayed);

                if (sce.AutoStart)
                    sce.Play();
            }
        }

        #endregion


        void sce_OnScenePlayed(Scene pScene)
        {
            foreach (Scene sce in mCurrentScene)
                sce.SetState(SceneState.Nothing);
            mCurrentScene.Clear();
            mCurrentSceneIndex = 0;
            mCurrentScene.Add(pScene);

            pScene.SetState(SceneState.PlayingExclusive);
            UpdateSubManagerState(SceneManagerState.Paused);
            if (mState == SceneManagerState.Running)
            {
                if (mCurrentScene.Count == 1)
                {
                    mTimer.Enabled = true;
                    mFixture.StartSceneMode();
                }
                mFixture.UnforceAllChannels();
            }
        }

        

        void sce_OnSceneAdded(Scene pScene)
        {
            pScene.SetState(SceneState.Waiting);
            mCurrentScene.Add(pScene);
            UpdateSubManagerState(SceneManagerState.Paused);
            if (mCurrentScene.Count == 1)
            {
                mFixture.StartSceneMode();
                if(mState == SceneManagerState.Running)
                    mTimer.Enabled = true;
                pScene.SetState(SceneState.Playing);
            }
        }

        void sce_OnSceneRemoved(Scene pScene)
        {
            pScene.SetState(SceneState.Nothing);
            mCurrentScene.Remove(pScene);
            if (mCurrentScene.Count == 0)
            {
                
                mTimer.Enabled = false;
                if (mState != SceneManagerState.Paused)
                {
                    UpdateSubManagerState(SceneManagerState.Running);
                    mFixture.StopSceneMode();
                }
            }
        }

        
        
        void mTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (mCurrentScene.Count == 0 || mCurrentSceneIndex >= mCurrentScene.Count)
                return;

            int mNextSceneIndex;
            bool SceneFinished = ((Scene)mCurrentScene[mCurrentSceneIndex]).Tick();

            if (SceneFinished)
            {
                mNextSceneIndex = mCurrentSceneIndex + 1;
                if (mNextSceneIndex == mCurrentScene.Count)
                    mNextSceneIndex = 0;

                if (mNextSceneIndex != mCurrentSceneIndex)
                {
                    ((Scene)mCurrentScene[mNextSceneIndex]).Reset();
                    ((Scene)mCurrentScene[mCurrentSceneIndex]).SetState(SceneState.Waiting);
                    ((Scene)mCurrentScene[mNextSceneIndex]).SetState(SceneState.Playing);
                }
                mCurrentSceneIndex = mNextSceneIndex;
            }
            /*else if (SceneFinished && !((Scene)mCurrentScene[mCurrentSceneIndex]).Loop)
            {

                
            }*/
        }



        public void SetState(SceneManagerState pNewState)
        {
            bool UpdateSubManager = false;
            if(pNewState==mState)
                return;

            mState = pNewState;
            if(OnSceneManagerStateChanged!=null)
                OnSceneManagerStateChanged(this,mState);


            
            if(mState == SceneManagerState.Paused)
                UpdateSubManager = true;
            else if(mCurrentScene.Count==0)
                UpdateSubManager = true;

            if(UpdateSubManager)
                UpdateSubManagerState(mState);

            if (mState == SceneManagerState.Paused)
            {
                mTimer.Enabled = false;
                /*if (mCurrentScene.Count != 0)
                    mCurrentScene[mCurrentSceneIndex].SaveContext();*/
                //mFixture.StopSceneMode();
                mFixture.StartSceneMode();
            }
            else
            {
                /*if(mCurrentScene.Count!=0)
                    mCurrentScene[mCurrentSceneIndex].RestaureContext();*/
                mTimer.Enabled = true;
                if(mCurrentScene.Count==0)
                    mFixture.StopSceneMode();
                //mFixture.StartSceneMode();
            }
        }


        private void UpdateSubManagerState(SceneManagerState pNewState)
        {
            /*if(pNewState != mState)
                return;*/
            if (mSubSceneManager == null)
                return;
            foreach(SceneManager sm in mSubSceneManager)
                sm.SetState(pNewState);
        }

        public XmlNode GetXmlNode(XmlDocument pDocument)
        {
            XmlElement ScenesElement = pDocument.CreateElement("Scenes");

            XmlAttribute XmlAttribute = pDocument.CreateAttribute("RowCount");
            XmlAttribute.InnerText = mRowCount+"";
            ScenesElement.Attributes.Append(XmlAttribute);

            XmlAttribute = pDocument.CreateAttribute("ColumnCount");
            XmlAttribute.InnerText = mColumnCount + "";
            ScenesElement.Attributes.Append(XmlAttribute);

            foreach (Scene sce in mScene)
                ScenesElement.AppendChild(sce.GetXmlNode(pDocument));

            return ScenesElement;
        }

        public void AddScene(Scene pScene)
        {
            mScene.Add(pScene);
            pScene.OnSceneAdded += new OnSceneAddedHandler(sce_OnSceneAdded);
            pScene.OnSceneRemoved += new OnSceneRemovedHandler(sce_OnSceneRemoved);
            pScene.OnScenePlayed += new OnScenePlayedHandler(sce_OnScenePlayed);
        }

        public void AddQuickScene(string pCategory, string pName)
        {
            /*mScene.Add(pScene);
            pScene.OnSceneAdded += new OnSceneAddedHandler(sce_OnSceneAdded);
            pScene.OnSceneRemoved += new OnSceneRemovedHandler(sce_OnSceneRemoved);
            pScene.OnScenePlayed += new OnScenePlayedHandler(sce_OnScenePlayed);*/

            Scene scene = new Scene();
            scene.Category = pCategory;
            scene.Name = pName;

            scene.Loop = true;
            scene.StepTime = 0;
            scene.WaitingTime = 1000;

            scene.AddChannel(mFixture.GetAllRealChannels(), mFixture.GetAllRealChannelsName());
            scene.AddStep();
            AddScene(scene);
            scene.Play();
            //mFixture.Channels
            //scene.AddChannel(
        }

        public void Exit()
        {
            mTimer.Enabled = false;
        }
    }
}
