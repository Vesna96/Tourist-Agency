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
    public partial class DodavanjePosebneOpreme : Form
    {
        DataLayer dl = new DataLayer();
        public Hotel hotel;

        public DodavanjePosebneOpreme()
        {
            InitializeComponent();
        }
        public DodavanjePosebneOpreme(Hotel h)
        {
            this.hotel = h;
            InitializeComponent();
        }

        public void UcitajPodatke()
        {
            List<SpecijalnaOprema> lista = dl.VratiOpremuUHotelu(hotel);
            foreach (SpecijalnaOprema so in lista)
            {
                ListViewItem item = new ListViewItem(new string[] { so.Naziv });
                listView1.Items.Add(item);
            }

            List<SpecijalnaOprema> opreme = dl.VratiSpecijalneOpreme();
            foreach (SpecijalnaOprema d in opreme)
            {
                cmbxOprema.Items.Add(d.Naziv);
            }
        }
        private void DodavanjePosebneOpreme_Load(object sender, EventArgs e)
        {
            this.UcitajPodatke();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            String naziv = txtNaziv.Text;
            if (naziv != "")
            {
                if (dl.VratiSpecijalnuOpremu(naziv) != null)
                {
                    MessageBox.Show("Oprema vec postoji u bazi, selektujte je");
                   
                }
                else
                {
                    dl.DodajNovuSpecijalnuOpremuZaHotel(hotel.Id, naziv);
                    listView1.Items.Clear();
                    this.UcitajPodatke();
                }
            }
            else
            {
                if(cmbxOprema.SelectedItem == null)
                {
                    MessageBox.Show("Niste uneli potrebne podatke");
                }
                else
                {
                    dl.DodajSpecijalnuOpremuZaHotel(hotel.Id, cmbxOprema.SelectedItem.ToString());
                    listView1.Items.Clear();
                    this.UcitajPodatke();
                }
            }
        
        
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            txtNaziv.Text = listView1.SelectedItems[0].SubItems[0].Text;
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            //ne radi!!!
        }
    }
}
