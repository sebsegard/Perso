using System;
using System.Collections.Generic;
using System.Text;
using DmxFramework.Scene;
using System.Xml;

namespace DmxFramework.Midi.Action
{
    public class SceneMidiPlayer:Action
    {
        internal const string XmlElementName = "ScenePlayer";
        public const string ActionDescription = "Scene player";

        private int mRecievedValue;
        private Scene.Scene mScene;

        
        public SceneMidiPlayer()
            : base()
        {
            
        }



        public SceneMidiPlayer(XmlNode pElement)
            :base()
        {
           string ScenePath = pElement.Attributes["Scene"].InnerText;
           mScene = Framework.Fixtures.GetScene(ScenePath);
           mScene.OnScenePlayed += new OnScenePlayedHandler(mScene_OnScenePlayed);
           mScene.OnSceneRemoved += new OnSceneRemovedHandler(mScene_OnSceneRemoved);
           mScene.OnSceneStateChanged += new OnSceneStateChangeHandler(mScene_OnSceneStateChanged);
        }

        void mScene_OnSceneStateChanged(DmxFramework.Scene.Scene pScene, SceneState pState)
        {
            if (pState == SceneState.Playing || pState == SceneState.PlayingExclusive)
            {
                if (mRecievedValue != 127)
                {
                    SendValueToMidi(127);
                    mRecievedValue = 127;
                }
            }
            else
            {
                if (mRecievedValue != 0)
                {
                    SendValueToMidi(0);
                    mRecievedValue = 0;
                }
            }
        }



        internal override void Receive(int pValue)
        {
            mRecievedValue = 127;
            if (pValue == 127)
                mScene.Play();
            else
                mScene.Remove();
        }

        internal override XmlElement GetXml(XmlDocument pDocument)
        {
            if(mScene == null)
                return null;
            
            XmlElement Element = pDocument.CreateElement(XmlElementName);
            Utils.Xml.AddAttribute(Element,pDocument,"Scene",mScene.Path);
            return Element;
        }

        public override string ToString()
        {
            return ActionDescription;
        }


        #region Properties

        public Scene.Scene Scene
        {
            get { return mScene; }
            set {
                if (mScene != null)
                {
                    mScene.OnScenePlayed -= this.mScene_OnScenePlayed;
                    mScene.OnSceneRemoved -= this.mScene_OnSceneRemoved;
                }
                mScene = value;
                mScene.OnScenePlayed += new OnScenePlayedHandler(mScene_OnScenePlayed);
                mScene.OnSceneRemoved += new OnSceneRemovedHandler(mScene_OnSceneRemoved);
            }
        }
       
        #endregion

        #region scene event

        void mScene_OnSceneRemoved(DmxFramework.Scene.Scene pScene)
        {
            //if (mRecievedValue != 0)
            //{
            //    SendValueToMidi(0);
            //    mRecievedValue = 0;
            //}
        }

        void mScene_OnScenePlayed(DmxFramework.Scene.Scene pScene)
        {
            //if (mRecievedValue != 127)
            //{
            //    SendValueToMidi(127);
            //    mRecievedValue = 127;
            //}
        }

        #endregion
    }
}
