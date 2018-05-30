using System;
using System.Collections.Generic;
using System.Text;

namespace DmxFramework.Fixtures
{
    public class DmxPoint
    {
        
        int miX;
        int miY;
        float mfX;
        float mfY;

        public DmxPoint()
        {
            miX = 0;
            miY = 0;
            mfX = 0;
            mfY = 0;
        }
        
        public DmxPoint(int pX, int pY)
        {
            miX = pX;
            miY = pY;
            mfX = Convert.ToSingle(pX);
            mfY = Convert.ToSingle(pY);
        }

        public DmxPoint(float pX, float pY)
        {
            mfX = pX;
            mfY = pY;
            miX = Convert.ToInt32(pX);
            miY = Convert.ToInt32(pY);
        }

        public int iX
        {
            get { return miX; }
            set
            {
                miX = value;
                mfX = Convert.ToSingle(value);
            }
        }

        public int iY
        {
            get { return miY; }
            set
            {
                miY = value;
                mfY = Convert.ToSingle(value);
            }
        }

        public float fX
        {
            get { return mfX; }
            set
            {
                mfX = value;
                miX = Convert.ToInt32(value);
            }
        }

        public float fY
        {
            get { return mfY; }
            set
            {
                mfY = value;
                miY = Convert.ToInt32(value);
            }
        }
    }
}
