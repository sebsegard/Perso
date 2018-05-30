using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DmxFramework.Midi.Action
{
    public delegate void OnActionListDescriptionChangedEvent(ActionList pActionList,string pDescription);

    public class ActionList
    {
        #region Private members

        List<Action> mActionList;
        string mDescription;

        private Device mDevice;

        private string mKey;
        private string mDeviceName;
        private string mCommand;
        private int mMidiChannel;
        private int mData1;

        #endregion

        public event OnActionListDescriptionChangedEvent OnActionListDescriptionChanged = null;

        #region Constructor

        public ActionList(string pDeviceName, string pCommand, int pMidiChannel, int pData1)
        {
            mDeviceName = pDeviceName;
            mCommand = pCommand;
            mMidiChannel = pMidiChannel;
            mData1 = pData1;
            mKey = Action.GetKey(mDeviceName, mCommand, mMidiChannel, mData1);
            mDescription = "";
            mActionList = new List<Action>();
        }

        internal ActionList(XmlNode pElement)
        {
            mDeviceName = pElement.Attributes["DeviceName"].InnerText;
            mCommand = pElement.Attributes["Command"].InnerText;
            mMidiChannel = Convert.ToInt32(pElement.Attributes["MidiChannel"].InnerText);
            mData1 = Convert.ToInt32(pElement.Attributes["Data1"].InnerText);
            mKey = Action.GetKey(mDeviceName, mCommand, mMidiChannel, mData1);
            mDescription = pElement.Attributes["Description"].InnerText;
            mActionList = new List<Action>();

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

                }
                catch { }
            }
        }

        
        #endregion


        #region Properties

        public Device Device
        {
            get { return mDevice; }
            set { mDevice = value; }
        }

        public string DeviceName
        {
            get { return mDeviceName; }
        }

        public string Command
        {
            get { return mCommand; }
        }

        public int MidiChannel
        {
            get { return mMidiChannel; }
        }

        public int Data1
        {
            get { return mData1; }
        }

        public string Description
        {
            get { return mDescription; }
            set { 
                mDescription = value;

                if (OnActionListDescriptionChanged != null)
                    OnActionListDescriptionChanged(this,mDescription);
            }
        }

        public string Key
        {
            get { return mKey; }
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

            Utils.Xml.AddAttribute(ListElement, pDocument, "DeviceName", mDeviceName);
            Utils.Xml.AddAttribute(ListElement, pDocument, "Command", mCommand);
            Utils.Xml.AddAttribute(ListElement, pDocument, "MidiChannel", mMidiChannel.ToString());
            Utils.Xml.AddAttribute(ListElement, pDocument, "Data1", mData1.ToString());
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
            if (mDevice != null)
                mDevice.SendValue(mCommand, mMidiChannel, mData1, pValue);
        } 

        #endregion
    }
}
