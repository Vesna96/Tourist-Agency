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
    public partial class AranzmaniAdmin : Form
    {
        DataLayer dl = new DataLayer();
        public List<Soba> Sobe = new List<Soba>();
        public AranzmaniAdmin()
        {
            InitializeComponent();
        }
        public int BrojJednokrevetnih
        {
            get
            {
                int broj = 0;
                foreach (Soba s in Sobe)
                    if (s.BrojKreveta == 1)
                        broj++;
                return broj;
            }

        }

        public int BrojDvokrevetnih
        {
            get
            {
                int broj = 0;
                foreach (Soba s in Sobe)
                    if (s.BrojKreveta == 2)
                        broj++;
                return broj;
            }

        }
        public int BrojTrokrevetnih
        {
            get
            {
                int broj = 0;
                foreach (Soba s in Sobe)
                    if (s.BrojKreveta == 3)
                        broj++;
                return broj;
            }

        }
        public int BrojCetvorokrevetnih
        {
            get
            {
                int broj = 0;
                foreach (Soba s in Sobe)
                    if (s.BrojKreveta == 4)
                        broj++;
                return broj;
            }
        }
        public int BrojPetokrevetnih
        {
            get
            {
                int broj = 0;
                foreach (Soba s in Sobe)
                    if (s.BrojKreveta == 5)
                        broj++;
                return broj;
            }

        }
        public void PopuniFormu()
        {
            List<TipAranzmana> tipovi = dl.VratiTipoveAranzmana();
            foreach(TipAranzmana ta in tipovi)
            {
                cmbTip.Items.Add(ta.Naziv);
            }
            List<Drzava> drzave = dl.VratiDrzave();
            foreach (Drzava dr in drzave)
            {
                cmbDrzava.Items.Add(dr.Naziv);
            }
            cmbGrad.Enabled = false;
            cmbHotel.Enabled = false;
        }
        private void AranzmaniAdmin_Load(object sender, EventArgs e)
        {
            this.PopuniFormu();
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";

        }

        private void cmbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGrad.Items.Clear();
            cmbGrad.Enabled = true;
            String nazivDrzave = cmbDrzava.SelectedItem.ToString();
            List<Grad> gradovi = dl.VratiGradoveUDrzavi(nazivDrzave);
            foreach (Grad gr in gradovi)
            {
                cmbGrad.Items.Add(gr.Naziv);
            }
        }

        private void cmbGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbHotel.Items.Clear();
            cmbHotel.Enabled = true;
            String nazivGrada = cmbGrad.SelectedItem.ToString();
            List<Hotel> hoteli = dl.VratiHoteleIzGrada(nazivGrada);
            foreach (Hotel h in hoteli)
            {
                cmbHotel.Items.Add(h.NazivHotela);
            }
            
            List<Prevoz> prevozi =  dl.VratiPrevozeDoGrada(nazivGrada);
            List<Prevoz> prev = new List<Prevoz>();
            foreach(Prevoz p in prevozi)
            {
                if (!prev.Contains(p))
                    prev.Add(p);
            }
            foreach(Prevoz p in prev)
            {

                PrevoznikKompanija pk = dl.VratiKompanijuPrevoza(p.Sifra);
                cmbxPrevoz.Items.Add(pk.NazivKompanije + "-" + p.Cena);
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (cmbTip.SelectedItem != null && cmbHotel.SelectedItem != null)
            {
                DateTime datumOd = dtpDatumOd.Value;
                DateTime datumDo = dtpDatumDo.Value;
                String tip = cmbTip.SelectedItem.ToString();
                String hotel = cmbHotel.SelectedItem.ToString();
                int popust = (int)numPopust.Value;
                int brojRata = (int)numRate.Value;
                String sifra = txtSifra.Text;
                String[] prevoz = cmbxPrevoz.SelectedItem.ToString().Split('-');
                String nazivKompanije = prevoz[0];

                if (datumDo.CompareTo(datumOd) > 0)
                {
                    TimeSpan ts = datumDo.Subtract(datumOd);
                    String b = ts.ToString();
                    String[] niz = b.Split('.');
                    int brojDana = Int32.Parse(niz[0]);

                    String nazivHotela = cmbHotel.SelectedItem.ToString();
                    float jednokrevetne, dvokrevetne, trokrevetne, cetvorokrevetne, petokrevetne;
                    Soba sobaJednokrevetna = dl.VratiNtoKrevetnuSobu(1, nazivHotela);
                    Soba sobaDvokrevetna = dl.VratiNtoKrevetnuSobu(2, nazivHotela);
                    Soba sobaTrokrevetna = dl.VratiNtoKrevetnuSobu(3, nazivHotela);
                    Soba sobaCetvorokrevetna = dl.VratiNtoKrevetnuSobu(4, nazivHotela);
                    Soba sobaPetokrevetna = dl.VratiNtoKrevetnuSobu(5, nazivHotela);
                    jednokrevetne = sobaJednokrevetna.CenaSobePoDanu * brojDana;
                    dvokrevetne = sobaDvokrevetna.CenaSobePoDanu * brojDana;
                    trokrevetne = sobaTrokrevetna.CenaSobePoDanu * brojDana;
                    cetvorokrevetne = sobaCetvorokrevetna.CenaSobePoDanu * brojDana;
                    petokrevetne = sobaPetokrevetna.CenaSobePoDanu * brojDana;

                    String[] prevozCena = cmbxPrevoz.Text.Split('-');

                    dl.DodajAranzman(sifra,datumOd, datumDo, popust, brojRata, tip, hotel, brojDana, jednokrevetne, dvokrevetne, trokrevetne,
                        cetvorokrevetne, petokrevetne,prevozCena[0],BrojJednokrevetnih,BrojDvokrevetnih,BrojTrokrevetnih,
                        BrojCetvorokrevetnih,BrojPetokrevetnih);
                    this.PopuniListu(hotel);
                }
                else
                {
                    MessageBox.Show("Niste uneli validne datume!");
                }
            }
                else
            {
                MessageBox.Show("Niste uneli potrebne podatke!");
            }
        }
        public void PopuniListu(String nazivHotela)
        {
            listView1.Items.Clear();
            List<Aranzman> aranzmani = dl.VratiAranzmaneZaHotel(nazivHotela);
            foreach (Aranzman a in aranzmani)
            {
                ListViewItem item = new ListViewItem(new string[] { (a.DatumOd).ToString(), (a.DatumDo).ToString(),
                a.BrojRata.ToString(),a.Popust.ToString(),a.CenaJednokrevetne.ToString(),a.CenaDvokrevetne.ToString(),
                a.CenaTrokrevetne.ToString(),a.CenaCetvorokrevetne.ToString(),a.CenaPetokrevetne.ToString(),
                a.Sifra});
                listView1.Items.Add(item);
            }
        }
        private void cmbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHotel.SelectedItem != null)
            {
                String nazivHotela = cmbHotel.SelectedItem.ToString();
                this.PopuniListu(nazivHotela);
                foreach(Soba s in Sobe)
                {
                    Sobe.Remove(s);
                }
                Sobe = dl.VratiSobeUHotelu(nazivHotela);


            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count != 0)
            {
                String sifra = listView1.SelectedItems[0].SubItems[9].Text;
                dl.ObrisiAranzman(sifra);
                listView1.Items.Remove(listView1.SelectedItems[0]);
                
            }
            else
            {
                MessageBox.Show("Niste selektovali aranzman za brisanje!");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                String sifra = listView1.SelectedItems[0].SubItems[9].Text;
                AzuriranjeAranzmana form = new AzuriranjeAranzmana(sifra);
                form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Niste selektovali aranzman za azuriranje!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbHotel.SelectedItem != null)
            {
                String nazivHotela = cmbHotel.SelectedItem.ToString();
                
                DateTime datumOd = dtpDatumOd.Value;
                DateTime datumDo = dtpDatumDo.Value;

                if (datumDo.CompareTo(datumOd) > 0)
                {
                    TimeSpan ts = datumDo.Subtract(datumOd);
                    String b = ts.ToString();
                    String[] niz = b.Split('.');
                    int brojDana = Int32.Parse(niz[0]);
                    
                    float jednokrevetne, dvokrevetne, trokrevetne, cetvorokrevetne, petokrevetne;
                    Soba sobaJednokrevetna = dl.VratiNtoKrevetnuSobu(1, nazivHotela);
                    Soba sobaDvokrevetna = dl.VratiNtoKrevetnuSobu(2, nazivHotela);
                    Soba sobaTrokrevetna = dl.VratiNtoKrevetnuSobu(3, nazivHotela);
                    Soba sobaCetvorokrevetna = dl.VratiNtoKrevetnuSobu(4, nazivHotela);
                    Soba sobaPetokrevetna = dl.VratiNtoKrevetnuSobu(5, nazivHotela);
                    jednokrevetne = sobaJednokrevetna.CenaSobePoDanu * brojDana;
                    if (jednokrevetne != 0)
                    {

                        label14.Text = jednokrevetne.ToString();
                    }
                    else
                    {
                        label14.Text = "----";
                    }

                    dvokrevetne = sobaDvokrevetna.CenaSobePoDanu * brojDana;
                    if (dvokrevetne != 0)
                    {

                        label15.Text = dvokrevetne.ToString();
                    }
                    else
                    {
                        label15.Text = "----";
                    }

                    trokrevetne = sobaTrokrevetna.CenaSobePoDanu * brojDana;
                    if (trokrevetne != 0)
                    {

                        label16.Text = trokrevetne.ToString();
                    }
                    else
                    {
                        label16.Text = "----";
                    }

                    cetvorokrevetne = sobaCetvorokrevetna.CenaSobePoDanu * brojDana;
                    if (cetvorokrevetne != 0)
                    {

                        label17.Text = cetvorokrevetne.ToString();
                    }
                    else
                    {
                        label17.Text = "----";
                    }

                    petokrevetne = sobaPetokrevetna.CenaSobePoDanu * brojDana;
                    if (petokrevetne != 0)
                    {

                        label18.Text = petokrevetne.ToString();
                    }
                    else
                    {
                        label18.Text = "----";
                    }
                }
                else
                {
                    MessageBox.Show("Niste uneli validne datume!");
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali hotel!");
            }
        }

        private void cmbxPrevoz_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
