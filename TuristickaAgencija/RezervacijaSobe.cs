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
    public partial class RezervacijaSobe : Form
    {
        private DataLayer dl = new DataLayer();
        private Aranzman Aranzman;
        private Hotel hotel;
        private float cenaHotela;
        private float cenaPrevoza;
        private int brojKreveta;
        private float cenaPansiona;
        private int BrojDana;

        public RezervacijaSobe(Aranzman a,Hotel h,float cenaH,float cenaP,int bk,int bd)
        {
            Aranzman = a;
            cenaHotela = cenaH;
            cenaPrevoza = cenaP;
            brojKreveta = bk;
            hotel = h;
            cenaPansiona = 0;
            BrojDana = bd;
            InitializeComponent();
        }

        private void RezervacijaSobe_Load(object sender, EventArgs e)
        {
            List<Pansion> pansioni = dl.VratiPansioneIzHotela(hotel.NazivHotela);
            foreach (Pansion p in pansioni)
            {
                cmbxPansioni.Items.Add(p.TipPansiona + "-" +p.Cena);
            }

            cenaRate.Text = "Cena rate:" + (cenaHotela + cenaPrevoza * brojKreveta) / (Int32)numBrojRata.Value;
            lblMaxRate.Text = "Maksimalan broj mogucih rata: " + Aranzman.BrojRata;
            numBrojRata.Maximum = Aranzman.BrojRata;
            rbtnRate.Checked = true;
            txtCenaHotela.Text = "Cena hotela: " + cenaHotela + " din";
            txtCenaprevoza.Text = "Cena prevoza " + cenaPrevoza * brojKreveta + " din";
            lblPopust.Text = "";
            lblUkupno.Text = (cenaHotela + cenaPrevoza * brojKreveta).ToString() + " din";
        }

        private void rbtnGotovina_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnGotovina.Checked)
            {
                lblPopust.Text = "Popust za gotovinu " + ((cenaPrevoza * brojKreveta + cenaHotela + cenaPansiona * brojKreveta*BrojDana) * Aranzman.Popust / 100);
                lblUkupno.Text = (cenaHotela + cenaPrevoza * brojKreveta +cenaPansiona* brojKreveta*BrojDana
                  - ((cenaPrevoza * brojKreveta + cenaHotela+ cenaPansiona * brojKreveta * BrojDana) * Aranzman.Popust / 100)).ToString() + " din";
                cenaRate.Text = "";
            }
            else
            {
                lblUkupno.Text = (cenaHotela + cenaPrevoza * brojKreveta).ToString() + " din";
                cenaRate.Text = "Cena rate: " + (cenaHotela + cenaPrevoza * brojKreveta +cenaPansiona * brojKreveta * BrojDana) / (Int32)numBrojRata.Value;
            }
        }

        private void rbtnRate_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnRate.Checked)
            {
                numBrojRata.Enabled = true;
                lblPopust.Text = "";
            }
            else
            {
                numBrojRata.Enabled = false;
            }
        }

        private void lblMaxRate_Click(object sender, EventArgs e)
        {

        }

        private void numBrojRata_ValueChanged(object sender, EventArgs e)
        {
            cenaRate.Text = "Cena rate: " + (cenaHotela + cenaPrevoza * brojKreveta+ cenaPansiona * brojKreveta * BrojDana) /(Int32)numBrojRata.Value;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            String ime = txtIme.Text;
            String prezime = txtPrezime.Text;
            String licna = txtLicna.Text;
            String[] niz = (lblUkupno.Text).Split(' ');
            float ukupno = float.Parse(niz[0]);
            int rate;
            if(rbtnGotovina.Checked)
            {
                rate = 1;
            }
            else
            {
                rate = (int)numBrojRata.Value;
            }
            String tipSobe;
            if(brojKreveta == 1)
            {
                tipSobe = "Jednokrevetna";
            }
            else if(brojKreveta == 2)
            {
                tipSobe = "Dvokrevetna";
            }
            else if(brojKreveta == 3)
            {
                tipSobe = "Trokrevetna";
            }
            else if(brojKreveta == 4)
            {
                tipSobe = "Cetvorokrevetna";
            }
            else 
            {
                tipSobe = "Petokrevetna";
            }
            String[] niz1 = cmbxPansioni.Text.Split('-');
            String tipPansiona;
            tipPansiona = niz1[0];
            String nazivKompanije = (dl.VratiKompanijuAranzmana(Aranzman.Id)).NazivKompanije;
            dl.DodajRezervaciju(ime,prezime,licna,Aranzman.Sifra,ukupno,rate,hotel.NazivHotela,tipSobe,tipPansiona,nazivKompanije);
            if(brojKreveta == 1)
            {
                dl.AzurirajAranzmanSlobodneSobe(Aranzman.Sifra, Aranzman.BrojSlobodnihJednokrevetnih - 1,
                    Aranzman.BrojSlobodnihDvokrevetnih, Aranzman.BrojSlobodnihTrokrevetnih, Aranzman.BrojSlobodnihCetvorokrevetnih,
                    Aranzman.BrojSlobodnihPetokrevetnih);
            }
            else if(brojKreveta == 2)
            {
                dl.AzurirajAranzmanSlobodneSobe(Aranzman.Sifra, Aranzman.BrojSlobodnihJednokrevetnih,
                    Aranzman.BrojSlobodnihDvokrevetnih-1, Aranzman.BrojSlobodnihTrokrevetnih, Aranzman.BrojSlobodnihCetvorokrevetnih,
                    Aranzman.BrojSlobodnihPetokrevetnih);
            }
            else if(brojKreveta == 3)
            {
                dl.AzurirajAranzmanSlobodneSobe(Aranzman.Sifra, Aranzman.BrojSlobodnihJednokrevetnih,
                    Aranzman.BrojSlobodnihDvokrevetnih, Aranzman.BrojSlobodnihTrokrevetnih-1, Aranzman.BrojSlobodnihCetvorokrevetnih,
                    Aranzman.BrojSlobodnihPetokrevetnih);
            }
            else if(brojKreveta == 4)
            {
                dl.AzurirajAranzmanSlobodneSobe(Aranzman.Sifra, Aranzman.BrojSlobodnihJednokrevetnih,
                    Aranzman.BrojSlobodnihDvokrevetnih, Aranzman.BrojSlobodnihTrokrevetnih, Aranzman.BrojSlobodnihCetvorokrevetnih-1,
                    Aranzman.BrojSlobodnihPetokrevetnih);
            }
            else if(brojKreveta == 5)
            {
                dl.AzurirajAranzmanSlobodneSobe(Aranzman.Sifra, Aranzman.BrojSlobodnihJednokrevetnih,
                    Aranzman.BrojSlobodnihDvokrevetnih , Aranzman.BrojSlobodnihTrokrevetnih, Aranzman.BrojSlobodnihCetvorokrevetnih,
                    Aranzman.BrojSlobodnihPetokrevetnih-1);
            }
            MessageBox.Show("Uspesno ste rezervisali sobu!");
        }

        private void cmbxPansioni_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[] niz = cmbxPansioni.Text.Split('-');
            cenaPansiona = float.Parse(niz[1]);
            
            lblUkupno.Text = (cenaHotela + cenaPrevoza * brojKreveta+cenaPansiona*brojKreveta*BrojDana).ToString() + " din";
            
            if(rbtnGotovina.Checked)
            {
                lblPopust.Text = "Popust za gotovinu " + ((cenaPrevoza * brojKreveta + cenaHotela + cenaPansiona * brojKreveta*BrojDana) * Aranzman.Popust / 100);
                cenaRate.Text = "";
            }
            else
            {
                cenaRate.Text = "Cena rate: " + (cenaHotela + cenaPrevoza * brojKreveta + cenaPansiona * brojKreveta*BrojDana) / (Int32)numBrojRata.Value;
                lblPopust.Text = "";
            }
            
        }
        
    }
}
