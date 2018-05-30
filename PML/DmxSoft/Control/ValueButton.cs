using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using DmxFramework.Channels;
using System.Drawing;
using System.IO;

namespace DmxSoft.Control
{
    public delegate void OnNewBtnValueHandler(int pValue);
    
    public class ValueButton:System.Windows.Forms.Button
    {
        DmxValue mValue;
        public event OnNewBtnValueHandler OnNewBtnValue = null;
        Color mDefaultColor;

        public ValueButton(DmxFramework.Channels.DmxValue pValue)
            : base()
        {
            mValue = pValue;
            mDefaultColor = this.BackColor;
            if (mValue.Image != null && mValue.Image != "" && File.Exists(mValue.Image))
            {
                System.Drawing.Image img = Image.FromFile(mValue.Image);
                this.BackgroundImage = img;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            }
            else
            {
                this.Text = mValue.Text;
            }
            this.MouseClick += new MouseEventHandler(ValueButton_MouseClick); 
        }

        void ValueButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (OnNewBtnValue != null)
                OnNewBtnValue(mValue.Value);
        }


        public bool IsConcerned(int pValue)
        {
            if (pValue >= mValue.StartValue && pValue < mValue.EndValue)
                return true;
            else
                return false;
        }

        public void SetSelectedMode(bool pIsSelected)
        {
            if (pIsSelected)
                this.BackColor = Color.Chartreuse;
            else
                this.BackColor = Color.White;
        }

        
    }
}
