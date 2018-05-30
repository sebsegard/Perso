using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace DmxFramework.Fixtures
{
    public  class RealFixture: Fixture
    {
        string mLightName;
        string mLightConstructor;
        string mImage;
        string mFixtureFileName;
        int mStartAddress;
        Fixtures.Poursuit mPoursuit;
        bool mToSave = false;

        #region constructors

        public RealFixture()
            : base(null,FixtureType.Real)
        {
            mLightName = "";
            mLightConstructor = "";
            mImage = "";
            mStartAddress = 0;
            mPoursuit = new Poursuit();
        }

       public RealFixture(Fixture pParent,XmlNode pNode,DmxOutput pOutput, int pLevel,string pPath)
           : base(pParent,FixtureType.Real)
       {
           
           mName = pNode.Attributes["Name"].InnerText;
           mLightName = pNode.Attributes["PRODUCT"].InnerText;
           mLightConstructor = pNode.Attributes["Constructor"].InnerText;
           mImage = pNode.Attributes["img"].InnerText;
           mStartAddress = Convert.ToInt32(pNode.Attributes["StartAddress"].InnerText);
           mPoursuit = new Poursuit();
           mLevel = pLevel;
           mPath = pPath + mName;

           if (pNode.ChildNodes != null && pNode.ChildNodes.Count != 0)
           {
               XmlNode ChannelNode = pNode.ChildNodes[0];
               foreach (XmlNode node in ChannelNode)
               {
                   Channels.RealChannel chan = new Channels.RealChannel(node, mStartAddress, pOutput, mPoursuit);
                   chan.Fixture = this;
                   this.mChannels.Add(chan);
               }
           }
           DetectPanTiltChannel();

           Framework.RealFixtureList.Add(this);
       }

       public RealFixture(string pConstructor, string pLightName)
           : base(null,FixtureType.Real)
       {

           DirectoryInfo Root = new DirectoryInfo(DmxFramework.Framework.FixtureDir);

           mFixtureFileName = Root.FullName + "\\" + pConstructor + "\\" + pLightName + "\\fixture.xml";
           if (File.Exists(mFixtureFileName))
           {

               XmlDocument doc = new XmlDocument();
               
               doc.Load(mFixtureFileName);

               mName = "";
               XmlNode FixNode = doc.ChildNodes[0].ChildNodes[0];
               mLightName = FixNode.Attributes["PRODUCT"].InnerText;
               mLightConstructor = FixNode.Attributes["Constructor"].InnerText;
               mImage = FixNode.Attributes["img"].InnerText;
               mPoursuit = null;
               mLevel = 0;
               mPath = mFixtureFileName;
               if (FixNode.ChildNodes != null && FixNode.ChildNodes.Count != 0)
               {
                   XmlNode ChannelNode = FixNode.ChildNodes[0];
                   foreach (XmlNode node in ChannelNode)
                   {
                       this.mChannels.Add(new Channels.RealChannel(node, 0, null, mPoursuit));
                   }
                   foreach (Channels.RealChannel chan in this.mChannels)
                   {
                       chan.Fixture = this;
                   }
               }
           }
           else
           {
               mLightConstructor = pConstructor;
               mLightName = pLightName;
               mImage = "";
           }
       }

        public RealFixture(string pFileName)
            : base(null, FixtureType.Real)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(pFileName);
            mName = "";
            XmlNode FixNode = doc.ChildNodes[0].ChildNodes[0];
            mLightName = FixNode.Attributes["PRODUCT"].InnerText;
            mLightConstructor = FixNode.Attributes["Constructor"].InnerText;
            mImage = FixNode.Attributes["img"].InnerText;
            mPoursuit = null;
            mLevel = 0;
            mPath = pFileName;
            if (FixNode.ChildNodes != null && FixNode.ChildNodes.Count != 0)
            {
                XmlNode ChannelNode = FixNode.ChildNodes[0];
                foreach (XmlNode node in ChannelNode)
                {
                    this.mChannels.Add(new Channels.RealChannel(node, 0, null, mPoursuit));
                }
            }
        }
        #endregion

        #region properties

        public string LightName
        {
            get { return mLightName; }
            set { mLightName = value; }
        }

        public string LightConstructor
        {
            get { return mLightConstructor; }
            set { mLightConstructor = value; }
        }

        public string Image
        {
            get {
                if (mImage != "" || mImage != null)
                    return "Fixtures\\"+mLightConstructor + "\\" + mLightName + "\\" + mImage;
                else
                    return "";
            }
            set { mImage = value; }
        }

       public Fixtures.Poursuit Poursuite
       {
           get { return mPoursuit; }
           set { mPoursuit = value; }
       }


        public bool ToSave
        {
            get { return mToSave; }
            set { mToSave = value; }
        }


       public int StartAddress
       {
           get { return mStartAddress; }
           set { mStartAddress = value; }
       }

        #endregion

       #region scenes methods

       internal override void LoadScene(XmlNode pNode)
       {
           if (pNode == null || pNode.ChildNodes == null || pNode.ChildNodes.Count == 0)
               return;

           foreach (XmlNode node in pNode.ChildNodes)
           {
               if (node.Name == "Poursuit")
                   mPoursuit.LoadXml(node);
               else if (node.Name == "Scenes")
                   mManager.Load(node);
               else if (node.Name == "ChanParameters")
                   LoadChanParameters(node);
               else if (node.Name == "Parameters")
               {
                    mNumAutoMode = Convert.ToInt16(node.Attributes["NumAutoMode"].InnerText);
                    XmlAttribute atr = node.Attributes.GetNamedItem("InvertPanInAutoMode") as XmlAttribute;
                   if(atr!=null && this.PanChannel!=null)
                   {
                       this.PanChannel.InvertedInAutoMode = Convert.ToBoolean(atr.InnerText);
                   }

                   atr = node.Attributes.GetNamedItem("InvertTiltInAutoMode") as XmlAttribute;
                   if (atr != null && this.PanChannel != null)
                   {
                       this.TiltChannel.InvertedInAutoMode = Convert.ToBoolean(atr.InnerText);
                   }

               }
           }

           //mPoursuit
           

           //parameters

           /*if(pNode.ChildNodes.Count > 1)
               mManager.Load(pNode.ChildNodes[1]);*/
       }

       internal override XmlNode GetSceneXml(XmlDocument pDocument)
       {
           XmlElement FixtureNode = pDocument.CreateElement("Fixture");
           XmlAttribute Attribute = pDocument.CreateAttribute("Name");
           Attribute.InnerText = mName;
           FixtureNode.Attributes.Append(Attribute);
           FixtureNode.AppendChild(mPoursuit.GetXml(pDocument));
           FixtureNode.AppendChild(mManager.GetXmlNode(pDocument));
           XmlElement Parameters = pDocument.CreateElement("ChanParameters");
           foreach(DmxFramework.Channels.RealChannel chan in mChannels)
               Parameters.AppendChild(chan.GetParametersXml(pDocument));

           FixtureNode.AppendChild(Parameters);

           XmlElement ParametersElement = pDocument.CreateElement("Parameters");
           Utils.Xml.AddAttribute(ParametersElement, pDocument, "NumAutoMode", mNumAutoMode.ToString());
           if(this.PanChannel != null)
                Utils.Xml.AddAttribute(ParametersElement, pDocument, "InvertPanInAutoMode", this.PanChannel.InvertedInAutoMode.ToString());
           if(this.TiltChannel!=null)
                Utils.Xml.AddAttribute(ParametersElement, pDocument, "InvertTiltInAutoMode", this.TiltChannel.InvertedInAutoMode.ToString());
           FixtureNode.AppendChild(ParametersElement);
           return FixtureNode;
       }

       #endregion

       
        #region internal override methods
       internal override Channels.Channel GetChannel(string pPath)
       {
           string[] tab = pPath.Split(new char[] { '/' });
           if (tab[0] != this.mName)
               return null;

           foreach (DmxFramework.Channels.Channel chan in mChannels)
           {
               if (chan.Name == tab[1])
                   return chan;
           }
           return null;
       }

        internal override Scene.Scene GetScene(string pPath)
        {
            string[] tab = pPath.Split(new char[] { '/' });
            if (tab[0] != this.mName)
                return null;

            foreach (DmxFramework.Scene.Scene scene in mManager.Scenes)
            {
                if (scene.Category == tab[1] && scene.Name == tab[2])
                    return scene;
            }
            return null;
        }

       internal override void Exit()
       {
           this.mManager.Exit();
       }
#endregion


        #region save Fixture ....

        public void Save()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<PimpMyLightFixture></PimpMyLightFixture>");

            XmlNode FixElement = Save(doc);

            doc.DocumentElement.AppendChild(FixElement);
            doc.Save(mFixtureFileName);
            ToSave = true;
        }

        public override XmlNode Save(XmlDocument pDocument)
        {
            XmlElement FixElement = pDocument.CreateElement("Fixture");

            FixElement.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "Constructor", this.mLightConstructor));
            FixElement.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "PRODUCT", this.mLightName));
            FixElement.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "img", this.mImage));
            FixElement.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "Name", this.mName));
            FixElement.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "StartAddress", this.mStartAddress+""));
            FixElement.Attributes.Append(Utils.Xml.GetAttribute(pDocument, "Type", this.mType.ToString()));


            XmlElement XmlChanElement = pDocument.CreateElement("Channels");

            foreach (DmxFramework.Channels.RealChannel channel in this.mChannels)
                XmlChanElement.AppendChild(channel.Save(pDocument));

            FixElement.AppendChild(XmlChanElement);
            return FixElement;
        }


        #endregion


        public override void RefreshFixture(RealFixture pFixture)
        {
            int i =0;
            bool found = false;
            if (pFixture.LightConstructor != this.mLightConstructor || pFixture.LightName != this.mLightName)
                return;

            foreach (DmxFramework.Channels.RealChannel ThisChan in this.Channels)
            {
                found = false;
                foreach (DmxFramework.Channels.RealChannel pChan in pFixture.Channels)
                {
                    if (ThisChan.Name == pChan.Name)
                    {
                        ThisChan.RefreshChannel(pChan);
                        found = true;
                        break;
                    }
                }
                if(!found)
                    //here, no chan found. destroy channel ...
                    this.Channels.Remove(ThisChan);
            }
            i = 0;
            foreach (DmxFramework.Channels.RealChannel pChan in pFixture.Channels)
            {
                found = false;
                foreach (DmxFramework.Channels.RealChannel ThisChan in this.Channels)
                {
                    if (ThisChan.Name == pChan.Name)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    //here, no chan found. add channel ...
                    this.Channels.Insert(i, pChan);
                i++;
            }


        }

        void LoadChanParameters(XmlNode pNode)
        {
            foreach (XmlNode node in pNode)
            {
                DmxFramework.Channels.RealChannel chan = (DmxFramework.Channels.RealChannel)GetChannelByName(node.Attributes["Name"].InnerText);
                if(chan==null)
                    continue;

                chan.LoadParameters(node);
            }
        }


        public override List<DmxFramework.Channels.Channel> GetAllRealChannels()
        {
            return mChannels;
        }

        public override List<string> GetAllRealChannelsName()
        {
            List<string> lst = new List<string>();
            foreach (DmxFramework.Channels.Channel chan in mChannels)
            {
                lst.Add(this.Name + "/" + chan.Name);
            }
            return lst;
        }

   }
}
