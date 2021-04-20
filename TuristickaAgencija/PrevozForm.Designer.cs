using System;

namespace TuristickaAgencija
{
    partial class PrevozForm
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
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDodajPrevoz = new System.Windows.Forms.Button();
            this.btnObrisiPrevoz = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTipPrevoza = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCenaPrevoza = new System.Windows.Forms.TextBox();
            this.cmbxPrevozDo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbxDrzava = new System.Windows.Forms.ComboBox();
            this.Sifra = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.cmbxPrevozOd = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listView1.Location = new System.Drawing.Point(30, 37);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(410, 217);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sifra";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tip prevoza";
            this.columnHeader7.Width = 105;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Prevoz od";
            this.columnHeader8.Width = 108;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Prevoz do";
            this.columnHeader9.Width = 165;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Cena";
            // 
            // btnDodajPrevoz
            // 
            this.btnDodajPrevoz.Location = new System.Drawing.Point(115, 288);
            this.btnDodajPrevoz.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDodajPrevoz.Name = "btnDodajPrevoz";
            this.btnDodajPrevoz.Size = new System.Drawing.Size(83, 50);
            this.btnDodajPrevoz.TabIndex = 1;
            this.btnDodajPrevoz.Text = "Dodaj prevoz";
            this.btnDodajPrevoz.UseVisualStyleBackColor = true;
            this.btnDodajPrevoz.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnObrisiPrevoz
            // 
            this.btnObrisiPrevoz.Location = new System.Drawing.Point(248, 288);
            this.btnObrisiPrevoz.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnObrisiPrevoz.Name = "btnObrisiPrevoz";
            this.btnObrisiPrevoz.Size = new System.Drawing.Size(83, 50);
            this.btnObrisiPrevoz.TabIndex = 2;
            this.btnObrisiPrevoz.Text = "Obrisi prevoz";
            this.btnObrisiPrevoz.UseVisualStyleBackColor = true;
            this.btnObrisiPrevoz.Click += new System.EventHandler(this.btnObrisiPrevoz_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(504, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tip prevoza:";
            // 
            // txtTipPrevoza
            // 
            this.txtTipPrevoza.Location = new System.Drawing.Point(588, 49);
            this.txtTipPrevoza.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTipPrevoza.Name = "txtTipPrevoza";
            this.txtTipPrevoza.Size = new System.Drawing.Size(92, 20);
            this.txtTipPrevoza.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(514, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Prevoz od:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(479, 201);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Prevoz do(Grad):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(493, 241);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Cena prevoza:";
            // 
            // txtCenaPrevoza
            // 
            this.txtCenaPrevoza.Location = new System.Drawing.Point(588, 238);
            this.txtCenaPrevoza.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCenaPrevoza.Name = "txtCenaPrevoza";
            this.txtCenaPrevoza.Size = new System.Drawing.Size(92, 20);
            this.txtCenaPrevoza.TabIndex = 15;
            // 
            // cmbxPrevozDo
            // 
            this.cmbxPrevozDo.FormattingEnabled = true;
            this.cmbxPrevozDo.Location = new System.Drawing.Point(588, 198);
            this.cmbxPrevozDo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbxPrevozDo.Name = "cmbxPrevozDo";
            this.cmbxPrevozDo.Size = new System.Drawing.Size(92, 21);
            this.cmbxPrevozDo.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(480, 164);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Izaberite drzavu:";
            // 
            // cmbxDrzava
            // 
            this.cmbxDrzava.FormattingEnabled = true;
            this.cmbxDrzava.Location = new System.Drawing.Point(588, 161);
            this.cmbxDrzava.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbxDrzava.Name = "cmbxDrzava";
            this.cmbxDrzava.Size = new System.Drawing.Size(92, 21);
            this.cmbxDrzava.TabIndex = 18;
            this.cmbxDrzava.SelectedIndexChanged += new System.EventHandler(this.cmbxDrzava_SelectedIndexChanged);
            // 
            // Sifra
            // 
            this.Sifra.AutoSize = true;
            this.Sifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sifra.Location = new System.Drawing.Point(545, 91);
            this.Sifra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Sifra.Name = "Sifra";
            this.Sifra.Size = new System.Drawing.Size(37, 13);
            this.Sifra.TabIndex = 19;
            this.Sifra.Text = "Sifra:";
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(588, 88);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(92, 20);
            this.txtSifra.TabIndex = 20;
            // 
            // cmbxPrevozOd
            // 
            this.cmbxPrevozOd.FormattingEnabled = true;
            this.cmbxPrevozOd.Location = new System.Drawing.Point(588, 124);
            this.cmbxPrevozOd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbxPrevozOd.Name = "cmbxPrevozOd";
            this.cmbxPrevozOd.Size = new System.Drawing.Size(92, 21);
            this.cmbxPrevozOd.TabIndex = 21;
            // 
            // PrevozForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 385);
            this.Controls.Add(this.cmbxPrevozOd);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.Sifra);
            this.Controls.Add(this.cmbxDrzava);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbxPrevozDo);
            this.Controls.Add(this.txtCenaPrevoza);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTipPrevoza);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnObrisiPrevoz);
            this.Controls.Add(this.btnDodajPrevoz);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "PrevozForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prevoz";
            this.Load += new System.EventHandler(this.Prevoz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnDodajPrevoz;
        private System.Windows.Forms.Button btnObrisiPrevoz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTipPrevoza;
        private EventHandler button1_Click_1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCenaPrevoza;
        private System.Windows.Forms.ComboBox cmbxPrevozDo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbxDrzava;
        private System.Windows.Forms.Label Sifra;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.ComboBox cmbxPrevozOd;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}