using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DmxFramework.Fixtures
{
    /// <summary>
    /// TYpe of fixture
    /// </summary>
    public enum FixtureType
    {
        /// <summary>
        /// Virtual fixture : group of fixtures
        /// </summary>
        Virtual,

        /// <summary>
        /// Real fixture 
        /// </summary>
        Real
    }

    public delegate void OnBeatDetectionStateChangedHandler(bool pNewState);
    public delegate void OnAutoModeStateChangedHandler(bool pNewState);
    
    public abstract class Fixture
    {
        #region members

        protected List<DmxFramework.Channels.Channel> mChannels;
        protected FixtureType mType;
        protected string mName;
        protected Scene.SceneManager mManager;
        protected int mLevel;

        protected Channels.Channel mPanChannel = null;
        protected Channels.Channel mTiltChannel = null;
        protected bool mIsInMusicalDetection = false;
        protected bool mIsInAutoMode = false;
        protected string mPath;
        protected bool mLocked = false;
        protected bool mIsInSceneMode = false;
        protected Fixture mParent=null;

        protected int mNumAutoMode = 0;
        

        public event OnBeatDetectionStateChangedHandler OnBeatDetectionStateChanged = null;
        public event OnAutoModeStateChangedHandler OnAutoModeStateChanged = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pType"></param>
        public Fixture(Fixture pParent, FixtureType pType)
        {
            mParent = pParent;
            mManager = new DmxFramework.Scene.SceneManager();
            mManager.Fixture = this;
            mName = "";
            mType = pType;
            mChannels = new List<DmxFramework.Channels.Channel>();
        }

        #endregion


        #region properties
        /// <summary>
        /// Fixture Name
        /// </summary>
        public string Name
        {
            set { mName = value; }
            get { return mName; }
        }

        /// <summary>
        /// Scene manager
        /// </summary>
        public Scene.SceneManager Manager
        {
            set { mManager = value; }
            get { return mManager; }
        }

        /// <summary>
        /// Type of fixture (real or virtual)
        /// </summary>
        public FixtureType Type
        {
            get { return mType; }
        }

        /// <summary>
        /// Type of fixture (real or virtual)
        /// </summary>
        public List<DmxFramework.Channels.Channel> Channels
        {
            get { return mChannels; }
        }


        /// <summary>
        /// Is the fixture in musical detection
        /// </summary>
        public bool IsMusicalDetection
        {
            get { return mIsInMusicalDetection; }
        }

        /// <summary>
        /// Is the fixture in automatic mode
        /// </summary>
        public bool IsAutoMode
        {
            get { return mIsInAutoMode; }
        }

        public string Path
        {
            get { return mPath; }
        }

        public bool Locked
        {
            get { return mLocked; }
            set
            {
                mLocked = value;
                foreach (Channels.Channel chan in this.mChannels)
                    chan.Locked = mLocked;
            }
        }

        public DmxFramework.Channels.Channel PanChannel
        {
            get { return mPanChannel; }
        }

        public DmxFramework.Channels.Channel TiltChannel
        {
            get { return mTiltChannel; }
        }

        public Fixture Parent
        {
            get { return mParent; }
            internal set { mParent = value; }
        }

        public int AutoModeNum
        {
            get { return mNumAutoMode; }
            set { mNumAutoMode = value; }
        }
        
        #endregion

        #region Overloaded methods

        public override string ToString()
        {
            return mName ;
        }


        #endregion


        #region static methods
        public static FixtureType GetTypeFromXmlNode(XmlNode pNode)
        {
            string Type = pNode.Attributes["Type"].InnerText;
            if (Type == FixtureType.Real.ToString())
                return FixtureType.Real;
            else
                return FixtureType.Virtual;
        }

        #endregion


        internal abstract void Exit();
      
        internal abstract void LoadScene(XmlNode pNode);

        internal abstract XmlNode GetSceneXml(XmlDocument pDocument);

        //internal abstract void SaveScene(XmlDocument pDocument, );


        internal abstract Channels.Channel GetChannel(string pPath);
        internal abstract Scene.Scene GetScene(string pPath);

        internal virtual void UnforceAllChannels()
        {
            foreach (DmxFramework.Channels.Channel chan in mChannels)
                chan.UnforceValue();
        }

        protected void DetectPanTiltChannel()
        {
            foreach (DmxFramework.Channels.Channel chan in mChannels)
            {
                if (chan.Function == DmxFramework.Channels.ChannelFunction.Pan)
                    mPanChannel = chan;
                else if (chan.Function == DmxFramework.Channels.ChannelFunction.Tilt)
                    mTiltChannel = chan;
            }
        }


        #region beat detection methods

        public void StartMusicalDetection()
        {
            if (mIsInAutoMode)
                StopAutomaticMode();
            
            mIsInMusicalDetection = true;
            if(OnBeatDetectionStateChanged != null)
                OnBeatDetectionStateChanged(true);
            
            //DmxFramework.Framework.beatDetection.OnBeatChanged += new DmxFramework.Sound.OnBeatChangedHandler(beatDetection_OnBeatChanged);
            DmxFramework.Framework.MusicMode.AddChannel(mPanChannel);
            DmxFramework.Framework.MusicMode.AddChannel(mTiltChannel);
            DmxFramework.Framework.MusicMode.Start();
        }

        
        public void StopMusicalDetection()
        {
            mIsInMusicalDetection = false;
            if (OnBeatDetectionStateChanged != null)
                OnBeatDetectionStateChanged(false);

            DmxFramework.Framework.MusicMode.RemoveChannel(mPanChannel);
            DmxFramework.Framework.MusicMode.RemoveChannel(mTiltChannel);
            DmxFramework.Framework.MusicMode.Start();
        }



        #endregion

        #region scene
        
        public void StartSceneMode()
        {
            if (mIsInSceneMode)
                return;

            mIsInSceneMode = true;
            foreach (DmxFramework.Channels.Channel chan in mChannels)
                chan.IsInSceneMode = true;
        }

        public void StopSceneMode()
        {
            if (!mIsInSceneMode)
                return;

            mIsInSceneMode = false;
            foreach (DmxFramework.Channels.Channel chan in mChannels)
                chan.IsInSceneMode = false;
        }

        #endregion

        #region Automatic mode methods

        public void StartAutomaticMode()
        {
            if (mIsInAutoMode)
                return;
            
            if (mIsInMusicalDetection)
                StopMusicalDetection();

            mIsInAutoMode = true;
            if (OnAutoModeStateChanged != null)
                OnAutoModeStateChanged(true);

            
            DmxFramework.Framework.AutomaticMode[mNumAutoMode].AddChannel(mPanChannel);
            DmxFramework.Framework.AutomaticMode[mNumAutoMode].AddChannel(mTiltChannel);

            DmxFramework.Framework.AutomaticMode[mNumAutoMode].Start();
        }

       




        public void StopAutomaticMode()
        {
            mIsInAutoMode = false;
            if (OnAutoModeStateChanged != null)
                OnAutoModeStateChanged(false);

            DmxFramework.Framework.AutomaticMode[mNumAutoMode].RemoveChannel(mPanChannel);
            DmxFramework.Framework.AutomaticMode[mNumAutoMode].RemoveChannel(mTiltChannel);
            //DmxFramework.Framework.Au.OnBeatChanged -= this.beatDetection_OnBeatChanged;
            DmxFramework.Framework.AutomaticMode[mNumAutoMode].Stop();
            //DmxFramework.Framework.AutomaticMode.OnAutoModeChange -=this.AutomaticMode_OnAutoModeChange;

        }

        public abstract XmlNode Save(XmlDocument pDocument);

        #endregion 
   
    
        public abstract void RefreshFixture(RealFixture pFixture);

        public Channels.Channel GetChannelByName(string pChannelName)
        {
            foreach (Channels.Channel chan in mChannels)
                if (chan.Name == pChannelName)
                    return chan;
            return null;
        }

        public abstract List<DmxFramework.Channels.Channel> GetAllRealChannels();


        public abstract List<string> GetAllRealChannelsName();
    
    }
}
