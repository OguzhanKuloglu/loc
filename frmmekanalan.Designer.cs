namespace bitirme
{
    partial class frmmekanalan
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmekanalan));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.asToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.listönsiparis = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonadekle = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listbekleyen = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asToolStripMenuItem,
            this.asToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(768, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // asToolStripMenuItem
            // 
            this.asToolStripMenuItem.Name = "asToolStripMenuItem";
            this.asToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // asToolStripMenuItem1
            // 
            this.asToolStripMenuItem1.Name = "asToolStripMenuItem1";
            this.asToolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 438);
            this.panel1.TabIndex = 0;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = global::bitirme.Properties.Resources.geri1;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.Location = new System.Drawing.Point(0, 512);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(52, 47);
            this.button8.TabIndex = 10;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // listönsiparis
            // 
            this.listönsiparis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listönsiparis.GridLines = true;
            this.listönsiparis.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listönsiparis.Location = new System.Drawing.Point(3, 0);
            this.listönsiparis.Name = "listönsiparis";
            this.listönsiparis.Size = new System.Drawing.Size(275, 389);
            this.listönsiparis.TabIndex = 0;
            this.listönsiparis.UseCompatibleStateImageBehavior = false;
            this.listönsiparis.View = System.Windows.Forms.View.Details;
            this.listönsiparis.SelectedIndexChanged += new System.EventHandler(this.listönsiparis_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Adisyon id :";
            this.columnHeader1.Width = 72;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Zaman :";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Kullanıcı id :";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Kullanıcı Adı :";
            this.columnHeader4.Width = 108;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.buttonadekle);
            this.panel2.Controls.Add(this.listönsiparis);
            this.panel2.Location = new System.Drawing.Point(450, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 435);
            this.panel2.TabIndex = 1;
            // 
            // buttonadekle
            // 
            this.buttonadekle.Location = new System.Drawing.Point(-2, 395);
            this.buttonadekle.Name = "buttonadekle";
            this.buttonadekle.Size = new System.Drawing.Size(277, 28);
            this.buttonadekle.TabIndex = 1;
            this.buttonadekle.Text = "Ekle";
            this.buttonadekle.UseVisualStyleBackColor = true;
            this.buttonadekle.Click += new System.EventHandler(this.buttonadekle_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::bitirme.Properties.Resources._20c4da4dcfeb30e0f04126e62e0f5226;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(656, 512);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 48);
            this.panel3.TabIndex = 7;
            // 
            // listbekleyen
            // 
            this.listbekleyen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listbekleyen.Location = new System.Drawing.Point(734, 343);
            this.listbekleyen.Name = "listbekleyen";
            this.listbekleyen.Size = new System.Drawing.Size(121, 97);
            this.listbekleyen.TabIndex = 11;
            this.listbekleyen.UseCompatibleStateImageBehavior = false;
            this.listbekleyen.View = System.Windows.Forms.View.Details;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmmekanalan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::bitirme.Properties.Resources._1ana;
            this.ClientSize = new System.Drawing.Size(768, 551);
            this.Controls.Add(this.listbekleyen);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmmekanalan";
            this.Text = "MASALAR";
            this.Load += new System.EventHandler(this.frmmekanalan_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem asToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem asToolStripMenuItem1;
        private System.Windows.Forms.ListView listönsiparis;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonadekle;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView listbekleyen;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}