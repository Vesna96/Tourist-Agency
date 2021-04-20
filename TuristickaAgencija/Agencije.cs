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
    public partial class Agencije : Form
    {
        DataLayer dl = new DataLayer();
        public Agencije()
        {
            InitializeComponent();
        }

        public void UcitajPodatke()
        {
            List<Agencija> agencije = dl.VratiAgencije();
            foreach (Agencija a in agencije)
            {
                ListViewItem item = new ListViewItem(new string[] { a.SifraAgencije,a.Grad, a.AdresaAgencije });
                listView1.Items.Add(item);
            }
        }

        private void Agencije_Load(object sender, EventArgs e)
        {
            this.UcitajPodatke();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Agencija>("Agencija");
            String sifra = txtSifra.Text;
            String adresa = txtAdresa.Text;
            String grad = txtGrad.Text;
            if(sifra != "" && adresa != "" && grad != "")
            {
                dl.DodajAgenciju(sifra,grad, adresa);
            }
            else
                MessageBox.Show("Niste uneli potrebne podatke");

            listView1.Items.Clear();
            this.UcitajPodatke();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }

            txtSifra.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txtGrad.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtAdresa.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Agencija>("Agencija");
            String sifra = txtSifra.Text;
            String adresa = txtAdresa.Text;
            if (sifra != "" && adresa != "")
            {
                dl.ObrisiAgenciju(sifra);
            }
            else
                MessageBox.Show("Niste selektovali agenciju za brisanje");

            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sifra = txtSifra.Text;
            String adresa = txtAdresa.Text;
            String grad = txtGrad.Text;
            dl.AzurirajAgenciju(sifra,grad, adresa);
            listView1.Items.Clear();
            this.UcitajPodatke();
        }
    }
}
