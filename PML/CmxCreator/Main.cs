using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DmxCreator.Control;
using DmxFramework.Fixtures;

namespace DmxCreator
{
    public partial class Main : Form
    {
        public static DmxFramework.Framework FrameWork = new DmxFramework.Framework();
        public static bool HasToBeSaved = false;
        //public static Dialog.ImageBrowser ImageBrowser = new DmxCreator.Dialog.ImageBrowser(); 
        
        public Main()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            try
            {
                FrameWork.LoadXml();
                FrameWork.LoadScenes();

                LoadFrameworkExplorer();

                LoadFixtureExplorer();

                this.fixtureCtrl1.OnFixtureChanged += new OnFixtureChangedEvent(fixtureCtrl1_OnFixtureChanged);
                this.fixtureConfCtrl1.OnFixtureChanged += new OnFixtureChangedEvent(fixtureCtrl1_OnFixtureChanged);

                this.workspaceTree1.OnRealFixtureSelected += new OnRealFixtureSelectedDelegate(workspaceTree1_OnRealFixtureSelected);
                this.workspaceTree1.OnVirtualFixtureSelected += new OnVirtualFixtureSelectedDelegate(workspaceTree1_OnVirtualFixtureSelected);

                HideAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        void fixtureCtrl1_OnFixtureChanged(Fixture pFixture)
        {
            this.workspaceTree1.ChangeFixture(pFixture);
        }


        #region Framework explorer

        

        private void LoadFrameworkExplorer()
        {
            this.workspaceTree1.Clear();
            this.workspaceTree1.LoadTree();
         
            this.fixtureConfCtrl1.RefreshAdress();
        }

        void workspaceTree1_OnVirtualFixtureSelected(DmxFramework.Fixtures.VirtualFixture pFixture)
        {
            try
            {
                HideAll();
                this.fixtureCtrl1.SetVirtualFixture(pFixture);
                this.fixtureCtrl1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Please Retry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogException(ex);
            }
        }

        void workspaceTree1_OnRealFixtureSelected(DmxFramework.Fixtures.RealFixture pFixture)
        {
            HideAll();
            this.fixtureConfCtrl1.Visible = true;
            this.fixtureConfCtrl1.SetFixture(pFixture);
        }

        #endregion

        #region Fixture Tree

        private void LoadFixtureExplorer()
        {
            this.fixtureTree1.LoadTree();
            this.fixtureTree1.OnRealFixtureSelected += new OnRealFixtureSelectedEvent(fixtureTree1_OnRealFixtureSelected);
        }

        void fixtureTree1_OnRealFixtureSelected(DmxFramework.Fixtures.RealFixture pFixture)
        {
            try
            {
                HideAll();
                this.fixtureCtrl1.SetRealFixture(pFixture);
                this.fixtureCtrl1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Please Retry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogException(ex);
            }
        }

        #endregion


        #region workspace menu items

        private void menuItem_NewW_Click(object sender, EventArgs e)
        {
            DialogResult res;
            if (DmxFramework.Framework.WorkspaceManager.CurrentWorkspace != null)
            {
                res = MessageBox.Show(this, "Do you want to save current workspace before creating a new one ?", "Save ...", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Cancel)
                    return;
                else if (res == DialogResult.Yes)
                    FrameWork.SaveFramework();
            }

            Dialog.NewWorkspace dlg = new DmxCreator.Dialog.NewWorkspace();
            res = dlg.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                DmxFramework.Workspace.Workspace work = new DmxFramework.Workspace.Workspace(dlg.WorkspaceName);
                FrameWork.OpenWorkspace(work);
                FrameWork.LoadXml();
                FrameWork.LoadScenes();

                LoadFrameworkExplorer();
            }  
        }

        private void menuItem_OpenW_Click(object sender, EventArgs e)
        {
            DialogResult res;
            if (DmxFramework.Framework.WorkspaceManager.CurrentWorkspace != null)
            {
                res = MessageBox.Show(this, "Do you want to save current workspace before creating a new one ?", "Save ...", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Cancel)
                    return;
                else if (res == DialogResult.Yes)
                    FrameWork.SaveFramework();
            }
            
            Dialog.OpenWorkspaceDlg dlg = new DmxCreator.Dialog.OpenWorkspaceDlg();
             res = dlg.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                FrameWork.OpenWorkspace(dlg.SelectedWorkspace);
                FrameWork.LoadXml();
                FrameWork.LoadScenes();

                LoadFrameworkExplorer();
            }
        }

        private void menuItem_CloseW_Click(object sender, EventArgs e)
        {
            if (DmxFramework.Framework.WorkspaceManager.CurrentWorkspace != null)
            {
                DialogResult res = MessageBox.Show(this, "Do you want to save current workspace before opening an other ?", "Save ...", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Cancel)
                    return;
                else if (res == DialogResult.Yes)
                    FrameWork.SaveFramework();
            }
        }

        private void menuItem_SaveW_Click(object sender, EventArgs e)
        {
            FrameWork.SaveFramework();
        }

        private void menuItem_SaveAs_Click(object sender, EventArgs e)
        {
            
            
            Dialog.NewWorkspace dlg = new DmxCreator.Dialog.NewWorkspace();
            DialogResult res = dlg.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                FrameWork.SaveFrameworkAs(dlg.WorkspaceName);
            }            
        }

        private void menuItem_SelectW_Click(object sender, EventArgs e)
        {

        }

#endregion


        #region Fixture Menu items

        private void dmxAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog.DmxAddresses dlg = new DmxCreator.Dialog.DmxAddresses();
            dlg.Show(this);
        }

        private void addCompagnieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog.AddCompanie dlg = new DmxCreator.Dialog.AddCompanie();
            DialogResult res = dlg.ShowDialog(this);
            if (res != DialogResult.OK)
                return;

            this.fixtureTree1.AddCompanie(dlg.CompanieName);
        }

        #endregion


        #region private methods

        private void HideAll()
        {
            this.fixtureCtrl1.Visible = false;
            this.fixtureConfCtrl1.Visible = false;
        }

        #endregion


        #region ERROR MESSAGE : static methods

        public static void LogException(Exception pEx)
        {
            TextWriter txt = new StreamWriter("log.txt", false);
            txt.WriteLine("");
            txt.WriteLine(DateTime.Now.ToShortDateString());
            txt.WriteLine(pEx.Message);
            txt.WriteLine(pEx.StackTrace);
            txt.Close();
        }

        #endregion

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fixtureTree1.Save();
        }



        

    }
}