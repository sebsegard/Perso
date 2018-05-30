using System;
using System.Collections.Generic;
using System.Text;

namespace DmxFramework
{
    /// <summary>
    /// This class manage all the dmx output knowns by the framework
    /// </summary>
    public class DmxOutput
    {
        #region members

        private Interface.DmxInterface[] mInterfaces;
        private int mNbChannels;



        private Interface.DmxInterface mMainDevice;
        #endregion


        #region constructor

        /// <summary>
        /// Constructor, build each known interfaces and add it into a table
        /// </summary>
        public DmxOutput()
        {
            mInterfaces = new DmxFramework.Interface.DmxInterface[2];
            mInterfaces[0] = new DmxFramework.Interface.Velleman();
            mInterfaces[1] = new DmxFramework.Interface.OpenDmx();
            SetActiveDevice(0);
        }

        #endregion

      
        #region properties


        //get the DMX interface managed bu the framework
        public Interface.DmxInterface[] Interfaces
        { get { return mInterfaces; } }

        #endregion 


        #region methods

        /// <summary>
        /// Connect to the active interface
        /// </summary>
        public void Connect()
        {
            if (mMainDevice != null)
            {
                mMainDevice.Connect();
                mMainDevice.SetNbChannels(mNbChannels);
            }
            /*foreach (Interface.DmxInterface dmx in mInterfaces)
            {
                if (dmx.IsActive)
                {
                    
                    dmx.Connect();
                    dmx.SetNbChannels(mNbChannels);
                }
            }*/
        }

        /// <summary>
        /// Connect to the active interface
        /// </summary>
        /*public void Connect(string pInterfaceName)
        {
            foreach (Interface.DmxInterface dmx in mInterfaces)
            {
                if (dmx.Name == pInterfaceName)
                {
                    dmx.Connect();
                    dmx.SetNbChannels(mNbChannels);
                }
            }
        }*/


        /// <summary>
        /// Disonnect to the active interface
        /// </summary>
        public void Disconnect()
        {
            /*foreach (Interface.DmxInterface dmx in mInterfaces)
            {
                if (dmx.IsActive)
                    dmx.Disconnect();
            }*/
            if (mMainDevice != null)
                mMainDevice.Disconnect();
        }


        public void SetActiveDevice(string pDeviceName)
        {
            if (mMainDevice!=null && mMainDevice.IsActive)
                mMainDevice.IsActive = false;

            foreach (Interface.DmxInterface dmx in mInterfaces)
            {
                if (dmx.Name == pDeviceName)
                {
                    mMainDevice = dmx;
                    mMainDevice.IsActive = true;
                }
            }
        }

        private void SetActiveDevice(int pDeviceNumber)
        {
            if (mMainDevice != null && mMainDevice.IsActive)
                mMainDevice.IsActive = false;

            mMainDevice = mInterfaces[pDeviceNumber];
            mMainDevice.IsActive = true;
        }

        /*public void SetActiveDevice(int pNum)
        {

        }*/


        /// <summary>
        /// Set the number of channel
        /// </summary>
        public void SetNbChannels(int pCount)
        {
            mNbChannels = pCount;
            /*foreach (Interface.DmxInterface dmx in mInterfaces)
            {
                if (dmx.IsActive)
                    dmx.SetNbChannels(pCount);
            }*/
            if (mMainDevice != null)
                mMainDevice.SetNbChannels(pCount);
        }

        /// <summary>
        /// Set the  value of a dmx channel
        /// </summary>
        public void SetDmxValue(int pChannel, int pValue)
        {
           /* foreach (Interface.DmxInterface dmx in mInterfaces)
            {
                if (dmx.IsActive && dmx.IsConnected)
                    dmx.SetDmxValue(pChannel, pValue);
            }*/
            if (mMainDevice != null)
                mMainDevice.SetDmxValue(pChannel, pValue);
        }

        #endregion
    }
}
