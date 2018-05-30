using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Forms
{
    public partial class AutoModeConfiguration : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        int mNum;

        public AutoModeConfiguration(int pNumAutomatic)
        {
            InitializeComponent();
            mNum = pNumAutomatic;
            this.Text = "Auto " + (pNumAutomatic+1);
            this.autoModeConfigCtrl1.SetAutoMode(DmxFramework.Framework.AutomaticMode[pNumAutomatic]);
            
        }

        protected override string GetPersistString()
        {
            return this.GetType().ToString() + "," + mNum;
        }

       
    }
}