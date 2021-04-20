using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuristickaAgencija
{
    public partial class AgencijaPocetna : Form
    {
        private Agencija Agencija;
        
        private DataLayer dl = new DataLayer();
        public AgencijaPocetna(Agencija a)
        {
            this.Agencija = a;
            
            InitializeComponent();
        }

        private void AgencijaPocetna_Load(object sender, EventArgs e)
        {
            this.Text = Agencija.AdresaAgencije;
            List<Drzava> drzave = dl.VratiDrzave();
            foreach(Drzava d in drzave)
            {
                cmbxDrzave.Items.Add(d.Naziv);
            }

            List<SpecijalnaOprema> opreme = dl.VratiSpecijalneOpreme();
            foreach (SpecijalnaOprema d in opreme)
            {
                cmbxOprema.Items.Add(d.Naziv);
            }
        }

        private void cmbxDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbxGradovi.Items.Clear();
            cmbxGradovi.Enabled = true;
            String nazivDrzave = cmbxDrzave.SelectedItem.ToString();
            List<Grad> gradovi = dl.VratiGradoveUDrzavi(nazivDrzave);
            foreach (Grad gr in gradovi)
            {
                cmbxGradovi.Items.Add(gr.Naziv);
            }
        }

        private void cmbxGradovi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbxTipAranzmana_SelectedIndexChanged(object sender, EventArgs e)
        {


            
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            listViewAranzmani.Items.Clear();
            if(cmbxGradovi.SelectedItem != null && cmbxOprema.SelectedItem != null)
            {
                List<Hotel> hoteli1 = dl.VratiHoteleIzGrada(cmbxGradovi.SelectedItem.ToString());
                List<Hotel> hoteli2 = dl.VratiHoteleSaOpremom(cmbxOprema.SelectedItem.ToString());
                
                foreach (Hotel h1 in hoteli1)
                {
                    foreach(Hotel h2 in hoteli2)
                    {
                        if(h1.Id.Equals(h2.Id))
                        {
                            
                            listViewAranzmani.Items.Add(new ListViewItem(new string[] { h1.NazivHotela }));

                        }
                    }
                    
                }
            }
            else if(cmbxGradovi.SelectedItem != null)
            {
               
                List<Hotel> hoteli = dl.VratiHoteleIzGrada(cmbxGradovi.SelectedItem.ToString());

             
                foreach(Hotel h in hoteli)
                {
                    listViewAranzmani.Items.Add(new ListViewItem(new string[] { h.NazivHotela }));
                }
               
            }
            else
            {
                MessageBox.Show("Obavezna je selekcija grada!");
            }
        }

        private void listViewAranzmani_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewAranzmani_DoubleClick(object sender, EventArgs e)
        {
            String nazivHotela = listViewAranzmani.SelectedItems[0].Text;
            Hotel hotel = dl.VratiHotel(nazivHotela);
            AranzmaniAgencije form = new AranzmaniAgencije(hotel,Agencija.Grad,cmbxGradovi.Text);
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String licna = txtLicna.Text;
            List<RezervacijaAranzmana> rezervacije = dl.VratiRezervacijeKorisnika(licna);
            if (rezervacije.Count() == 0)
            {
                MessageBox.Show("Nemate ni jednu rezervaciju!");
            }
            else
            {
                KorisnikRezervacije kr = new KorisnikRezervacije(licna);
                kr.ShowDialog();
            }
        }
    }
}
