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
    public partial class PrevozForm : Form
    {
        private String NazivKompanije;
        public PrevozForm(String naziv)
        {
            this.NazivKompanije = naziv;
            InitializeComponent();
        }
        DataLayer dl = new DataLayer();
        public void UcitajPodatke()
        {
            List<Prevoz> prevoz = dl.VratiPrevozIzKompanije(NazivKompanije);
            foreach (Prevoz p in prevoz)
            {

                ListViewItem item = new ListViewItem(new string[] {p.Sifra, p.TipPrevoza,p.PrevozOd,p.PrevozDo,p.Cena });
                listView1.Items.Add(item);
            }
        }

        private void Prevoz_Load(object sender, EventArgs e)
        {
            
            this.UcitajPodatke();
            List<Drzava> drzave = dl.VratiDrzave();
            foreach (Drzava d in drzave)
            {
                cmbxDrzava.Items.Add(d.Naziv);
            }


            List<Agencija> agencije = dl.VratiAgencije();
            foreach (Agencija g in agencije)
            {
                cmbxPrevozOd.Items.Add(g.Grad);
            }

            cmbxPrevozDo.Enabled = false;
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Prevoz>("Prevoz");
            String tip = txtTipPrevoza.Text;
            String sifra = txtSifra.Text;
            String prevozOd = cmbxPrevozOd.SelectedItem.ToString();
            String prevozDo = cmbxPrevozDo.Text;
            String cena = txtCenaPrevoza.Text;


            if (tip != "" && sifra != "" && prevozOd != "" && prevozDo != "" && cena != "")
            {
                dl.DodajPrevoz(sifra,tip,NazivKompanije,prevozOd,prevozDo,cena);
            }
            else
                MessageBox.Show("Niste uneli potrebne podatke");

            listView1.Items.Clear();
            this.UcitajPodatke();
            txtTipPrevoza.Clear();
            txtSifra.Clear();
            cmbxPrevozOd.Text = "";
            cmbxPrevozDo.Items.Clear();
            txtCenaPrevoza.Clear();
            cmbxPrevozDo.Items.Clear();
            cmbxPrevozDo.Text = "";
          

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*txtTipPrevoza.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txtNazivKompanije.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtSifra.Text = listView1.SelectedItems[0].SubItems[2].Text;*/
        }

        private void btnObrisiPrevoz_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            if (listView1.SelectedItems.Count == 1)
            {
                var collection = database.GetCollection<Prevoz>("Prevoz");
                String sifra = listView1.SelectedItems[0].SubItems[0].Text;
                String tip = listView1.SelectedItems[0].SubItems[1].Text;
                String naziv = NazivKompanije; 
                String prevozOd = listView1.SelectedItems[0].SubItems[3].Text;
                String prevozDo = listView1.SelectedItems[0].SubItems[4].Text;
                String cena = listView1.SelectedItems[0].SubItems[5].Text;
                if (tip != "" && naziv != "" && sifra != "" && prevozOd != "" && prevozDo != "" && cena != "")
                {
                    dl.ObrisiPrevoz(sifra);
                }
            }
            else if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Niste selektovali prevoz za brisanje");
            }
                listView1.Items.Clear();
                this.UcitajPodatke();
                txtTipPrevoza.Clear();
                txtSifra.Clear();
                cmbxPrevozOd.Text = "";
                cmbxPrevozDo.Items.Clear();
                txtCenaPrevoza.Clear();
        }

        private void btnDodajCenu_Click(object sender, EventArgs e)
        {
            /*var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Prevoz>("Prevoz");
            String tip = txtTipPrevoza.Text;
            String naziv = txtNazivKompanije.Text;
            String sifra = txtSifra.Text;
            String prevozOd = txtPrevozOd.Text;
            String prevozDo = txtPrevozDo.Text;


            if (tip != "" && naziv != "" && sifra != "" && prevozOd != "" && prevozDo != "")
            {
                dl.DodajPrevoz(tip, naziv, sifra, prevozOd, prevozDo);
            }
            else
                MessageBox.Show("Niste uneli potrebne podatke");

            listView1.Items.Clear();
            this.UcitajPodatke();
            txtTipPrevoza.Clear();
            txtNazivKompanije.Clear();
            txtSifra.Clear();
            txtPrevozOd.Clear();
            txtPrevozDo.Clear();*/
        }

        private void txtDrzava_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbxDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbxPrevozDo.Enabled = true;
            cmbxPrevozDo.Items.Clear();
            string drzava = cmbxDrzava.SelectedItem.ToString();
            List<Grad> gradovi = dl.VratiGradoveUDrzavi(drzava);
            foreach (Grad g in gradovi)
            {
                cmbxPrevozDo.Items.Add(g.Naziv);
            }
           
        }
    }
    }
    

