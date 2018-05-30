using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DmxFramework.AutoMode;
using DmxFramework.Fixtures;

namespace DmxFramework.Midi.Action
{
    public class AutoSpeed : Action
    {
        internal const string XmlElementName = "AutoSpeed";
        public const string ActionDescription = "Automatic mode speed";

        int mAutoModeNum;
        AutoMode.AutoMode mAutoMode;
        private float mRatio;
        private int mSendValue;

        public AutoSpeed()
        {
            ComputeRatio();
        }

        public AutoSpeed(XmlNode pNode)
        {
            mAutoModeNum = Utils.Xml.GetInt16(pNode, "AutoModeNum");
            mAutoMode = Framework.AutomaticMode[AutoModeNum];
            mAutoMode.OnAutoModeTimeChanged += new OnAutoModeTimeChangedEvent(mAutoMode_OnAutoModeTimeChanged);
            ComputeRatio();
        }

        void mAutoMode_OnAutoModeTimeChanged(DmxFramework.AutoMode.AutoMode pAutomode, int pTime)
        {
            if (pTime == mSendValue)
                return;

            int NEwVal = (int)((pTime- AutoMode.AutoMode.MinTime) / mRatio) ;

            int value = 127 - NEwVal;
            SendValueToMidi(value);
        }

        internal override void Receive(int pValue)
        {
            int value = 127 - pValue;
            mSendValue = AutoMode.AutoMode.MinTime + (int)(mRatio * value);
            mAutoMode.Time = mSendValue;
        }

        private void ComputeRatio()
        {
            mRatio = (float)(AutoMode.AutoMode.MaxTime - AutoMode.AutoMode.MinTime) / (127 - 0);
        }




        internal override XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement(XmlElementName);
            Utils.Xml.AddAttribute(Element, pDocument, "AutoModeNum",mAutoModeNum);
            return Element;
        }


        public override string ToString()
        {
            return ActionDescription;
        }

        public int AutoModeNum
        {
            get { return mAutoModeNum; }
            set
            {
                mAutoModeNum = value;
                mAutoMode = Framework.AutomaticMode[AutoModeNum];
            }
        }
    }
}
