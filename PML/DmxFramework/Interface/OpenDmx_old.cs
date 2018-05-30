using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace DmxFramework.Interface
{

    public class OpenDmx_old : DmxInterface
    {
        Proxymity.QuickDmx.FtdiUsb.FtdiUsbDmxPort mPort = null;
        bool mRunning;
        object mLockObject = new object();
        byte[] mBytes;
        bool mHasChange = false;

        public OpenDmx_old() 
            : base("OpenDmx")
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
                //OpenDMXDriver.start();
                Proxymity.QuickDmx.FtdiUsb.FtdiUsbDmxPort[] ports = Proxymity.QuickDmx.FtdiUsb.FtdiUsbDmxPort.GetPorts();
                if (ports.Length == 0)
                    throw new Exception("Open dmx interface not found");

                mPort = ports[0];
                mPort.Open();

                mRunning = true;
                Thread thr = new Thread(new ThreadStart(OpenDmxThread));
                thr.Start();
                


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
                mRunning = false;
                mPort.Close();

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
            if (!mIsConnected)
                return;
            //OpenDMXDriver.setDmxValue(pChannel, (byte)pValue);


            lock (mLockObject)
            {
                if (mBytes[pChannel] != (byte)pValue)
                {
                    mBytes[pChannel] = (byte)pValue;
                    mHasChange = true;
                }
            }
        }

            
           /* mBytes[pChannel] = (byte)pValue;
            mPort.Send(mBytes);*/
        

       

        public override void SetNbChannels(int pNbChannels)
        {
            this.mNbChannels = pNbChannels;
            //throw new Exception("The method or operation is not implemented.");
            mBytes = new byte[pNbChannels];
            for (int i = 0; i < pNbChannels; i++)
                mBytes[i] = 0;
        }

        private void OpenDmxThread()
        {
            byte[] byteoSend = new Byte[mNbChannels];
            bool ToSend = false;

            while (true)
            {

                lock (mLockObject)
                {
                    if (mHasChange)
                    {
                       Array.Copy(mBytes,byteoSend,mNbChannels);
                        mHasChange = false;
                        ToSend = true;
                    }
                    else
                        ToSend = false;
                }

                //if(ToSend)
                    mPort.Send(byteoSend);
                
                if (mRunning)
                    Thread.Sleep(100);
                else
                    break;
            }
        }
    }


    //public class OpenDMXDriver
    //{

    //    public static byte[] buffer = new byte[511];
    //    public static uint handle;
    //    public static bool done = false;
    //    public static int bytesWritten = 0;
    //    public static FT_STATUS status;

    //    public const byte BITS_8 = 8;
    //    public const byte STOP_BITS_2 = 2;
    //    public const byte PARITY_NONE = 0;
    //    public const UInt16 FLOW_NONE = 0;
    //    public const byte PURGE_RX = 1;
    //    public const byte PURGE_TX = 2;


    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_Open(UInt32 uiPort, ref uint ftHandle);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_Close(uint ftHandle);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_Read(uint ftHandle, IntPtr lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesReturned);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_Write(uint ftHandle, IntPtr lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesWritten);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_SetDataCharacteristics(uint ftHandle, byte uWordLength, byte uStopBits, byte uParity);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_SetFlowControl(uint ftHandle, char usFlowControl, byte uXon, byte uXoff);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_GetModemStatus(uint ftHandle, ref UInt32 lpdwModemStatus);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_Purge(uint ftHandle, UInt32 dwMask);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_ClrRts(uint ftHandle);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_SetBreakOn(uint ftHandle);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_SetBreakOff(uint ftHandle);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_GetStatus(uint ftHandle, ref UInt32 lpdwAmountInRxQueue, ref UInt32 lpdwAmountInTxQueue, ref UInt32 lpdwEventStatus);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_ResetDevice(uint ftHandle);
    //    [DllImport("FTD2XX.dll")]
    //    public static extern FT_STATUS FT_SetDivisor(uint ftHandle, char usDivisor);


    //    public static void start()
    //    {
    //        handle = 0;
    //        status = FT_Open(0, ref handle);
    //        if (status != FT_STATUS.FT_OK)
    //            throw new Exception("FT_Open failed");
    //        Thread thread = new Thread(new ThreadStart(writeData));
    //        thread.Start();
    //        setDmxValue(0, 0);  //Set DMX Start Code
    //    }

    //    public static void setDmxValue(int channel, byte value)
    //    {
    //        if (buffer != null)
    //        {
    //            buffer[0] = 0;
    //            buffer[channel+1] = value;
    //        }
    //    }

    //    public static void writeData()
    //    {
           
    //            initOpenDMX();
                
    //            FT_SetBreakOn(handle);
    //            FT_SetBreakOff(handle);
    //            while (!done)
    //            {
    //            bytesWritten = write(handle, buffer, buffer.Length);
    //            Thread.Sleep(20);
    //        }

    //    }

    //    public static int write(uint handle, byte[] data, int length)
    //    {
    //        IntPtr ptr = Marshal.AllocHGlobal((int)length);
    //        Marshal.Copy(data, 0, ptr, (int)length);
    //        uint bytesWritten = 0;
    //        status = FT_Write(handle, ptr, (uint)length, ref bytesWritten);
    //        if (status != FT_STATUS.FT_OK)
    //            throw new Exception("FT_Write failed");
    //        return (int)bytesWritten;
    //    }

    //    public static void initOpenDMX()
    //    {
    //        status = FT_ResetDevice(handle);
    //        if (status != FT_STATUS.FT_OK)
    //            throw new Exception("FT_ResetDevice failed");
            
    //       // status = FT_SetDivisor(handle, (char)12);  // set baud rate
    //        status = FT_SetDivisor(handle, (char)12);
    //        if (status != FT_STATUS.FT_OK)
    //            throw new Exception("FT_SetDivisor failed");
            
    //        status = FT_SetDataCharacteristics(handle, BITS_8, STOP_BITS_2, PARITY_NONE);
    //        if (status != FT_STATUS.FT_OK)
    //            throw new Exception("FT_SetDataCharacteristics failed");
            
    //        status = FT_SetFlowControl(handle, (char)FLOW_NONE, 0, 0);
    //        if (status != FT_STATUS.FT_OK)
    //            throw new Exception("FT_SetFlowControl failed");
            
    //        status = FT_ClrRts(handle);
    //        if (status != FT_STATUS.FT_OK)
    //            throw new Exception("FT_ClrRts failed");
            
    //        status = FT_Purge(handle, PURGE_TX);
    //        if (status != FT_STATUS.FT_OK)
    //            throw new Exception("FT_Purge failed");
            
    //        status = FT_Purge(handle, PURGE_RX);
    //        if (status != FT_STATUS.FT_OK)
    //            throw new Exception("FT_Purge failed");
    //    }

    //}

    ///// <summary>
    ///// Enumaration containing the varios return status for the DLL functions.
    ///// </summary>
    //public enum FT_STATUS
    //{
    //    FT_OK = 0,
    //    FT_INVALID_HANDLE,
    //    FT_DEVICE_NOT_FOUND,
    //    FT_DEVICE_NOT_OPENED,
    //    FT_IO_ERROR,
    //    FT_INSUFFICIENT_RESOURCES,
    //    FT_INVALID_PARAMETER,
    //    FT_INVALID_BAUD_RATE,
    //    FT_DEVICE_NOT_OPENED_FOR_ERASE,
    //    FT_DEVICE_NOT_OPENED_FOR_WRITE,
    //    FT_FAILED_TO_WRITE_DEVICE,
    //    FT_EEPROM_READ_FAILED,
    //    FT_EEPROM_WRITE_FAILED,
    //    FT_EEPROM_ERASE_FAILED,
    //    FT_EEPROM_NOT_PRESENT,
    //    FT_EEPROM_NOT_PROGRAMMED,
    //    FT_INVALID_ARGS,
    //    FT_OTHER_ERROR
    //};
}
