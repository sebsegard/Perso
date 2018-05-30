namespace DmxCreator.Control
{
    partial class FixtureConfCtrl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Product = new System.Windows.Forms.TextBox();
            this.txt_Constructor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Check = new System.Windows.Forms.Button();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dmxAdressCtrl1 = new DmxCreator.Control.DmxAdressCtrl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Product);
            this.groupBox1.Controls.Add(this.txt_Constructor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 122);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fixture";
            // 
            // txt_Product
            // 
            this.txt_Product.Location = new System.Drawing.Point(30, 96);
            this.txt_Product.Name = "txt_Product";
            this.txt_Product.ReadOnly = true;
            this.txt_Product.Size = new System.Drawing.Size(176, 20);
            this.txt_Product.TabIndex = 2;
            // 
            // txt_Constructor
            // 
            this.txt_Constructor.Location = new System.Drawing.Point(30, 32);
            this.txt_Constructor.Name = "txt_Constructor";
            this.txt_Constructor.ReadOnly = true;
            this.txt_Constructor.Size = new System.Drawing.Size(176, 20);
            this.txt_Constructor.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Constructor :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Check);
            this.groupBox2.Controls.Add(this.txt_Address);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_Name);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(221, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 122);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paramaters";
            // 
            // btn_Check
            // 
            this.btn_Check.Location = new System.Drawing.Point(209, 94);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(48, 23);
            this.btn_Check.TabIndex = 5;
            this.btn_Check.Text = "Check";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(27, 96);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(176, 20);
            this.txt_Address.TabIndex = 4;
            this.txt_Address.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Address_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dmx Address";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(27, 32);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(176, 20);
            this.txt_Name.TabIndex = 2;
            this.txt_Name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Name_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name :";
            // 
            // dmxAdressCtrl1
            // 
            this.dmxAdressCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dmxAdressCtrl1.Location = new System.Drawing.Point(3, 131);
            this.dmxAdressCtrl1.Name = "dmxAdressCtrl1";
            this.dmxAdressCtrl1.Size = new System.Drawing.Size(550, 332);
            this.dmxAdressCtrl1.TabIndex = 0;
            // 
            // FixtureConfCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dmxAdressCtrl1);
            this.Name = "FixtureConfCtrl";
            this.Size = new System.Drawing.Size(556, 466);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DmxAdressCtrl dmxAdressCtrl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Product;
        private System.Windows.Forms.TextBox txt_Constructor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Check;
    }
}
