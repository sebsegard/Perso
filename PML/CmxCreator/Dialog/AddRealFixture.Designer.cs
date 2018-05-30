namespace DmxCreator.Dialog
{
    partial class AddRealFixture
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fixtureTree1 = new DmxCreator.Control.FixtureTree();
            this.txt_Fixture = new System.Windows.Forms.TextBox();
            this.btn_AddFixture = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fixtureTree1
            // 
            this.fixtureTree1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fixtureTree1.Location = new System.Drawing.Point(1, 1);
            this.fixtureTree1.Name = "fixtureTree1";
            this.fixtureTree1.Size = new System.Drawing.Size(331, 257);
            this.fixtureTree1.TabIndex = 0;
            this.fixtureTree1.OnRealFixtureSelected += new DmxCreator.Control.OnRealFixtureSelectedEvent(this.fixtureTree1_OnRealFixtureSelected);
            // 
            // txt_Fixture
            // 
            this.txt_Fixture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Fixture.Location = new System.Drawing.Point(1, 264);
            this.txt_Fixture.Name = "txt_Fixture";
            this.txt_Fixture.Size = new System.Drawing.Size(331, 20);
            this.txt_Fixture.TabIndex = 1;
            // 
            // btn_AddFixture
            // 
            this.btn_AddFixture.Location = new System.Drawing.Point(176, 290);
            this.btn_AddFixture.Name = "btn_AddFixture";
            this.btn_AddFixture.Size = new System.Drawing.Size(75, 23);
            this.btn_AddFixture.TabIndex = 2;
            this.btn_AddFixture.Text = "Add Fixture";
            this.btn_AddFixture.UseVisualStyleBackColor = true;
            this.btn_AddFixture.Click += new System.EventHandler(this.btn_AddFixture_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(257, 290);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // AddRealFixture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 318);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_AddFixture);
            this.Controls.Add(this.txt_Fixture);
            this.Controls.Add(this.fixtureTree1);
            this.Name = "AddRealFixture";
            this.Text = "Add Fixture";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DmxCreator.Control.FixtureTree fixtureTree1;
        private System.Windows.Forms.TextBox txt_Fixture;
        private System.Windows.Forms.Button btn_AddFixture;
        private System.Windows.Forms.Button btn_Cancel;
    }
}