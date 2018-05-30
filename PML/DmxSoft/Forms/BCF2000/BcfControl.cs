using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Forms.BCF2000
{
    public partial class BcfControl : UserControl
    {
        protected DmxFramework.Midi.BcfControl mBcfControl;
        
        public BcfControl()
        {
            InitializeComponent();
        }

        public void SetBcfControl(DmxFramework.Midi.BcfControl pControl)
        {

        }
    }
}
