using System;
using System.Collections.Generic;
using System.Text;

namespace DmxFramework.Fixtures
{
    public class DmxVector
    {
        DmxPoint mPoint1;
        DmxPoint mPoint2;

        float mA;
        float mB;

        bool mIsInversed;

        public DmxVector()
        {
            mPoint1 = null;
            mPoint2 = null;
            mIsInversed = false;
        }

        public DmxVector(DmxPoint pPoint1, DmxPoint pPoint2)
        {
            mPoint1 = pPoint1;
            mPoint2 = pPoint2;
             mIsInversed = false;
        }

        public DmxPoint Point1
        {
            get { return mPoint1; }
            set { mPoint1 = value; }
        }

        public DmxPoint Point2
        {
            get { return mPoint2; }
            set { mPoint2 = value; }
        }

        public float A
        {
            get { return mA; }
        }

        public float B
        {
            get { return mB; }
        }

        public bool IsInverted
        {
             get { return mIsInversed; }
            set { mIsInversed = value; }
        }

        public void ComputeEquation()
        {
            if(!mIsInversed)
            {
                mA = (mPoint2.fY - mPoint1.fY) / (mPoint2.fX - mPoint1.fX);
                mB = mPoint1.fY - mPoint1.fX * mA;
            }
            else
            {
                mA = (mPoint2.fX- mPoint1.fX) / (mPoint2.fY - mPoint1.fY);
                mB = mPoint1.fX - mPoint1.fY * mA;
            }
        }



        public float GetLongueur()
        {
            float longueur = Point2.fX-Point1.fX;
            float largeur = Point2.fY - Point1.fY;
            return (float)Math.Sqrt(longueur * longueur + largeur * largeur);
        }


        public DmxPoint GetIntersection(DmxVector pVector)
        {
            DmxPoint InterectionPoint = new DmxPoint();

            this.ComputeEquation();
            pVector.ComputeEquation();

            if(!mIsInversed)
            {
                InterectionPoint.fX = (this.B - pVector.B) / (pVector.A - this.A);
                InterectionPoint.fY = this.A * InterectionPoint.fX + this.B;
            }
            else
            {
                InterectionPoint.fY = (this.B - pVector.B) / (pVector.A - this.A);
                InterectionPoint.fX = this.A * InterectionPoint.fY + this.B;
            }
            return InterectionPoint;
        }

        public static float operator /(DmxVector Vector1, DmxVector Vector2)
        {
            DmxPoint Rapport = new DmxPoint();

            return Vector1.GetLongueur() / Vector2.GetLongueur();

           
        }

        public static DmxVector operator *(DmxVector pVector, float Rapport)
        {
            DmxPoint point1 = pVector.Point1;
            DmxPoint point2 = new DmxPoint();
            point2.fX = point1.fX + Rapport * (pVector.Point2.fX - pVector.Point1.fX);
            point2.fY = point1.fY + Rapport * (pVector.Point2.fY - pVector.Point1.fY);

            return new DmxVector(point1, point2);
        }
        

        public DmxPoint GetProjectionPoint(DmxPoint pCommun, DmxVector pProjection)
        {
            DmxPoint pt = new DmxPoint();
            if (pProjection.Point1.fY == pProjection.Point2.fY)
            {
                pt.fY = pProjection.Point1.fY;

                if (this.Point2.fY == this.Point1.fY)
                    pt.fX = this.Point2.fY;
                else
                    pt.fX = (pt.fY - pCommun.fY) * (this.Point2.fX - this.Point1.fX) / (this.Point2.fY - this.Point1.fY) + pCommun.fX;   
            }
            else if (pProjection.Point1.fX == pProjection.Point2.fX)
            {
                pt.fX = pProjection.Point1.fX;
                
                if (this.Point2.fX - this.Point1.fX== 0)
                    pt.fY = this.Point2.fX;
                else
                    pt.fY = (pt.fX - pCommun.fX) * (this.Point2.fY - this.Point1.fY) / (this.Point2.fX - this.Point1.fX) + pCommun.fY;         
            }
            else
                throw new Exception("Unexpected");

            return pt;
        }
    }
}
