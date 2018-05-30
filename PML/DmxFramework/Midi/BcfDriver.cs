using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;
using System.Xml;

namespace DmxFramework.Midi
{
    public class BcfDriver
    {
        List<Device> mDeviceList;
        List<Device> mSubscribedDevice;
        Dictionary<string, Action.BcfAction> mActionTable;

        List<Bcf2000> mBCF2000;


        List<Action.BcfAction> mBcfIO;

        static int NbBcfIO = 8 + 8 + 8 + 8 + 4;

        public static int CurrentMode { get; set; }

        public List<string> BcfMode { get; set; }


        public BcfDriver()
        {
            mDeviceList = new List<Device>();
            mActionTable = new Dictionary<string, Action.BcfAction>();
            mSubscribedDevice = new List<Device>();

            mBcfIO = new List<Action.BcfAction>();

            BcfMode = new List<string>();
            BcfMode.Add("Default");



            for (int i = 0; i < NbBcfIO; i++)
                mBcfIO.Add(new Action.BcfAction());
            //RefreshDevices();
            //Connect();
        }

        
        public List<Device> DeviceList
        {
            get { return mDeviceList; }
        }


        public Dictionary<string, Action.BcfAction> ActionTable
        {
            get { return mActionTable;}
            set { mActionTable = value;  }
        }

        public void RefreshDevices()
        {
            int Count = 0, i=0, j=0;

            List<Device> devList = new List<Device>();
            
            Count = InputDevice.DeviceCount;
            for (i = 0; i < Count; i++)
                devList.Add(new Device(i));

            Count = OutputDevice.DeviceCount;
            for (i = 0; i < Count; i++)
            {
                MidiOutCaps cap = OutputDevice.GetDeviceCapabilities(i);
                for (j = 0; j < devList.Count; j++)
                {
                    if (devList[j].Name == cap.name)
                        devList[j].SetOutputDevice(i);
                }
            }

            /*foreach (Device dev in devList)
            {
                bool found = true;
                
                for(int i =0; i<mDeviceList.Count; i++)
                    if (mDeviceList[i].Name == dev.Name)
                    {
                        found = true;
                        break;
                    }
                if(!found)
            }*/
            mDeviceList = devList;
        }

        public void SubscribeToDevice(string pDeviceName)
        {
           
            for (int i = 0; i < mDeviceList.Count; i++)
                if (mDeviceList[i].Name == pDeviceName)
                    SubscribeToDevice(mDeviceList[i]);
        }

        public void SubscribeToDevice(Device pDevice)
        {
            if (mSubscribedDevice.Contains(pDevice))
                return;

            pDevice.OnMidiValueChanged += new OnMidiValueChangedDelegate(pDevice_OnMidiValueChanged);
            pDevice.Subscribe();
            pDevice.Start();
            
        }

        void pDevice_OnMidiValueChanged(string pName, string pCommand, int pMidiChannel, int pData1, int pData2)
        {
            string key = Action.Action.GetKey(pName, pCommand, pMidiChannel, pData1);

            Action.BcfAction Actlist;
            if (mActionTable.TryGetValue(key, out Actlist))
                Actlist.Recieve(pData2);
        }



        internal void LoadXml(XmlNode pNode)
        {
            if (pNode.Name != Constant.BcfXmlNodeName)
                return;

            int i = 0;
            foreach (XmlNode node in pNode.ChildNodes)
            {
                //Action.ActionList actList = new DmxFramework.Midi.Action.ActionList(node);
               // mActionTable.Add(actList.Key, actList);

                mBcfIO[i].LoadXml(node);
            }
        }

        internal XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement MidiElement= pDocument.CreateElement(Constant.BcfXmlNodeName);
            foreach (Action.BcfAction act in mBcfIO)
                MidiElement.AppendChild(act.GetXml(pDocument));

            return MidiElement;
        }

        internal void StopAll()
        {
            foreach (Action.BcfAction act in mActionTable.Values)
                act.Device = null;
            
            foreach (Device dev in mDeviceList)
                dev.ForceStop();
        }

        public void Connect()
        {
            StopAll();
            mDeviceList.Clear();
            RefreshDevices();
            bool initialized = false;
            foreach(Device dev in mDeviceList)
            {
                initialized = false;
                foreach (Action.BcfAction act in mBcfIO)
                {
                    if (act.DeviceName == dev.Name)
                    {
                        if (!initialized)
                        {
                            SubscribeToDevice(dev);
                            initialized = true;
                        }
                        act.Device = dev;     
                    }
                }

                /*
                foreach (Bcf2000 bcf in mBCF2000)
                {
                    if (bcf.DeviceName == dev.Name)
                        bcf.Device = dev;
                }
                */
            }
        }

        /*
        public Action.BcfAction AddOrGetAction(string pName, string pCommand, int pMidiChannel, int pData1)
        {
            string key = Action.Action.GetKey(pName, pCommand, pMidiChannel, pData1);

            Action.BcfAction Actlist;
            if (mActionTable.TryGetValue(key, out Actlist))
                return Actlist;

            return null;
        }*/

        internal void ChangeKey(string poldestKey, Action.BcfAction pAction)
        {
            Action.BcfAction oldestRef;
            if(mActionTable.TryGetValue(poldestKey, out oldestRef))
            {
                mActionTable.Remove(poldestKey);
            }

            mActionTable.Add(pAction.Key, pAction);
        }

        //public void AddMode(string pName="New")
        //{
        //    BcfMode.Add("New");

        //    foreach(Action.BcfAction act in mBcfIO)
        //    {
        //        act.AddMode();
        //    }
                

        //}


    }
}
