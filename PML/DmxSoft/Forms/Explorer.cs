using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DmxFramework;
using DmxFramework.Fixtures;

namespace DmxSoft.Forms
{
    public partial class Explorer : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        Framework mFrameWork;
        TreeNode mSelectedNode = null;
        
        #region constructor

        public Explorer(Framework pFrameWork)
        {
            mFrameWork = pFrameWork;
            InitializeComponent();
            //mImageList = new ImageList();
            this.treeView1.ImageList = new ImageList() ;
            LoadTree();

            
        }

        #endregion

        #region LoadExplorer

        private void LoadTree()
        {
            string FilePath = System.Environment.CurrentDirectory + "\\icons\\white.ico";
            Icon ico = new Icon(FilePath);
            this.treeView1.ImageList.Images.Add(ico);
            //foreach (Fixture fix in mFrameWork.Fixtures)
            this.treeView1.Nodes.Add(LoadFixture(DmxFramework.Framework.Fixtures));

            this.treeView1.ExpandAll();

        }

        private TreeNode LoadFixture(Fixture pFixture)
        {
            TreeNode Node = new TreeNode(pFixture.Name);
            Node.Tag = pFixture;
            if (pFixture.Type == FixtureType.Real)
            {
                string FilePath = System.Environment.CurrentDirectory + "\\" + ((RealFixture)pFixture).Image;

                if (File.Exists(FilePath))
                {
                    Image img = Image.FromFile(FilePath);
                    this.treeView1.ImageList.Images.Add(img);
                    Node.ImageIndex = this.treeView1.ImageList.Images.Count - 1;
                    Node.SelectedImageIndex = this.treeView1.ImageList.Images.Count - 1;
                }
            }
            else
            {
                Node.ImageIndex = 0;
                foreach (Fixture fix in ((VirtualFixture)pFixture).SubFixture)
                    Node.Nodes.Add(LoadFixture(fix));
            }
            //Node.Expand();
            return Node;
        }

        #endregion

        #region explorer event
        private void Explorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        #endregion

        #region context menu
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.mSelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                ShowMenu(e.Location);
            }
            if (e.Button == MouseButtons.Middle)
            {
                panelToolStripMenuItem_Click(null, null);
            }
        }
      

        private void ShowMenu(Point pPoint)
        {
            Fixture fix = (Fixture)mSelectedNode.Tag;
            this.ParameterstoolStripMenuItem1.Enabled = false;

            if (fix.Channels == null || fix.Channels.Count == 0)
            {
                basicDmxConsoleToolStripMenuItem.Enabled = false;
                advancedDmxConsoleToolStripMenuItem.Enabled = false;

            }
            else
            {
                basicDmxConsoleToolStripMenuItem.Enabled = true;
                advancedDmxConsoleToolStripMenuItem.Enabled = true;
            }

            if (fix.Type == FixtureType.Real)
            {
                poursuitToolStripMenuItem.Enabled = true;
                this.ParameterstoolStripMenuItem1.Enabled = true;
                poursuitToolStripMenuItem.Checked = ((RealFixture)fix).Poursuite.IsActive;
            }
            else
            {
                poursuitToolStripMenuItem.Enabled = false;
            }

            if (fix.PanChannel != null)
            {
                InvertPanStripMenuItem.Enabled = true;
                this.ParameterstoolStripMenuItem1.Enabled = true;
                InvertPanStripMenuItem.Checked = fix.PanChannel.InvertedInAutoMode;
            }
            else
                InvertPanStripMenuItem.Enabled = false;

            if (fix.TiltChannel != null)
            {
                InvertTiltStripMenuItem.Enabled = true;
                InvertTiltStripMenuItem.Checked = fix.TiltChannel.InvertedInAutoMode;
                this.ParameterstoolStripMenuItem1.Enabled = true;
            }
            else
                InvertTiltStripMenuItem.Enabled = false;

            //menu
            musicalDetectiobToolStripMenuItem.Checked = fix.IsMusicalDetection;
            lockToolStripMenuItem.Checked = fix.Locked;


            
            this.contextMenuStrip1.Show(this.treeView1, pPoint);
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void basicDmxConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixture fix = (Fixture)mSelectedNode.Tag;
            //protection
            if (fix.Channels == null || fix.Channels.Count == 0)
                return;
            Forms.DmxOutPut Output = new Forms.DmxOutPut(fix);
            Output.DockPanel = this.DockPanel;
            Output.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Float;
            Output.Show();
        }

        private void advancedDmxConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixture fix = (Fixture)mSelectedNode.Tag;
            //protection
            if (fix.Channels == null || fix.Channels.Count == 0)
                return;
            Forms.AdvancedForm dlg = new AdvancedForm(fix);
            dlg.DockPanel = this.DockPanel;
            dlg.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Float;
            dlg.Show();
        }

        private void scenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Fixture fix = (Fixture)mSelectedNode.Tag;
                Forms.SceneEditor dlg = new SceneEditor(fix);
                dlg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Fixture fix = (Fixture)mSelectedNode.Tag;
                Forms.SceneEditor dlg = new SceneEditor(fix);
                dlg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void quickSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Fixture fix = (Fixture)mSelectedNode.Tag;
                QuickScene dlg = new QuickScene(fix);
                dlg.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Fixture fix = (Fixture)mSelectedNode.Tag;
                Forms.ScenePlayer dlg = new ScenePlayer(fix);

               // dlg.Size = new Size(439, 288);
                dlg.DockPanel = this.DockPanel;
                dlg.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Float;
                dlg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            mSelectedNode = e.Node;
            Fixture fix = (Fixture)mSelectedNode.Tag;
            //protection
            if (fix.Channels == null || fix.Channels.Count == 0)
                return;

            Forms.AdvancedForm dlg = new AdvancedForm(fix);
            dlg.DockPanel = this.DockPanel;
            dlg.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Float;
            
            dlg.Show();
        }

        private void poursuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //mSelectedNode = e.Node;
            RealFixture fix = (RealFixture)mSelectedNode.Tag;
            Forms.PoursuitEditor dlg = new PoursuitEditor(fix);
            //dlg.DockPanel = this.DockPanel;
            dlg.Show();
        }

        private void musicalDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixture fix = (Fixture)mSelectedNode.Tag;
            if (fix.IsMusicalDetection)
                fix.StopMusicalDetection();
            else
                fix.StartMusicalDetection();
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixture fix = (Fixture)mSelectedNode.Tag;
            if (fix.Locked)
                fix.Locked = false;
            else
                fix.Locked = true;
        }

        private void InvertTiltStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixture fix = (Fixture)mSelectedNode.Tag;
            fix.TiltChannel.InvertedInAutoMode = !fix.TiltChannel.InvertedInAutoMode;
        }

        private void InvertPanStripMenuItem_Click(object sender, EventArgs e)
        {
            Fixture fix = (Fixture)mSelectedNode.Tag;
            fix.PanChannel.InvertedInAutoMode = !fix.PanChannel.InvertedInAutoMode;
        }


        #endregion

        private void ParameterstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Fixture fix = (Fixture)mSelectedNode.Tag;
            try
            {
                FixtureParameters param = new FixtureParameters(fix);
                param.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Fixture fix = (Fixture)mSelectedNode.Tag;
                Forms.SceneExplorer dlg = new SceneExplorer(fix);

                // dlg.Size = new Size(439, 288);
                dlg.DockPanel = this.DockPanel;
                dlg.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Float;
                dlg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        
    }
}