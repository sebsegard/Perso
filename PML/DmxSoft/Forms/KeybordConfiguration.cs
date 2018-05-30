using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Keyboard;

namespace DmxSoft.Forms
{
    public partial class KeybordConfiguration:Form
    {
        KeyEventArgs mLastKey; 

        public KeybordConfiguration()
        {
            InitializeComponent();
            this.sceneBrowserCtrl1.LoadTree();
            //RefreshKeyTable();
            RefreshKeyList();
            this.sceneBrowserCtrl1.OnDoubleClicked += new DmxSoft.Control.OnDoubleClickEvent(sceneBrowserCtrl1_OnDoubleClick);
            if (DmxFramework.Framework.KeyBord.KeyStepr != null)
                this.txt_KeyStep.Text = DmxFramework.Framework.KeyBord.KeyStepr.ToString();
        }

        void sceneBrowserCtrl1_OnDoubleClick(DmxFramework.Keyboard.Action pAction)
        {
            Hotkey key = (Hotkey)this.comboKey.SelectedItem;
            if (key != null)
            {
                key.Actions.Add(pAction);
                RefreshKeyTable(key);
            }
        }

        private void btn_detect_Click(object sender, EventArgs e)
        {
            if (btn_detect.Text == "Detect")
            {
                btn_detect.Text = "Stop detection";
                DmxFramework.Framework.KeyBord.OnKeyPressed += new DmxFramework.Keyboard.OnKeyPressedHandler(KeyBord_OnKeyPressed);

                
            }
            else
            {
                btn_detect.Text = "Detect";
                DmxFramework.Framework.KeyBord.OnKeyPressed -= this.KeyBord_OnKeyPressed;
            }
            
        }

        void KeyBord_OnKeyPressed(KeyEventArgs pKey)
        {
            mLastKey = pKey;
            this.txt_code.Text = pKey.KeyCode.ToString();
            this.txt_value.Text = pKey.KeyValue.ToString();

            Hotkey key = DmxFramework.Framework.KeyBord.GetKey(pKey.KeyValue);
            if (key != null)
            {
                this.comboKey.SelectedItem = key;
            }
            else
            {
                this.comboKey.SelectedItem = null;
                this.dataGridView1.Rows.Clear();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            /*if (this.sceneBrowserCtrl1.Action == null)
            {
                MessageBox.Show(this, "Please select a scene", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/

            if (this.mLastKey == null)
            {
                MessageBox.Show(this, "Please detect a key", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                Hotkey key = DmxFramework.Framework.KeyBord.AddKey(mLastKey);
                if (!this.comboKey.Items.Contains(key))
                    this.comboKey.Items.Add(key);
                this.comboKey.SelectedItem = key;
                //Action action = this.sceneBrowserCtrl1.Action;
                
                //key.Actions.Add(action);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //RefreshKeyTable((Hotkey)this.comboKey.SelectedItem);

        }

        private void RefreshKeyList()
        {
            this.comboKey.Items.Clear();

            //Main.mFrameWork.KeyBord.KeyList.Sort(

            foreach (DmxFramework.Keyboard.Hotkey key in DmxFramework.Framework.KeyBord.KeyList)
                this.comboKey.Items.Add(key);

            this.comboKey.Sorted = true;
        }

        private void RefreshKeyTable(DmxFramework.Keyboard.Hotkey pKey)
        {
            this.dataGridView1.Rows.Clear();

            if (pKey == null)
                return;
            try
            {
                foreach (DmxFramework.Keyboard.Action action in pKey.Actions)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Tag = pKey;
                    this.dataGridView1.Rows[index].Cells[0].Value = pKey.KeyCode;
                    this.dataGridView1.Rows[index].Cells[1].Value = pKey.KeyValue;
                    this.dataGridView1.Rows[index].Cells[2].Value = action.Path;
                    this.dataGridView1.Rows[index].Cells[2].Tag = action;
                    ((DataGridViewCheckBoxCell)this.dataGridView1.Rows[index].Cells[3]).Value = action.StopOnKeyUp;
                    this.dataGridView1.Rows[index].Cells[4].Value = "Remove";
                }
            }
            catch { }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DmxFramework.Keyboard.Hotkey key = (DmxFramework.Keyboard.Hotkey)this.dataGridView1.Rows[e.RowIndex].Tag;
            DmxFramework.Keyboard.Action action = (DmxFramework.Keyboard.Action)this.dataGridView1.Rows[e.RowIndex].Cells[2].Tag;
            if (e.ColumnIndex == 4)
            {
                key.Actions.Remove(action);
                /*if (key.Actions.Count == 0)
                {
                    Main.mFrameWork.KeyBord.Remove(key);
                    this.comboKey.rem
                }*/
                RefreshKeyTable((Hotkey)this.comboKey.SelectedItem);
            }
            else if (e.ColumnIndex == 3)
            {
                action.StopOnKeyUp = !(action.StopOnKeyUp);
                RefreshKeyTable((Hotkey)this.comboKey.SelectedItem);
            }
        }

        private void comboKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboKey.SelectedItem != null)
                RefreshKeyTable((Hotkey)this.comboKey.SelectedItem);
        }

        private void KeybordConfiguration_KeyDown(object sender, KeyEventArgs e)
        {
            KeyBord_OnKeyPressed(e);
        }

        private void KeybordConfiguration_KeyPress(object sender, KeyPressEventArgs e)
        {
            //KeyBord_OnKeyPressed((KeyEventArgs)e.KeyChar);
            //KeyBord_OnKeyPressed((KeyEventArgs)e.);
        }

        private void btn_detect_KeyDown(object sender, KeyEventArgs e)
        {
            KeyBord_OnKeyPressed(e);
        }

        private void btn_KeyStep_Click(object sender, EventArgs e)
        {
            Hotkey key = DmxFramework.Framework.KeyBord.GetKey(mLastKey.KeyValue);
            if (key != null)
            {
                DialogResult res = MessageBox.Show(this, "Key is already assigned. Are you sure to set it as step key ? That will remove every action !", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (res != DialogResult.OK)
                    return;

                key.Actions.Clear();
            }
            else
            {
                key = DmxFramework.Framework.KeyBord.AddKey(mLastKey);
            }
            key.IsKeyStep = true;
            DmxFramework.Framework.KeyBord.KeyStepr = key;
            this.txt_KeyStep.Text = key.ToString();
        }
    }
}