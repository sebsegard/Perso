using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;



namespace DmxFramework
{
    public class Framework
    {
        public const int Tick = 30;
        public const string FixtureDir = "Fixtures";
        public const string WorskspaceDir = "Worskspace";
       
       
        DmxOutput mOutput;
        Keyboard.KeyBord mKeyBord;
        public static bool InvertChannelsInAutoMode = false;

        public static Fixtures.VirtualFixture Fixtures;
        public static Sound.MusicMode MusicMode = new DmxFramework.Sound.MusicMode();
        public static List<AutoMode.AutoMode> AutomaticMode = new List<AutoMode.AutoMode>();
        public static Random random = new Random();
        public static List<DmxFramework.Fixtures.RealFixture> RealFixtureList = new List<DmxFramework.Fixtures.RealFixture>();
        public static Workspace.Manager WorkspaceManager = new DmxFramework.Workspace.Manager();
        public static Midi.Driver MidiDriver = new DmxFramework.Midi.Driver();
        public static Midi.BcfDriver BcfDriver = new DmxFramework.Midi.BcfDriver();
        public static Keyboard.KeyBord KeyBord = new DmxFramework.Keyboard.KeyBord();
        public static Midi.Bcf2000 Bcf2000 = new DmxFramework.Midi.Bcf2000();

        public Framework()
        {
            mOutput = new DmxOutput();
        }

        /*public void StartKeybordListening()
        {
            mKeyBord = new Keyboard.KeyBord();
        }*/

        public void StartDmxDevice()
        {
           
            //mOutput.Interfaces[0].IsActive = true;
        }

        public  void LoadXml()
        {
            RealFixtureList.Clear();
            Fixtures = null;

            if (File.Exists(Constant.FrameworkName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Framework.xml");

                XmlNode WorkSpaceNode = (doc.GetElementsByTagName(Constant.WorkspaceXmlNodeName))[0];
                WorkspaceManager.SetCurrentWorkspace(WorkSpaceNode);

                XmlNode ParameterNode = (doc.GetElementsByTagName("Parameters"))[0];

                if (ParameterNode.Attributes["Device"] != null)
                    this.mOutput.SetActiveDevice(ParameterNode.Attributes["Device"].InnerText);
                this.mOutput.SetNbChannels(Convert.ToInt32(ParameterNode.Attributes["MaxRealCanal"].InnerText));


                XmlNode FixtureNode = (doc.GetElementsByTagName("Fixture"))[0];
                Fixtures = new DmxFramework.Fixtures.VirtualFixture(null, FixtureNode, mOutput, 0, "");
            }
            else
            {
                if(WorkspaceManager.CurrentWorkspace != null)
                    Fixtures = new DmxFramework.Fixtures.VirtualFixture(WorkspaceManager.CurrentWorkspace.Name);
            }
        }

        

        public void LoadScenes()
        {
            XmlDocument doc = new XmlDocument();
            if (!System.IO.File.Exists(Constant.SceneName))
            {
                //no scene : add at least one automatic mode
                AutomaticMode.Add(new DmxFramework.AutoMode.AutoMode());
                return;
            }

            doc.Load(Constant.SceneName);

      
            XmlNode FixtureNode = (doc.GetElementsByTagName("Fixture"))[0];
            Fixtures.LoadScene(FixtureNode);


            XmlNode KeyBordNode = (doc.GetElementsByTagName("Keyboard"))[0];
            if(KeyBordNode!=null && KeyBord!=null)
                KeyBord.LoadXml(Fixtures,KeyBordNode);

            XmlNode AutoNode = (doc.GetElementsByTagName("AutoMode"))[0];
            if (AutoNode != null)
            {
                foreach (XmlNode node in AutoNode.ChildNodes)
                {
                    AutomaticMode.Add(new DmxFramework.AutoMode.AutoMode(node));
                }
            }
            else
                AutomaticMode.Add(new DmxFramework.AutoMode.AutoMode());

            XmlNode SnapNode = (doc.GetElementsByTagName("Snapshots"))[0];
            if (SnapNode != null)
                Channels.SnapShot.LoadXml(SnapNode);

            //XmlNode MidiNode = (doc.GetElementsByTagName(Constant.MidiXmlNodeName))[0];
            //if (MidiNode != null)
            //    MidiDriver.LoadXml(MidiNode);

            XmlNode BcfNode = (doc.GetElementsByTagName(Constant.BcfXmlNodeName))[0];
            if (BcfNode != null)
                Bcf2000.LoadXml(BcfNode);

        }


        /*public Fixtures.VirtualFixture Fixtures
        {
            get { return mFixtures; }
        }*/

        public DmxOutput Outputs
        {
            get { return mOutput; }
        }

        /*public Keyboard.KeyBord KeyBord
        {
            get { return mKeyBord; }
        }*/

        public void Exit()
        {
            try
            {
                this.mOutput.Disconnect();
            }
            catch{}

            try
            {
                MusicMode.StopAll();
                for(int i =0; i< AutomaticMode.Count; i++)
                    AutomaticMode[i].StopAll();
            }catch{}

            try
            {
                SaveScene();
            }catch{}

            try
            {
                Fixtures.Exit();
            }
            catch { }

            try { MidiDriver.StopAll(); }
            catch { }

            try { Bcf2000.StopAll(); }
            catch { }
           
        }

        public void SaveScene()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<PimpMyScenes></PimpMyScenes>");


            doc.DocumentElement.AppendChild(Fixtures.GetSceneXml(doc));
            doc.DocumentElement.AppendChild(KeyBord.GetXml(doc));

            XmlElement AutoElement = doc.CreateElement("AutoMode");
            for (int i = 0; i < AutomaticMode.Count; i++)
                AutoElement.AppendChild(AutomaticMode[i].GetXMl(doc));
            doc.DocumentElement.AppendChild(AutoElement);

            doc.DocumentElement.AppendChild(Channels.SnapShot.GetXml(doc));

            doc.DocumentElement.AppendChild(MidiDriver.GetXml(doc));
            doc.DocumentElement.AppendChild(Bcf2000.GetXml(doc));
            
            doc.Save("Scene.xml");
        }



        public Fixtures.Fixture GetFixtureFromPath(string pPath)
        {
            return Fixtures.GetFixtureFromPath(pPath);
        }

        public void SaveFramework()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<DmxFramework></DmxFramework>");

            doc.DocumentElement.AppendChild(WorkspaceManager.GetXml(doc));
            XmlElement ParamElement = doc.CreateElement("Parameters");
            Utils.Xml.AddAttribute(ParamElement, doc, "MaxRealCanal", "170");
            doc.DocumentElement.AppendChild(ParamElement);
            doc.DocumentElement.AppendChild(Fixtures.Save(doc));

            doc.Save("Framework.xml");
            WorkspaceManager.CurrentWorkspace.Save();
        }

        public void SaveFrameworkAs(string pText)
        {
            SaveFramework();
            Workspace.Workspace wkp= new DmxFramework.Workspace.Workspace(pText);
            WorkspaceManager.SaveAs(wkp);
        }

        public void OpenWorkspace(Workspace.Workspace pWorkspace)
        {
            WorkspaceManager.Load(pWorkspace);
        }



        
    }
}
