using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DmxFramework.Channels;
using DmxFramework.Fixtures;
using System.Windows.Forms;

namespace DmxSoft.Forms
{
    public partial class DmxOutPut : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        DmxFramework.Framework mFrameWork;
        DmxFramework.Fixtures.Fixture mFixture;
      
        
        public DmxOutPut(DmxFramework.Framework pFrameWork)
        {
            mFrameWork = pFrameWork;
            InitializeComponent();
            mFixture = null;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.AutoScroll = true;

            for (int i = 0; i < 20; i++)
            {
                
                
                Control.DmxOutputCtrl ctrl = new DmxSoft.Control.DmxOutputCtrl(i+1);
                ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
                ctrl.MaximumSize = new System.Drawing.Size(49, 0);
                ctrl.MinimumSize = new System.Drawing.Size(49, 100);
                ctrl.Name = "dmxOutputCtrl"+i;
                ctrl.Size = new System.Drawing.Size(49, 100);
                ctrl.TabIndex = i;
                tableLayoutPanel1.Controls.Add(ctrl);

                this.tableLayoutPanel1.ColumnCount++;
            }

        }

        public DmxOutPut(Fixture pFixture)
        {
            //mFrameWork = pFrameWork;
            mFixture = pFixture;
            InitializeComponent();
            this.TabText =pFixture.Name;
            this.Text = pFixture.Name;
            List<DmxFramework.Channels.Channel> channels = pFixture.Channels;

            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.AutoScroll = true;

            for (int i = 0; i < channels.Count; i++)
            {


                Control.DmxOutputCtrl ctrl = new DmxSoft.Control.DmxOutputCtrl(channels[i]);
                ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
                ctrl.MaximumSize = new System.Drawing.Size(49, 0);
                ctrl.MinimumSize = new System.Drawing.Size(49, 100);
                ctrl.Name = "dmxOutputCtrl" + i;
                ctrl.Size = new System.Drawing.Size(49, 100);
                ctrl.TabIndex = i;
                tableLayoutPanel1.Controls.Add(ctrl);

                this.tableLayoutPanel1.ColumnCount++;
            }

        }

        public DmxOutPut()
        {
            InitializeComponent();
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.AutoScroll = true;
        }

        public void SetChannels(DmxFramework.Channels.Channel[] pChannels)
        {
            for (int i = 0; i < pChannels.Length; i++)
            {


                Control.DmxOutputCtrl ctrl = new DmxSoft.Control.DmxOutputCtrl(pChannels[i]);
                ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
                ctrl.MaximumSize = new System.Drawing.Size(49, 0);
                ctrl.MinimumSize = new System.Drawing.Size(49, 100);
                ctrl.Name = "dmxOutputCtrl" + i;
                ctrl.Size = new System.Drawing.Size(49, 100);
                ctrl.TabIndex = i;
                tableLayoutPanel1.Controls.Add(ctrl);

                this.tableLayoutPanel1.ColumnCount++;
            }
        }


        public DmxOutPut(DmxFramework.Channels.Channel[] pChannels)
        {
            InitializeComponent();
            

            

           
        }

        private void DmxOutPut_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
           // MessageBox.Show("huhu on se desabonne"); 
            e.Cancel = true;
        }

        private void DmxOutPut_Shown(object sender, EventArgs e)
        {
            //MessageBox.Show("huhu on s'abonne"); 
        }

       

        

        private void DmxOutPut_VisibleChanged(object sender, EventArgs e)
        {
            /*
            if(this.Visible)
                MessageBox.Show("huhu on s'abonne"); 
            else
                MessageBox.Show("huhu on se desabonne"); 
             * */
        }

        protected override string GetPersistString()
        {
            if(this.mFixture!=null)
                return this.GetType().ToString() + "," + this.mFixture.Path;

            return this.GetType().ToString();
        }

        

        
    }
}

