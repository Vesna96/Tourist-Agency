using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;



namespace TuristickaAgencija
{
    public partial class Form1 : Form
    {
        DataLayer dl = new DataLayer();
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String sifra = txtSifra.Text;
            
            if (sifra != "")
            {
                if (rbtnAdmin.Checked)
                {
                    Admin a = dl.VratiAdmina(sifra);
                    if (a != null)
                    {
                        AdminPocetna forma = new AdminPocetna(sifra);
                        forma.ShowDialog();
                    }
                    else
                        MessageBox.Show("Nevalidna sifra!");

                }
                else if (rbtnAgencija.Checked)
                {
                    Agencija a = dl.VratiAgenciju(sifra);
                    if (a != null)
                    {
                        AgencijaPocetna forma = new AgencijaPocetna(a);
                        forma.ShowDialog();
                    }
                    else
                        MessageBox.Show("Nevalidna sifra!");

                }
                else
                    MessageBox.Show("Niste odabrali profil za prijavljivanje");

            }
            else
                MessageBox.Show("Niste uneli sifru!");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
