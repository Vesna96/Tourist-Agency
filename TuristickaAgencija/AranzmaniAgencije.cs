using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuristickaAgencija
{
    public partial class AranzmaniAgencije : Form
    {
        private DataLayer dl = new DataLayer();
        public Hotel hotel;
        public String gradAgencije;
        public String gradHotela;
        public AranzmaniAgencije()
        {
            InitializeComponent();
        }
        public AranzmaniAgencije(Hotel h,String grad,String gHotela)
        {
            this.hotel = h;
            this.gradAgencije = grad;
            this.gradHotela = gHotela;
            InitializeComponent();
        }
        private void AranzmaniAgencije_Load(object sender, EventArgs e)
        {
            lblNaziv.Text = hotel.NazivHotela + " " + hotel.BrojZvezdica + " zvezdice";
            List<TipAranzmana> tipovi = dl.VratiTipoveAranzmana();
            foreach (TipAranzmana tip in tipovi)
            {
                cmbxTip.Items.Add(tip.Naziv);
            }

            List<SpecijalnaOprema> sadrzaji = dl.VratiOpremuUHotelu(hotel);
            foreach (SpecijalnaOprema sp in sadrzaji)
            {
                listView2.Items.Add(new ListViewItem(new string[] {sp.Naziv}));
                
               
            }


            if (hotel.PutanjaSlike != "")
                pictureBox1.Image = resizeImage(new Bitmap(hotel.PutanjaSlike), 420, 327);
        }

        public static Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            String sifraAranzmana = listView1.SelectedItems[0].SubItems[2].Text;
            
            Rezervacija rez = new Rezervacija(hotel,sifraAranzmana,gradAgencije,gradHotela);
            rez.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    
    private void cmbxTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            List<Aranzman> aranzmani1 = dl.VratiAranzmaneZaHotel(hotel.NazivHotela);

            List<Aranzman> aranzmani2 = dl.VratiAranzmanePoTipu(cmbxTip.SelectedItem.ToString());
            List<Aranzman> aranzmani = new List<Aranzman>();
            foreach(Aranzman ar1 in aranzmani1)
            {
                foreach(Aranzman ar2 in aranzmani2)
                {
                    if(ar1.Sifra.Equals(ar2.Sifra))
                        aranzmani.Add(ar1);
                   
                }
            }
            
            foreach (Aranzman a in aranzmani)
            {
                PrevoznikKompanija pk = dl.VratiKompanijuAranzmana(a.Id);
                List<Prevoz> prevozi = dl.VratiPrevozIzKompanije(pk.NazivKompanije);
                foreach (Prevoz p in prevozi)
                {
                    if (p.PrevozOd == gradAgencije)
                    {

                        listView1.Items.Add(new ListViewItem(new string[] {a.DatumOd.ToShortDateString(),
                                a.DatumDo.ToShortDateString(),a.Sifra}));
                        break;
                    }
                }
            }

        }
    }
}
