using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DmxFramework.AutoMode;
using DmxFramework.Fixtures;

namespace DmxFramework.Midi.Action
{
    public class SceneSpeed : Action
    {
        internal const string XmlElementName = "SceneSpeed";
        public const string ActionDescription = "Scene speed";

        int mAutoModeNum;
        AutoMode.AutoMode mAutoMode;
        private float mRatio;
        private int mSendValue;

        public SceneSpeed()
        {
            ComputeRatio();
        }

        public SceneSpeed(XmlNode pNode)
        {
           
        }

        

        internal override void Receive(int pValue)
        {
            int value = pValue;
            int SceneRatio = -100+200/127*value;
            for (int i = 0; i < DmxFramework.Scene.Scene.PlayingScenes.Count; i++)
                DmxFramework.Scene.Scene.PlayingScenes[i].Ratio = SceneRatio;
        }

        private void ComputeRatio()
        {
            mRatio = (float)(AutoMode.AutoMode.MaxTime - AutoMode.AutoMode.MinTime) / (127 - 0);
        }




        internal override XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement(XmlElementName);
            //Utils.Xml.AddAttribute(Element, pDocument, "AutoModeNum",mAutoModeNum);
            return Element;
        }


        public override string ToString()
        {
            return ActionDescription;
        }


    }
}
