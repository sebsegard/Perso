using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WeifenLuo.WinFormsUI.Docking;

namespace DmxSoft
{
    
    
    public partial class Main : System.Windows.Forms.Form   
    {
        public const string DockConfigFile = "pml.config"; 
        Forms.Explorer mExplorer = null;
        public static DmxFramework.Framework mFrameWork = new DmxFramework.Framework();
        public Timer mSaveTimer;

        public static DmxOption Options = new DmxOption();
        
        public Main()
        {
            

        }

        public void Init()
        {
            InitializeComponent();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            try
            {

                //mFrameWork.StartDmxDevice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("could not start dmx interface\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //mFrameWork.StartKeybordListening();

            try
            {
                mFrameWork.LoadXml();
                mFrameWork.LoadScenes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("could not load configuration\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (File.Exists(DockConfigFile))
                {
                    this.dockPanel1.LoadFromXml(DockConfigFile, new DeserializeDockContent(GetContentFromPersistString));
                }
                else
                {
                    mExplorer = new DmxSoft.Forms.Explorer(mFrameWork);
                    mExplorer.DockPanel = dockPanel1;
                    mExplorer.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
                    mExplorer.Show();
                }
            }
            catch (Exception ex)
            {

            }



            mSaveTimer = new Timer();
            //sauvegarde toute les 5 minutes ....
            mSaveTimer.Interval = 1000 * 60 * 5;
            mSaveTimer.Tick += new EventHandler(mSaveTimer_Tick);
            mSaveTimer.Enabled = true;

            for(int i=0; i<DmxFramework.Framework.AutomaticMode.Count; i++)
                LoadModeConfigurationItem(i);
        }

        void LoadModeConfigurationItem(int pNum)
        {
            ToolStripMenuItem Auto = new ToolStripMenuItem("Auto Mode " + (pNum + 1));
            Auto.Tag = pNum;
            Auto.Click += new EventHandler(Auto_Click);

            this.automaticModeToolStripMenuItem.DropDownItems.Insert(pNum, Auto);
        }



        void Auto_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                int Num = (int)(((ToolStripMenuItem)sender).Tag);


                Forms.AutoModeConfiguration dlg = new DmxSoft.Forms.AutoModeConfiguration(Num);
                dlg.DockPanel = dockPanel1;
                dlg.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Float;
                dlg.Show();
            }
        }



        void mSaveTimer_Tick(object sender, EventArgs e)
        {
            mFrameWork.SaveScene();
        }

        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(this, "You should restart Pimp My Lights", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            TextWriter txt = new StreamWriter("log.txt",false);
            txt.WriteLine("");
            txt.WriteLine(DateTime.Now.ToShortDateString());
            txt.WriteLine(e.Exception.Message);
            txt.WriteLine(e.Exception.StackTrace);
            txt.Close();
        }

        private void dmxOutPutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //mDmxOutput.Show();
        }

        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mExplorer != null)
                mExplorer.Show();
            else
            {
                mExplorer = new DmxSoft.Forms.Explorer(mFrameWork);
                mExplorer.DockPanel = dockPanel1;
                mExplorer.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
                mExplorer.Show();
            }
        }

        private void SceneExplorerMenuItem_Click(object sender, EventArgs e)
        {

            DmxSoft.Forms.SceneExplorer SceneExplorer = new DmxSoft.Forms.SceneExplorer(mFrameWork);
            SceneExplorer.DockPanel = dockPanel1;
            SceneExplorer.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            SceneExplorer.Show();
        }

        private void chansonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DmxSoft.Forms.Chansons chans = new DmxSoft.Forms.Chansons();
            chans.DockPanel = dockPanel1;
            chans.Show();
        }

        private void sceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mFrameWork.Outputs.Connect();

        }

        private void invertChannelsInAutomatiqueModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DmxFramework.Framework.InvertChannelsInAutoMode)
                DmxFramework.Framework.InvertChannelsInAutoMode = false;
            else
                DmxFramework.Framework.InvertChannelsInAutoMode = true;
            invertChannelsInAutomatiqueModeToolStripMenuItem.Checked = DmxFramework.Framework.InvertChannelsInAutoMode;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.About about = new DmxSoft.Forms.About();
            about.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            mFrameWork.Exit();
            this.dockPanel1.SaveAsXml("pml.config");
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            DmxFramework.Framework.KeyBord.PressKey(e);
        }

        private void beatDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.BeatDetectionConfiguration dlg = new DmxSoft.Forms.BeatDetectionConfiguration(DmxFramework.Framework.MusicMode.BeatDetection);
            dlg.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Options opt = new DmxSoft.Forms.Options();
            opt.Show();
        }

        private void automaticModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.AutoModeConfiguration dlg = new DmxSoft.Forms.AutoModeConfiguration(0);
            dlg.Show();
        }

        private void keyborToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.KeybordConfiguration dlg = new DmxSoft.Forms.KeybordConfiguration();
            /*dlg.DockPanel = dockPanel1;
            dlg.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Float;*/
            dlg.Show();
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            DmxFramework.Framework.KeyBord.KeyUp(e);
        }


        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(Forms.Explorer).ToString())
            {
                mExplorer = new DmxSoft.Forms.Explorer(mFrameWork);
                return mExplorer;
            }
            
            else
            {
                string[] parsedStrings = persistString.Split(new char[] { ',' });
                if (parsedStrings[0] == typeof(Forms.AdvancedForm).ToString())
                {
                    if (parsedStrings.Length > 1)
                    {
                        DmxFramework.Fixtures.Fixture Fixture = mFrameWork.GetFixtureFromPath(parsedStrings[1]);
                        if (Fixture == null)
                            return null;
                        return new Forms.AdvancedForm(Fixture);
                    }
                }
                else if (parsedStrings[0] == typeof(Forms.ScenePlayer).ToString())
                {
                    if (parsedStrings.Length > 1)
                        return new Forms.ScenePlayer(mFrameWork.GetFixtureFromPath(parsedStrings[1]));
                }
                else if (parsedStrings[0] == typeof(Forms.AutoModeConfiguration).ToString())
                {
                    if (parsedStrings.Length > 1)
                        return new Forms.AutoModeConfiguration(Convert.ToInt16(parsedStrings[1]));
                }
                else if (parsedStrings[0] == typeof(Forms.DmxOutPut).ToString())
                {
                    if (parsedStrings.Length > 1)
                    {
                        DmxFramework.Fixtures.Fixture Fixture = mFrameWork.GetFixtureFromPath(parsedStrings[1]);
                        if (Fixture == null)
                            return null;
                        return new Forms.DmxOutPut(Fixture);

                    }
                    else
                        return new Forms.DmxOutPut(mFrameWork);
                }
                else if (parsedStrings[0] == typeof(Forms.SceneExplorer).ToString())
                {
                    if (parsedStrings.Length > 1)
                        return new Forms.SceneExplorer(mFrameWork.GetFixtureFromPath(parsedStrings[1]));
                }


            }
            return null;
        }

        private void newWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.dockPanel1.LoadFromXml(DockConfigFile, new DeserializeDockContent(GetContentFromPersistString));

            /*foreach (DockContent crl in this.dockPanel1.Contents)
                crl.Close();

            this.dockPanel1.Contents.cl*/

            /*while (this.dockPanel1.Documents != null && this.dockPanel1.DocumentsCount != 0)
                ((DockContent)((this.dockPanel1.DocumentsToArray())[0])).Close();*/

            //IDockContent[] doc = this.dockPanel1.DocumentsToArray();
            //for (int i = 0; i < doc.Length; i++)
            //    ((DockContent)doc[i]).Close();

           /* foreach (DockContent win in this.dockPanel1.Documents)
                win.Close();*/

            mExplorer = new DmxSoft.Forms.Explorer(mFrameWork);
            mExplorer.DockPanel = dockPanel1;
            mExplorer.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            mExplorer.Show();
        }

        private void AddAUtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DmxFramework.Framework.AutomaticMode.Add(new DmxFramework.AutoMode.AutoMode());
            LoadModeConfigurationItem(DmxFramework.Framework.AutomaticMode.Count - 1);
        }

        private void seeDmxInterfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void snapshotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.SnapShotDlg dlg = new DmxSoft.Forms.SnapShotDlg();
                dlg.Show();
            }
            catch { }
        }

        private void connectKnownMidiDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DmxFramework.Framework.MidiDriver.Connect();
        }

        private void midiConfiguratiobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.Midi.ConfForm dlg = new Forms.Midi.ConfForm();
                dlg.Show();
            }
            catch { }
        }

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);



        private bool mFullScreen = false;

        private void SetFullScreen()
        {
            int hWnd = FindWindow("Shell_TrayWnd", "");
            mFullScreen = !mFullScreen;
            if (mFullScreen)
            {
               
                ShowWindow(hWnd, SW_HIDE);
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
                this.TopMost = true;

            }
            else
            {
                ShowWindow(hWnd, SW_SHOW);
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.TopMost = false;
            } 
           
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFullScreen();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.DmxAddresses dlg = new DmxSoft.Forms.DmxAddresses();
                dlg.Show();
            }
            catch { }
        }

        private void connectBCF2000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DmxFramework.Framework.Bcf2000.Connect();
        }

        private void bCF2000ConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.BCF2000.BCF2000 dlg = new Forms.BCF2000.BCF2000();
            dlg.DoLoad();
            dlg.Show();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mFrameWork.SaveScene();
        }

        private void bcfModeChoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DmxSoft.Forms.BCF2000.BcfModeForm SceneExplorer = new DmxSoft.Forms.BCF2000.BcfModeForm();
            SceneExplorer.DockPanel = dockPanel1;
            SceneExplorer.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Float;
            SceneExplorer.Show();
        }

       

       
       
        
    }
}