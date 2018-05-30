using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DmxFramework.Scene;
using System.Threading;

namespace DmxSoft.Control
{
    public partial class SceneButton : UserControl
    {
        DmxFramework.Scene.Scene mScene;
        private SynchronizationContext mCOntext;
        public SceneButton(DmxFramework.Scene.Scene pScene)
        {
            mScene = pScene;

            InitializeComponent();
            mCOntext = SynchronizationContext.Current;
            this.label1.Text = pScene.Name;
            this.trackBar1.Value = pScene.Ratio;
            this.label2.Text = pScene.Ratio.ToString();
            mScene_OnSceneStateChanged(mScene, mScene.State);
            mScene.OnSceneStateChanged += new DmxFramework.Scene.OnSceneStateChangeHandler(mScene_OnSceneStateChanged);
            mScene.OnSceneRatioChanged += new OnSceneRatioChangedHandler(mScene_OnSceneRatioChanged);
            if (mScene.Steps.Count < 2)
            {
                this.tableLayoutPanel1.RowStyles[2].Height = 0;
            }
            //mScene.o
        }

        void mScene_OnSceneRatioChanged(Scene pScene)
        {
            mCOntext.Post(new SendOrPostCallback(
               delegate
               {
                   this.trackBar1.Value = pScene.Ratio;

               }), null);
        }

        void mScene_OnSceneStateChanged(DmxFramework.Scene.Scene pScene, DmxFramework.Scene.SceneState pState)
        {
            mCOntext.Post(new SendOrPostCallback(
                delegate
                {
                    ChangeSceneState(pScene, pState);

                }), null);

        }

        void ChangeSceneState(DmxFramework.Scene.Scene pScene, DmxFramework.Scene.SceneState pState)
        {
            switch (pState)
            {
                case SceneState.Nothing:
                        this.BackColor = Color.White;
                        this.btn_Add.Text = "Add";
                        this.btn_Play.Text = "Play";                   
                        break;
                case SceneState.Pause:
                    this.BackColor = Color.Orange; 
                    this.btn_Add.Text = "Add";
                    this.btn_Play.Text = "Play";
                    break;

                case SceneState.PlayingExclusive:
                    this.BackColor = Color.Tomato; 
                    this.btn_Add.Text = "Add";
                    this.btn_Play.Text = "Stop";
                    break;

                case SceneState.Playing: 
                    this.BackColor = Color.LightGreen;
                    this.btn_Add.Text = "Remove";
                    this.btn_Play.Text = "Play";
                    break;
                case SceneState.Waiting: 
                    this.BackColor = Color.LightBlue;
                    this.btn_Add.Text = "Remove";
                    this.btn_Play.Text = "Play";
                    break;      
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.btn_Add.Text == "Add")
                mScene.Add();
            else
                mScene.Remove();
        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            if (this.btn_Play.Text == "Play")
                mScene.Play();
            else
                mScene.Remove();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            mScene.Ratio = this.trackBar1.Value;
            this.label2.Text = mScene.Ratio.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //mScene.Ratio = 0;
            this.trackBar1.Value = 0;
        }




    }
}
