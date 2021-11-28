namespace WindowsFormsApplication1.PL
{
    partial class FRM_CATEGORIES
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
            this.butnfirst = new System.Windows.Forms.Button();
            this.dataGridViewcat = new System.Windows.Forms.DataGridView();
            this.butnlast = new System.Windows.Forms.Button();
            this.txtdes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butnnext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.butnpriv = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.butnclose = new System.Windows.Forms.Button();
            this.butncatwithproducts = new System.Windows.Forms.Button();
            this.butnalltopdf = new System.Windows.Forms.Button();
            this.butnprintone = new System.Windows.Forms.Button();
            this.butnprintall = new System.Windows.Forms.Button();
            this.butnupdate = new System.Windows.Forms.Button();
            this.butnremove = new System.Windows.Forms.Button();
            this.butnadd = new System.Windows.Forms.Button();
            this.butnnew = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcat)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butnfirst);
            this.groupBox1.Controls.Add(this.dataGridViewcat);
            this.groupBox1.Controls.Add(this.butnlast);
            this.groupBox1.Controls.Add(this.txtdes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.butnnext);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.butnpriv);
            this.groupBox1.Controls.Add(this.txtid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(793, 266);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات الصنف";
            // 
            // butnfirst
            // 
            this.butnfirst.Location = new System.Drawing.Point(718, 183);
            this.butnfirst.Name = "butnfirst";
            this.butnfirst.Size = new System.Drawing.Size(56, 23);
            this.butnfirst.TabIndex = 10;
            this.butnfirst.Text = "||<<";
            this.butnfirst.UseVisualStyleBackColor = true;
            this.butnfirst.Click += new System.EventHandler(this.butnfirst_Click);
            // 
            // dataGridViewcat
            // 
            this.dataGridViewcat.AllowUserToAddRows = false;
            this.dataGridViewcat.AllowUserToDeleteRows = false;
            this.dataGridViewcat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewcat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewcat.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridViewcat.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewcat.Name = "dataGridViewcat";
            this.dataGridViewcat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewcat.Size = new System.Drawing.Size(428, 241);
            this.dataGridViewcat.TabIndex = 0;
            // 
            // butnlast
            // 
            this.butnlast.Location = new System.Drawing.Point(440, 183);
            this.butnlast.Name = "butnlast";
            this.butnlast.Size = new System.Drawing.Size(56, 23);
            this.butnlast.TabIndex = 9;
            this.butnlast.Text = ">>||";
            this.butnlast.UseVisualStyleBackColor = true;
            this.butnlast.Click += new System.EventHandler(this.butnlast_Click);
            // 
            // txtdes
            // 
            this.txtdes.Location = new System.Drawing.Point(440, 89);
            this.txtdes.Multiline = true;
            this.txtdes.Name = "txtdes";
            this.txtdes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtdes.Size = new System.Drawing.Size(278, 64);
            this.txtdes.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(588, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(724, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "رقم النوع:";
            // 
            // butnnext
            // 
            this.butnnext.Location = new System.Drawing.Point(518, 183);
            this.butnnext.Name = "butnnext";
            this.butnnext.Size = new System.Drawing.Size(61, 23);
            this.butnnext.TabIndex = 7;
            this.butnnext.Text = ">>";
            this.butnnext.UseVisualStyleBackColor = true;
            this.butnnext.Click += new System.EventHandler(this.butnnext_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(717, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "وصف النوع:";
            // 
            // butnpriv
            // 
            this.butnpriv.Location = new System.Drawing.Point(644, 183);
            this.butnpriv.Name = "butnpriv";
            this.butnpriv.Size = new System.Drawing.Size(58, 23);
            this.butnpriv.TabIndex = 6;
            this.butnpriv.Text = "<<";
            this.butnpriv.UseVisualStyleBackColor = true;
            this.butnpriv.Click += new System.EventHandler(this.butnpriv_Click);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(599, 60);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(119, 20);
            this.txtid.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.butnclose);
            this.groupBox3.Controls.Add(this.butncatwithproducts);
            this.groupBox3.Controls.Add(this.butnalltopdf);
            this.groupBox3.Controls.Add(this.butnprintone);
            this.groupBox3.Controls.Add(this.butnprintall);
            this.groupBox3.Controls.Add(this.butnupdate);
            this.groupBox3.Controls.Add(this.butnremove);
            this.groupBox3.Controls.Add(this.butnadd);
            this.groupBox3.Controls.Add(this.butnnew);
            this.groupBox3.Location = new System.Drawing.Point(12, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(791, 97);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "العمليات المتاحة ";
            // 
            // butnclose
            // 
            this.butnclose.Location = new System.Drawing.Point(164, 57);
            this.butnclose.Name = "butnclose";
            this.butnclose.Size = new System.Drawing.Size(75, 23);
            this.butnclose.TabIndex = 8;
            this.butnclose.Text = "خروج";
            this.butnclose.UseVisualStyleBackColor = true;
            this.butnclose.Click += new System.EventHandler(this.butnclose_Click);
            // 
            // butncatwithproducts
            // 
            this.butncatwithproducts.Location = new System.Drawing.Point(258, 57);
            this.butncatwithproducts.Name = "butncatwithproducts";
            this.butncatwithproducts.Size = new System.Drawing.Size(224, 23);
            this.butncatwithproducts.TabIndex = 7;
            this.butncatwithproducts.Text = "حفظ الصنف الحالى مع منتجاتة فى ملف pdf";
            this.butncatwithproducts.UseVisualStyleBackColor = true;
            this.butncatwithproducts.Click += new System.EventHandler(this.butncatwithproducts_Click);
            // 
            // butnalltopdf
            // 
            this.butnalltopdf.Location = new System.Drawing.Point(504, 57);
            this.butnalltopdf.Name = "butnalltopdf";
            this.butnalltopdf.Size = new System.Drawing.Size(172, 23);
            this.butnalltopdf.TabIndex = 6;
            this.butnalltopdf.Text = "حفظ لائحة الاصناف ف ملف pdf";
            this.butnalltopdf.UseVisualStyleBackColor = true;
            this.butnalltopdf.Click += new System.EventHandler(this.butnalltopdf_Click);
            // 
            // butnprintone
            // 
            this.butnprintone.Location = new System.Drawing.Point(55, 19);
            this.butnprintone.Name = "butnprintone";
            this.butnprintone.Size = new System.Drawing.Size(162, 23);
            this.butnprintone.TabIndex = 5;
            this.butnprintone.Text = "طباعة الصنف الحالى بمنتجاتة";
            this.butnprintone.UseVisualStyleBackColor = true;
            this.butnprintone.Click += new System.EventHandler(this.butnprintone_Click);
            // 
            // butnprintall
            // 
            this.butnprintall.Location = new System.Drawing.Point(233, 19);
            this.butnprintall.Name = "butnprintall";
            this.butnprintall.Size = new System.Drawing.Size(132, 23);
            this.butnprintall.TabIndex = 4;
            this.butnprintall.Text = "طباعة كل الاصناف";
            this.butnprintall.UseVisualStyleBackColor = true;
            this.butnprintall.Click += new System.EventHandler(this.butnprintall_Click);
            // 
            // butnupdate
            // 
            this.butnupdate.Location = new System.Drawing.Point(382, 19);
            this.butnupdate.Name = "butnupdate";
            this.butnupdate.Size = new System.Drawing.Size(75, 23);
            this.butnupdate.TabIndex = 3;
            this.butnupdate.Text = "تعديل";
            this.butnupdate.UseVisualStyleBackColor = true;
            this.butnupdate.Click += new System.EventHandler(this.butnupdate_Click);
            // 
            // butnremove
            // 
            this.butnremove.Location = new System.Drawing.Point(477, 19);
            this.butnremove.Name = "butnremove";
            this.butnremove.Size = new System.Drawing.Size(75, 23);
            this.butnremove.TabIndex = 2;
            this.butnremove.Text = "حذف";
            this.butnremove.UseVisualStyleBackColor = true;
            this.butnremove.Click += new System.EventHandler(this.butnremove_Click);
            // 
            // butnadd
            // 
            this.butnadd.Enabled = false;
            this.butnadd.Location = new System.Drawing.Point(571, 19);
            this.butnadd.Name = "butnadd";
            this.butnadd.Size = new System.Drawing.Size(75, 23);
            this.butnadd.TabIndex = 1;
            this.butnadd.Text = "اضافة ";
            this.butnadd.UseVisualStyleBackColor = true;
            this.butnadd.Click += new System.EventHandler(this.butnadd_Click);
            // 
            // butnnew
            // 
            this.butnnew.Location = new System.Drawing.Point(662, 19);
            this.butnnew.Name = "butnnew";
            this.butnnew.Size = new System.Drawing.Size(75, 23);
            this.butnnew.TabIndex = 0;
            this.butnnew.Text = "جديد";
            this.butnnew.UseVisualStyleBackColor = true;
            this.butnnew.Click += new System.EventHandler(this.butnnew_Click);
            // 
            // FRM_CATEGORIES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 385);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_CATEGORIES";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ادارة الانواع";
            this.Load += new System.EventHandler(this.FRM_CATEGORIES_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcat)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewcat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butnnext;
        private System.Windows.Forms.Button butnpriv;
        private System.Windows.Forms.TextBox txtdes;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button butnfirst;
        private System.Windows.Forms.Button butnlast;
        private System.Windows.Forms.Button butnclose;
        private System.Windows.Forms.Button butncatwithproducts;
        private System.Windows.Forms.Button butnalltopdf;
        private System.Windows.Forms.Button butnprintone;
        private System.Windows.Forms.Button butnprintall;
        private System.Windows.Forms.Button butnupdate;
        private System.Windows.Forms.Button butnremove;
        private System.Windows.Forms.Button butnadd;
        private System.Windows.Forms.Button butnnew;
    }
}