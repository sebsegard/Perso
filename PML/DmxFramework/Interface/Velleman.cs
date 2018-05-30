using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DmxFramework.Interface
{
    
    /// <summary>
    /// Class for Velleman vm116 dmx-usb interface
    /// </summary>
    public class Velleman : DmxInterface
    {
        public Velleman()
            : base("Velleman VM 116")
        {
            //nothing to do here ....
        }

        public override void Connect()
        {
            if (mIsConnected && mIsActive)
                return;

            mIsConnected = false;
            try
            {
                StartDevice();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Could not connect to  velleman interface");
            }
            mIsConnected = true;
        }

        public override void Disconnect()
        {
            if (!mIsConnected)
                return;

            try
            {
                StopDevice();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Could not connect to  velleman interface");
            }

            mIsConnected = false;
        }

        public override void SetDmxValue(int pChannel, int pValue)
        {
            lock (this)
            {
                try
                {
                    SetData(pChannel, pValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception("Could not set dmx value");
                }
            }
        }

        public override void SetNbChannels(int pNbChannels)
        {
            this.mNbChannels = pNbChannels;
            try
            {
                SetChannelCount(pNbChannels);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Could not set number of channel");
            }

        }


        [DllImport("K8062D.dll", EntryPoint = "StartDevice", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StartDevice();

        [DllImport("K8062D.dll", EntryPoint = "SetData", CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetData(int Channel, int Data);

        [DllImport("K8062D.dll", EntryPoint = "SetChannelCount", CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetChannelCount(int Count);

        [DllImport("K8062D.dll", EntryPoint = "StopDevice", CallingConvention = CallingConvention.Cdecl)]
        private static extern void StopDevice();


    }
}
