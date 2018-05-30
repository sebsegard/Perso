using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DmxFramework.Workspace
{
    public class Workspace
    {
        string mName;
        DirectoryInfo mDir;

        string mFrameworkFile;
        string mSceneFile;

        public Workspace(DirectoryInfo pDir)
        {
            mName = pDir.Name;
            mDir = pDir;

            mFrameworkFile = mDir.FullName + "/"+Constant.FrameworkName;
            mSceneFile = mDir.FullName + "/"+Constant.SceneName; 
        }

        public Workspace(string pName)
        {
            mName = pName;

            mDir = new DirectoryInfo(Constant.WorkspaceDir + "/" + mName);
            if (!mDir.Exists)
                mDir.Create();
            

            mFrameworkFile = mDir.FullName + "/" + Constant.FrameworkName;
            mSceneFile = mDir.FullName + "/" + Constant.SceneName;
        }

        public string Name
        {
            get { return mName; }
        }

        public void Load()
        {
            //The loading cinsis in the replacement of framework and scene files
            //string mFrame
            if (File.Exists(mFrameworkFile))
            {
                File.Copy(mFrameworkFile, Constant.FrameworkName, true);
            }
            else
                File.Delete(Constant.FrameworkName);

            if (File.Exists(mSceneFile))
            {
                File.Copy(mFrameworkFile, Constant.SceneName, true);
            }
            else
                File.Delete(Constant.SceneName);

            if (File.Exists(Constant.ScreenConfigurationFile))
                File.Delete(Constant.ScreenConfigurationFile);
        }

        public void Save()
        {
            //The loading cinsis in the replacement of framework and scene files
            if(File.Exists(Constant.FrameworkName))
                File.Copy(Constant.FrameworkName, mFrameworkFile, true);
            if (File.Exists(Constant.SceneName))
                File.Copy(Constant.SceneName, mSceneFile, true);
        }

        public override string ToString()
        {
            return mName;
        }


    }
}
