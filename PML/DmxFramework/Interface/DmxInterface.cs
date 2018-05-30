using System;
using System.Collections.Generic;
using System.Text;

namespace DmxFramework.Interface
{
    public abstract class DmxInterface
    {
        protected bool mIsActive;
        protected bool mIsConnected;
        protected string mName;
        protected int mNbChannels;
        
        public  DmxInterface(string pName)
        {
            mName = pName;
            mIsConnected = false;
            mIsActive = false;
            mNbChannels = 0;
        }
        
        
        /// <summary>
        /// Name of the interface
        /// </summary>
        public string Name
        {
            get { return mName; }

        }

        /// <summary>
        /// Is the interface active
        /// </summary>
        public bool IsActive
        {
            get
            {
                return mIsActive;
            }
            set
            {
                mIsActive = value;
            }
        }

        /// <summary>
        /// Is the interface connected
        /// </summary>
       public bool IsConnected
        {
            get{  return mIsConnected; }
        }

        /// <summary>
        /// Number of managed channels
        /// </summary>
        public int NbChannels
        { get { return mNbChannels; } }

        public abstract void Connect();
       
        public abstract void Disconnect();

        public abstract void SetDmxValue(int pChannel, int pValue);

        public abstract void SetNbChannels(int pNbChannels);  
    }
}
