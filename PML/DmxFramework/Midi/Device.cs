using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;


namespace DmxFramework.Midi
{
    public delegate void OnMidiValueChangedDelegate(string pName, string Command, int pMidiChannel, int pData1, int pData2); 
    
    public class Device
    {
        InputDevice mInput = null;
        OutputDevice mOutput = null;
        bool mRunning = false;
        string mName = null;
        MidiInCaps mCap;
        int mInDeviceID;
        int mOutDeviceID;
        public event OnMidiValueChangedDelegate OnMidiValueChanged;
        int mNbSubscriber = 0;
        int mNbStart = 0;
        

        internal Device(int pDeviceID)
        {
            mInDeviceID = pDeviceID;
            mOutDeviceID = -1;
            mCap = InputDevice.GetDeviceCapabilities(pDeviceID);
            mName = mCap.name;
        }

        ~Device()
        {

                Stop();
        }

        public string Name
        { get {return mName;}}

        internal void SetOutputDevice(int pDeviceID)
        {
            mOutDeviceID = pDeviceID;
            //mOutput = new OutputDevice(pDeviceID);
        }

        public void Subscribe()
        {
            if (mNbSubscriber == 0 && mInput==null)
            {
                mInput = new InputDevice(mInDeviceID);
                mInput.ChannelMessageReceived += HandleChannelMessageReceived;
                mInput.Error += new EventHandler<ErrorEventArgs>(mInput_Error);

                if (mOutDeviceID != -1)
                    mOutput = new OutputDevice(mOutDeviceID);
            }
            mNbSubscriber++;
        }

        public void Start()
        {
            mNbStart++;
            if (mRunning)
                return;

            mInput.StartRecording();
            mRunning = true;
        }

        public void Stop()
        {
            mNbStart--;
            if (mNbStart > 0)
                return;

            if (mInput != null)
            {
                if (mRunning)
                    mInput.StopRecording();
                //mInput.Close();
                mRunning = false;
            }
            //if (mOutput != null)
            //    mOutput.Close();
        }

        internal void ForceStop()
        {
            mNbStart=0;
            

            if (mInput != null)
            {
                if (mRunning)
                    mInput.StopRecording();
                mInput.Close();
                mRunning = false;
            }
            if (mOutput != null)
                mOutput.Close();
        }

        private void mInput_Error(object sender, ErrorEventArgs e)
        {
            throw e.Error;
        }

        private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            if (OnMidiValueChanged != null)
                OnMidiValueChanged(mName, e.Message.Command.ToString(), e.Message.MidiChannel, e.Message.Data1, e.Message.Data2);
        }

        internal void SendValue(string Command, int pMidiChannel, int pData1, int pData2)
        {
            if (mOutput == null)
                return;

            try
            {
                ChannelCommand Cmd;

                if (Command == ChannelCommand.Controller.ToString())
                    Cmd = ChannelCommand.Controller;
                else if (Command == ChannelCommand.ProgramChange.ToString())
                    Cmd = ChannelCommand.ProgramChange;
                else if (Command == ChannelCommand.NoteOn.ToString())
                    Cmd = ChannelCommand.NoteOn;
                else if (Command == ChannelCommand.NoteOff.ToString())
                    Cmd = ChannelCommand.NoteOff;
                else if (Command == ChannelCommand.ChannelPressure.ToString())
                    Cmd = ChannelCommand.ChannelPressure;
                else
                    Cmd = ChannelCommand.PolyPressure;

                ChannelMessage mes = new ChannelMessage(Cmd, pMidiChannel, pData1, pData2);
                mOutput.Send(mes);

            }
            catch
            {
                mOutput = null;
            }

        }

        public override string ToString()
        {
            return mName;
        }
    }
}
