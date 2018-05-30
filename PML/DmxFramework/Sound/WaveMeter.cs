using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;

namespace DmxFramework.Sound
{
    public delegate void OnVolumeChangedHandler(int pValue);
    
    public class WaveMeter
    {
        private const int mSamples = 32;
        private static int[] mSampleFormatArray = { mSamples, 2, 1 };
        private int mSampleDelay;
        private int mFrameDelay;
        private Microsoft.DirectX.DirectSound.CaptureDevicesCollection mAudioDevices;
        private System.Collections.Specialized.StringCollection mAudioDeviceNames;
        private Microsoft.DirectX.DirectSound.CaptureBuffer mAudioBuffer;
        private System.Threading.Thread mSignalThread;
        private String mCurrentDeviceName;
        private int mCurrentDeviceIndex;
        private int mAudioMode;
        private int mChannels;
        private bool mIsRunning = false;

        public event OnVolumeChangedHandler OnVolumeChanged = null;


        public WaveMeter()
        {
            mAudioMode = 2; //only one channel
            mSampleDelay = 50;
            mFrameDelay = 10;

            mChannels = mAudioMode;
            mAudioDevices = new CaptureDevicesCollection();
            mAudioDeviceNames = new System.Collections.Specialized.StringCollection();

            for (int i = 0; i < mAudioDevices.Count; i++)
            {
                mAudioDeviceNames.Add(mAudioDevices[i].Description);
            }

            mCurrentDeviceIndex = 1;
            Init();
            
        }

        public string[] Interfaces
        {
            get {
                int i = 0;
                string[] tab = new string[mAudioDevices.Count];
                foreach (string device in mAudioDeviceNames)
                {
                    tab[i] = mAudioDevices[i].Description;
                    i++;
                }
                return tab; 
            }
        }

        public int SelectedInterface
        {
            set 
            { 
                mCurrentDeviceIndex = value;
                Stop();
                Init();
                Start();
            }
            get { 
                return mCurrentDeviceIndex; 
            }
        }

        public void Init()
        {
            mCurrentDeviceName = mAudioDevices[mCurrentDeviceIndex].Description;

            Microsoft.DirectX.DirectSound.Capture audioCapture = new Capture(mAudioDevices[mCurrentDeviceIndex].DriverGuid);
            Microsoft.DirectX.DirectSound.CaptureBufferDescription audioCaptureDescription = new CaptureBufferDescription();
            Microsoft.DirectX.DirectSound.WaveFormat audioFormat = new WaveFormat();
            audioFormat.BitsPerSample = (short)(mChannels * 8);
            audioFormat.SamplesPerSecond = 44100;
            audioFormat.Channels = (short)mChannels;
            audioFormat.BlockAlign = (short)(mChannels * audioFormat.BitsPerSample / 8);
            audioFormat.AverageBytesPerSecond = audioFormat.BlockAlign * audioFormat.SamplesPerSecond;
            audioFormat.FormatTag = WaveFormatTag.Pcm;

            audioCaptureDescription.Format = audioFormat;
            audioCaptureDescription.BufferBytes = mSamples * audioFormat.BlockAlign;
            mAudioBuffer = new CaptureBuffer(audioCaptureDescription, audioCapture);
            mIsRunning = false;    
        }

        public void Start()
        {
            if (!mIsRunning)
            {
                mIsRunning = true;
                mAudioBuffer.Start(true);
                mSignalThread = new System.Threading.Thread(new System.Threading.ThreadStart(UpdateSignal));
                mSignalThread.Priority = System.Threading.ThreadPriority.Lowest;
                //isRunning = true;
                mAudioBuffer.Start(true);
                mSignalThread.Start();
            }
        }

        public void Stop()
        {
            if (mIsRunning)
            {
                mSignalThread.Abort();
                mSignalThread.Join();
                mAudioBuffer.Stop();
                mIsRunning = false;
            }
            //isRunning = false;
            //if (clearOnStop == true) UpdateLevel(0, 0);
        }


        private void UpdateSignal()
        {
            while (true)
            {
                int TempFrameDelay = mFrameDelay;
                int TempSampleDelay = mSampleDelay;

                int LevelMax = 0;

                try
                {
                    Array SampleArray = mAudioBuffer.Read(0, typeof(Int16), LockFlag.FromWriteCursor, mSampleFormatArray);

                

                
                    for (int i = 0; i < mSamples; i++)
                    {
                        LevelMax += (int)Math.Abs((Int16)SampleArray.GetValue(i, 0, 0));
                        LevelMax += (int)Math.Abs((Int16)SampleArray.GetValue(i, 1, 0));
                    }
                }
                catch
                {
                    LevelMax = 0;
                }
                Console.WriteLine(LevelMax);
                
                 

                LevelMax =LevelMax / (2*mSamples);

                double dbl =  Int16.MaxValue / 100;
                double preciselvl = LevelMax / dbl;

                int level = (int)preciselvl;
              //  Console.WriteLine(" >> "+level );

                if (level > 100)
                    level = 100;

                if(OnVolumeChanged != null)
                    OnVolumeChanged(level);
                /*double LedIncrement = Int16.MaxValue / totalLeds;

                //double AbsLeftStepSize = Math.Abs(LeftStepSize);
                //double AbsRightStepSize = Math.Abs(RightStepSize);

                double preciseLeftLevel = LeftMax / LedIncrement;
                double preciseRightLevel = RightMax / LedIncrement;

                leftLevel = (int)preciseLeftLevel;
                rightLevel = (int)preciseRightLevel;

                UpdateLevel(leftLevel, rightLevel);*/

                System.Threading.Thread.Sleep(mSampleDelay);
            }
        }

    }
}
