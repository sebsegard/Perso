using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DmxFramework.Midi.Action
{
    //public delegate void OnActionListDescriptionChangedEvent(ActionList pActionList, string pDescription);

    public class BcfAction
    {
        #region Private members

        List<BcfActionList> mActionList;
        string mDescription;

        private Device mDevice;

        private string mKey;
        private string mDeviceName;
        private string mCommand;
        private int mMidiChannel;
        private int mData1;

        #endregion

       // public event OnActionListDescriptionChangedEvent OnActionListDescriptionChanged = null;

        #region Constructor

        public BcfAction()
        {

            mActionList = new List<BcfActionList>();
        }

        public BcfActionList CurrentActionList { get { return mActionList[Bcf2000.CurrentMode]; } }

        public BcfAction(string pDeviceName, string pCommand, int pMidiChannel, int pData1)
        {
            mDeviceName = pDeviceName;
            mCommand = pCommand;
            mMidiChannel = pMidiChannel;
            mData1 = pData1;
            mKey = Action.GetKey(mDeviceName, mCommand, mMidiChannel, mData1);
            mActionList = new List<BcfActionList>();
            //mActionList.Add(new BcfActionList(this,));
        }

        internal BcfAction(XmlNode pElement)
        {
            mDeviceName = pElement.Attributes["DeviceName"].InnerText;
            mCommand = pElement.Attributes["Command"].InnerText;
            mMidiChannel = Convert.ToInt32(pElement.Attributes["MidiChannel"].InnerText);
            mData1 = Convert.ToInt32(pElement.Attributes["Data1"].InnerText);
            mKey = Action.GetKey(mDeviceName, mCommand, mMidiChannel, mData1);

            mActionList = new List<BcfActionList>();

            int i = 0;
            foreach (XmlNode node in pElement.ChildNodes)
            {
                mActionList[i] = new BcfActionList(this, this.Device, node, i);
                i++;
            }
        }

        public void SetMidiConfiguration(string pDeviceName, string pCommand, int pMidiChannel, int pData1)
        {
            string oldestKey = "";
            if(!string.IsNullOrEmpty(mKey))
                oldestKey=  String.Copy(mKey);
            
          
            
            mDeviceName = pDeviceName;
            mCommand = pCommand;
            mMidiChannel = pMidiChannel;
            mData1 = pData1;
            mKey = Action.GetKey(mDeviceName, mCommand, mMidiChannel, mData1);

            Framework.Bcf2000.ChangeKey(oldestKey, this);

           
        }

        internal void LoadXml(XmlNode pElement)
        {
            mDeviceName = pElement.Attributes["DeviceName"].InnerText;
            mCommand = pElement.Attributes["Command"].InnerText;
            mMidiChannel = Convert.ToInt32(pElement.Attributes["MidiChannel"].InnerText);
            mData1 = Convert.ToInt32(pElement.Attributes["Data1"].InnerText);
            mKey = Action.GetKey(mDeviceName, mCommand, mMidiChannel, mData1);

            /*mActionList = new List<BcfActionList>();

            foreach (XmlNode node in pElement.ChildNodes)
            {
                mActionList.Add(new BcfActionList(this, this.Device, node));

            }*/
            int i=0;
            foreach (XmlNode node in pElement.ChildNodes)
            {
                mActionList[i] = new BcfActionList(this, this.Device, node,i);
                i++;
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



        public string Key
        {
            get { return mKey; }
        }

        public List<BcfActionList> Actions
        {
            get { return mActionList; }
            set { mActionList = value; }
        }
        #endregion



        #region Public methods

        internal void Recieve(int pValue)
        {
            /*for (int i = 0; i < mActionList.Count; i++)
                mActionList[i].Receive(pValue);*/
            mActionList[Bcf2000.CurrentMode].Recieve(pValue);
        }

        internal XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement ListElement = pDocument.CreateElement("ActionList");

            Utils.Xml.AddAttribute(ListElement, pDocument, "DeviceName", mDeviceName);
            Utils.Xml.AddAttribute(ListElement, pDocument, "Command", mCommand);
            Utils.Xml.AddAttribute(ListElement, pDocument, "MidiChannel", mMidiChannel.ToString());
            Utils.Xml.AddAttribute(ListElement, pDocument, "Data1", mData1.ToString());
            //Utils.Xml.AddAttribute(ListElement, pDocument, "Description", mDescription);


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


        internal void AddMode(int ModeIndex)
        {
            mActionList.Add(new BcfActionList(this, ModeIndex));
        }
    }
}
