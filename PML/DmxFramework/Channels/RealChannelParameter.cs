using System;
using System.Collections.Generic;
using System.Text;

namespace DmxFramework.Channels
{
    public class RealChannelParameter
    {
        private RealChannel mChannel;

        public RealChannelParameter(RealChannel pChannel)
        {
            mChannel = pChannel;
        }

        public bool Inverted
        {
            get { return mChannel.IsInverted; }
            set { mChannel.IsInverted = value; }
        }
        
        public string Name
        {
            get { return mChannel.Name; }
        }

        public string Type
        {
            get { return mChannel.Function.ToString(); }
        }
    }
}
