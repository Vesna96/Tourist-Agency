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
    public partial class Destinacije : Form
    {
        DataLayer dl = new DataLayer();
        public Destinacije()
        {
            InitializeComponent();
        }
        public void UcitajPodatkeOTipovima()
        {
            List<TipAranzmana> tipovi = dl.VratiTipoveAranzmana();
            foreach (TipAranzmana t in tipovi)
            {
                ListViewItem item = new ListViewItem(new string[] { t.Naziv });
                listView1.Items.Add(item);
            }

            
        }
        public void UcitajPodatkeODrzavama()
        {
            

            List<Drzava> drzave = dl.VratiDrzave();
            foreach (Drzava d in drzave)
            {
                ListViewItem item = new ListViewItem(new string[] { d.Naziv });
                listView2.Items.Add(item);
            }
        }
        private void Destinacije_Load(object sender, EventArgs e)
        {
            this.UcitajPodatkeOTipovima();
            this.UcitajPodatkeODrzavama();
        }

        private void btnDodajTip_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<TipAranzmana>("TipAranzmana");
            String naziv = txtTip.Text;
            
            if (naziv != "" )
            {
                dl.DodajTipAranzmana(naziv);
            }
            else
                MessageBox.Show("Niste uneli potrebne podatke");

            listView1.Items.Clear();
            this.UcitajPodatkeOTipovima();
        }

        private void btnObrisiTip_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<TipAranzmana>("TipAranzmana");
            String naziv = txtTip.Text;
           
            if (naziv != "" )
            {
                dl.ObrisiTipAranzmana(naziv);
            }
            else
                MessageBox.Show("Niste selektovali agenciju za brisanje");

            listView1.Items.Clear();
            this.UcitajPodatkeOTipovima();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            txtTip.Text = listView1.SelectedItems[0].SubItems[0].Text;
            
        }

        private void btnDodajDrzavu_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Drzava>("Drzava");
            String naziv = txtDrzava.Text;

            if (naziv != "")
            {
                dl.DodajDrzavu(naziv);
            }
            else
                MessageBox.Show("Niste uneli potrebne podatke");

            listView2.Items.Clear();
            this.UcitajPodatkeODrzavama();
        }

        private void btnObrisiDrzavu_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Drzava>("Drzava");
            String naziv = txtDrzava.Text;

            if (naziv != "")
            {
                dl.ObrisiGradoveUDrzavi(naziv);
                dl.ObrisiDrzavu(naziv);
               
            }
            else
                MessageBox.Show("Niste selektovali agenciju za brisanje");

            listView2.Items.Clear();
            this.UcitajPodatkeODrzavama();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
            {
                return;
            }
            txtDrzava.Text = listView2.SelectedItems[0].SubItems[0].Text;
        }

        private void btnGradovi_Click(object sender, EventArgs e)
        {
            String nazivDrzave = txtDrzava.Text;
            if (nazivDrzave != "")
            {
                DestinacijeUDrzavi form = new DestinacijeUDrzavi(nazivDrzave);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Niste izabrali drzavu!");
            }
        }
    }
}
