using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace DmxFramework.Fixtures
{
    public class Poursuit
    {
        DmxPoint mPointA;   //upper left
        DmxPoint mPointB;   //upper right
        DmxPoint mPointC;   //lower right
        DmxPoint mPointD;   //lower left
        DmxPoint mInterectionPoint;
        bool mIsActive;

        DmxPoint mCurrentPoint;

        #region constructor

        public Poursuit()
        {
            mPointA = new DmxPoint(40,40);
            mPointB = new DmxPoint(200, 40);
            mPointC = new DmxPoint(200, 200);
            mPointD = new DmxPoint(40, 200);
            mInterectionPoint = new DmxPoint();
            mCurrentPoint = new DmxPoint();
            mIsActive = false;
        }

        #endregion

        #region properties

        public DmxPoint PointA
        {
            get {return mPointA;}
            set {mPointA = value;}
        }

        public DmxPoint PointB
        {
            get { return mPointB; }
            set { mPointB = value; }
        }

        public DmxPoint PointC
        {
            get { return mPointC; }
            set { mPointC = value; }
        }

        public DmxPoint PointD
        {
            get { return mPointD; }
            set { mPointD = value; }
        }

        public DmxPoint PointIntersection
        {
            get { return mInterectionPoint; }
        }

        public bool IsActive
        {
            get { return mIsActive ; }
            set { mIsActive = value; }
        }

        #endregion

        #region public methods

        public void ComputeIntersection()
        {
            DmxVector AC = new DmxVector(mPointA, mPointC);
            DmxVector BD = new DmxVector(mPointB, mPointD);

            mInterectionPoint = BD.GetIntersection(AC);
        }

        public int SetPan(int pValue)
        {
            if (!mIsActive)
                return pValue;
            mCurrentPoint.fX = pValue;
            DmxPoint pt = GetRelativePosition();
            return pt.iX;
        }

        public int SetTilt(int pValue)
        {
            if (!mIsActive)
                return pValue;
            mCurrentPoint.fY = pValue;
            DmxPoint pt = GetRelativePosition();
            return pt.iY;
        }

        public DmxPoint GetRelativePosition()
        {
           
            DmxPoint pt_O = new DmxPoint(128,128);
            DmxPoint pt_P = mCurrentPoint;
            DmxPoint pt_R; //RESULT POINT;

            DmxPoint pt_I = mInterectionPoint;
           
            DmxPoint pt_A;
            DmxPoint pt_B;
            
            DmxPoint pt_C;
            DmxPoint pt_D;

            DmxPoint pt_F;
            DmxPoint pt_G;

            

            DmxVector v_OP;
            DmxVector v_AB;
            DmxVector v_CD;
            DmxVector v_AF;
            DmxVector v_OF;
            DmxVector v_CG;
            DmxVector v_IG;
            DmxVector v_IR;
            
            if (mCurrentPoint.fY == 128 && mCurrentPoint.fX == 128)
            {
               
                return mInterectionPoint;
            }
            else if (mCurrentPoint.fX >= mCurrentPoint.fY && mCurrentPoint.fY < (255 - mCurrentPoint.fX))
            {
                pt_A = new DmxPoint(0, 0);
                pt_B = new DmxPoint(255, 0);

                pt_C = mPointA;
                pt_D = mPointB;
                
            
                Console.WriteLine("haut");

           }
            else if (mCurrentPoint.fX >= mCurrentPoint.fY && mCurrentPoint.fY >= (255 - mCurrentPoint.fX))
            {
                pt_A = new DmxPoint(255, 0);
                pt_B = new DmxPoint(255, 255);

                pt_C = mPointB;
                pt_D = mPointC;

                Console.WriteLine("droite");
            }
            else if (mCurrentPoint.fX < mCurrentPoint.fY && mCurrentPoint.fY >= (255 - mCurrentPoint.fX))
            {
                pt_A = new DmxPoint(255, 255);
                pt_B = new DmxPoint(0, 255);

                pt_C = mPointC;
                pt_D = mPointD;
                Console.WriteLine("bas");
            }
            else
            {
                pt_A = new DmxPoint(0, 255);
                pt_B = new DmxPoint(0, 0);

                pt_C = mPointD;
                pt_D = mPointA;
                Console.WriteLine("gauche");
            }


            v_OP = new DmxVector(pt_O, pt_P);
            v_AB = new DmxVector(pt_A, pt_B);
            v_CD = new DmxVector(pt_C, pt_D);

            
            pt_F = v_OP.GetProjectionPoint(pt_O, v_AB);
            v_AF = new DmxVector(pt_A, pt_F);
            v_OF = new DmxVector(pt_O, pt_F);

            float Rapport = v_AF / v_AB;

            v_CG = v_CD * Rapport;
            pt_G = v_CG.Point2;

            v_IG = new DmxVector(pt_I, pt_G);

            Rapport = v_OP / v_OF;

            v_IR = v_IG * Rapport;

            pt_R = v_IR.Point2;

            return pt_R;
        }



        public XmlNode GetXml(XmlDocument pDocument)
        {
            XmlElement FixtureNode = pDocument.CreateElement("Poursuit");
            XmlAttribute Attribute = pDocument.CreateAttribute("Active");
            Attribute.InnerText = this.mIsActive.ToString();
            FixtureNode.Attributes.Append(Attribute);

            Attribute = pDocument.CreateAttribute("pt_A_X");
            Attribute.InnerText = this.mPointA.iX.ToString();
            FixtureNode.Attributes.Append(Attribute);

            Attribute = pDocument.CreateAttribute("pt_A_Y");
            Attribute.InnerText = this.mPointA.iY.ToString();
            FixtureNode.Attributes.Append(Attribute);

            Attribute = pDocument.CreateAttribute("pt_B_X");
            Attribute.InnerText = this.mPointB.iX.ToString();
            FixtureNode.Attributes.Append(Attribute);

            Attribute = pDocument.CreateAttribute("pt_B_Y");
            Attribute.InnerText = this.mPointB.iY.ToString();
            FixtureNode.Attributes.Append(Attribute);

            Attribute = pDocument.CreateAttribute("pt_C_X");
            Attribute.InnerText = this.mPointC.iX.ToString();
            FixtureNode.Attributes.Append(Attribute);

            Attribute = pDocument.CreateAttribute("pt_C_Y");
            Attribute.InnerText = this.mPointC.iY.ToString();
            FixtureNode.Attributes.Append(Attribute);

            Attribute = pDocument.CreateAttribute("pt_D_X");
            Attribute.InnerText = this.mPointD.iX.ToString();
            FixtureNode.Attributes.Append(Attribute);

            Attribute = pDocument.CreateAttribute("pt_D_Y");
            Attribute.InnerText = this.mPointD.iY.ToString();
            FixtureNode.Attributes.Append(Attribute);

            return FixtureNode;
        }

        public void LoadXml(XmlNode pNode)
        {
            if (pNode.Name != "Poursuit")
                return;

            mIsActive = Convert.ToBoolean(pNode.Attributes["Active"].Value);

            mPointA.iX = Convert.ToInt16(pNode.Attributes["pt_A_X"].Value);
            mPointA.iY = Convert.ToInt16(pNode.Attributes["pt_A_Y"].Value);

            mPointB.iX = Convert.ToInt16(pNode.Attributes["pt_B_X"].Value);
            mPointB.iY = Convert.ToInt16(pNode.Attributes["pt_B_Y"].Value);

            mPointC.iX = Convert.ToInt16(pNode.Attributes["pt_C_X"].Value);
            mPointC.iY = Convert.ToInt16(pNode.Attributes["pt_C_Y"].Value);

            mPointD.iX = Convert.ToInt16(pNode.Attributes["pt_D_X"].Value);
            mPointD.iY = Convert.ToInt16(pNode.Attributes["pt_D_Y"].Value);

           
        }
        #endregion

    }
}
