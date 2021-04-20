namespace TuristickaAgencija
{
    partial class AdminPocetna
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgencije = new System.Windows.Forms.Button();
            this.btnDestinacije = new System.Windows.Forms.Button();
            this.btnPrevoz = new System.Windows.Forms.Button();
            this.btnAranzmani = new System.Windows.Forms.Button();
            this.btnHoteli = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // btnAgencije
            // 
            this.btnAgencije.Location = new System.Drawing.Point(41, 73);
            this.btnAgencije.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgencije.Name = "btnAgencije";
            this.btnAgencije.Size = new System.Drawing.Size(86, 63);
            this.btnAgencije.TabIndex = 1;
            this.btnAgencije.Text = "Agencije";
            this.btnAgencije.UseVisualStyleBackColor = true;
            this.btnAgencije.Click += new System.EventHandler(this.btnAgencije_Click);
            // 
            // btnDestinacije
            // 
            this.btnDestinacije.Location = new System.Drawing.Point(145, 73);
            this.btnDestinacije.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDestinacije.Name = "btnDestinacije";
            this.btnDestinacije.Size = new System.Drawing.Size(85, 63);
            this.btnDestinacije.TabIndex = 2;
            this.btnDestinacije.Text = "Destinacije";
            this.btnDestinacije.UseVisualStyleBackColor = true;
            this.btnDestinacije.Click += new System.EventHandler(this.btnDestinacije_Click);
            // 
            // btnPrevoz
            // 
            this.btnPrevoz.Location = new System.Drawing.Point(248, 73);
            this.btnPrevoz.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrevoz.Name = "btnPrevoz";
            this.btnPrevoz.Size = new System.Drawing.Size(86, 63);
            this.btnPrevoz.TabIndex = 3;
            this.btnPrevoz.Text = "Prevoz";
            this.btnPrevoz.UseVisualStyleBackColor = true;
            this.btnPrevoz.Click += new System.EventHandler(this.btnPrevoz_Click);
            // 
            // btnAranzmani
            // 
            this.btnAranzmani.Location = new System.Drawing.Point(354, 73);
            this.btnAranzmani.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAranzmani.Name = "btnAranzmani";
            this.btnAranzmani.Size = new System.Drawing.Size(87, 63);
            this.btnAranzmani.TabIndex = 4;
            this.btnAranzmani.Text = "Aranzmani";
            this.btnAranzmani.UseVisualStyleBackColor = true;
            this.btnAranzmani.Click += new System.EventHandler(this.btnRute_Click);
            // 
            // btnHoteli
            // 
            this.btnHoteli.Location = new System.Drawing.Point(458, 73);
            this.btnHoteli.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHoteli.Name = "btnHoteli";
            this.btnHoteli.Size = new System.Drawing.Size(85, 65);
            this.btnHoteli.TabIndex = 5;
            this.btnHoteli.Text = "Hoteli";
            this.btnHoteli.UseVisualStyleBackColor = true;
            this.btnHoteli.Click += new System.EventHandler(this.btnHoteli_Click);
            // 
            // AdminPocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 247);
            this.Controls.Add(this.btnHoteli);
            this.Controls.Add(this.btnAranzmani);
            this.Controls.Add(this.btnPrevoz);
            this.Controls.Add(this.btnDestinacije);
            this.Controls.Add(this.btnAgencije);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "AdminPocetna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPocetna";
            this.Load += new System.EventHandler(this.AdminPocetna_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgencije;
        private System.Windows.Forms.Button btnDestinacije;
        private System.Windows.Forms.Button btnPrevoz;
        private System.Windows.Forms.Button btnAranzmani;
        private System.Windows.Forms.Button btnHoteli;
    }
}