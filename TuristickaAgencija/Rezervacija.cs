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
    public partial class Rezervacija : Form
    {
        private DataLayer dl = new DataLayer();
        public Hotel hotel;
        public String gradOd;


        public Aranzman aranzman;
        Prevoz prevoz;
        public int brojDana;
        public Rezervacija()
        {
            InitializeComponent();
        }
        public Rezervacija(Hotel h,String sifra,String gradOd,String gradDo)
        {
            this.hotel = h;
            aranzman = dl.VratiAranzman(sifra);
            prevoz = dl.vratiPrevozIzKompanijeOdDo(h.NazivHotela,gradOd,gradDo);
            InitializeComponent();
        }

        private void Rezervacija_Load(object sender, EventArgs e)
        {
            
            TimeSpan ts = aranzman.DatumDo.Subtract(aranzman.DatumOd);
            String b = ts.ToString();
            String[] niz = b.Split('.');
            brojDana = Int32.Parse(niz[0]);

            if (aranzman.CenaJednokrevetne != 0 && aranzman.BrojSlobodnihJednokrevetnih != 0)
                cenaJednokrevetne.Text = "Cena jednokrevetne sobe: " + aranzman.CenaJednokrevetne / brojDana + " za jedan dan";
            else
            {
                button1.Enabled = false;
                cenaJednokrevetne.Text = "Nema slobodnih jednokrevetne sobe";
            }

            if (aranzman.CenaDvokrevetne != 0 && aranzman.BrojSlobodnihDvokrevetnih != 0)
                cenaDvokrevetne.Text = "Cena dvokrevetne sobe: " + aranzman.CenaDvokrevetne / brojDana + " za jedan dan";
            else
            {
                button2.Enabled = false;
                cenaDvokrevetne.Text = "Nema slobodnih dvokrevetnih soba";
            }

            if (aranzman.CenaTrokrevetne != 0 && aranzman.BrojSlobodnihTrokrevetnih != 0)
                cenaTrokrevetne.Text = "Cena trokrevetne sobe: " + aranzman.CenaTrokrevetne / brojDana + " za jedan dan";
            else
            {
                button3.Enabled = false;
                cenaTrokrevetne.Text = "Nema slobodnih trokrevetnih soba";
            }

            if (aranzman.CenaCetvorokrevetne != 0 && aranzman.BrojSlobodnihCetvorokrevetnih != 0)
                cenaCetvorokrevetne.Text = "Cena cetvorokrevetne sobe: " + aranzman.CenaCetvorokrevetne / brojDana + " za jedan dan";
            else
            {
                button4.Enabled = false;
                cenaCetvorokrevetne.Text = "Nema slobodnih cetvorokrevetnih soba";
            }

            if (aranzman.CenaPetokrevetne != 0 && aranzman.BrojSlobodnihPetokrevetnih != 0)
                cenaPetokrevetne.Text = "Cena petokrevetne sobe: " + aranzman.CenaPetokrevetne / brojDana + " za jedan dan";
            else
            {
                button5.Enabled = false;
                cenaPetokrevetne.Text = "Nema slobodnih petokrevetnih soba";
            }

            cenaPrevoza.Text = "Cena prevoza po osobi: " + prevoz.Cena;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RezervacijaSobe rs = new RezervacijaSobe(aranzman, hotel,aranzman.CenaTrokrevetne, float.Parse(prevoz.Cena),3,brojDana);
            rs.ShowDialog();
        }

        private void cenaPetokrevetne_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RezervacijaSobe rs = new RezervacijaSobe(aranzman,hotel,aranzman.CenaJednokrevetne,float.Parse(prevoz.Cena),1,brojDana);
            rs.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RezervacijaSobe rs = new RezervacijaSobe(aranzman, hotel,aranzman.CenaDvokrevetne, float.Parse(prevoz.Cena),2,brojDana);
            rs.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RezervacijaSobe rs = new RezervacijaSobe(aranzman, hotel,aranzman.CenaCetvorokrevetne, float.Parse(prevoz.Cena),4,brojDana);
            rs.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RezervacijaSobe rs = new RezervacijaSobe(aranzman, hotel,aranzman.CenaPetokrevetne, float.Parse(prevoz.Cena),5,brojDana);
            rs.ShowDialog();
        }
    }
}
