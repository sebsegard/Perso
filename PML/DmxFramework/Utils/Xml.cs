using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace DmxFramework.Utils
{
    class Xml
    {
        public static XmlAttribute GetAttribute(XmlDocument pDocument, string pName, string pValue)
        {
            XmlAttribute attr = pDocument.CreateAttribute(pName);
            attr.InnerText = pValue;
            return attr;
        }

        public static void AddAttribute(XmlElement pELement,XmlDocument pDocument, string pName, string pValue)
        {
            pELement.Attributes.Append(GetAttribute(pDocument,pName,pValue));
        }

        public static void AddAttribute(XmlElement pELement, XmlDocument pDocument, string pName, int pValue)
        {
            pELement.Attributes.Append(GetAttribute(pDocument, pName, pValue.ToString()));
        }

        public static int GetInt16(XmlNode pElement, string pName)
        {
            return Convert.ToInt32(pElement.Attributes[pName].InnerText);
        }
    }
}
