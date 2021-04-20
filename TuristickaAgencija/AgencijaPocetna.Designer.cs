namespace TuristickaAgencija
{
    partial class AgencijaPocetna
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
            this.cmbxDrzave = new System.Windows.Forms.ComboBox();
            this.cmbxGradovi = new System.Windows.Forms.ComboBox();
            this.listViewAranzmani = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.txtLicna = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbxOprema = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbxDrzave
            // 
            this.cmbxDrzave.FormattingEnabled = true;
            this.cmbxDrzave.Location = new System.Drawing.Point(12, 80);
            this.cmbxDrzave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbxDrzave.Name = "cmbxDrzave";
            this.cmbxDrzave.Size = new System.Drawing.Size(121, 24);
            this.cmbxDrzave.TabIndex = 0;
            this.cmbxDrzave.Text = "Izaberite drzavu";
            this.cmbxDrzave.SelectedIndexChanged += new System.EventHandler(this.cmbxDrzave_SelectedIndexChanged);
            // 
            // cmbxGradovi
            // 
            this.cmbxGradovi.FormattingEnabled = true;
            this.cmbxGradovi.Location = new System.Drawing.Point(152, 80);
            this.cmbxGradovi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbxGradovi.Name = "cmbxGradovi";
            this.cmbxGradovi.Size = new System.Drawing.Size(121, 24);
            this.cmbxGradovi.TabIndex = 1;
            this.cmbxGradovi.Text = "Izaberite grad";
            this.cmbxGradovi.SelectedIndexChanged += new System.EventHandler(this.cmbxGradovi_SelectedIndexChanged);
            // 
            // listViewAranzmani
            // 
            this.listViewAranzmani.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewAranzmani.Location = new System.Drawing.Point(24, 132);
            this.listViewAranzmani.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewAranzmani.Name = "listViewAranzmani";
            this.listViewAranzmani.Size = new System.Drawing.Size(204, 306);
            this.listViewAranzmani.TabIndex = 3;
            this.listViewAranzmani.UseCompatibleStateImageBehavior = false;
            this.listViewAranzmani.View = System.Windows.Forms.View.Details;
            this.listViewAranzmani.SelectedIndexChanged += new System.EventHandler(this.listViewAranzmani_SelectedIndexChanged);
            this.listViewAranzmani.DoubleClick += new System.EventHandler(this.listViewAranzmani_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hotel";
            this.columnHeader3.Width = 150;
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(465, 65);
            this.btnPretrazi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(123, 52);
            this.btnPretrazi.TabIndex = 5;
            this.btnPretrazi.Text = "Pretrazi";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // txtLicna
            // 
            this.txtLicna.Location = new System.Drawing.Point(456, 238);
            this.txtLicna.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLicna.Name = "txtLicna";
            this.txtLicna.Size = new System.Drawing.Size(159, 22);
            this.txtLicna.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(369, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Uneti broj licne karte za pregled rezervacija";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 293);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 49);
            this.button1.TabIndex = 8;
            this.button1.Text = "Pregledaj rezervacije";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbxOprema
            // 
            this.cmbxOprema.FormattingEnabled = true;
            this.cmbxOprema.Location = new System.Drawing.Point(298, 78);
            this.cmbxOprema.Name = "cmbxOprema";
            this.cmbxOprema.Size = new System.Drawing.Size(121, 24);
            this.cmbxOprema.TabIndex = 9;
            this.cmbxOprema.Text = "Izaberite sadrzaj";
            // 
            // AgencijaPocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 450);
            this.Controls.Add(this.cmbxOprema);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLicna);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.listViewAranzmani);
            this.Controls.Add(this.cmbxGradovi);
            this.Controls.Add(this.cmbxDrzave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "AgencijaPocetna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgencijaPocetna";
            this.Load += new System.EventHandler(this.AgencijaPocetna_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxDrzave;
        private System.Windows.Forms.ComboBox cmbxGradovi;
        private System.Windows.Forms.ListView listViewAranzmani;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.TextBox txtLicna;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbxOprema;
    }
}