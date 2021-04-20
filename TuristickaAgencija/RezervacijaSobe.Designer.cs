namespace TuristickaAgencija
{
    partial class RezervacijaSobe
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
            this.txtCenaHotela = new System.Windows.Forms.Label();
            this.txtCenaprevoza = new System.Windows.Forms.Label();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.rbtnGotovina = new System.Windows.Forms.RadioButton();
            this.rbtnRate = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPopust = new System.Windows.Forms.Label();
            this.numBrojRata = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxRate = new System.Windows.Forms.Label();
            this.cenaRate = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLicna = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRezervisi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbxPansioni = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrojRata)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCenaHotela
            // 
            this.txtCenaHotela.AutoSize = true;
            this.txtCenaHotela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCenaHotela.Location = new System.Drawing.Point(30, 50);
            this.txtCenaHotela.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtCenaHotela.Name = "txtCenaHotela";
            this.txtCenaHotela.Size = new System.Drawing.Size(72, 13);
            this.txtCenaHotela.TabIndex = 0;
            this.txtCenaHotela.Text = "cenaHotela";
            // 
            // txtCenaprevoza
            // 
            this.txtCenaprevoza.AutoSize = true;
            this.txtCenaprevoza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCenaprevoza.Location = new System.Drawing.Point(21, 96);
            this.txtCenaprevoza.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtCenaprevoza.Name = "txtCenaprevoza";
            this.txtCenaprevoza.Size = new System.Drawing.Size(81, 13);
            this.txtCenaprevoza.TabIndex = 1;
            this.txtCenaprevoza.Text = "cenaPrevoza";
            // 
            // lblUkupno
            // 
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUkupno.Location = new System.Drawing.Point(26, 269);
            this.lblUkupno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(49, 13);
            this.lblUkupno.TabIndex = 2;
            this.lblUkupno.Text = "ukupno";
            // 
            // rbtnGotovina
            // 
            this.rbtnGotovina.AutoSize = true;
            this.rbtnGotovina.Location = new System.Drawing.Point(14, 57);
            this.rbtnGotovina.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnGotovina.Name = "rbtnGotovina";
            this.rbtnGotovina.Size = new System.Drawing.Size(76, 17);
            this.rbtnGotovina.TabIndex = 3;
            this.rbtnGotovina.TabStop = true;
            this.rbtnGotovina.Text = "Gotovina";
            this.rbtnGotovina.UseVisualStyleBackColor = true;
            this.rbtnGotovina.CheckedChanged += new System.EventHandler(this.rbtnGotovina_CheckedChanged);
            // 
            // rbtnRate
            // 
            this.rbtnRate.AutoSize = true;
            this.rbtnRate.Location = new System.Drawing.Point(14, 25);
            this.rbtnRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnRate.Name = "rbtnRate";
            this.rbtnRate.Size = new System.Drawing.Size(111, 17);
            this.rbtnRate.TabIndex = 4;
            this.rbtnRate.TabStop = true;
            this.rbtnRate.Text = "Placanje u rate";
            this.rbtnRate.UseVisualStyleBackColor = true;
            this.rbtnRate.CheckedChanged += new System.EventHandler(this.rbtnRate_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnRate);
            this.groupBox1.Controls.Add(this.rbtnGotovina);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(182, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(150, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nacin placanja";
            // 
            // lblPopust
            // 
            this.lblPopust.AutoSize = true;
            this.lblPopust.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPopust.Location = new System.Drawing.Point(30, 224);
            this.lblPopust.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPopust.Name = "lblPopust";
            this.lblPopust.Size = new System.Drawing.Size(45, 13);
            this.lblPopust.TabIndex = 6;
            this.lblPopust.Text = "popust";
            // 
            // numBrojRata
            // 
            this.numBrojRata.Location = new System.Drawing.Point(196, 183);
            this.numBrojRata.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numBrojRata.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numBrojRata.Name = "numBrojRata";
            this.numBrojRata.Size = new System.Drawing.Size(108, 20);
            this.numBrojRata.TabIndex = 7;
            this.numBrojRata.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numBrojRata.ValueChanged += new System.EventHandler(this.numBrojRata_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Izaberite broj rata";
            // 
            // lblMaxRate
            // 
            this.lblMaxRate.AutoSize = true;
            this.lblMaxRate.Location = new System.Drawing.Point(197, 211);
            this.lblMaxRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxRate.Name = "lblMaxRate";
            this.lblMaxRate.Size = new System.Drawing.Size(35, 13);
            this.lblMaxRate.TabIndex = 9;
            this.lblMaxRate.Text = "label2";
            this.lblMaxRate.Click += new System.EventHandler(this.lblMaxRate_Click);
            // 
            // cenaRate
            // 
            this.cenaRate.AutoSize = true;
            this.cenaRate.Location = new System.Drawing.Point(197, 246);
            this.cenaRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cenaRate.Name = "cenaRate";
            this.cenaRate.Size = new System.Drawing.Size(35, 13);
            this.cenaRate.TabIndex = 10;
            this.cenaRate.Text = "label2";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(453, 47);
            this.txtIme.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(110, 20);
            this.txtIme.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(418, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ime ";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(453, 75);
            this.txtPrezime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(110, 20);
            this.txtPrezime.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(398, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Prezime";
            // 
            // txtLicna
            // 
            this.txtLicna.Location = new System.Drawing.Point(453, 106);
            this.txtLicna.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLicna.Name = "txtLicna";
            this.txtLicna.Size = new System.Drawing.Size(110, 20);
            this.txtLicna.TabIndex = 15;
            this.txtLicna.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(356, 109);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Broj licne karte";
            // 
            // btnRezervisi
            // 
            this.btnRezervisi.Location = new System.Drawing.Point(453, 154);
            this.btnRezervisi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRezervisi.Name = "btnRezervisi";
            this.btnRezervisi.Size = new System.Drawing.Size(110, 38);
            this.btnRezervisi.TabIndex = 17;
            this.btnRezervisi.Text = "Rezervisi";
            this.btnRezervisi.UseVisualStyleBackColor = true;
            this.btnRezervisi.Click += new System.EventHandler(this.btnRezervisi_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Izaberite pansion";
            // 
            // cmbxPansioni
            // 
            this.cmbxPansioni.FormattingEnabled = true;
            this.cmbxPansioni.Location = new System.Drawing.Point(11, 183);
            this.cmbxPansioni.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbxPansioni.Name = "cmbxPansioni";
            this.cmbxPansioni.Size = new System.Drawing.Size(140, 21);
            this.cmbxPansioni.TabIndex = 19;
            this.cmbxPansioni.SelectedIndexChanged += new System.EventHandler(this.cmbxPansioni_SelectedIndexChanged);
            // 
            // RezervacijaSobe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 349);
            this.Controls.Add(this.cmbxPansioni);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRezervisi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLicna);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.cenaRate);
            this.Controls.Add(this.lblMaxRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numBrojRata);
            this.Controls.Add(this.lblPopust);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.txtCenaprevoza);
            this.Controls.Add(this.txtCenaHotela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "RezervacijaSobe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RezervacijaSobe";
            this.Load += new System.EventHandler(this.RezervacijaSobe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrojRata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtCenaHotela;
        private System.Windows.Forms.Label txtCenaprevoza;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.RadioButton rbtnGotovina;
        private System.Windows.Forms.RadioButton rbtnRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPopust;
        private System.Windows.Forms.NumericUpDown numBrojRata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaxRate;
        private System.Windows.Forms.Label cenaRate;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLicna;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRezervisi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbxPansioni;
    }
}