using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace DmxFramework.Channels
{
    public class DmxValue
    {
        int mStart = 0;
        int mEnd = 0;
        int mValue = 0;
        string mImage;
        string mText;
        //Channel[]   mAssociatedChannels;
        List<Channel> mAssociatedChannels;
        //int[]       mAssociatedValues;
        List<int> mAssociatedValues;

        ArrayList mSubDmxValues;
        ArrayList mSubChannels;

        public DmxValue()
        {
            mValue = 0;
            mImage = null;
            mAssociatedChannels = null;
            mSubDmxValues = new ArrayList();
            mSubChannels = new ArrayList();
        }

        public DmxValue(XmlNode pNode,ArrayList pSubFixtures)
        {
            mValue = Convert.ToInt32(pNode.Attributes["value"].InnerText);
            mImage = pNode.Attributes["img"].InnerText;
            mStart = Convert.ToInt32(pNode.Attributes["start"].InnerText);
            mEnd = Convert.ToInt32(pNode.Attributes["end"].InnerText);
            mText = pNode.Attributes["text"].InnerText;
            mSubDmxValues = new ArrayList();
            mSubChannels = new ArrayList();

            if (pNode.ChildNodes != null && pNode.ChildNodes.Count != 0 && pSubFixtures != null && pSubFixtures.Count != 0)
            {
                /*mAssociatedChannels = new Channel[pNode.ChildNodes.Count];
                mAssociatedValues = new int[pNode.ChildNodes.Count];*/

                mAssociatedChannels = new List<Channel>();
                mAssociatedValues = new List<int>();
                int i = 0;
                foreach (XmlNode node in pNode.ChildNodes)
                {
                    string Name = node.Attributes["Name"].InnerText;
                    string channelName = node.Attributes["ChannelName"].InnerText;
                    int val =Convert.ToInt32( node.Attributes["Value"].InnerText);
                    foreach (DmxFramework.Fixtures.Fixture fix in pSubFixtures)
                    {
                        if (fix.Name == Name)
                        {
                            foreach (Channel chan in fix.Channels)
                            {
                                if (chan.Name == channelName)
                                {
                                    mAssociatedChannels.Add(chan);
                                    mAssociatedValues.Add(val);


                                    LoadSubDmxValues(chan, val);

                                    i++;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
                mAssociatedChannels = null;
        }

        public ArrayList SubDmxValues
        {
            get { return mSubDmxValues; }
        }

        public ArrayList SubChannels
        {
            get { return mSubChannels; }
        }


        private void LoadSubDmxValues(Channel pChannel, int pValue)
        {
            if (pChannel.DmxValues == null || pChannel.DmxValues.Count == 0)
                return;

            foreach (DmxValue val in pChannel.DmxValues)
            {
                if (pValue >= val.StartValue && pValue < val.EndValue)
                {
                    mSubChannels.Add(pChannel);
                    mSubDmxValues.Add(val);
                    return;
                }
            }
        }

        #region properties

        public int Value
        {
            get { return mValue; }
            set { mValue = value; }
        }

        public int StartValue
        {
            get { return mStart; }
            set { mStart = value; }
        }

        public int EndValue
        {
            get { return mEnd; }
            set { mEnd = value; }
        }


        public string Image
        {
            get { return mImage; }
            set { mImage = value; }
        }

        public string Text
        {
            get { return mText; }
            set { mText = value; }
        }

        

        public List<Channel> AssociatedChannels
        {
            get { return mAssociatedChannels; }
            set { mAssociatedChannels = value; }
        }

        public List<int> AssociatedValues
        {
            get { return mAssociatedValues; }
            set { mAssociatedValues = value; }
        }

        #endregion

        public override string ToString()
        {
            return mText;
        }

        internal void RemoveChannel(Channel pChannel)
        {
            for (int i = 0; i < mAssociatedChannels.Count; i++)
            {
                if (mAssociatedChannels[i] == pChannel)
                {
                    /*mAssociatedChannels = (Channel[])Utils.tables.RemoveFromTab(mAssociatedChannels, i);
                    mAssociatedValues = Utils.tables.RemoveFromTab(mAssociatedValues, i);*/
                    //mAssociatedChannels.Remove(pChannel
                    mAssociatedChannels.RemoveAt(i);
                    mAssociatedValues.RemoveAt(i);
                }
            }
        }


        internal XmlElement Save(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement("btn");

            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "value", mValue+""));
            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "img", mImage));
            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "start", mStart + ""));
            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "end", mEnd + ""));
            Element.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "text", mText));


            if (mSubChannels != null && mSubChannels.Count != 0)
            {
                for (int i = 0; i < mSubChannels.Count; i++)
                {
                    Channel chan = (Channel)mSubChannels[i];
                    DmxValue val = (DmxValue)mSubDmxValues[i];


                    XmlElement Cpy = pDocument.CreateElement("CopyTo");

                    Utils.Xml.AddAttribute(Cpy,pDocument,"Name",chan.Fixture.Name);
                    Utils.Xml.AddAttribute(Cpy,pDocument,"ChannelName",chan.Name);
                    Utils.Xml.AddAttribute(Cpy,pDocument,"Value",val.Value+"");
                    Element.AppendChild(Cpy);
                }
            }

            return Element;
        }

        internal bool EqualsTo(DmxValue pValue)
        {
            if (this.Text != pValue.Text)
                return false;

            if (this.Image != pValue.Image)
                return false;

            return true;
        }

        internal void RefreshValue(DmxValue pValue)
        {
            this.mStart = pValue.StartValue;
            this.mEnd = pValue.EndValue;
            this.mValue = pValue.Value;
        }

    }
}
