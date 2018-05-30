using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DmxFramework.Midi.Action
{
    public delegate void OnBcfActionListDescriptionChangedEvent(BcfActionList pActionList,string pDescription);
    
    public class BcfActionList
    {
        #region Private members

        List<Action> mActionList;
        string mDescription;
        BcfAction mBcfAction;
        Device mDevice;
        int mModeIndex;
        #endregion

        public event OnBcfActionListDescriptionChangedEvent OnActionListDescriptionChanged = null;

        #region Constructor

        public BcfActionList(BcfAction pAction, int Modeindex)
        {
            mBcfAction = pAction;
            mActionList = new List<Action>();
            mModeIndex = Modeindex;
        }

        public BcfActionList(BcfAction pAction, Device pDevice)
        {
            mBcfAction = pAction;

            mActionList = new List<Action>();
            mDevice = pDevice;
        }

       // public string Description { get; set; }


        internal BcfActionList(BcfAction pAction, Device pDevice, XmlNode pElement, int Modeindex)
        {
            mBcfAction = pAction;
            mDevice = pDevice;
            mDescription = pElement.Attributes["Description"].InnerText;
            mActionList = new List<Action>();
            mModeIndex = Modeindex;
            foreach (XmlNode node in pElement.ChildNodes)
            {
                try
                {
                    if (node.Name == ChangeDmxValue.XmlElementName)
                    {
                        Action act = new ChangeDmxValue(node);
                        act.OnNewValueToSend += new OnNewValueToSendEvent(act_OnNewValueToSend);
                        mActionList.Add(act);
                    }
                    else if (node.Name == SceneMidiPlayer.XmlElementName)
                    {
                        Action act = new SceneMidiPlayer(node);
                        act.OnNewValueToSend += new OnNewValueToSendEvent(act_OnNewValueToSend);
                        mActionList.Add(act);
                    }
                    else if (node.Name == AutoPress.XmlElementName)
                    {

                        
                            Action act = new AutoPress(node);
                            act.OnNewValueToSend += new OnNewValueToSendEvent(act_OnNewValueToSend);
                            mActionList.Add(act);
                       
                    }
                    else if (node.Name == AutoSpeed.XmlElementName)
                    {
                        Action act = new AutoSpeed(node);
                        act.OnNewValueToSend += new OnNewValueToSendEvent(act_OnNewValueToSend);
                        mActionList.Add(act);
                    }
                    else if (node.Name == SceneSpeed.XmlElementName)
                    {
                        Action act = new SceneSpeed(node);
                        //act.OnNewValueToSend += new OnNewValueToSendEvent(act_OnNewValueToSend);
                        mActionList.Add(act);
                    }

                }
                catch { }
            }
        }

        
        #endregion


        #region Properties

        
       
        
        public string Description
        {
            get { return mDescription; }
            set { 
                mDescription = value;

                if (OnActionListDescriptionChanged != null)
                    OnActionListDescriptionChanged(this,mDescription);
            }
        }

        

        public List<Action> Actions
        {
            get { return mActionList; }
            set { mActionList = value; }
        }
        #endregion



        #region Public methods

        internal void Recieve(int pValue)
        {
            for (int i = 0; i < mActionList.Count; i++)
                mActionList[i].Receive(pValue);
        }

        internal XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement ListElement = pDocument.CreateElement("ActionList");

            Utils.Xml.AddAttribute(ListElement, pDocument, "Description", mDescription);


            for (int i = 0; i < mActionList.Count; i++)
            {
                try
                {
                    XmlElement ele = mActionList[i].GetXml(pDocument);
                    if (ele != null)
                        ListElement.AppendChild(ele);
                }
                catch { }
            }

            return ListElement;
        }
        
        void act_OnNewValueToSend(int pValue)
        {
            if (mBcfAction.Device!=null && mModeIndex == Bcf2000.CurrentMode)
                mBcfAction.Device.SendValue(mBcfAction.Command, mBcfAction.MidiChannel, mBcfAction.Data1, pValue);
        } 

        #endregion
    }
}
