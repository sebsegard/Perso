using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using Sanford.Multimedia.Midi;
using DmxFramework.Channels;

namespace DmxFramework.Midi.Action
{
    public class ChangeDmxValue:Action
    {
        internal const string XmlElementName = "ChangeDmxValue";
        public const string ActionDescription = "Change Dmx Value";

        #region Members
        private Channel mChannel;
        private int mMinMidi = 0;
        private int mMaxMidi = 127;
        private int mMinDmx = 0;
        private int mMaxDmx = 255;
        private int mDmxValue = 0;

        private float mRatio = 0; 
        #endregion
        
        public ChangeDmxValue()
            : base()
        {
            
        }

        

        public ChangeDmxValue(XmlNode pElement)
            :base()
        {
            //pElement.Attributes["Channel"].InnerText;
            mChannel = Framework.Fixtures.GetChannel(pElement.Attributes["Channel"].InnerText);
            mMinDmx = Utils.Xml.GetInt16(pElement, "DmxMin");
            mMaxDmx = Utils.Xml.GetInt16(pElement, "DmxMax");
            mMinMidi = Utils.Xml.GetInt16(pElement, "MidiMin");
            mMaxMidi = Utils.Xml.GetInt16(pElement, "MidiMax");

            mChannel.OnValueChanged += new OnValueChangedHandler(mChannel_OnValueChanged);

            ComputeRatio();
        }

        internal override void Receive(int pValue)
        {
            //mRecieveValue = pValue;

            if (pValue < mMinMidi || pValue > mMaxMidi)
                return;
           
            int ValueToSend = mMinDmx + (int)((pValue-mMinMidi) * mRatio);
            mDmxValue = ValueToSend;
            mChannel.ForceValue(ValueToSend, ChangeOrigin.User);
        }

        internal override XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement(ChangeDmxValue.XmlElementName);
            if (mChannel == null)
                return null;
            Utils.Xml.AddAttribute(Element, pDocument, "Channel", mChannel.Path);
            Utils.Xml.AddAttribute(Element, pDocument, "DmxMin", mMinDmx);
            Utils.Xml.AddAttribute(Element, pDocument, "DmxMax", mMaxDmx);
            Utils.Xml.AddAttribute(Element, pDocument, "MidiMin", mMinMidi);
            Utils.Xml.AddAttribute(Element, pDocument, "MidiMax", mMaxMidi);
            return Element;
        }

        public override string ToString()
        {
            return ActionDescription;
        }


        #region Properties
        private void ComputeRatio()
        {
            mRatio = (float)((float)(mMaxDmx - mMinDmx) / (float)(mMaxMidi - mMinMidi));
        }

        public int MinDmx
        {
            get { return mMinDmx; }
            set
            {
                mMinDmx = value;
                ComputeRatio();
            }
        }

        public int MaxDmx
        {
            get { return mMaxDmx; }
            set
            {
                mMaxDmx = value;
                ComputeRatio();
            }
        }

        public int MinMidi
        {
            get { return mMinMidi; }
            set
            {
                mMinMidi = value;
                ComputeRatio();
            }
        }

        public int MaxMidi
        {
            get { return mMaxMidi; }
            set
            {
                mMaxMidi = value;
                ComputeRatio();
            }
        }

        public Channel Channel
        {
            get { return mChannel; }
            set { mChannel = value; }
        }

        

        #endregion

        void mChannel_OnValueChanged(Channel pChannel, int pValue)
        {
            if (pValue != mDmxValue)
            {
                mDmxValue = pValue;

                int NEwValue = (int)(((pValue- mMinDmx) / mRatio)) ;

                if (NEwValue < mMinMidi || NEwValue > mMaxMidi)
                    return;

                SendValueToMidi(NEwValue);
            }
        }
    }
}
