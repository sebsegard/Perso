using System;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace DmxFramework.Scene
{
    public enum StepArrangement
    {
        Classic = 1,
        Sound
    }

    public enum SceneType
    {
        Hold = 1,
        Pulse
    }

    public enum SceneState
    {
        Nothing,
        PlayingExclusive,
        Waiting,
        Playing,
        Pause
    }

    public delegate void OnSceneAddedHandler(Scene pScene);
    public delegate void OnScenePlayedHandler(Scene pScene);
    public delegate void OnSceneRemovedHandler(Scene pScene);
    public delegate void OnSceneStateChangeHandler(Scene pScene,SceneState pState);
    public delegate void OnSceneRatioChangedHandler(Scene pScene);
    
    public class Scene
    {
        #region members
        Fixtures.Fixture mFixture;
        ArrayList mChannels;
        ArrayList mChannelNames;
        ArrayList mSteps;
        string mName;
        string mCategory;
        int mWaitingTime = 100;
        int mStepTime = 50;
        int mCurrentTick;

        int mCurrentSpeedRatio = 0;

        int mNbTickPerStep;
        int mNbTickBetween2Step;

        Step mCurrentStep;
        Step mNextStep;

        int mBtnX;
        int mBtnY;

        int mCurrentStepIndex;
        SceneState mState;
        bool mLoop = true;
        bool mAutoStart = false;
        bool mMusicBeat = false;
        bool mKeyBeat = false;
        public object HmiObject = null;



        #endregion

        #region events
        public event OnSceneAddedHandler OnSceneAdded;
        public event OnScenePlayedHandler OnScenePlayed;
        public event OnSceneRemovedHandler OnSceneRemoved;
        public event OnSceneStateChangeHandler OnSceneStateChanged;
        public event OnSceneRatioChangedHandler OnSceneRatioChanged;
        #endregion


        public static List<Scene> PlayingScenes = new List<Scene>();

        #region constructors

        public Scene()
        {
            mChannels = new ArrayList();
            mSteps = new ArrayList();
            mName = "";
            mCategory = "";
            mChannelNames = new ArrayList();
            mState = SceneState.Nothing;
        }

        public Scene(Fixtures.Fixture pFixture, XmlNode pNode)
        {
            mFixture = pFixture;
            mChannelNames = new ArrayList();
            mChannels = new ArrayList();
            mSteps = new ArrayList();
            mName = pNode.Attributes["Name"].Value;
            mCategory = pNode.Attributes["Category"].Value;
            mStepTime = Convert.ToInt32(pNode.Attributes["StepTime"].Value);
            mWaitingTime = Convert.ToInt32(pNode.Attributes["WaitingTime"].Value);

            if (pNode.Attributes["Ratio"] != null)
                mCurrentSpeedRatio = Convert.ToInt32(pNode.Attributes["Ratio"].Value);

            if (pNode.Attributes["btn_x"] != null)
            {
                mBtnX = Convert.ToInt32(pNode.Attributes["btn_x"].Value);
                mBtnY = Convert.ToInt32(pNode.Attributes["btn_y"].Value);
            }
            else
            {
                mBtnX = -1;
                mBtnY = -1;
            }

            if (pNode.Attributes["Loop"] != null)
                mLoop = Convert.ToBoolean(pNode.Attributes["Loop"].InnerText);

            if (pNode.Attributes["AutoStart"] != null)
                mAutoStart = Convert.ToBoolean(pNode.Attributes["AutoStart"].InnerText);

            if (pNode.Attributes["MusicBeat"] != null)
                mMusicBeat = Convert.ToBoolean(pNode.Attributes["MusicBeat"].InnerText);

            if (pNode.Attributes["KeyBeat"] != null)
                mKeyBeat = Convert.ToBoolean(pNode.Attributes["KeyBeat"].InnerText);
            
            XmlNode ChannelsNode = pNode.ChildNodes[0];
            foreach (XmlNode node in ChannelsNode.ChildNodes)
            {
                this.mChannelNames.Add(node.Attributes["ChannelName"].InnerText);
                this.mChannels.Add(pFixture.GetChannel(node.Attributes["ChannelName"].InnerText));
            }

            XmlNode StepNode = pNode.ChildNodes[1];
            foreach (XmlNode node in StepNode.ChildNodes)
            {
                //this.mSteps.Add(new Step(this.mChannels, mChannelNames, node));
                this.mSteps.Add(new Step(node));
            }
            mState = SceneState.Nothing;

            

        }

        #endregion

        #region properties

        public int Ratio
        {
            get
            {
                return mCurrentSpeedRatio;
            }
            set
            {
                if (value != mCurrentSpeedRatio)
                {
                    mCurrentSpeedRatio = value;
                    if (OnSceneRatioChanged != null)
                        OnSceneRatioChanged(this);
                    /*if (mState == SceneState.Playing || mState == SceneState.PlayingExclusive)
                    {*/
                    ComputeTicks();
                    //}
                }
            }
        }

        public ArrayList Channels
        {
            get { return mChannels; }
            set { mChannels=value; }
        }

        public ArrayList ChannelNames
        {
            get { return mChannelNames; }
            set { mChannelNames = value; }
        }

        public ArrayList Steps
        {
            get { return mSteps; }
            set { mSteps = value; }
        }

        public int WaitingTime
        {
            get { return mWaitingTime; }
            set { mWaitingTime = value; }
        }

        public int StepTime
        {
            get { return mStepTime; }
            set { mStepTime = value; }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public string Category
        {
            get { return mCategory; }
            set { mCategory = value; }
        }

        public int BtnX
        {
            get { return mBtnX; }
            set { mBtnX = value; }
        }

        public int BtnY
        {
            get { return mBtnY; }
            set { mBtnY = value; }
        }

        public SceneState State
        {
            get { return mState; }
            set { mState = value; }
        }

        public bool Loop
        {
            get { return mLoop; }
            set { mLoop = value; }
        }

        public bool AutoStart
        {
            get { return mAutoStart; }
            set { mAutoStart = value; }
        }

        public bool MusicBeat
        {
            get { return mMusicBeat; }
            set { mMusicBeat = value; }
        }

        public Fixtures.Fixture Fixture
        {
            get { return mFixture; }
            set { mFixture = value; }
        }

        public bool KeyBeat
        {
            get { return mKeyBeat; }
            set { mKeyBeat = value; }
        }

        public string Path
        {
            get { return mFixture.Path + "/" + mCategory + "/" + mName; }
        }
        #endregion

        #region public Methods

        

        internal void SetState(SceneState pState)
        {
            if (pState == mState)
                return;

            mState = pState;

            if (mState == SceneState.Nothing || mState == SceneState.Pause || mState == SceneState.Waiting)
            {
                if (mMusicBeat)
                {
                    Framework.MusicMode.BeatDetection.Stop();
                    Framework.MusicMode.BeatDetection.OnBeatChanged -= this.BeatDetection_OnBeatChanged;
                }
                if (mKeyBeat)
                {
                    if (Framework.KeyBord.KeyStepr != null)
                        Framework.KeyBord.KeyStepr.OnKeyStepPressed -= this.KeyStepr_OnKeyStepPressed;
                }
                if (Scene.PlayingScenes.Contains(this))
                    Scene.PlayingScenes.Remove(this);
            }
            else if (mState == SceneState.Playing || mState == SceneState.PlayingExclusive)
            {
                StartScene();
                Scene.PlayingScenes.Add(this);
            }
           

            if (OnSceneStateChanged != null)
                OnSceneStateChanged(this, pState);
        }
        
        public void Add()
        {
            if (mSteps.Count == 0)
                return;

            //Les scenes musicales ne peuvent pas être ajoutes ...
            if (mMusicBeat)
            {
                Play();
                return;
            }
            //StartScene();
            /*
            mNbTickPerStep = (int)mStepTime / Framework.Tick;
            mNbTickBetween2Step = (int)mWaitingTime / Framework.Tick;
            
            StartScene
            mCurrentTick = 0;
            mCurrentStepIndex = 1;
            mCurrentStep = (Step)mSteps[0];
            if (mSteps.Count == 1)
                mNextStep = mCurrentStep;
            else
                mNextStep = (Step)mSteps[1];
            */
            OnSceneAdded(this);
        }

        public void Play()
        {
            if (mSteps.Count == 0)
                return;

            //StartScene();

            OnScenePlayed(this);
        }

        private void ComputeTicks()
        {
            float StepRatio = (mStepTime * mCurrentSpeedRatio) /100;
            int StepTime = mStepTime - Convert.ToInt16(StepRatio);

            float WaitingRatio = (mWaitingTime * mCurrentSpeedRatio) / 100;
            int WaitTime = mWaitingTime - Convert.ToInt16(WaitingRatio);

            mNbTickPerStep = (int)StepTime / Framework.Tick;
            mNbTickBetween2Step = (int)WaitTime / Framework.Tick;

            if (mNbTickPerStep == 0)
                mNbTickPerStep = 1;

            if (mNbTickBetween2Step == 0)
                mNbTickBetween2Step = 1;

        }

        private void StartScene()
        {
            Ratio = 0;
            if (mMusicBeat)
            {
                Framework.MusicMode.BeatDetection.OnBeatChanged += new DmxFramework.Sound.OnBeatChangedHandler(BeatDetection_OnBeatChanged);
                Framework.MusicMode.BeatDetection.Start();
            }
            else if (mKeyBeat)
            {
                if(Framework.KeyBord.KeyStepr != null)
                    Framework.KeyBord.KeyStepr.OnKeyStepPressed += new DmxFramework.Keyboard.Hotkey.OnKeyStepPressedDlg(KeyStepr_OnKeyStepPressed);
            }
            else
            {
                /*mNbTickPerStep = (int)mStepTime / Framework.Tick;
                mNbTickBetween2Step = (int)mWaitingTime / Framework.Tick;

                if (mNbTickPerStep == 0)
                    mNbTickPerStep = 1;

                if (mNbTickBetween2Step == 0)
                    mNbTickBetween2Step = 1;*/
                ComputeTicks();
                mCurrentTick = 0;
            }



            mCurrentStepIndex = 1;
            mCurrentStep = (Step)mSteps[0];
            if (mSteps.Count == 1)
                mNextStep = mCurrentStep;
            else
                mNextStep = (Step)mSteps[1];
        }

        

       
       

        public void Remove()
        {
            mCurrentTick = 0;

            
            OnSceneRemoved(this);
        }

        public void Reset()
        {
            mCurrentTick = 0;
            mCurrentStepIndex = 1;
            mCurrentStep = (Step)mSteps[0];
            if (mSteps.Count == 1)
                mNextStep = mCurrentStep;
            else
                mNextStep = (Step)mSteps[1];
        }

        
        #endregion

        #region internal Methods

        internal bool Tick()
        {
            bool result = false;
            if (mMusicBeat)
                return false;

            if (mNbTickPerStep == 0)
            {
                return true;
            }
            lock (this)
            {
                
                
                if (mCurrentTick <= mNbTickPerStep)
                {
                    for (int i = 0; i < mChannels.Count; i++)
                    {
                        int NewValue = mCurrentStep.Values[i] + (mCurrentTick * (mNextStep.Values[i] - mCurrentStep.Values[i])) / mNbTickPerStep;
                        ((Channels.Channel)mChannels[i]).SetValue(NewValue,DmxFramework.Channels.ChangeOrigin.Scene);
                    }
                    mCurrentTick++;
                }
                else if (mCurrentTick < (mNbTickPerStep + mNbTickBetween2Step))
                {
                    mCurrentTick++;
                }

                if (mCurrentTick >= (mNbTickPerStep + mNbTickBetween2Step))
                {
                    mCurrentTick = 0;
                    mCurrentStepIndex++;
                    if (mCurrentStepIndex >= mSteps.Count)
                    {
                        mCurrentStepIndex = 0;
                        if (!mLoop)
                            Remove();
                    }
                    else if (mCurrentStepIndex ==1)
                        result = true;
                        
                        mCurrentStep = mNextStep;
                        mNextStep = (Step)mSteps[mCurrentStepIndex];

                }
            }
            return result;
        }

        void BeatDetection_OnBeatChanged(bool pActive)
        {
            if (!pActive)
                return;

           

            for (int i = 0; i < mChannels.Count; i++)
            {
                int NewValue = mNextStep.Values[i];
                ((Channels.Channel)mChannels[i]).SetValue(NewValue, DmxFramework.Channels.ChangeOrigin.Scene);
            }

            mCurrentStep = mNextStep;

            mCurrentStepIndex++;
            if(mCurrentStepIndex >= mSteps.Count)
                mCurrentStepIndex = 0;
         
            mNextStep = (Step)mSteps[mCurrentStepIndex];


            
            

        }

        void KeyStepr_OnKeyStepPressed()
        {
            if (!(mState == SceneState.Playing || mState == SceneState.PlayingExclusive))
                return;


            for (int i = 0; i < mChannels.Count; i++)
            {
                int NewValue = mNextStep.Values[i];
                ((Channels.Channel)mChannels[i]).SetValue(NewValue, DmxFramework.Channels.ChangeOrigin.Scene);
            }

            mCurrentStep = mNextStep;

            mCurrentStepIndex++;
            if (mCurrentStepIndex >= mSteps.Count)
                mCurrentStepIndex = 0;

            mNextStep = (Step)mSteps[mCurrentStepIndex];
        }

        


        #endregion

        public void AddChannel(Channels.Channel pChannel, string pChannelName)
        {
            this.Channels.Add(pChannel);
            this.ChannelNames.Add(pChannelName);

            foreach (Step step in mSteps)
                step.AddChannel(pChannel);
            
        }

        public void AddChannel(List<Channels.Channel> pChannel, List<string> pChannelName)
        {
            for (int i = 0; i < pChannel.Count; i++)
                AddChannel(pChannel[i], pChannelName[i]);
        }

        public Step AddStep()
        {
            Step step = new Step(this.mChannels);
            mSteps.Add(step);
            return step;
        }

        public void RemoveChannel(Channels.Channel pChannel)
        {
            int index = mChannels.IndexOf(pChannel);
            if (index == -1)
                return;

            mChannels.RemoveAt(index);
            mChannelNames.RemoveAt(index);

            foreach (Step step in mSteps)
                step.RemoveChannel(index);
        }

        public XmlNode GetXmlNode(XmlDocument pDocument)
        {
            XmlElement node = pDocument.CreateElement("Scene");
            
            XmlAttribute XmlAttribute = pDocument.CreateAttribute("Name");
            XmlAttribute.InnerText = mName;
            node.Attributes.Append(XmlAttribute);

            XmlAttribute = pDocument.CreateAttribute("Category");
            XmlAttribute.InnerText = mCategory;
            node.Attributes.Append(XmlAttribute);

            XmlAttribute = pDocument.CreateAttribute("StepTime");
            XmlAttribute.InnerText = mStepTime+"";
            node.Attributes.Append(XmlAttribute);

            XmlAttribute = pDocument.CreateAttribute("WaitingTime");
            XmlAttribute.InnerText = mWaitingTime + "";
            node.Attributes.Append(XmlAttribute);

            XmlAttribute = pDocument.CreateAttribute("btn_x");
            XmlAttribute.InnerText = mBtnX + "";
            node.Attributes.Append(XmlAttribute);

            XmlAttribute = pDocument.CreateAttribute("btn_y");
            XmlAttribute.InnerText = mBtnY + "";
            node.Attributes.Append(XmlAttribute);

            XmlAttribute = pDocument.CreateAttribute("Loop");
            XmlAttribute.InnerText = mLoop.ToString();
            node.Attributes.Append(XmlAttribute);

            XmlAttribute = pDocument.CreateAttribute("AutoStart");
            XmlAttribute.InnerText = mAutoStart.ToString();
            node.Attributes.Append(XmlAttribute);

            XmlAttribute = pDocument.CreateAttribute("MusicBeat");
            XmlAttribute.InnerText = mMusicBeat.ToString();
            node.Attributes.Append(XmlAttribute);

            XmlAttribute = pDocument.CreateAttribute("KeyBeat");
            XmlAttribute.InnerText = mKeyBeat.ToString();
            node.Attributes.Append(XmlAttribute);

            XmlAttribute = pDocument.CreateAttribute("Ratio");
            XmlAttribute.InnerText = mCurrentSpeedRatio.ToString();
            node.Attributes.Append(XmlAttribute);

            XmlElement ChannelsElement = pDocument.CreateElement("Channels");

            foreach (string channame in mChannelNames)
            {
                XmlElement chanElement = pDocument.CreateElement("Channel");
                XmlAttribute = pDocument.CreateAttribute("ChannelName");
                XmlAttribute.InnerText = channame;
                chanElement.Attributes.Append(XmlAttribute);

                ChannelsElement.AppendChild(chanElement);
            }

            node.AppendChild(ChannelsElement);


            XmlElement StepsElement = pDocument.CreateElement("Steps");

            foreach (Step ste in mSteps)
                StepsElement.AppendChild(ste.GetXmlNode(pDocument));

            node.AppendChild(StepsElement);

            return node;
        }

        public override string ToString()
        {
            return mName;
        }

        public Scene Clone()
        {
            Scene scene = new Scene();
            scene.Category = this.Category;
            scene.Name = "Copy of "+this.mName;
            scene.Steps = new ArrayList();
            foreach(Step step in this.Steps)
               scene.Steps.Add(step.Clone());

            scene.ChannelNames = new ArrayList();
            foreach (string Chan in this.ChannelNames)
                scene.ChannelNames.Add(Chan);

            scene.Channels = new ArrayList();
            foreach (DmxFramework.Channels.Channel Chan in this.Channels)
                scene.Channels.Add(Chan);

            scene.StepTime = this.StepTime;
            scene.WaitingTime = this.WaitingTime;
            scene.Loop = this.Loop;
            scene.KeyBeat = this.mKeyBeat;
            
            return scene;
        }
    }
}
