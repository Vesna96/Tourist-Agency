using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;


namespace TuristickaAgencija
{
    public partial class KorisnikRezervacije : Form
    {
        private DataLayer dl = new DataLayer();
        public String BrojLicneKarte;
        public KorisnikRezervacije(String blk)
        {
            BrojLicneKarte = blk;
            InitializeComponent();
        }

        private void popuniListView()
        {
            List<RezervacijaAranzmana> rezervacije = dl.VratiRezervacijeKorisnika(BrojLicneKarte);
            foreach (RezervacijaAranzmana rez in rezervacije)
            {
                Aranzman ar = dl.VratiAranzman(rez.SifraAranzmana);
                ListViewItem item = new ListViewItem(new string[] { rez.NazivHotela,ar.DatumOd.ToShortDateString(),
                ar.DatumDo.ToShortDateString(),rez.TipSobe,rez.TipPansiona,rez.Prevoznik,rez.UkupnaCena.ToString(),
                rez.Id.ToString()});
                listView1.Items.Add(item);
            }
        }

        private void KorisnikRezervacije_Load(object sender, EventArgs e)
        {
           
            List<RezervacijaAranzmana> rezervacije = dl.VratiRezervacijeKorisnika(BrojLicneKarte);
            RezervacijaAranzmana prvi = rezervacije.FirstOrDefault();
            if(prvi != null)
            {
                label1.Text = prvi.Ime + " " + prvi.Prezime;
            }

            this.popuniListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                String rezervacija = listView1.SelectedItems[0].SubItems[7].Text;
                ObjectId idRezervacije = MongoDB.Bson.ObjectId.Parse(rezervacija);
                RezervacijaAranzmana rez = dl.VratiRezervacijuAranzmana(idRezervacije);
                dl.ObrisiRezervaciju(idRezervacije);
                int brojKreveta;
                if (rez.TipSobe == "Jednokrevetna")
                {
                    brojKreveta = 1;
                }
                else if (rez.TipSobe == "Dvokrevetna")
                {
                    brojKreveta = 2;
                }
                else if (rez.TipSobe == "Trokrevetna")
                {
                    brojKreveta = 3;
                }
                else if (rez.TipSobe == "Cetvorokrevetna")
                {
                    brojKreveta = 4;
                }
                else
                {
                    brojKreveta = 5;
                }
                Aranzman ar = dl.VratiAranzman(rez.SifraAranzmana);
                if (brojKreveta == 1)
                {
                    dl.AzurirajAranzmanSlobodneSobe(ar.Sifra, ar.BrojSlobodnihJednokrevetnih + 1,
                        ar.BrojSlobodnihDvokrevetnih, ar.BrojSlobodnihTrokrevetnih, ar.BrojSlobodnihCetvorokrevetnih,
                        ar.BrojSlobodnihPetokrevetnih);
                }
                else if (brojKreveta == 2)
                {
                    dl.AzurirajAranzmanSlobodneSobe(ar.Sifra, ar.BrojSlobodnihJednokrevetnih,
                        ar.BrojSlobodnihDvokrevetnih + 1, ar.BrojSlobodnihTrokrevetnih, ar.BrojSlobodnihCetvorokrevetnih,
                        ar.BrojSlobodnihPetokrevetnih);
                }
                else if (brojKreveta == 3)
                {
                    dl.AzurirajAranzmanSlobodneSobe(ar.Sifra, ar.BrojSlobodnihJednokrevetnih,
                        ar.BrojSlobodnihDvokrevetnih, ar.BrojSlobodnihTrokrevetnih + 1, ar.BrojSlobodnihCetvorokrevetnih,
                        ar.BrojSlobodnihPetokrevetnih);
                }
                else if (brojKreveta == 4)
                {
                    dl.AzurirajAranzmanSlobodneSobe(ar.Sifra, ar.BrojSlobodnihJednokrevetnih,
                        ar.BrojSlobodnihDvokrevetnih, ar.BrojSlobodnihTrokrevetnih, ar.BrojSlobodnihCetvorokrevetnih + 1,
                        ar.BrojSlobodnihPetokrevetnih);
                }
                else if (brojKreveta == 5)
                {
                    dl.AzurirajAranzmanSlobodneSobe(ar.Sifra, ar.BrojSlobodnihJednokrevetnih,
                        ar.BrojSlobodnihDvokrevetnih, ar.BrojSlobodnihTrokrevetnih, ar.BrojSlobodnihCetvorokrevetnih,
                        ar.BrojSlobodnihPetokrevetnih + 1);
                }

                listView1.Items.Clear();
                this.popuniListView();
                MessageBox.Show("Uspesno ste otkazali rezervaciju!");
            }
            else
            {
                MessageBox.Show("Niste selektovali rezervaciju za otkazivanje!");
            }
        }
    }
}
