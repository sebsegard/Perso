using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace DmxFramework.Sound
{
    public class MusicMode
    {
        private BeatDetection mBeatDetection;
        private int mCount = 0;
        private ArrayList mAutoChanList;
        
        private int mStepTime = 4000; // 4 secondes
        private int mDetectionTime = 1000;
        private int mCurrentTime = 0;
        private int mNumberOfStep = 0;


        private Timer mMainTimer;
        private Timer mTickTimer;
        bool mProgressive = false;
        bool mBeatLastPeriod = true;

        #region Constructor

        public MusicMode()
        {
            mBeatDetection = new BeatDetection();
            mBeatDetection.OnBeatChanged += new OnBeatChangedHandler(mBeatDetection_OnBeatChanged);

            mAutoChanList = new ArrayList();

            mMainTimer = new Timer(mDetectionTime);
            mMainTimer.Enabled = false;
            mMainTimer.Elapsed += new ElapsedEventHandler(mMainTimer_Elapsed);

            mTickTimer = new Timer(DmxFramework.Framework.Tick);
            mTickTimer.Enabled = false;
            mTickTimer.Elapsed += new ElapsedEventHandler(mTickTimer_Elapsed);

            mNumberOfStep = mStepTime / DmxFramework.Framework.Tick;
        }

       

        #endregion


        #region Properties

        public BeatDetection BeatDetection
        {
            get { return mBeatDetection; }
        }

        private bool Progressive
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
            }
        }

        #endregion


        #region public start/stop

        public void Start()
        {
            if (mCount == 0)
            {
                mBeatDetection.Start();
                mMainTimer.Enabled = true;
                mTickTimer.Enabled = false;
                mBeatLastPeriod = true;
                mProgressive = false;
            }
            mCount++;
        }

        public void Stop()
        {
            mCount--;
            if (mCount == 0)
            {
                mBeatDetection.Stop();
                mMainTimer.Enabled = false;
                mTickTimer.Enabled = false;
            }
        }

        public void StopAll()
        {
            mBeatDetection.StopAll();
            mMainTimer.Enabled = false;
            mTickTimer.Enabled = false;
        }

        #endregion

        void mBeatDetection_OnBeatChanged(bool pActive)
        {
            if (!pActive)
                return;


            if (mBeatLastPeriod)
            {
                if (Progressive)
                {
                    Progressive = false;
                    mTickTimer.Enabled = false;
                    return;
                }
                

            }
            lock (mAutoChanList)
            {
                foreach (Channels.AutoChannel chan in mAutoChanList)
                    chan.MainTick();
            }
            mBeatLastPeriod = true;
        }


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
            if (mBeatLastPeriod)
            {
                mBeatLastPeriod = false;
                return;
            }

            if (!Progressive)
            {
                Progressive = true;
                mTickTimer.Enabled = true;
                mCurrentTime = 0;
                return;
            }

            if (mCurrentTime == 0)
            {
                lock (mAutoChanList)
                {
                    foreach (Channels.AutoChannel chan in mAutoChanList)
                        chan.MainTick();
                }
            }

            mCurrentTime += mDetectionTime;
            if (mCurrentTime > mStepTime)
                mCurrentTime = 0;
            
        }

        #region add or remove chan

        public void AddChannel(Channels.Channel pChannel)
        {
            if (pChannel == null)
                return;

            //Check if the channel is in the liste
            Channels.AutoChannel chan = new DmxFramework.Channels.AutoChannel(pChannel, Channels.ChangeOrigin.AutoMode);
            chan.ProgressMode = Progressive;
            chan.NumberOfStep = mNumberOfStep;
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
    }
}
