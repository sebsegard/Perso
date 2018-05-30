using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Forms.BCF2000
{
    public partial class BcfControlAssignement : Form
    {
        public BcfControlAssignement()
        {
            InitializeComponent();
        }

        public void SetAction(DmxFramework.Midi.Action.BcfActionList pAction)
        {
            this.atctionListCtrl1.SetAction(pAction);
        }
    }
}
