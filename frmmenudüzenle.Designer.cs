namespace bitirme
{
    partial class frmmenudüzenle
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textfiyat = new System.Windows.Forms.TextBox();
            this.textporsiyon = new System.Windows.Forms.TextBox();
            this.textadi = new System.Windows.Forms.TextBox();
            this.richTextacıklama = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(16, 66);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(431, 391);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ürün Adı :";
            this.columnHeader1.Width = 131;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Birim Porsiyon :";
            this.columnHeader2.Width = 116;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fiyat : ";
            this.columnHeader3.Width = 114;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Açıklama :";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ürün id :";
            this.columnHeader5.Width = 31;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::bitirme.Properties.Resources.but;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(165, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "     Ürün ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textfiyat);
            this.panel1.Controls.Add(this.textporsiyon);
            this.panel1.Controls.Add(this.textadi);
            this.panel1.Controls.Add(this.richTextacıklama);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(453, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 391);
            this.panel1.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::bitirme.Properties.Resources.but;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(165, 355);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 33);
            this.button4.TabIndex = 6;
            this.button4.Text = "Kaydet";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label5.Location = new System.Drawing.Point(0, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 42);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ürün \r\nAçıklaması :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label4.Location = new System.Drawing.Point(26, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fiyat :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label3.Location = new System.Drawing.Point(3, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Porsiyon :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ürün Adı:";
            // 
            // textfiyat
            // 
            this.textfiyat.Location = new System.Drawing.Point(98, 172);
            this.textfiyat.Name = "textfiyat";
            this.textfiyat.Size = new System.Drawing.Size(189, 21);
            this.textfiyat.TabIndex = 6;
            // 
            // textporsiyon
            // 
            this.textporsiyon.Location = new System.Drawing.Point(98, 102);
            this.textporsiyon.Name = "textporsiyon";
            this.textporsiyon.Size = new System.Drawing.Size(189, 21);
            this.textporsiyon.TabIndex = 5;
            // 
            // textadi
            // 
            this.textadi.Location = new System.Drawing.Point(98, 28);
            this.textadi.Name = "textadi";
            this.textadi.Size = new System.Drawing.Size(189, 21);
            this.textadi.TabIndex = 4;
            // 
            // richTextacıklama
            // 
            this.richTextacıklama.Location = new System.Drawing.Point(98, 209);
            this.richTextacıklama.Name = "richTextacıklama";
            this.richTextacıklama.Size = new System.Drawing.Size(189, 99);
            this.richTextacıklama.TabIndex = 3;
            this.richTextacıklama.Text = "";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::bitirme.Properties.Resources.buta;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(269, 463);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 35);
            this.button2.TabIndex = 4;
            this.button2.Text = "Ürün Sil ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::bitirme.Properties.Resources.buta;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(269, 508);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 35);
            this.button3.TabIndex = 5;
            this.button3.Text = "     Ürün Düzenle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::bitirme.Properties.Resources._20c4da4dcfeb30e0f04126e62e0f5226;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(650, 494);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 48);
            this.panel2.TabIndex = 6;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = global::bitirme.Properties.Resources.geri1;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.Location = new System.Drawing.Point(12, 496);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(52, 47);
            this.button8.TabIndex = 11;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // frmmenudüzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::bitirme.Properties.Resources._1ana;
            this.ClientSize = new System.Drawing.Size(773, 555);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmmenudüzenle";
            this.Text = "frmmenudüzenle";
            this.Load += new System.EventHandler(this.frmmenudüzenle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textfiyat;
        private System.Windows.Forms.TextBox textporsiyon;
        private System.Windows.Forms.TextBox textadi;
        private System.Windows.Forms.RichTextBox richTextacıklama;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button8;
    }
}