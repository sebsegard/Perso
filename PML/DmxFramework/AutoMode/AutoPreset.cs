using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DmxFramework.AutoMode
{
    public class AutoPreset
    {
        #region members

        int mTime = 1000;
        bool mProgressive = false;

        #endregion

        #region constructor

        public AutoPreset()
        {

        }

        #endregion

        #region properties

        public int Time
        {
            get { return mTime; }
            set { mTime = value; }
        }

        public bool Progressive
        {
            get { return mProgressive; }
            set { mProgressive = value; }
        }

        #endregion

        #region xmlMethods
       
        public void LoadXml(XmlNode pNode)
        {
            mTime = Convert.ToInt16(pNode.Attributes["Time"].InnerText);
            mProgressive = Convert.ToBoolean(pNode.Attributes["Progressive"].InnerText);
        }

        public XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement Element = pDocument.CreateElement("AutoPreset");
            Utils.Xml.AddAttribute(Element, pDocument, "Time", mTime.ToString());
            Utils.Xml.AddAttribute(Element, pDocument, "Progressive", mProgressive.ToString());
            return Element;
        }

        #endregion

    }
}
