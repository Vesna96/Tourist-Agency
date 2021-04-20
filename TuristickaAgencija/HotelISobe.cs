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


    public partial class HotelISobe : Form
    {
        DataLayer dl = new DataLayer();
        private Hotel Hotel;
        private List<Soba> Sobe;
        private List<Pansion> Pansioni;
        public HotelISobe(Hotel n, List<Soba> s, List<Pansion> p)
        {
            InitializeComponent();
            this.Hotel = n;
            this.Sobe = s;
            this.Pansioni = p;
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

        public float CenaJednokrevetnih
        {
            get
            {
                foreach (Soba s in Sobe)
                {
                    if (s.BrojKreveta == 1)
                        return s.CenaSobePoDanu;
                }
                return 0;
            }
        }

        public float CenaDvokrevetnih
        {
            get
            {
                foreach (Soba s in Sobe)
                {
                    if (s.BrojKreveta == 2)
                        return s.CenaSobePoDanu;
                }
                return 0;
            }
        }

        public float CenaTrokrevetnih
        {
            get
            {
                foreach (Soba s in Sobe)
                {
                    if (s.BrojKreveta == 3)
                        return s.CenaSobePoDanu;
                }
                return 0;
            }
        }

        public float CenaCetvorokrevetnih
        {
            get
            {
                foreach (Soba s in Sobe)
                {
                    if (s.BrojKreveta == 4)
                        return s.CenaSobePoDanu;
                }
                return 0;
            }
        }

        public float CenaPetokrevetnih
        {
            get
            {
                foreach (Soba s in Sobe)
                {
                    if (s.BrojKreveta == 5)
                        return s.CenaSobePoDanu;
                }
                return 0;
            }
        }

        public float CenaPolupansiona
        {
            get
            {

                foreach (Pansion p in Pansioni)
                {
                    if (p.TipPansiona == "Polupansion")
                        return p.Cena;
                }
                return 0;
            }
        }

        public float CenaPunogPansiona
        {
            get
            {

                foreach (Pansion p in Pansioni)
                {
                    if (p.TipPansiona == "Pun pansion")
                        return p.Cena;
                }
                return 0;
            }
        }

        private void HotelISobe_Load(object sender, EventArgs e)
        {
            lblNaziv.Text = Hotel.NazivHotela;
            lblZvezdice.Text = Hotel.BrojZvezdica + " zvezdice";
            numZvezdice.Value = Hotel.BrojZvezdica;
            lblJednokrevetne.Text = "Broj jednokrevetnih soba: " + BrojJednokrevetnih;
            lblDvokrevetne.Text = "Broj dvokrevetnih soba: " + BrojDvokrevetnih;
            lblTrokrevetne.Text = "Broj trokrevetnih soba: " + BrojTrokrevetnih;
            lblCetvorokrevetne.Text = "Broj cetvorokrevetnih soba: " + BrojCetvorokrevetnih;
            lblPetokrevetne.Text = "Broj petokrevetnih soba: " + BrojPetokrevetnih;
            cenaJednokrevetnih.Text = CenaJednokrevetnih.ToString();
            cenaDvokrevetnih.Text = CenaDvokrevetnih.ToString();
            cenaTrokrevetnih.Text = CenaTrokrevetnih.ToString();
            cenaCetvorokrevetnih.Text = CenaCetvorokrevetnih.ToString();
            cenaPetokrevetnih.Text = CenaPetokrevetnih.ToString();
            if (CenaPunogPansiona == 0)
            {
                CenaPansiona.Text = "Nema";
            }
            else
            {
                CenaPansiona.Text = CenaPunogPansiona.ToString();
            }

            if (CenaPolupansiona == 0)
            {
                cenaPolupansiona.Text = "Nema";
            }
            else
            {
                cenaPolupansiona.Text = CenaPolupansiona.ToString();
            }
            txtNoviNaziv.Text = Hotel.NazivHotela;
            txtLokacija.Text = Hotel.LokacijaUGradu;
            if(Hotel.PutanjaSlike != "")
                pictureBox1.Image = resizeImage(new Bitmap(Hotel.PutanjaSlike),377,359);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cenaJednokrevetnih_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cenaDvokrevetnih_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cenaTrokrevetnih_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cenaCetvorokrevetnih_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cenaPetokrevetnih_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnDodajJednokrevetnu_Click(object sender, EventArgs e)
        {
            Soba s = new Soba { BrojKreveta = 1, CenaSobePoDanu = float.Parse(cenaJednokrevetnih.Text) };
            Sobe.Add(s);

            dl.DodajSobu(1, float.Parse(cenaJednokrevetnih.Text), this.Hotel.NazivHotela);
            lblJednokrevetne.Text = "Broj jednokrevetnih soba: " + BrojJednokrevetnih.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnDodajDvokrevetnu_Click(object sender, EventArgs e)
        {
            Soba s = new Soba { BrojKreveta = 2, CenaSobePoDanu = float.Parse(cenaDvokrevetnih.Text) };
            Sobe.Add(s);

            dl.DodajSobu(2, float.Parse(cenaDvokrevetnih.Text), this.Hotel.NazivHotela);
            lblDvokrevetne.Text = "Broj dvokrevetnih soba: " + BrojDvokrevetnih.ToString();
        }

        private void btnDodajTrokrevetnu_Click(object sender, EventArgs e)
        {
            Soba s = new Soba { BrojKreveta = 3, CenaSobePoDanu = float.Parse(cenaTrokrevetnih.Text) };
            Sobe.Add(s);

            dl.DodajSobu(3, float.Parse(cenaTrokrevetnih.Text), this.Hotel.NazivHotela);
            lblTrokrevetne.Text = "Broj trokrevetnih soba: " + BrojTrokrevetnih.ToString();
        }

        private void btnDodajCetvorokrevetnu_Click(object sender, EventArgs e)
        {
            Soba s = new Soba { BrojKreveta = 4, CenaSobePoDanu = float.Parse(cenaCetvorokrevetnih.Text) };
            Sobe.Add(s);

            dl.DodajSobu(4, float.Parse(cenaCetvorokrevetnih.Text), this.Hotel.NazivHotela);
            lblCetvorokrevetne.Text = "Broj cetvorokrevetnih soba: " + BrojCetvorokrevetnih.ToString();
        }

        private void btnDodajPetokrevetnu_Click(object sender, EventArgs e)
        {
            Soba s = new Soba { BrojKreveta = 5, CenaSobePoDanu = float.Parse(cenaPetokrevetnih.Text) };
            Sobe.Add(s);

            dl.DodajSobu(5, float.Parse(cenaPetokrevetnih.Text), this.Hotel.NazivHotela);
            lblPetokrevetne.Text = "Broj petokrevetnih soba: " + BrojPetokrevetnih.ToString();
        }

        private void btnIzbaciJednokrevetnu_Click(object sender, EventArgs e)
        {
            dl.ObrisiNtokrevetnu(Hotel, 1);
            Soba s = Sobe.Find(soba => soba.BrojKreveta == 1);
            Sobe.Remove(s);
            lblJednokrevetne.Text = "Broj jednokrevetnih soba: " + BrojJednokrevetnih.ToString();
        }

        private void btnIzbaciDvokrevetnu_Click(object sender, EventArgs e)
        {
            dl.ObrisiNtokrevetnu(Hotel, 2);
            Soba s = Sobe.Find(soba => soba.BrojKreveta == 2);
            Sobe.Remove(s);
            lblDvokrevetne.Text = "Broj dvokrevetnih soba: " + BrojDvokrevetnih.ToString();
        }

        private void btnIzbaciTrokrevetnu_Click(object sender, EventArgs e)
        {
            dl.ObrisiNtokrevetnu(Hotel, 3);
            Soba s = Sobe.Find(soba => soba.BrojKreveta == 3);
            Sobe.Remove(s);
            lblTrokrevetne.Text = "Broj trokrevetnih soba: " + BrojTrokrevetnih.ToString();
        }

        private void btnIzbaciCetvorokrevetnu_Click(object sender, EventArgs e)
        {
            dl.ObrisiNtokrevetnu(Hotel, 4);
            Soba s = Sobe.Find(soba => soba.BrojKreveta == 4);
            Sobe.Remove(s);
            lblCetvorokrevetne.Text = "Broj cetvorokrevetnih soba: " + BrojCetvorokrevetnih.ToString();
        }

        private void btnIzbaciPetokrevetnu_Click(object sender, EventArgs e)
        {
            dl.ObrisiNtokrevetnu(Hotel, 5);
            Soba s = Sobe.Find(soba => soba.BrojKreveta == 5);
            Sobe.Remove(s);
            lblPetokrevetne.Text = "Broj petokrevetnih soba: " + BrojPetokrevetnih.ToString();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            dl.AzurirajHotel(Hotel.Id, txtNoviNaziv.Text,(int)numZvezdice.Value, float.Parse(cenaJednokrevetnih.Text),
                float.Parse(cenaDvokrevetnih.Text), float.Parse(cenaTrokrevetnih.Text), float.Parse(cenaCetvorokrevetnih.Text),
                float.Parse(cenaPetokrevetnih.Text), txtLokacija.Text, CenaPansiona.Text, cenaPolupansiona.Text);
        }

        private void btnSpecijlnaOprema_Click(object sender, EventArgs e)
        {
            DodavanjePosebneOpreme form = new DodavanjePosebneOpreme(Hotel);
            form.ShowDialog();
        }

        public static Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp;";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtSlika.Text = fd.FileName;

                pictureBox1.Image = resizeImage(new Bitmap(fd.FileName),377,359);
                dl.AzurirajPutanjuSlike(txtSlika.Text,Hotel.Id);
            }
        }
    }
}
