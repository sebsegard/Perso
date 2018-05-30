using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DmxFramework.Channels
{
    public class SnapShot
    {
        #region private members
        int[] mValues;
        string mName;
        #endregion

        #region constructor

        public SnapShot(string pName)
        {
            mName = pName;
            SnapShot.List.Add(this);
        }

        #endregion

        #region properties

        public string Name
        {
            get { return mName; }
        }

        public int[] Values
        {
            get { return mValues; }
            set {mValues = value;}
        }

        #endregion

        #region public methods

        public void Take()
        {
            int Max = 0, i=0, j=0;
            
            for (i = 0; i < Framework.RealFixtureList.Count; i++)
            {
                for (j = 0; j < Framework.RealFixtureList[i].Channels.Count; j++)
                {
                    RealChannel chan = (RealChannel)Framework.RealFixtureList[i].Channels[j];
                    if (chan.DmxAddress > Max)
                        Max = chan.DmxAddress;
                }
            }
            Max++;

            mValues = new int[Max];
            for (i = 0; i < Max; i++)
                mValues[i] = -1;

            for (i = 0; i < Framework.RealFixtureList.Count; i++)
            {
                for (j = 0; j < Framework.RealFixtureList[i].Channels.Count; j++)
                {
                    RealChannel chan = (RealChannel)Framework.RealFixtureList[i].Channels[j];
                    mValues[chan.DmxAddress] = chan.Value;
                }
            }
        }

        public void Apply()
        {
            for (int i = 0; i < Framework.RealFixtureList.Count; i++)
            {
                for (int j = 0; j < Framework.RealFixtureList[i].Channels.Count; j++)
                {
                    RealChannel chan = (RealChannel)Framework.RealFixtureList[i].Channels[j];
                    if (chan.DmxAddress < mValues.Length)
                    {
                        if (mValues[chan.DmxAddress] != -1)
                        {
                            chan.ForceValue(mValues[chan.DmxAddress], ChangeOrigin.User);
                        }
                    }
                }
            }
        }


        public override string ToString()
        {
            return mName;
        }


        #endregion

        #region static members and methods

        public static List<SnapShot> List = new List<SnapShot>();

        public static void LoadXml(XmlNode pNode)
        {
            foreach (XmlNode Node in pNode.ChildNodes)
            {
                SnapShot shot = new SnapShot(Node.Attributes["Name"].InnerText);

                shot.Values = new int[Node.Attributes.Count - 1];
                for (int i = 1; i < Node.Attributes.Count; i++)
                {
                    shot.Values[i-1] = Convert.ToInt16(Node.Attributes[i].InnerText);
                }
            }
        }

        public static XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement("Snapshots");

            for (int i = 0; i < List.Count; i++)
            {
                XmlElement snap = pDocument.CreateElement("Snap");

                Utils.Xml.AddAttribute(snap, pDocument, "Name", List[i].Name);
                for (int j = 0; j < List[i].Values.Length; j++)
                {
                    Utils.Xml.AddAttribute(snap, pDocument, "V_"+j, List[i].Values[j].ToString());
                }
                Element.AppendChild(snap);

            }
            return Element;
        }

        #endregion


    }
}
