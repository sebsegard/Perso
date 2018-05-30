using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace DmxFramework.Workspace
{
    public class Manager
    {
        
        
        private Workspace mCurrentWorkspace;
        
        public Manager()
        {

        }

        public Workspace CurrentWorkspace
        {
            get { return mCurrentWorkspace; }
        }

        public void SetCurrentWorkspace(XmlNode pNode)
        {
            if (pNode == null)
                return;

            string wkpName = pNode.Attributes["Name"].InnerText;

            List<Workspace> lst = GetWorkspaceList();
            foreach (Workspace wkp in lst)
            {
                if (wkp.Name == wkpName)
                {
                    mCurrentWorkspace = wkp;
                    break;
                }
            }
        }
        
        public static List<Workspace> GetWorkspaceList()
        {
            List<Workspace> workspaces = new List<Workspace>();
            DirectoryInfo inf = new DirectoryInfo(Constant.WorkspaceDir);
            DirectoryInfo[] wkpDir = inf.GetDirectories();
            foreach (DirectoryInfo dir in wkpDir)
            {
                workspaces.Add(new Workspace(dir));
            }
            return workspaces;
        }

        public void Load(Workspace pWorkspace)
        { 
            mCurrentWorkspace = pWorkspace;
            mCurrentWorkspace.Load();
        }

        public void SaveAs(Workspace pWorkspace)
        {
            mCurrentWorkspace = pWorkspace;
            mCurrentWorkspace.Save();
        }

        public XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement ManagerElement = pDocument.CreateElement(Constant.WorkspaceXmlNodeName);
            Utils.Xml.AddAttribute(ManagerElement, pDocument, "Name", mCurrentWorkspace.Name);
            return ManagerElement;
        }

        

        
    }
}
