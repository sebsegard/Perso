using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DmxFramework.Channels
{
    public class RealChannel:Channel
    {
        int mAbsoluteNum;
        DmxOutput mOutput;
        Fixtures.Poursuit mPoursuit;

        #region constructor

        public RealChannel(string pName, int pNum, int pAbsoluteNum, DmxOutput pOutput)
            : base(ChannelType.Real)
        {
            mOutput = pOutput;
            mAbsoluteNum = pAbsoluteNum;
            mName = pName;
            mNumber = pNum;
            mAbsoluteNum = pAbsoluteNum;
        }

        public RealChannel(XmlNode pNode, int pStartAddress, DmxOutput pOutput, Fixtures.Poursuit pPoursuit)
            : base(ChannelType.Real)
        {
            mOutput = pOutput;
            

            mName = pNode.Attributes["Name"].InnerText;
            mNumber = Convert.ToInt32(pNode.Attributes["Num"].InnerText);
            mAbsoluteNum = pStartAddress - 1 + mNumber;


            mFunction = Channel.StringToFunction(pNode.Attributes["Type"].InnerText);
            LoadButtons(pNode,null);

            if (this.mFunction == ChannelFunction.Pan || this.mFunction == ChannelFunction.Tilt)
                mPoursuit = pPoursuit;
            else
                mPoursuit = null;
        }

        public RealChannel(string pName, int pNum, string pFunction)
            : base(ChannelType.Real)
        {    
            mName = pName;
            mNumber = pNum;
            mDmxValues = new System.Collections.ArrayList();
            this.mFunction = Channel.StringToFunction(pFunction);
        }

        #endregion

        public int DmxAddress
        {
            get { return mAbsoluteNum; }
        }

        public override int MaxInAutoMode
        {
            get { return mMaxInAutoMode; }
            set { mMaxInAutoMode = value; }
        }

        public override int MinInAutoMode
        {
            get { return mMinInAutoMode; }
            set { mMinInAutoMode = value; }
        }

        #region Change DMX value

        protected override void ChangeValue(int pValue, bool pFromForcage,ChangeOrigin pOrigin)
        {
            int ValueToSend = pValue;

            if (mPoursuit != null && mPoursuit.IsActive)
            {
                if (mFunction == ChannelFunction.Tilt)
                    ValueToSend = mPoursuit.SetTilt(pValue);
                else
                    ValueToSend = mPoursuit.SetPan(pValue);
            }

            mOutput.SetDmxValue(mAbsoluteNum, ValueToSend);
        }

        #endregion


        public override XmlNode Save(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement("Channel");

            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "Name", mName));
            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "Num", mNumber+""));
            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "Type", mFunction.ToString()));

            if (mFunction == ChannelFunction.Btn)
            {
                Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "RowCount", mRowCount + ""));
                Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "ColumnCount", mColumnCount + ""));
            }

            if (mDmxValues == null || mDmxValues.Count == 0)
                return Element;

            foreach (DmxValue val in this.DmxValues)
            {
                Element.AppendChild(val.Save(pDocument));
            }
            return Element;
        }


        internal void LoadParameters(XmlNode pNode)
        {
            if (pNode.Attributes["Inverted"] != null)
                this.mIsInverted = Convert.ToBoolean(pNode.Attributes["Inverted"].InnerText);
        }

        internal XmlElement GetParametersXml(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement("ChanParameter");

            Utils.Xml.AddAttribute(Element, pDocument, "Name", mName);
            Utils.Xml.AddAttribute(Element, pDocument, "Inverted", mIsInverted.ToString());
            return Element;
        }



        internal void RefreshChannel(Channel pChannel)
        {
            bool found = true;
            int i = 0;
            if (pChannel.Function == this.Function)
            {
                this.Function = pChannel.Function;
            }
            if (this.Function == ChannelFunction.Basic || this.Function == ChannelFunction.Pan || this.Function == ChannelFunction.Tilt)
            {
                if(this.mDmxValues!=null)
                    this.mDmxValues.Clear();
                return;
            }

            if (this.mDmxValues == null)
                this.mDmxValues = new System.Collections.ArrayList();

            foreach (DmxValue ThisValue in mDmxValues)
            {
                found = false;
                foreach (DmxValue pValue in pChannel.DmxValues)
                {
                    if(pValue.EqualsTo(ThisValue))
                    {
                        ThisValue.RefreshValue(pValue);
                        found = true;
                        break;
                    }
                }

                if (!found)
                    mDmxValues.Remove(ThisValue);
            }

            foreach (DmxValue pValue in pChannel.DmxValues)
            {
                found = false;
                foreach (DmxValue ThisValue in mDmxValues)
                {
                    if (pValue.EqualsTo(ThisValue))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    mDmxValues.Insert(1,pValue);
                i++;
            }

        }
    
    
    
    
    }
}
