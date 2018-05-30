using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Timers;
using System.Xml;

namespace DmxFramework.AutoMode
{
    //public delegate void OnAutoModeChangeHandler(int pPanValue, int pTiltValue);

    public delegate void OnAutoModeTimeChangedEvent (AutoMode pAutomode, int pTime);
    public delegate void OnAutoModePresetStateChangedEvent(AutoMode pAutoMode, AutoPreset pAutoPreset, bool pEnabled);

    public class AutoMode
    {

        #region public constants

        public const int MinTime = 100;
        public const int MaxTime = 2000;

        #endregion

        public event OnAutoModeTimeChangedEvent OnAutoModeTimeChanged;
        public event OnAutoModePresetStateChangedEvent OnAutoModePresetStateChanged;

        #region Members
        AutoPreset mCurrentPreset;
        int mNumberOfStep = 0;
        int mTime = 1000;
        bool mStarted = true;

        int mClientCount = 0;

        Timer mMainTimer = null;
        Timer mTickTimer = null;

        bool mProgressive = false;

        bool mLimitEnabled = false;
        int mPanMin = 0;
        int mPanMax = 255;
        int mTiltMin = 0;
        int mTiltMax = 255;

        AutoPreset mPreset1 = new AutoPreset();
        AutoPreset mPreset2 = new AutoPreset();


        List<Channels.AutoChannel> mAutoChanList; 
        #endregion


        #region constructor

        public AutoMode()
        {
            mMainTimer = new Timer(mTime);
            mMainTimer.Enabled = false;
            mMainTimer.Elapsed += new ElapsedEventHandler(mMainTimer_Elapsed);
            mNumberOfStep = (mTime / Framework.Tick) + 1;
            mMainTimer.Interval = mTime;
            mTickTimer = new Timer(DmxFramework.Framework.Tick);
            mTickTimer.Enabled = false;
            mTickTimer.Elapsed += new ElapsedEventHandler(mTickTimer_Elapsed);
            mAutoChanList = new List<Channels.AutoChannel>();
        }

        public AutoMode(XmlNode pNode)
        {
            LoadXMl(pNode);
            
            mMainTimer = new Timer(mTime);


            mMainTimer.Enabled = false;
            mMainTimer.Elapsed += new ElapsedEventHandler(mMainTimer_Elapsed);
            mNumberOfStep = (mTime / Framework.Tick) + 1;
            mMainTimer.Interval = mTime;
            mTickTimer = new Timer(DmxFramework.Framework.Tick);
            mTickTimer.Enabled = false;
            mTickTimer.Elapsed += new ElapsedEventHandler(mTickTimer_Elapsed);
            mAutoChanList = new List<Channels.AutoChannel>();


        }

       

        #endregion

        #region properties

        public int Time
        {
            get { return mTime; }
            set
            {
                if (value < MinTime || value > MaxTime)
                    return;

                mTime = value;
                mNumberOfStep = (mTime / Framework.Tick) + 1;

                lock (mAutoChanList)
                {
                    foreach (Channels.AutoChannel chan in mAutoChanList)
                        chan.NumberOfStep = mNumberOfStep;
                }
                mMainTimer.Interval = mTime;

                if (OnAutoModeTimeChanged != null)
                    OnAutoModeTimeChanged(this, mTime);
            }
        }



        public bool Progressive
        {
            get { return mProgressive; }
            set
            {
                mProgressive = value;

                lock (mAutoChanList)
                {
                    foreach (Channels.AutoChannel chan in mAutoChanList)
                        chan.ProgressMode = mProgressive;
                }

                if (mStarted && mProgressive)
                    mTickTimer.Enabled = true;
                else
                    mTickTimer.Enabled = false;
            }
        }


        public int PanMin
        {
            get { return mPanMin; }
            set
            {
                mPanMin = value;
                if (!mLimitEnabled)
                    return;
                for (int i = 0; i < mAutoChanList.Count; i++)
                {
                    if (mAutoChanList[i].Chan.Function == DmxFramework.Channels.ChannelFunction.Pan)
                        mAutoChanList[i].Min = mPanMin;
                }
            }
        }

        #region Pan and tilt limits
        public int PanMax
        {
            get { return mPanMax; }
            set
            {
                mPanMax = value;
                if (!mLimitEnabled)
                    return;
                for (int i = 0; i < mAutoChanList.Count; i++)
                {
                    if (mAutoChanList[i].Chan.Function == DmxFramework.Channels.ChannelFunction.Pan)
                        mAutoChanList[i].Max = mPanMax;
                }
            }
        }

        public int TiltMin
        {
            get { return mTiltMin; }
            set
            {
                mTiltMin = value;
                if (!mLimitEnabled)
                    return;
                for (int i = 0; i < mAutoChanList.Count; i++)
                {
                    if (mAutoChanList[i].Chan.Function == DmxFramework.Channels.ChannelFunction.Tilt)
                        mAutoChanList[i].Min = mTiltMin;
                }
            }
        }

        public int TiltMax
        {
            get { return mTiltMax; }
            set
            {
                mTiltMax = value;
                if (!mLimitEnabled)
                    return;
                for (int i = 0; i < mAutoChanList.Count; i++)
                {
                    if (mAutoChanList[i].Chan.Function == DmxFramework.Channels.ChannelFunction.Tilt)
                        mAutoChanList[i].Max = mTiltMax;
                }
            }
        }

        public bool LimitEnabled
        {
            get { return mLimitEnabled; }
            set
            {
                mLimitEnabled = value;
                int panmin = 0;
                int panmax = 255;
                int tiltmin = 0;
                int tiltmax = 255;
                if (mLimitEnabled == true)
                {
                    panmin = mPanMin;
                    panmax = mPanMax;
                    tiltmin = mTiltMin;
                    tiltmax = mTiltMax;
                }

                if (mAutoChanList != null)
                {
                    for (int i = 0; i < mAutoChanList.Count; i++)
                    {
                        if (mAutoChanList[i].Chan.Function == DmxFramework.Channels.ChannelFunction.Tilt)
                        {
                            mAutoChanList[i].Min = tiltmin;
                            mAutoChanList[i].Max = tiltmax;
                        }
                        else if (mAutoChanList[i].Chan.Function == DmxFramework.Channels.ChannelFunction.Pan)
                        {
                            mAutoChanList[i].Min = panmin;
                            mAutoChanList[i].Max = panmax;
                        }
                    }
                }

            }
        } 
        #endregion


        #region AutoPreset
        public AutoPreset Preset1
        {
            get { return mPreset1; }
            set { mPreset1 = value; }
        }

        public AutoPreset Preset2
        {
            get { return mPreset2; }
            set { mPreset2 = value; }
        } 
        #endregion
       

        #endregion

        #region public methods

        public void Start()
        {
            if (mClientCount == 0)
            {
                mMainTimer.Enabled = true;
                if (mProgressive)
                    mTickTimer.Enabled = true;
            }
            mClientCount++;
        }

        public void Stop()
        {
            mClientCount--;
            if (mClientCount == 0)
            {
                mTickTimer.Enabled = false;
                mMainTimer.Enabled = false;

                
            }
            if (OnAutoModePresetStateChanged != null)
            {
                OnAutoModePresetStateChanged(this, mPreset1, false);
                OnAutoModePresetStateChanged(this, mPreset2, false);
            }
        }

        public void StopAll()
        {
            mMainTimer.Enabled = false;
            mTickTimer.Enabled = false;
        }

        public void Reset()
        {
            mMainTimer.Stop();
            mMainTimer_Elapsed(null, null);
            mMainTimer.Start();
        }

        public void Exit()
        {
            mTickTimer.Enabled = false;
            mMainTimer.Enabled = false;
        }

        #endregion

        #region timer events

        void mTickTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (mAutoChanList)
            {
                foreach (Channels.AutoChannel chan in mAutoChanList)
                    chan.SmallTick();
            }
        }

        void mMainTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

            lock (mAutoChanList)
            {
                foreach (Channels.AutoChannel chan in mAutoChanList)
                    chan.MainTick();
            }
        }

        #endregion

        #region private method

        //private void SendValue(int pPanValue, int pTiltValue)
        //{
        //    if (pPanValue < 0)
        //        pPanValue = 0;
        //    else if (pPanValue > 255)
        //        pPanValue = 255;

        //    if (pTiltValue < 0)
        //        pTiltValue = 0;
        //    else if (pTiltValue > 255)
        //        pTiltValue = 255;

        //    if (OnAutoModeChange != null)
        //        OnAutoModeChange(pPanValue, pTiltValue);
        //}

        #endregion

        #region preset methods

        public void SetPreset(AutoPreset pPreset)
        {
            Progressive = pPreset.Progressive;
            Time = pPreset.Time;
            if (OnAutoModePresetStateChanged != null && mCurrentPreset!=pPreset)
            {
                mCurrentPreset = pPreset;
                if (pPreset == mPreset1)
                {
                    OnAutoModePresetStateChanged(this, mPreset1, true);
                    OnAutoModePresetStateChanged(this, mPreset2, false);
                }
                else
                {
                    OnAutoModePresetStateChanged(this, mPreset1, false);
                    OnAutoModePresetStateChanged(this, mPreset2, true);
                }
            }
           
        }

        #endregion

        #region add/remove channel

        public void AddChannel(Channels.Channel pChannel)
        {
            if (pChannel == null)
                return;

            //Check if the channel is in the liste
            Channels.AutoChannel chan = new DmxFramework.Channels.AutoChannel(pChannel, Channels.ChangeOrigin.AutoMode);
            chan.ProgressMode = mProgressive;
            chan.NumberOfStep = mNumberOfStep;

            if (pChannel.Function == DmxFramework.Channels.ChannelFunction.Pan && mLimitEnabled)
            {
                chan.Min = mPanMin;
                chan.Max = mPanMax;
            }
            else if (pChannel.Function == DmxFramework.Channels.ChannelFunction.Tilt && mLimitEnabled)
            {
                chan.Min = mTiltMin;
                chan.Max = mTiltMax;
            }

            lock (mAutoChanList)
            {
                mAutoChanList.Add(chan);
            }
        }

        public void RemoveChannel(Channels.Channel pChannel)
        {
            if (pChannel == null)
                return;

            lock (mAutoChanList)
            {
                foreach (Channels.AutoChannel chan in mAutoChanList)
                {
                    if (chan.Chan == pChannel)
                    {
                        mAutoChanList.Remove(chan);
                        break;
                    }
                }
            }
        }

        #endregion

        #region xml

        private void LoadXMl(XmlNode pNode)
        {
            mTime = Convert.ToInt16(pNode.Attributes["Time"].InnerText);
            mProgressive = Convert.ToBoolean(pNode.Attributes["Progressive"].InnerText);

            mPanMin = Convert.ToInt16(pNode.Attributes["PanMin"].InnerText);
            mPanMax = Convert.ToInt16(pNode.Attributes["PanMax"].InnerText);

            mTiltMin = Convert.ToInt16(pNode.Attributes["TiltMin"].InnerText);
            mTiltMax = Convert.ToInt16(pNode.Attributes["TiltMax"].InnerText);

            mPreset1.LoadXml(pNode.ChildNodes[0]);
            mPreset2.LoadXml(pNode.ChildNodes[1]);

            XmlAttribute atr = pNode.Attributes.GetNamedItem("LimitEnabled") as XmlAttribute;
            if(atr !=null)
                LimitEnabled = Convert.ToBoolean(atr.InnerText);
        }

        public XmlElement GetXMl(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement("Auto");

            Utils.Xml.AddAttribute(Element, pDocument, "Time", mTime.ToString());
            Utils.Xml.AddAttribute(Element, pDocument, "Progressive", mProgressive.ToString());

            Utils.Xml.AddAttribute(Element, pDocument, "PanMin", mPanMin.ToString());
            Utils.Xml.AddAttribute(Element, pDocument, "PanMax", mPanMax.ToString());
            Utils.Xml.AddAttribute(Element, pDocument, "TiltMin", mTiltMin.ToString());
            Utils.Xml.AddAttribute(Element, pDocument, "TiltMax", mTiltMax.ToString());
            Utils.Xml.AddAttribute(Element, pDocument, "LimitEnabled", mLimitEnabled.ToString());

            Element.AppendChild(mPreset1.GetXml(pDocument));
            Element.AppendChild(mPreset2.GetXml(pDocument));

            return Element;
        }

        #endregion
    }
}
