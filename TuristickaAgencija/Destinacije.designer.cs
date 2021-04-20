namespace TuristickaAgencija
{
    partial class Destinacije
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
            this.btnDodajTip = new System.Windows.Forms.Button();
            this.btnObrisiTip = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.txtTip = new System.Windows.Forms.TextBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDrzava = new System.Windows.Forms.Label();
            this.txtDrzava = new System.Windows.Forms.TextBox();
            this.btnDodajDrzavu = new System.Windows.Forms.Button();
            this.btnObrisiDrzavu = new System.Windows.Forms.Button();
            this.btnGradovi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Location = new System.Drawing.Point(42, 29);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(191, 158);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Naziv tipa aranzmana";
            this.columnHeader1.Width = 233;
            // 
            // btnDodajTip
            // 
            this.btnDodajTip.Location = new System.Drawing.Point(363, 73);
            this.btnDodajTip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDodajTip.Name = "btnDodajTip";
            this.btnDodajTip.Size = new System.Drawing.Size(142, 36);
            this.btnDodajTip.TabIndex = 1;
            this.btnDodajTip.Text = "Dodaj novi tip";
            this.btnDodajTip.UseVisualStyleBackColor = true;
            this.btnDodajTip.Click += new System.EventHandler(this.btnDodajTip_Click);
            // 
            // btnObrisiTip
            // 
            this.btnObrisiTip.Location = new System.Drawing.Point(363, 126);
            this.btnObrisiTip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnObrisiTip.Name = "btnObrisiTip";
            this.btnObrisiTip.Size = new System.Drawing.Size(142, 33);
            this.btnObrisiTip.TabIndex = 2;
            this.btnObrisiTip.Text = "Obrisi selektovani tip";
            this.btnObrisiTip.UseVisualStyleBackColor = true;
            this.btnObrisiTip.Click += new System.EventHandler(this.btnObrisiTip_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTip.Location = new System.Drawing.Point(269, 32);
            this.lblTip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(90, 13);
            this.lblTip.TabIndex = 3;
            this.lblTip.Text = "Tip aranzmana";
            // 
            // txtTip
            // 
            this.txtTip.Location = new System.Drawing.Point(363, 29);
            this.txtTip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTip.Name = "txtTip";
            this.txtTip.Size = new System.Drawing.Size(142, 20);
            this.txtTip.TabIndex = 4;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listView2.Location = new System.Drawing.Point(42, 226);
            this.listView2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(191, 161);
            this.listView2.TabIndex = 5;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Naziv drzave";
            this.columnHeader2.Width = 249;
            // 
            // lblDrzava
            // 
            this.lblDrzava.AutoSize = true;
            this.lblDrzava.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrzava.Location = new System.Drawing.Point(278, 219);
            this.lblDrzava.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDrzava.Name = "lblDrzava";
            this.lblDrzava.Size = new System.Drawing.Size(81, 13);
            this.lblDrzava.TabIndex = 6;
            this.lblDrzava.Text = "Naziv drzave";
            // 
            // txtDrzava
            // 
            this.txtDrzava.Location = new System.Drawing.Point(363, 212);
            this.txtDrzava.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDrzava.Name = "txtDrzava";
            this.txtDrzava.Size = new System.Drawing.Size(142, 20);
            this.txtDrzava.TabIndex = 7;
            // 
            // btnDodajDrzavu
            // 
            this.btnDodajDrzavu.Location = new System.Drawing.Point(363, 257);
            this.btnDodajDrzavu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDodajDrzavu.Name = "btnDodajDrzavu";
            this.btnDodajDrzavu.Size = new System.Drawing.Size(142, 31);
            this.btnDodajDrzavu.TabIndex = 8;
            this.btnDodajDrzavu.Text = "Dodaj drzavu";
            this.btnDodajDrzavu.UseVisualStyleBackColor = true;
            this.btnDodajDrzavu.Click += new System.EventHandler(this.btnDodajDrzavu_Click);
            // 
            // btnObrisiDrzavu
            // 
            this.btnObrisiDrzavu.Location = new System.Drawing.Point(363, 305);
            this.btnObrisiDrzavu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnObrisiDrzavu.Name = "btnObrisiDrzavu";
            this.btnObrisiDrzavu.Size = new System.Drawing.Size(142, 34);
            this.btnObrisiDrzavu.TabIndex = 9;
            this.btnObrisiDrzavu.Text = "Obrisi selektovanu drzavu";
            this.btnObrisiDrzavu.UseVisualStyleBackColor = true;
            this.btnObrisiDrzavu.Click += new System.EventHandler(this.btnObrisiDrzavu_Click);
            // 
            // btnGradovi
            // 
            this.btnGradovi.Location = new System.Drawing.Point(363, 353);
            this.btnGradovi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGradovi.Name = "btnGradovi";
            this.btnGradovi.Size = new System.Drawing.Size(142, 34);
            this.btnGradovi.TabIndex = 10;
            this.btnGradovi.Text = "Destinacije u drzavi";
            this.btnGradovi.UseVisualStyleBackColor = true;
            this.btnGradovi.Click += new System.EventHandler(this.btnGradovi_Click);
            // 
            // Destinacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 426);
            this.Controls.Add(this.btnGradovi);
            this.Controls.Add(this.btnObrisiDrzavu);
            this.Controls.Add(this.btnDodajDrzavu);
            this.Controls.Add(this.txtDrzava);
            this.Controls.Add(this.lblDrzava);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.txtTip);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnObrisiTip);
            this.Controls.Add(this.btnDodajTip);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Destinacije";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Destinacije";
            this.Load += new System.EventHandler(this.Destinacije_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnDodajTip;
        private System.Windows.Forms.Button btnObrisiTip;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.TextBox txtTip;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblDrzava;
        private System.Windows.Forms.TextBox txtDrzava;
        private System.Windows.Forms.Button btnDodajDrzavu;
        private System.Windows.Forms.Button btnObrisiDrzavu;
        private System.Windows.Forms.Button btnGradovi;
    }
}