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
    public partial class AdminPocetna : Form
    {
        public String sifra;
        public AdminPocetna()
        {
            InitializeComponent();
        }
        public AdminPocetna(String s)
        {
            InitializeComponent();
            this.sifra = s;
        }
       
        
        private void AdminPocetna_Load(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");
          
            var collection = database.GetCollection<Admin>("Admin");
            var query = Query.EQ("SifraAdmin", sifra);
            Admin a = collection.Find(query).FirstOrDefault();
            label1.Text = a.ImeAdmin + " " + a.PrezimeAdmin;
        }

        private void btnAgencije_Click(object sender, EventArgs e)
        {
            Agencije form = new Agencije();
            form.ShowDialog();
        }

        private void btnDestinacije_Click(object sender, EventArgs e)
        {
            Destinacije form = new Destinacije();
            form.ShowDialog();
        }

        private void btnPrevoz_Click(object sender, EventArgs e)
        {
            PrevozKompanije form = new PrevozKompanije();
            form.ShowDialog();
        }

        private void btnRute_Click(object sender, EventArgs e)
        {
            AranzmaniAdmin form = new AranzmaniAdmin();
            form.ShowDialog();
        }

        private void btnHoteli_Click(object sender, EventArgs e)
        {
            Hoteli form = new Hoteli();
            form.ShowDialog();
        }
    }
}
