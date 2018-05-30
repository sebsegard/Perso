using System;
using System.Collections.Generic;
using System.Text;

namespace DmxSoft
{
    public class DmxOption
    {
        bool mVisualize;

        public DmxOption()
        {
            mVisualize = true;
        }

        public bool Visualize
        {
            get {return mVisualize;}
            set { mVisualize = value; }
        }

        
    }
}
