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
    public partial class DestinacijeUDrzavi : Form
    {
        DataLayer dl = new DataLayer();
        private String NazivDrzave;
        public DestinacijeUDrzavi()
        {
            
            InitializeComponent();
        }
        public DestinacijeUDrzavi(String naziv)
        {
            this.NazivDrzave = naziv;
            InitializeComponent();
        }
        public void UcitajPodatke()
        {
            List<Grad> gradovi = dl.VratiGradoveUDrzavi(NazivDrzave);
            foreach (Grad g in gradovi)
            {
                ListViewItem item = new ListViewItem(new string[] { g.Naziv });
                listView1.Items.Add(item);
            }


        }
        private void DestinacijeUDrzavi_Load(object sender, EventArgs e)
        {
            this.UcitajPodatke();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Grad>("Grad");
            String naziv = txtNaziv.Text;

            if (naziv != "")
            {
                dl.DodajGrad(naziv,NazivDrzave);
            }
            else
                MessageBox.Show("Niste uneli potrebne podatke");

            listView1.Items.Clear();
            this.UcitajPodatke();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Grad>("Grad");
            String naziv = txtNaziv.Text;

            if (naziv != "")
            {
                dl.ObrisiGrad(naziv);
            }
            else
                MessageBox.Show("Niste selektovali agenciju za brisanje");

            listView1.Items.Clear();
            this.UcitajPodatke();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            txtNaziv.Text = listView1.SelectedItems[0].SubItems[0].Text;
        }
    }
}
