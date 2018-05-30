using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DmxFramework.Fixtures
{
    public class VirtualFixture : Fixture
    {
        private ArrayList mSubFixture;

        #region constructors

        public VirtualFixture():base(null,FixtureType.Virtual)
        {
            mSubFixture = new ArrayList();
        }

        public VirtualFixture(string pName)
            : base(null, FixtureType.Virtual)
        {
            mSubFixture = new ArrayList();
            this.mName = pName;
        }

        public VirtualFixture(Fixture pParent,XmlNode pnode, DmxOutput pOutput, int pLevel, string pPath)
            : base(pParent,FixtureType.Virtual)
        {
            mLevel = pLevel;
            mSubFixture = new ArrayList();
            LoadFromXml(pnode, pOutput, pLevel + 1, pPath);
            DetectPanTiltChannel();
        }

        #endregion

      
        #region properties

        public ArrayList SubFixture
        {
            get { return mSubFixture; }
        }

        #endregion


        #region XML

        private void LoadFromXml(XmlNode pNode, DmxOutput pOutput, int pLevel, string pPath)
        {
            this.Name = pNode.Attributes["Name"].Value;
            mPath = pPath + mName;
            LoadSubFixtureXml(pNode.SelectSingleNode("SubFixtures"), pOutput, pLevel);
            LoadChannelsXml(pNode.SelectSingleNode("Channels"));
        }

        private void LoadSubFixtureXml(XmlNode pNode, DmxOutput pOutput, int pLevel)
        {
            if (pNode == null)
                return;

            foreach (XmlNode node in pNode.ChildNodes)
            {
                if(Fixture.GetTypeFromXmlNode(node) == FixtureType.Virtual)
                    mSubFixture.Add(new VirtualFixture(this, node, pOutput, pLevel, mPath + "/"));
                else
                    mSubFixture.Add(new RealFixture(this, node, pOutput, pLevel, mPath + "/"));
            }

        }

        private void LoadChannelsXml(XmlNode pNode)
        {
            if (pNode == null)
                return;
            
            foreach (XmlNode node in pNode.ChildNodes)
            {
                Channels.VirtualChannel chan = new Channels.VirtualChannel(node, mSubFixture);
                chan.Fixture = this;
                mChannels.Add(chan);
            }
        }

        #endregion


        internal override void LoadScene(XmlNode pNode)
        {
            foreach(XmlNode node in pNode.ChildNodes)
            {
                if (node.Name == "SubFixture")
                {
                    foreach (XmlNode Fixturenode in node.ChildNodes)
                    {
                        foreach (Fixture fix in this.mSubFixture)
                        {
                            if (fix.Name == Fixturenode.Attributes["Name"].InnerText)
                            {
                                fix.LoadScene(Fixturenode);
                                continue;
                            }
                        }
                    }
                }
                else if (node.Name == "Parameters")
                {
                    mNumAutoMode = Convert.ToInt16(node.Attributes["NumAutoMode"].InnerText);
                    XmlAttribute atr = node.Attributes.GetNamedItem("InvertPanInAutoMode") as XmlAttribute;
                    if (atr != null && this.PanChannel != null)
                    {
                        this.PanChannel.InvertedInAutoMode = Convert.ToBoolean(atr.InnerText);
                    }

                    atr = node.Attributes.GetNamedItem("InvertTiltInAutoMode") as XmlAttribute;
                    if (atr != null && this.PanChannel != null)
                    {
                        this.TiltChannel.InvertedInAutoMode = Convert.ToBoolean(atr.InnerText);
                    }
                }
                else
                {
                    mManager.Load(node);
                }
            }
        }



        internal override XmlNode GetSceneXml(XmlDocument pDocument)
        {
            XmlElement FixtureNode = pDocument.CreateElement("Fixture");
            XmlAttribute Attribute = pDocument.CreateAttribute("Name");
            Attribute.InnerText = mName;
            FixtureNode.Attributes.Append(Attribute);

            XmlElement SubFixtureElement = pDocument.CreateElement("SubFixture");
            foreach (Fixture fix in mSubFixture)
                SubFixtureElement.AppendChild(fix.GetSceneXml(pDocument));

            XmlElement ParametersElement = pDocument.CreateElement("Parameters");
            Utils.Xml.AddAttribute(ParametersElement, pDocument, "NumAutoMode", mNumAutoMode.ToString());
            if (this.PanChannel != null)
                Utils.Xml.AddAttribute(ParametersElement, pDocument, "InvertPanInAutoMode", this.PanChannel.InvertedInAutoMode.ToString());
            if (this.TiltChannel != null)
                Utils.Xml.AddAttribute(ParametersElement, pDocument, "InvertTiltInAutoMode", this.TiltChannel.InvertedInAutoMode.ToString());
            FixtureNode.AppendChild(ParametersElement);

            FixtureNode.AppendChild(SubFixtureElement);

            FixtureNode.AppendChild(mManager.GetXmlNode(pDocument));

            return FixtureNode;
        }

        internal override Channels.Channel GetChannel(string pPath)
        {
            string[] tab = pPath.Split(new char[] { '/' });
            
            if (tab[0] != this.mName)
                return null;

            if (tab.Length > 2)
            {
                string subpath = "";
                for (int i = 1; i < tab.Length; i++)
                {
                    if (i != 1)
                        subpath += "/";
                    subpath +=  tab[i];
                    
                }
                foreach(Fixture fix in this.mSubFixture)
                {
                    if(fix.Name==tab[1])
                        return fix.GetChannel(subpath);
                }
            }
            else
            {
                foreach (DmxFramework.Channels.Channel chan in mChannels)
                {
                    if (chan.Name == tab[1])
                        return chan;
                }
            }
            return null;
        }


        internal override Scene.Scene GetScene(string pPath)
        {
            string[] tab = pPath.Split(new char[] { '/' });

            if (tab[0] != this.mName)
                return null;

            if (tab.Length > 3)
            {
                string subpath = "";
                for (int i = 1; i < tab.Length; i++)
                {
                    if (i != 1)
                        subpath += "/";
                    subpath += tab[i];

                }
                foreach (Fixture fix in this.mSubFixture)
                {
                    if (fix.Name == tab[1])
                        return fix.GetScene(subpath);
                }
            }
            else
            {
                foreach (DmxFramework.Scene.Scene scene in mManager.Scenes)
                {
                    if (scene.Category == tab[1] && scene.Name == tab[2])
                        return scene;
                }
            }
            return null;
        }
        

        internal override void UnforceAllChannels()
        {
            foreach (Fixture fix in this.mSubFixture)
                fix.UnforceAllChannels();
            
            foreach (DmxFramework.Channels.Channel chan in mChannels)
                chan.UnforceValue();
        }

        internal Fixture GetFixtureFromPath(string pPath)
        {
            if (pPath == mPath)
                return this;

            foreach (Fixture fix in mSubFixture)
            {
                if (fix.Type == FixtureType.Real && fix.Path == pPath)
                    return fix;
                else if(fix.Type == FixtureType.Virtual)
                {
                    Fixture FixToReturn = ((VirtualFixture)fix).GetFixtureFromPath(pPath);
                    if (FixToReturn != null)
                        return FixToReturn;
                }
            }
            return null;
        }

        internal override void Exit()
        {
            this.mManager.Exit();
            foreach (Fixture fix in mSubFixture)
                fix.Exit();
        }


        public void RemoveFixture(Fixture pFixture)
        {
            //on vire l'ensemble des sub fixtures ...
            if (pFixture.Type == FixtureType.Virtual)
                foreach (Fixture fix in ((VirtualFixture)pFixture).SubFixture)
                    ((VirtualFixture)pFixture).RemoveFixture(fix);

            
            //on l'enleve de la liste des fixtures de la virtual fixture...
            mSubFixture.Remove(pFixture);

            //si c'est un reel, on l'enleve de la liste des fixture reels
            if (pFixture.Type == FixtureType.Real)
                DmxFramework.Framework.RealFixtureList.Remove((RealFixture)pFixture);

            //on vire le scene manager ...
            if (pFixture.Manager != null && this.mManager != null && this.mManager.SubSceneManager!=null)
                this.mManager.SubSceneManager.Remove(pFixture.Manager);

            foreach (DmxFramework.Channels.VirtualChannel chan in this.Channels)
            {
                chan.RemoveFixture(pFixture);
            }
        }

        public void AddFixture(Fixture pFixture)
        {
            mSubFixture.Add(pFixture);
            pFixture.Parent = this;

            if (pFixture.Type == FixtureType.Real)
                DmxFramework.Framework.RealFixtureList.Add((RealFixture)pFixture);
        }

        public override XmlNode Save(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement("Fixture");

            Utils.Xml.AddAttribute(Element, pDocument,"Name", this.Name);
            Utils.Xml.AddAttribute(Element, pDocument, "Type", FixtureType.Virtual.ToString());

            XmlElement SubFixElement = pDocument.CreateElement("SubFixtures");
            foreach (Fixture fix in mSubFixture)
                SubFixElement.AppendChild(fix.Save(pDocument));
            Element.AppendChild(SubFixElement);

            XmlElement ChanElement = pDocument.CreateElement("Channels");
            foreach (DmxFramework.Channels.Channel chan in mChannels)
                ChanElement.AppendChild(chan.Save(pDocument));
            Element.AppendChild(ChanElement);


            return Element;
        }

        public override void RefreshFixture(RealFixture pFixture)
        {
            foreach (Fixture fix in mSubFixture)
                fix.RefreshFixture(pFixture);
        }


        public override List<DmxFramework.Channels.Channel> GetAllRealChannels()
        {
            List<DmxFramework.Channels.Channel> chan = new List<DmxFramework.Channels.Channel>();
            foreach (Fixture fix in mSubFixture)
                chan.AddRange(fix.GetAllRealChannels());
            return chan;
        }

        public override List<string> GetAllRealChannelsName()
        {
            List<string> lst = new List<string>();
            foreach (Fixture fix in mSubFixture)
                lst.AddRange(fix.GetAllRealChannelsName());

            for (int i = 0; i < lst.Count; i++)
                lst[i] = this.Name + "/" + lst[i];

            return lst;
        }
    }
}
