using System;
using System.Collections.Generic;
using System.Text;
using Sanford.Multimedia.Midi;
using System.Xml;

namespace DmxFramework.Midi.Action
{
    public delegate void OnNewValueToSendEvent(int pValue);
    
    public abstract class Action
    {
        #region Static methods


        public static string GetKey(string pDeviceName, string pCommand, int pMidiChannel, int pData1)
        {
            return pDeviceName + "_" + pCommand + "_" + pMidiChannel + "_" + pData1;
        }

        public static string GetBcfKey(string pDeviceName, string pCommand, int pMidiChannel, int pData1)
        {
            return pDeviceName + "_" + pCommand + "_" + pMidiChannel + "_" + pData1;
        } 
        #endregion


        public event OnNewValueToSendEvent OnNewValueToSend = null;
       



        #region Constructors

        public Action()
        {

        }
        

        
        #endregion



       

        #region Abstract methods

        internal abstract void Receive(int pValue);

        
        #endregion
        


        #region Xml



        internal abstract XmlElement GetXml(XmlDocument pDocument);

       
        protected void SendValueToMidi(int pValue)
        {
            if (OnNewValueToSend != null)
            {
                if (pValue > 127)
                    OnNewValueToSend(127);
                else if (pValue < 0)
                    OnNewValueToSend(0);
                else
                    OnNewValueToSend(pValue);
            }
        }


	    #endregion


    }
}
