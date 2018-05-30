namespace DmxCreator.Control
{
    partial class FixtureCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grp_Group1 = new System.Windows.Forms.GroupBox();
            this.txt_1 = new System.Windows.Forms.TextBox();
            this.grp_Image = new System.Windows.Forms.GroupBox();
            this.lnk_ChangeImage = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grp_Group2 = new System.Windows.Forms.GroupBox();
            this.txt_2 = new System.Windows.Forms.TextBox();
            this.channelCtrl1 = new DmxCreator.Control.ChannelCtrl();
            this.grp_Group1.SuspendLayout();
            this.grp_Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grp_Group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_Group1
            // 
            this.grp_Group1.Controls.Add(this.txt_1);
            this.grp_Group1.Location = new System.Drawing.Point(3, 3);
            this.grp_Group1.Name = "grp_Group1";
            this.grp_Group1.Size = new System.Drawing.Size(200, 47);
            this.grp_Group1.TabIndex = 0;
            this.grp_Group1.TabStop = false;
            this.grp_Group1.Text = "Constructor";
            // 
            // txt_1
            // 
            this.txt_1.Location = new System.Drawing.Point(7, 19);
            this.txt_1.Name = "txt_1";
            this.txt_1.Size = new System.Drawing.Size(187, 20);
            this.txt_1.TabIndex = 4;
            this.txt_1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_1_KeyUp);
            //this.txt_1.TextChanged += new System.EventHandler(this.txt_1_TextChanged);
            // 
            // grp_Image
            // 
            this.grp_Image.Controls.Add(this.lnk_ChangeImage);
            this.grp_Image.Controls.Add(this.pictureBox1);
            this.grp_Image.Location = new System.Drawing.Point(209, 3);
            this.grp_Image.Name = "grp_Image";
            this.grp_Image.Size = new System.Drawing.Size(126, 121);
            this.grp_Image.TabIndex = 1;
            this.grp_Image.TabStop = false;
            this.grp_Image.Text = "Picture";
            // 
            // lnk_ChangeImage
            // 
            this.lnk_ChangeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk_ChangeImage.AutoSize = true;
            this.lnk_ChangeImage.Location = new System.Drawing.Point(76, 101);
            this.lnk_ChangeImage.Name = "lnk_ChangeImage";
            this.lnk_ChangeImage.Size = new System.Drawing.Size(44, 13);
            this.lnk_ChangeImage.TabIndex = 1;
            this.lnk_ChangeImage.TabStop = true;
            this.lnk_ChangeImage.Text = "Change";
            this.lnk_ChangeImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_ChangeImage_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // grp_Group2
            // 
            this.grp_Group2.Controls.Add(this.txt_2);
            this.grp_Group2.Location = new System.Drawing.Point(3, 67);
            this.grp_Group2.Name = "grp_Group2";
            this.grp_Group2.Size = new System.Drawing.Size(200, 57);
            this.grp_Group2.TabIndex = 3;
            this.grp_Group2.TabStop = false;
            this.grp_Group2.Text = "Nb Channels";
            // 
            // txt_2
            // 
            this.txt_2.Location = new System.Drawing.Point(7, 18);
            this.txt_2.Name = "txt_2";
            this.txt_2.Size = new System.Drawing.Size(187, 20);
            this.txt_2.TabIndex = 5;
            // 
            // channelCtrl1
            // 
            this.channelCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.channelCtrl1.Location = new System.Drawing.Point(3, 130);
            this.channelCtrl1.Name = "channelCtrl1";
            this.channelCtrl1.Size = new System.Drawing.Size(702, 349);
            this.channelCtrl1.TabIndex = 4;
            // 
            // FixtureCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.channelCtrl1);
            this.Controls.Add(this.grp_Group2);
            this.Controls.Add(this.grp_Image);
            this.Controls.Add(this.grp_Group1);
            this.Name = "FixtureCtrl";
            this.Size = new System.Drawing.Size(708, 482);
            this.grp_Group1.ResumeLayout(false);
            this.grp_Group1.PerformLayout();
            this.grp_Image.ResumeLayout(false);
            this.grp_Image.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grp_Group2.ResumeLayout(false);
            this.grp_Group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_Group1;
        private System.Windows.Forms.GroupBox grp_Image;
        private System.Windows.Forms.LinkLabel lnk_ChangeImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grp_Group2;
        private System.Windows.Forms.TextBox txt_1;
        private System.Windows.Forms.TextBox txt_2;
        private ChannelCtrl channelCtrl1;
    }
}
