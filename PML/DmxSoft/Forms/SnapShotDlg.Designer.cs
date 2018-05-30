namespace DmxSoft.Forms
{
    partial class SnapShotDlg
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listSnap = new System.Windows.Forms.ListBox();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.btn_Take = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Delete);
            this.groupBox1.Controls.Add(this.btn_Apply);
            this.groupBox1.Controls.Add(this.listSnap);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available snapshot";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Take);
            this.groupBox2.Controls.Add(this.txt_Name);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New snapshot";
            // 
            // listSnap
            // 
            this.listSnap.FormattingEnabled = true;
            this.listSnap.Location = new System.Drawing.Point(6, 19);
            this.listSnap.Name = "listSnap";
            this.listSnap.Size = new System.Drawing.Size(243, 108);
            this.listSnap.TabIndex = 0;
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(71, 129);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(178, 23);
            this.btn_Apply.TabIndex = 1;
            this.btn_Apply.Text = "Apply";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name : ";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(60, 17);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(186, 20);
            this.txt_Name.TabIndex = 1;
            // 
            // btn_Take
            // 
            this.btn_Take.Location = new System.Drawing.Point(82, 41);
            this.btn_Take.Name = "btn_Take";
            this.btn_Take.Size = new System.Drawing.Size(81, 23);
            this.btn_Take.TabIndex = 2;
            this.btn_Take.Text = "Take";
            this.btn_Take.UseVisualStyleBackColor = true;
            this.btn_Take.Click += new System.EventHandler(this.btn_Take_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(6, 129);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(59, 23);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // SnapShotDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 236);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SnapShotDlg";
            this.Text = "Snapshot";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.ListBox listSnap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Take;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label1;
    }
}