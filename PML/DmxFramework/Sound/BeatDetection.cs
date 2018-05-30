using System;
using System.Collections.Generic;
using System.Text;

namespace DmxFramework.Sound
{
    public delegate void OnBeatChangedHandler(bool pActive);
    
    public class BeatDetection
    {
        WaveMeter mWaveMeter;
        public event OnBeatChangedHandler OnBeatChanged = null;
        int mValue;
        bool mLastBeat;
        int mCount;



        public BeatDetection()
        {
           /* mWaveMeter = new WaveMeter();
            mWaveMeter.OnVolumeChanged += new OnVolumeChangedHandler(mWaveMeter_OnVolumeChanged);*/
            mLastBeat = false;
            mValue = 50;
            mCount = 0;
        }

        public int Value
        {
            get { return mValue; }
            set { mValue = value; }
        }

        public WaveMeter waveMeter
        {
            get { return mWaveMeter; }
        }

        public void Start()
        {
            if(mCount ==0)
                mWaveMeter.Start();
            mCount++;
        }

        public void Stop()
        {
            mCount--;
            if(mCount ==0)
                mWaveMeter.Stop();
        }

        internal void StopAll()
        {
            mCount = 0;
            //mWaveMeter.Stop();
        }

        void mWaveMeter_OnVolumeChanged(int pValue)
        {
            if (!mLastBeat && pValue >= mValue && OnBeatChanged!=null)
            {
                mLastBeat = true;
                OnBeatChanged(true);
            }
            else if (mLastBeat && pValue < mValue && OnBeatChanged != null)
            {
                mLastBeat = false;
                OnBeatChanged(false);
            }
        }



    }
}
