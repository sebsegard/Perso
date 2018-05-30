using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Forms
{
    public partial class ScenePlayer : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        DmxFramework.Fixtures.Fixture mFixture;
        DmxFramework.Scene.SceneManager mSceneManager;

        public delegate void delegate_SceneStateChanged(DmxFramework.Scene.SceneManager pManager, DmxFramework.Scene.SceneManagerState pState);

        private delegate_SceneStateChanged MySceneStateChangedDelegate;

        public ScenePlayer(DmxFramework.Fixtures.Fixture pFixture)
        {
            InitializeComponent();


            MySceneStateChangedDelegate = new delegate_SceneStateChanged(ChangeSceneState);
            this.TabText = pFixture.Name;
            this.Text = pFixture.Name;
            mFixture = pFixture;
            mSceneManager = mFixture.Manager;

            this.tableLayoutPanel1.Controls.Clear();

            this.tableLayoutPanel1.ColumnCount = 0;
            this.tableLayoutPanel1.RowCount =0;
            this.tableLayoutPanel1.AutoScroll = true;

            if (mSceneManager.RowCount == 0 || mSceneManager.ColumnCount == 0)
                return;

            int pourcentage = 100 / mSceneManager.RowCount;
            this.tableLayoutPanel1.RowStyles.Clear();
            this.tableLayoutPanel1.RowCount = mSceneManager.RowCount;
            for (int i = 0; i < mSceneManager.RowCount; i++)
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, pourcentage));


            //set columns ...
            pourcentage = 100 / mSceneManager.ColumnCount;
            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.ColumnCount = mSceneManager.ColumnCount;
            for (int i = 0; i < mSceneManager.ColumnCount; i++)
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, pourcentage));

           
            foreach (DmxFramework.Scene.Scene sce in mSceneManager.Scenes)
            {
                if (sce.BtnX < 1 || sce.BtnY < 1 || sce.BtnX > mSceneManager.ColumnCount || sce.BtnY > mSceneManager.RowCount)
                    continue;
                
                DmxSoft.Control.SceneButton sceneBtn = new DmxSoft.Control.SceneButton(sce);
                sceneBtn.Dock = System.Windows.Forms.DockStyle.Fill;
                sceneBtn.Location = new System.Drawing.Point(4, 4);

                this.tableLayoutPanel1.Controls.Add(sceneBtn, sce.BtnX-1, sce.BtnY-1);

            }

            mSceneManager.OnSceneManagerStateChanged += new DmxFramework.Scene.OnSceneManagerStateChangedHandler(mSceneManager_OnSceneManagerStateChanged);
            mSceneManager_OnSceneManagerStateChanged(mSceneManager, mSceneManager.State);
        }

        void mSceneManager_OnSceneManagerStateChanged(DmxFramework.Scene.SceneManager pManager, DmxFramework.Scene.SceneManagerState pState)
        {
            if(this.InvokeRequired)
                this.BeginInvoke(MySceneStateChangedDelegate,pManager,pState);
            else
                ChangeSceneState(pManager,pState);
        }

        void ChangeSceneState(DmxFramework.Scene.SceneManager pManager, DmxFramework.Scene.SceneManagerState pState)
        {
            if (pState == DmxFramework.Scene.SceneManagerState.Running)
                this.tableLayoutPanel1.BackColor = Color.LightBlue;
            else
                this.tableLayoutPanel1.BackColor = Color.Orange;
        }

        protected override string GetPersistString()
        {
            return this.GetType().ToString() + "," + this.mFixture.Path;
        }
    }
}