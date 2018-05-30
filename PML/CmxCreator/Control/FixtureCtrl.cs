using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using DmxFramework.Fixtures;
namespace DmxCreator.Control
{
    public delegate void OnFixtureChangedEvent(Fixture pFixture);
    
    public partial class FixtureCtrl : UserControl
    {
        private Fixture mFixture;
        public event OnFixtureChangedEvent OnFixtureChanged = null;

        public FixtureCtrl()
        {
            InitializeComponent();
        }

        public void SetRealFixture(RealFixture pFixture)
        {
          
            try
            {
                mFixture = pFixture;
                ((RealFixture)mFixture).ToSave = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "File is corrupt.\r\nDelete the fixture and try again ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DmxCreator.Main.LogException(ex);
            }

            this.grp_Group1.Text = "Constructor";
            this.txt_1.Text = ((RealFixture)mFixture).LightConstructor;
            this.grp_Group1.Enabled = false;
            this.grp_Group1.Visible = true;

            this.grp_Group2.Text = "Fixture Name";
            this.txt_2.Text = ((RealFixture)mFixture).LightName;
            this.grp_Group2.Enabled = false;
            this.grp_Group2.Visible = true;

            this.grp_Image.Visible = true;
            if(((RealFixture)mFixture).Image!=null && File.Exists(((RealFixture)mFixture).Image))
                this.pictureBox1.Image = Image.FromFile(((RealFixture)mFixture).Image);
            this.channelCtrl1.SetFixture(mFixture);

        }

        public void SetVirtualFixture(VirtualFixture pFixture)
        {
            try
            {
                mFixture = pFixture;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "File is corrupt.\r\nDelete the fixture and try again ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DmxCreator.Main.LogException(ex);
            }

            this.grp_Group1.Text = "Name";
            this.txt_1.Text = mFixture.Name;
            this.grp_Group1.Enabled = true;
            this.grp_Group1.Visible = true;


            this.grp_Group2.Visible = false;

            this.grp_Image.Visible = false;
            this.channelCtrl1.SetFixture(mFixture);
        }


        
        private void lnk_ChangeImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dialog.ImageBrowser browser;// = Main.ImageBrowser;
            if(mFixture==null)
                return;

            /*if (mFixture != null && (mFixture is RealFixture) && ((RealFixture)mFixture).Image != "")
                browser.SelectImage(((RealFixture)mFixture).Image);*/

            browser = new DmxCreator.Dialog.ImageBrowser(((RealFixture)mFixture).Image);

            browser.ShowDialog(this);

            if(mFixture==null || browser.SelectedImage==null)
                return;

            FileInfo file = new FileInfo(((RealFixture)mFixture).Image);
            
            if(file.FullName != browser.SelectedImage)
                this.pictureBox1.Image = Image.FromFile(browser.SelectedImage);
        }



       

        private void txt_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mFixture.Name = this.txt_1.Text;
                if (OnFixtureChanged != null)
                    OnFixtureChanged(mFixture);
            }
        }

       

      
    }
}
