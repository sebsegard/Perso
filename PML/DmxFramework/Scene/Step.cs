using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DmxFramework.Scene
{
    public class Step
    {
        //ArrayList mChannel;
        //string mChannelNames;
        int[] mValues;
        string mComment;

        public Step(ArrayList pChannels)
        {
           // mChannel=pChannels;
            //mChannelNames = pChannelsName;
            mComment="";
            this.mValues = new int[pChannels.Count];
            for (int i = 0; i < pChannels.Count; i++)
                mValues[i] = ((Channels.Channel)pChannels[i]).Value;

        }

        public Step()
        {
            // mChannel=pChannels;
            //mChannelNames = pChannelsName;
            mComment = "";
            this.mValues = null;

        }

        public Step(XmlNode pNode)
        //public Step(ArrayList pChannels, string pChannelsName, XmlNode pNode)
        {
            //mChannel=pChannels;
            //mChannelNames = pChannelsName;
            this.mComment = pNode.Attributes[0].InnerText;
            this.mValues = new int[pNode.Attributes.Count-1];
            for (int i = 1; i < pNode.Attributes.Count; i++)
                mValues[i-1] = Convert.ToInt32(pNode.Attributes[i].InnerText);
        }

        public int[] Values
        {
            get { return mValues; }
            set{mValues = value;}
        }

        public string Comment
        {
            get { return mComment; }
            set { mComment = value; }
        }

        /*public void Test()
        {
            for (int i = 0; i < mChannel.Count; i++)
            {
                ((Channels.Channel)mChannel[i]).SetValue(mValues[i]);
            }
        }*/

        /*public string ChannelName
        {
            get { return mChannelNames; }
        }*/

        public XmlNode GetXmlNode(XmlDocument pDocument)
        {
            XmlElement node = pDocument.CreateElement("Step");
            XmlAttribute XmlAttribute = pDocument.CreateAttribute("Comment");
            XmlAttribute.InnerText = mComment;
            node.Attributes.Append(XmlAttribute);

            for (int i = 0; i < mValues.Length; i++)
            {
                XmlAttribute = pDocument.CreateAttribute("Val"+(i+1));
                XmlAttribute.InnerText = mValues[i]+"";
                node.Attributes.Append(XmlAttribute);
            }
            return node;
        }

        internal void RemoveChannel(int pChannelIndex)
        {
            //mChannel.RemoveAt(pChannelIndex);
            int index = 0;
            int OriginalSize = Values.Length;
            int[] val = new int[OriginalSize - 1];
            for (int i = 0; i < OriginalSize; i++)
            {
                if (i == pChannelIndex)
                    continue;

                val[index] = Values[i];
                index++;
            }
            mValues = val;
        }


        internal void AddChannel(Channels.Channel pChannel)
        {
            int OriginalSize = Values.Length;
            int[] val = new int[OriginalSize + 1];
            for (int i = 0; i < OriginalSize; i++)
                val[i] = Values[i];
            val[OriginalSize] = pChannel.Value;

            mValues = val;
        }

        internal Step Clone()
        {
            Step step = new Step();
            step.Values = new int[this.Values.Length];
            for (int i = 0; i < this.Values.Length; i++)
                step.Values[i] = this.Values[i];

            step.Comment = mComment;
            return step;
        }

    }
}
