using System;
using System.Collections.Generic;
using System.Text;

namespace DmxFramework.Channels
{
    internal class AutoChannel
    {
        Channel mChannel;

        int mNumberOfStep = 10;
        float mCurrentValue = 0;
        float mNextValue = 0;
        float mStepValue = 0;
        bool mProgressMode;
        int mMaxRand = 255;
        ChangeOrigin mOrigin;
        int mMin = 0;
        int mMax = 255;

        #region constructor
        
        internal AutoChannel(Channel pChannel, ChangeOrigin pOrigin)
        {
            mProgressMode = false;
            mChannel = pChannel;
            mOrigin = pOrigin;
            mCurrentValue = mChannel.Value;
            mMaxRand = mMax - mMin;
        }
        
#endregion


        #region properties

        internal bool ProgressMode
        {
            get { return mProgressMode; }
            set { mProgressMode = value;}
        }

        internal int NumberOfStep
        {
            get { return mNumberOfStep; }
            set { mNumberOfStep = value; }
        }

        internal Channel Chan
        {
            get { return mChannel; }
        }

        internal int Min
        {
            get { return mMin; }
            set { 
                mMin = value;
                mMaxRand = mMax - mMin;
                mChannel.MinInAutoMode = mMin;
            }
        }

        internal int Max
        {
            get { return mMax; }
            set { 
                mMax = value;
                mMaxRand = mMax - mMin;
                mChannel.MaxInAutoMode = value;
            }
        }

        #endregion

        #region internal methods

        internal void MainTick()
        {
            mNextValue = Framework.random.Next(mMaxRand) + mMin;
            
            //en non progressif, on envoie directement la valeur ...
            if (!mProgressMode)
            {
                mCurrentValue = mNextValue;
                SendValue();
                return;
            }

            mStepValue = (float)((float)(mNextValue - mCurrentValue) / (float)mNumberOfStep);
            if (mStepValue == 0)
            {
                if ((mNextValue - mCurrentValue) > 0)
                    mStepValue = 1;
                else if ((mNextValue - mCurrentValue) < 0)
                    mStepValue = -1;
            }
        }


        internal void SmallTick()
        {
            mCurrentValue += mStepValue;
            SendValue();
        }

        #endregion


        #region private methods
        
        private void SendValue()
        {
            if (mCurrentValue <= 0)
                mCurrentValue = 0;

            if (mCurrentValue >= 255)
                mCurrentValue = 255;

            mChannel.SetValue((int)mCurrentValue, mOrigin);
        }

        #endregion
    }
}
