using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Midi.Action;

namespace DmxSoft.Forms.Midi
{
    public partial class ActionDescriptionCtrl : UserControl
    {
        private BcfActionList mAction;
        
        public ActionDescriptionCtrl()
        {
            InitializeComponent();
        }

        public void SetAction(BcfActionList pAction)
        {
            mAction = pAction;
            this.txt_Description.Text = pAction.Description;
        }

        private void txt_Description_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                mAction.Description = this.txt_Description.Text;
        }
    }
}
