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
    public partial class AtctionListCtrl : UserControl
    {
        BcfActionList mAction;
        
        public AtctionListCtrl()
        {
            InitializeComponent();

            this.cmb_AddAction.Items.Add(ChangeDmxValue.ActionDescription);
            this.cmb_AddAction.Items.Add(SceneMidiPlayer.ActionDescription);
            this.cmb_AddAction.Items.Add(AutoSpeed.ActionDescription);
            this.cmb_AddAction.Items.Add(AutoPress.ActionDescription);
            this.cmb_AddAction.Items.Add(SceneSpeed.ActionDescription);
        }

        public void SetAction(BcfActionList pAction)
        {
            ResetPanel();
            this.list_Action.Items.Clear();
            mAction = pAction;
            this.actionDescriptionCtrl1.SetAction(pAction);

            for (int i = 0; i < mAction.Actions.Count; i++)
                this.list_Action.Items.Add(mAction.Actions[i]);

        }

        private void list_Action_SelectedIndexChanged(object sender, EventArgs e)
        {
            object act = this.list_Action.SelectedItem;
            if (act == null)
                return;

            ResetPanel();
            if (act is ChangeDmxValue)
            {
                this.copyCtrl1.SetAction((ChangeDmxValue)act);
                this.copyCtrl1.Visible = true;
            }
            else if (act is SceneMidiPlayer)
            {
                this.scenePlyerCtrl1.SetAction((SceneMidiPlayer)act);
                this.scenePlyerCtrl1.Visible = true;
            }
            else if (act is AutoSpeed)
            {
                this.autoCtrl1.LoadTime((AutoSpeed)act);
                this.autoCtrl1.Visible = true;
            }
            else if (act is AutoPress)
            {
                this.autoCtrl1.LoadPresetBtn((AutoPress)act);
                this.autoCtrl1.Visible = true;
            }
            else if (act is SceneSpeed)
            {
                //this.autoCtrl1.LoadPresetBtn((SceneSpeed)act);
                this.autoCtrl1.Visible = false;
            } 
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DmxFramework.Midi.Action.Action NewAction = null;
            if (this.cmb_AddAction.SelectedIndex == 0)
                NewAction = new ChangeDmxValue();
            else if (this.cmb_AddAction.SelectedIndex == 1)
                NewAction = new SceneMidiPlayer();
            else if (this.cmb_AddAction.SelectedIndex == 2)
                NewAction = new AutoSpeed();
            else if (this.cmb_AddAction.SelectedIndex == 3)
                NewAction = new AutoPress();
            else if (this.cmb_AddAction.SelectedIndex == 4)
                NewAction = new SceneSpeed();

            if (NewAction != null)
            {
                mAction.Actions.Add(NewAction);
                this.list_Action.Items.Add(NewAction);
            }
        }

        private void ResetPanel()
        {
            this.copyCtrl1.Visible = false;
            this.scenePlyerCtrl1.Visible = false;
            this.autoCtrl1.Visible = false;
        }

        private void btn_uRemoveSelected_Click(object sender, EventArgs e)
        {
            DmxFramework.Midi.Action.Action act = this.list_Action.SelectedItem as DmxFramework.Midi.Action.Action;
            if (act == null)
                return;


            mAction.Actions.Remove(act);

            this.list_Action.Items.Remove(act);
            ResetPanel();

        }
    }
}
