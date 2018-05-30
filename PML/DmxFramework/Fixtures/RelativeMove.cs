using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DmxFramework.Fixtures
{
    /// <summary>
    /// TYpe of fixture
    /// </summary>
    public enum FixtureType
    {
        /// <summary>
        /// Virtual fixture : group of fixtures
        /// </summary>
        Virtual,

        /// <summary>
        /// Real fixture 
        /// </summary>
        Real
    }
    
    public abstract class Fixture
    {
        #region members

        protected ArrayList  mChannels;
        protected FixtureType mType;
        protected string mName;
        protected Scene.SceneManager mManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pType"></param>
        public Fixture(FixtureType pType)
        {
            mManager = new DmxFramework.Scene.SceneManager();
            mManager.Fixture = this;
            mName = "";
            mType = pType;
            mChannels = new ArrayList();
        }

        #endregion


        #region properties
        /// <summary>
        /// Fixture Name
        /// </summary>
        public string Name
        {
            set { mName = value; }
            get { return mName; }
        }

        /// <summary>
        /// Scene manager
        /// </summary>
        public Scene.SceneManager Manager
        {
            set { mManager = value; }
            get { return mManager; }
        }

        /// <summary>
        /// Type of fixture (real or virtual)
        /// </summary>
        public FixtureType Type
        {
            get { return mType; }
        }

        /// <summary>
        /// Type of fixture (real or virtual)
        /// </summary>
        public ArrayList Channels
        {
            get { return mChannels; }
        }

        #endregion

        #region Overloaded methods

        public override string ToString()
        {
            return mName ;
        }

        #endregion


        #region static methods
        public static FixtureType GetTypeFromXmlNode(XmlNode pNode)
        {
            string Type = pNode.Attributes["Type"].InnerText;
            if (Type == FixtureType.Real.ToString())
                return FixtureType.Real;
            else
                return FixtureType.Virtual;
        }

        #endregion


        internal abstract void LoadScene(XmlNode pNode);

        internal abstract XmlNode GetSceneXml(XmlDocument pDocument);

        //internal abstract void SaveScene(XmlDocument pDocument, );


        internal abstract Channels.Channel GetChannel(string pPath);
    }
}
