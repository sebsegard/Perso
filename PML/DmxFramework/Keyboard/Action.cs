using System;
using System.Collections.Generic;
using System.Text;

namespace DmxFramework.Keyboard
{
    public class Action
    {
        Channels.Channel mChannel = null;
        Channels.DmxValue mValue = null;
        Scene.Scene mScene = null;
        string mPath=null;

        
        private bool mStopOnKeyUp = false;
        private bool mPressed = false;

        public Action(Channels.Channel pChannel, Channels.DmxValue pValue)
        {
            mChannel = pChannel;
            mValue = pValue;
            //mPath = pPath;
        }

        public Action(Scene.Scene pScene)
        {
            mScene = pScene;
            //mPath = pPath;
        }

        public bool StopOnKeyUp
        {
            get { return mStopOnKeyUp; }
            set { mStopOnKeyUp = value; }
        }

        public string Path
        {
            get { return mPath; }
            set { mPath = value; }
        }

        public Scene.Scene Scene
        {
            get { return mScene; }
            set { mScene = value; }
        }

        public Channels.Channel Channel
        {
            get { return mChannel; }
            set { mChannel = value; }
        }

        public Channels.DmxValue Value
        {
            get { return mValue; }
            set { mValue = value; }
        }

        public void KeyDown()
        {
            if (mPressed)
                return;
            mPressed = true;

            if (mScene == null && mChannel==null)
                return;

            if (mScene != null)
            {
                if (mScene.State != DmxFramework.Scene.SceneState.PlayingExclusive && mScene.State != DmxFramework.Scene.SceneState.Waiting)
                    mScene.Play();
                else
                    mScene.Remove();
            }
            else
            {
                if (mChannel.IsForced && mChannel.Value == mValue.Value)
                    mChannel.UnforceValue();
                else
                    mChannel.ForceValue(mValue.Value, DmxFramework.Channels.ChangeOrigin.User);
            }
        }

        public void KeyUp()
        {
            mPressed = false;
            if (!this.mStopOnKeyUp || ( mScene == null && mChannel==null))
                return;

            if (mScene != null)
                mScene.Remove();
            else
                mChannel.UnforceValue();
        }




    }
}
