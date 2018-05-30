using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DmxFramework.Keyboard
{
    public class Hotkey
    {
        public delegate void OnKeyStepPressedDlg();

        #region members

        private string mKeyCode;
        private int mKeyValue;
        //private DmxFramework.Scene.Scene mScene;
        //private string mScenePath;
        //private bool mStopOnKeyUp;
        //private bool mPressed;
        ArrayList mActions = null;

        bool mIsKeyStep = false;

        public event OnKeyStepPressedDlg OnKeyStepPressed;

        #endregion

        

        #region constructors

        public Hotkey()
        {
            mActions = new ArrayList();
        }

        public Hotkey(string pKeyCode, int pKeyValue)//, DmxFramework.Scene.Scene pScene, string pScenePath)
        {
            mActions = new ArrayList();
            mKeyCode = pKeyCode;
            mKeyValue = pKeyValue;
            mIsKeyStep = false;
        }

        #endregion

        #region properties

        public string KeyCode { get { return mKeyCode; } }
        public int KeyValue { get { return mKeyValue; } }

 
        public bool IsKeyStep
        {
            get { return mIsKeyStep; }
            set { mIsKeyStep = value; }
        }

        public ArrayList Actions
        {
            get { return mActions; }
            set { mActions = value; }
        }
        
        //public DmxFramework.Scene.Scene HotScene { get { return mScene; } }
        //public string ScenePath { get { return mScenePath; } }
        
       /* public bool StopOnKeyUp 
        {
            get { return mStopOnKeyUp; }
            set { mStopOnKeyUp = value; }
        }*/

        #endregion


        #region public methods

        public void Press()
        {
            if (mIsKeyStep)
            {
                if (OnKeyStepPressed != null)
                    OnKeyStepPressed();
            }
            else
            {
                foreach (Action action in mActions)
                    action.KeyDown();
            }
        }

        public void KeyUp()
        {
            if (mIsKeyStep)
                return;

            foreach (Action action in mActions)
                action.KeyUp();
        }

        public override string ToString()
        {
           
            return mKeyCode+ " ("+mKeyValue+")";
        }

        #endregion
    }
}
