using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DmxFramework;

namespace DmxFramework.Channels
{
    public enum VirtualChannelType
    {
        Copy,
        ByValue
    }
    
    
    
    public class VirtualChannel : Channel
    {
        VirtualChannelType mVirtualType;
        ArrayList   mCopyChannel;
        bool[]      mIsChannelInverted;



        #region constructor
        
        public VirtualChannel(string pName, int pNum, VirtualChannelType pVirtualType)
            : base(ChannelType.Virtual)
        {
            mVirtualType = pVirtualType;
        }

        public VirtualChannel(string pName, string pFunction)
            : base(ChannelType.Virtual)
        {
            this.mName = pName;
            this.mFunction = Channel.StringToFunction(pFunction);
            
            switch (this.mFunction)
            {
                case ChannelFunction.Btn:
                case ChannelFunction.List :
                    this.mDmxValues = new ArrayList();
                    mVirtualType = VirtualChannelType.ByValue;
                    break;
                default:
                    mVirtualType = VirtualChannelType.Copy;
                    this.CopyChannel = new ArrayList();
                    break;
            }
            
        }

        public VirtualChannel(XmlNode pNode, ArrayList pFixtures)
            : base(ChannelType.Virtual)
        {
            LoadXml(pNode,pFixtures);
        }

        #endregion

        #region properties

        public ArrayList CopyChannel
        {
            get { return mCopyChannel; }
            set { mCopyChannel = value; }
        }

        public bool[] IsChannelInverted
        {
            get { return mIsChannelInverted; }
            set { mIsChannelInverted = value; }
        }

        public VirtualChannelType VirtualType
        { get { return mVirtualType; } }


        public override int MaxInAutoMode
        {
             get { return mMaxInAutoMode; }
             set { 
                mMaxInAutoMode = value;
                if (mCopyChannel != null)
                {
                    foreach (Channel chan in mCopyChannel)
                        chan.MaxInAutoMode = value;
                }
            }
        }

        public override int MinInAutoMode
        {
             get { return mMinInAutoMode; }
             set { 
                mMinInAutoMode = value;
                if (mCopyChannel != null)
                {
                    foreach (Channel chan in mCopyChannel)
                        chan.MinInAutoMode = value;
                }
            }
        }

        #endregion

       
        #region overloaded functions

        protected override void ChangeValue(int pValue, bool pFromForcage,ChangeOrigin pOrigin)
        {
            ChangeOrigin newOrigin = pOrigin;
            if (pOrigin == ChangeOrigin.User || pOrigin == ChangeOrigin.Scene)
                newOrigin = ChangeOrigin.Derivated;

            switch (mVirtualType)
            {
                case VirtualChannelType.Copy:
                    CopyValue(pValue, pFromForcage, newOrigin);
                    return;

                case VirtualChannelType.ByValue:
                    DetermineValue(pValue, pFromForcage, newOrigin);
                    return;
            }
        }

        public override void UnforceValue()
        {
            if (mIsForced)
            {
                this.mIsForced = false;
                TriggerNewForceEvent(false);
            
            
                switch (mVirtualType)
                {
                    case VirtualChannelType.Copy:
                    {
                         for (int i = 0; i < mCopyChannel.Count; i++)
                            ((Channel)(mCopyChannel[i])).UnforceValue();
                        return;
                    }
                    case VirtualChannelType.ByValue:
                    {
                        foreach (DmxValue value in mDmxValues)
                        {
                            for (int i = 0; i < value.AssociatedChannels.Count; i++)
                            {
                                value.AssociatedChannels[i].UnforceValue();                               
                            }
                            break;
                        }
                        return;
                    }
                }
            }
        }

        #endregion


        #region private functions

        private void CopyValue(int pValue, bool pFromForcage, ChangeOrigin pOrigin)
        {
            if (pFromForcage)
            {
                
                for (int i = 0; i < mCopyChannel.Count; i++)
                {
                    if (mIsChannelInverted[i])
                        ((Channel)(mCopyChannel[i])).ForceValue(255 - pValue, pOrigin);
                    else
                        ((Channel)(mCopyChannel[i])).ForceValue(pValue, pOrigin);
                }
            }
            else
            {
                for (int i = 0; i < mCopyChannel.Count; i++)
                {
                    if (mIsChannelInverted[i])
                        ((Channel)(mCopyChannel[i])).SetValue(255 - pValue, pOrigin);
                    else
                        ((Channel)(mCopyChannel[i])).SetValue(pValue, pOrigin);
                }
            }
        }

        private void DetermineValue(int pValue, bool pFromForcage, ChangeOrigin pOrigin)
        {
            if (pFromForcage)
            {
                foreach (DmxValue value in mDmxValues)
                {
                    if (pValue >= value.StartValue && pValue < value.EndValue)
                    {
                        for (int i = 0; i < value.AssociatedChannels.Count; i++)
                            value.AssociatedChannels[i].ForceValue(value.AssociatedValues[i], pOrigin);
                        break;
                    }
                }
            }
            else
            {
                foreach (DmxValue value in mDmxValues)
                {
                    if (pValue >= value.StartValue && pValue < value.EndValue)
                    {
                        for (int i = 0; i < value.AssociatedChannels.Count; i++)
                            value.AssociatedChannels[i].SetValue(value.AssociatedValues[i], pOrigin);
                        break;
                    }
                }
            }
        }

        #endregion


        #region xml

        private void LoadXml(XmlNode pNode, ArrayList pFixtures)
        {
            this.mName = pNode.Attributes["Name"].InnerText;
            this.mNumber = Convert.ToInt32(pNode.Attributes["Num"].InnerText);

            string VirtualType = pNode.Attributes["VirtualType"].InnerText;

            this.mFunction = Channel.StringToFunction(pNode.Attributes["Type"].InnerText);
            
            if(VirtualType == VirtualChannelType.Copy.ToString())
                LoadCopyXml(pNode, pFixtures);
            else
                LoadByValueXml(pNode, pFixtures);
        }


        private void LoadCopyXml(XmlNode pNode, ArrayList pFixtures)
        {
            this.mVirtualType = VirtualChannelType.Copy;
            mCopyChannel = new ArrayList() ;
            mIsChannelInverted = new bool[pNode.ChildNodes.Count];
            int i = 0;


            foreach (XmlNode node in pNode.ChildNodes)
            {
                if (node.Name == "CopyTo")
                {

                    try
                    {
                        string Name = node.Attributes["Name"].InnerText;
                        string channelName = node.Attributes["ChannelName"].InnerText;

                        foreach (DmxFramework.Fixtures.Fixture fix in pFixtures)
                        {
                            if (fix.Name == Name)
                            {
                                foreach (Channel chan in fix.Channels)
                                {
                                    if (chan.Name == channelName)
                                    {
                                        mCopyChannel.Add(chan);
                                        mIsChannelInverted[i] = false;
                                        i++;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                }
                else
                {

                }
            }
           /* if (i != pNode.ChildNodes.Count)
                throw new Exception("Undefined node");*/
        }


        private void LoadByValueXml(XmlNode pNode, ArrayList pFixtures)
        {
            this.mVirtualType = VirtualChannelType.ByValue;
            LoadButtons(pNode, pFixtures);
        }


        internal void RemoveChannel(Channel pChannel)
        {
            if (mVirtualType == VirtualChannelType.Copy)
            {
                mCopyChannel.Remove(pChannel);
            }
            else
            {
                foreach (DmxValue val in mDmxValues)
                {
                    val.RemoveChannel(pChannel);
                }
            }
        }


        internal void RemoveFixture(Fixtures.Fixture pFixture)
        {
            foreach (Channel chan in pFixture.Channels)
            {
                RemoveChannel(chan);
            }
        }



        public override XmlNode Save(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement("Channel");

            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "Name", mName));
            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "Num", mNumber + ""));
            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "inverted", mIsInverted + ""));
            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "Type", mFunction.ToString()));

            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "VirtualType", mVirtualType.ToString()));

            if (mFunction == ChannelFunction.Btn)
            {
                Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "RowCount", mRowCount + ""));
                Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "ColumnCount", mColumnCount + ""));
            }

            if (mCopyChannel != null && mCopyChannel.Count != 0)
            {
                foreach (Channel chan in this.CopyChannel)
                {
                    XmlElement Cpy = pDocument.CreateElement("CopyTo");
                    Utils.Xml.AddAttribute(Cpy, pDocument, "Name", chan.Fixture.Name);
                    Utils.Xml.AddAttribute(Cpy, pDocument, "ChannelName", chan.Name);
                    Element.AppendChild(Cpy);
                }
            }

            if (mDmxValues == null || mDmxValues.Count == 0)
                return Element;

            foreach (DmxValue val in this.DmxValues)
            {
                Element.AppendChild(val.Save(pDocument));
            }
            return Element;
        }


#endregion

    }

}
