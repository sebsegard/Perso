using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;

namespace DmxFramework.Midi
{
    public enum bcfControlType
    {
        Fader,
        ButtonUp,
        ButtonDown,
        Potar,
        ButtonRight,
        ButtonPotar
    }
    
    public class BcfControl
    {
        public Action.BcfAction BcfAction {get;set;}

       
        int mPosition;
        bcfControlType mType;
        public string Name { get; private set; }

        BcfControl()
        {

        }

        public BcfControl(int pPosition, bcfControlType pType)
        {
            mPosition = pPosition;
            mType = pType;
            Name = string.Format("{0} {1}",pType,pPosition);
            BcfAction = new Action.BcfAction();
        }

        public void LoadXml(XmlNode Node)
        {
            BcfAction.LoadXml(Node);
        }

        internal XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement element =BcfAction.GetXml(pDocument);;
            element.SetAttribute("CtrlName", Name);
            return element;
        }
    }
    
    public class Bcf2000
    {
        List<BcfControl> mAllControls;
        List<BcfControl> mFaders;
        List<BcfControl> mButtonDown;
        List<BcfControl> mButtonUp;
        List<BcfControl> mButtonRight;
        List<BcfControl> mPotards;
        List<BcfControl> mButtonPotards;
        Device mDevice;
        string mDeviceName;

        public static int CurrentMode { get; set; }

        public List<string> BcfMode { get; set; }

        List<Device> mDeviceList;
        List<Device> mSubscribedDevice;
        Dictionary<string, Action.BcfAction> mActionTable;

        public List<BcfControl> AllControls { get { return mAllControls; } }
        public List<BcfControl> Faders { get { return mFaders; } }
        public List<BcfControl> ButtonDown { get { return mButtonDown; } }
        public List<BcfControl> ButtonUp { get { return mButtonUp; } }
        public List<BcfControl> ButtonRight { get { return mButtonRight; } }
        public List<BcfControl> Potards { get { return mPotards; } }
        public List<BcfControl> buttonPotards { get { return mButtonPotards; } }

        public Bcf2000(string pDeviceName)
        {
            mDeviceName = pDeviceName;
            mAllControls = new List<BcfControl>();
            mFaders = InitList(bcfControlType.Fader, 8);
            mButtonDown = InitList(bcfControlType.ButtonDown, 8);
            mButtonUp = InitList(bcfControlType.ButtonUp, 8);
            mPotards = InitList(bcfControlType.Potar, 8);
            mButtonRight = InitList(bcfControlType.ButtonRight, 4);
            mButtonPotards = InitList(bcfControlType.ButtonPotar, 8);
            BcfMode = new List<string>();
            AddMode("Main");
        }

        public Bcf2000()
        {
            mDeviceName = "";
            mAllControls = new List<BcfControl>();
            mFaders = InitList(bcfControlType.Fader, 8);
            mButtonDown = InitList(bcfControlType.ButtonDown, 8);
            mButtonUp = InitList(bcfControlType.ButtonUp, 8);
            mPotards = InitList(bcfControlType.Potar, 8);
            mButtonRight = InitList(bcfControlType.ButtonRight, 4);
            BcfMode = new List<string>();
            AddMode("Main");

            mDeviceList = new List<Device>();
            mActionTable = new Dictionary<string, Action.BcfAction>();
            mSubscribedDevice = new List<Device>();
        }

        public string DeviceName { get { return mDeviceName; } set { mDeviceName = value; } }
        public Device Device { get { return mDevice; } set { mDevice = value; } }

        private List<BcfControl> InitList(bcfControlType pType, int pCount)
        {
            List<BcfControl> list = new List<BcfControl>();
            for(int i=0; i<pCount;i++)
                list.Add(new BcfControl(i, pType));
            mAllControls.AddRange(list);
            return list;
        }

        public void AddMode(string pName = "New")
        {
            BcfMode.Add(pName);
            int ModeIndex = BcfMode.Count - 1;
            foreach (BcfControl ctrl in mAllControls)
            {
                ctrl.BcfAction.AddMode(ModeIndex);
            }
        }

        public void RemoveMode(string pName)
        {
            //BcfMode.Add(pName);

            //foreach (BcfControl ctrl in mAllControls)
            //{
            //    ctrl.BcfAction.AddMode();
            //}
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

            foreach (BcfControl ctrl in mAllControls)
                ctrl.BcfAction.Device = pDevice;
        }

        void pDevice_OnMidiValueChanged(string pName, string pCommand, int pMidiChannel, int pData1, int pData2)
        {
            string key = Action.Action.GetKey(pName, pCommand, pMidiChannel, pData1);

            Action.BcfAction Actlist;
            if (mActionTable.TryGetValue(key, out Actlist))
                Actlist.Recieve(pData2);
        }

        public List<Device> DeviceList
        {
            get { return mDeviceList; }
        }


        public Dictionary<string, Action.BcfAction> ActionTable
        {
            get { return mActionTable; }
            set { mActionTable = value; }
        }

        public void RefreshDevices()
        {
            int Count = 0, i = 0, j = 0;

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

 
        internal void LoadXml(XmlNode pNode)
        {
            if (pNode.Name != Constant.BcfXmlNodeName)
                return;

            int iCtrl = 0;
            int iMode = 0;
            foreach (XmlNode node in pNode.ChildNodes)
            {
                if (node.Name == "Mode")
                {
                    string ModeName = node.Attributes["Name"].Value;
                    if (iMode == 0)
                        BcfMode[0] = ModeName;
                    else
                        AddMode(ModeName);
                    iMode++;
                }
                else
                {
                    mAllControls[iCtrl].LoadXml(node);
                    if(!string.IsNullOrEmpty(mAllControls[iCtrl].BcfAction.DeviceName) && !string.IsNullOrEmpty(mAllControls[iCtrl].BcfAction.Command))
                        mActionTable.Add(mAllControls[iCtrl].BcfAction.Key, mAllControls[iCtrl].BcfAction);
                    
                    iCtrl++;
                }
                //Action.ActionList actList = new DmxFramework.Midi.Action.ActionList(node);
                // mActionTable.Add(actList.Key, actList);

                
            }
        }

        internal XmlElement GetXml(XmlDocument pDocument)
        {
            XmlElement MidiElement = pDocument.CreateElement(Constant.BcfXmlNodeName);
            foreach (string modeName in BcfMode)
            {
                XmlElement ModeElement = pDocument.CreateElement("Mode");
                ModeElement.SetAttribute("Name",modeName);
                MidiElement.AppendChild(ModeElement);
            }
            foreach (BcfControl ctrl in this.mAllControls)
                MidiElement.AppendChild(ctrl.GetXml(pDocument));

            return MidiElement;
        }

        internal void StopAll()
        {
           if(mActionTable!=null)
                foreach (Action.BcfAction act in mActionTable.Values)
                    act.Device = null;

            if(mDeviceList!=null)
                foreach (Device dev in mDeviceList)
                    dev.ForceStop();
        }

        public void Connect()
        {
            StopAll();
            mDeviceList.Clear();
            RefreshDevices();
            bool initialized = false;
            foreach (Device dev in mDeviceList)
            {
                initialized = false;
                foreach (BcfControl ctrl in mAllControls)
                {
                    Action.BcfAction act = ctrl.BcfAction;
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
            if (mActionTable.TryGetValue(poldestKey, out oldestRef))
            {
                mActionTable.Remove(poldestKey);
            }

          
            mActionTable.Add(pAction.Key, pAction);
            


        }
    }
}
