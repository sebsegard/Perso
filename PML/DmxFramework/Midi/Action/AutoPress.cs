using System;
using System.Collections.Generic;
using System.Text;
using DmxFramework.AutoMode;
using System.Xml;


namespace DmxFramework.Midi.Action
{
    public class AutoPress:Action
    {
        internal const string XmlElementName = "AutoPress";
        public const string ActionDescription = "Automatic mode btn";


        int mAutoModeNum;
        AutoMode.AutoMode mAutoMode;
        int mPresetNum;
        AutoPreset mPreset;

        public AutoPress()
        {

        }

        public AutoPress(XmlNode pNode)
        {
            mAutoModeNum = Utils.Xml.GetInt16(pNode, "AutoModeNum");
            mPresetNum = Utils.Xml.GetInt16(pNode, "PresetNum");
            mAutoMode = Framework.AutomaticMode[AutoModeNum];
            if (mPresetNum == 0)
                mPreset = mAutoMode.Preset1;
            else
                mPreset = mAutoMode.Preset2;

            mAutoMode.OnAutoModePresetStateChanged += new OnAutoModePresetStateChangedEvent(mAutoMode_OnAutoModePresetStateChanged);
        }

        void mAutoMode_OnAutoModePresetStateChanged(DmxFramework.AutoMode.AutoMode pAutoMode, AutoPreset pAutoPreset, bool pEnabled)
        {
            if (pAutoPreset != mPreset)
                return;

            if (pEnabled)
                SendValueToMidi(127);
            else
                SendValueToMidi(0);
        }

        internal override void Receive(int pValue)
        {
            //all cases : send value ...
            mAutoMode.SetPreset(mPreset);
        }








        internal override XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement(XmlElementName);
            Utils.Xml.AddAttribute(Element, pDocument, "AutoModeNum", mAutoModeNum);
            Utils.Xml.AddAttribute(Element, pDocument, "PresetNum", mPresetNum);
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

        public int PresetNum
        {
            get { return mPresetNum; }
            set
            {
                mPresetNum = value;
                if (mPresetNum == 1)
                    mPreset = mAutoMode.Preset1;
                else
                    mPreset = mAutoMode.Preset2;
            }
        }
    }
}
