using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Midi.Action;
using DmxFramework.Scene;
namespace DmxSoft.Forms.Midi.ActionCtrl
{
    public partial class ScenePlyerCtrl : UserControl
    {
        private SceneMidiPlayer mScenePlayer;
        
        public ScenePlyerCtrl()
        {
            InitializeComponent();
            this.fullTreeCtrl1.OnSceneSelected += new DmxSoft.Control.OnSceneSelectedEvent(fullTreeCtrl1_OnSceneSelected);
        }

        void fullTreeCtrl1_OnSceneSelected(Scene pScene)
        {
            if (pScene != null)
                this.textBox1.Text = pScene.Path;
        }

        public void SetAction(SceneMidiPlayer pScenePlayer)
        {
            mScenePlayer = pScenePlayer;
            this.fullTreeCtrl1.Reset();
            this.fullTreeCtrl1.SelectedScene = pScenePlayer.Scene;
            this.fullTreeCtrl1.LoadTree();
            if (pScenePlayer.Scene != null)
                this.textBox1.Text = mScenePlayer.Scene.Path;
            else
                this.textBox1.Text = "";
           

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (fullTreeCtrl1.SelectedScene == null)
            {
                MessageBox.Show("Scene must be selected");
                return;
            }

            try
            {
                mScenePlayer.Scene = fullTreeCtrl1.SelectedScene;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
