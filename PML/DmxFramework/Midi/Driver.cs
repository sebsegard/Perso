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
    public class Driver
    {
        List<Device> mDeviceList;
        List<Device> mSubscribedDevice;
        Dictionary<string, Action.ActionList> mActionTable;

        List<Bcf2000> mBCF2000;
        
        public Driver()
        {
            mDeviceList = new List<Device>();
            mActionTable = new Dictionary<string, Action.ActionList>();
            mSubscribedDevice = new List<Device>();
            //RefreshDevices();
            //Connect();
        }

        public List<Device> DeviceList
        {
            get { return mDeviceList; }
        }


        public Dictionary<string, Action.ActionList> ActionTable
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

            Action.ActionList Actlist;
            if (mActionTable.TryGetValue(key, out Actlist))
                Actlist.Recieve(pData2);
        }



        internal void LoadXml(XmlNode pNode)
        {
            if (pNode.Name != Constant.MidiXmlNodeName)
                return;


            foreach (XmlNode node in pNode.ChildNodes)
            {
                Action.ActionList actList = new DmxFramework.Midi.Action.ActionList(node);
                mActionTable.Add(actList.Key, actList);
            }
        }

        internal XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement MidiElement= pDocument.CreateElement(Constant.MidiXmlNodeName);
            foreach (Action.ActionList act in mActionTable.Values)
                MidiElement.AppendChild(act.GetXml(pDocument));

            return MidiElement;
        }

        internal void StopAll()
        {
            foreach (Action.ActionList act in mActionTable.Values)
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
                foreach (Action.ActionList act in mActionTable.Values)
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

        public Action.ActionList AddOrGetAction(string pName, string pCommand, int pMidiChannel, int pData1)
        {
            string key = Action.Action.GetKey(pName, pCommand, pMidiChannel, pData1);

            Action.ActionList Actlist;
            if (mActionTable.TryGetValue(key, out Actlist))
                return Actlist;

            Actlist = new DmxFramework.Midi.Action.ActionList(pName, pCommand, pMidiChannel, pData1);
            mActionTable.Add(Actlist.Key, Actlist);
            return Actlist;
        }


    }
}
