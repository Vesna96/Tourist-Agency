using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuristickaAgencija
{
    public partial class Hoteli : Form
    {
        DataLayer dl = new DataLayer();
        public Hoteli()
        {
            InitializeComponent();
        }

        private void Hoteli_Load(object sender, EventArgs e)
        {
            List<Grad> gradovi = dl.VratiGradove();
            foreach(Grad g in gradovi)
            {
                cmbxGradovi.Items.Add(g.Naziv);
            }

            List<Hotel> hoteli = dl.VratiHotele();
            foreach(Hotel h in hoteli)
            {
                listViewHoteli.Items.Add(new ListViewItem(new string[] {h.NazivHotela }));
            }
        }

        private void btnDodajHotel_Click(object sender, EventArgs e)
        {
            if(txtNazivHotela.Text == String.Empty)
            {
                MessageBox.Show("Unesite naziv hotela");
            }
            else if(dl.VratiHotel(txtNazivHotela.Text) == null)
            {
                if (cmbxGradovi.SelectedItem == null)
                    MessageBox.Show("Selektujte grad u koji dodajete hotel");
                else
                {
                    //File.Copy(txtSlika.Text, Path.Combine(@"F:\NBP\TuristickaAgencija\TuristickaAgencija\Resources\Slike", Path.GetFileName(txtSlika.Text)), true);
                    dl.DodajHotel(txtNazivHotela.Text, (Int32)numZvezdice.Value,
                        (Int32)numJednokrevetne.Value, float.Parse(cenaJednokrevetnih.Text),
                        (Int32)numDvokrevetne.Value, float.Parse(cenaDvokrevetnih.Text),
                        (Int32)numTrokrevetne.Value, float.Parse(cenaTrokrevetnih.Text),
                        (Int32)numCetvorokrevetne.Value, float.Parse(cenaCetvorokrevetnih.Text),
                        (Int32)numPetokrevetnih.Value, float.Parse(cenaPetokrevetnih.Text),
                        txtLokacija.Text,cmbxGradovi.SelectedItem.ToString(),
                        checkBox1.Checked , float.Parse(cenaPolupansiona.Text),
                        checkBox2.Checked, float.Parse(cenaPansiona.Text),txtSlika.Text
                        );
                    listViewHoteli.Items.Add(new ListViewItem(new string[] { txtNazivHotela.Text}));
                    MessageBox.Show("Dodali ste hotel " + txtNazivHotela.Text+ " u grad " + cmbxGradovi.SelectedItem.ToString());
                }
            }
            else
            {
                MessageBox.Show("Hotel sa tim imenom vec postoji");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbxHoteli_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Hotel hotel = dl.VratiHotel(cmbxHoteli.SelectedItem.ToString());
            //hotel.Sobe = dl.VratiSobeUHotelu(hotel.Id);
            //cmbxGradovi.SelectedValue = hotel.Grad.Naziv;
            //cmbxGradovi.Text = hotel.Grad.Naziv;
            //txtNazivHotela.Text = hotel.NazivHotela;
            //txtLokacija.Text = hotel.LokacijaUGradu;
            //numZvezdice.Text = hotel.BrojZvezdica.ToString();
            //numJednokrevetne.Text = hotel.BrojJednokrevetnih.ToString();
            //numDvokrevetne.Text = hotel.BrojDvokrevetnih.ToString();
            //numTrokrevetne.Text = hotel.BrojTrokrevetnih.ToString();
            //numCetvorokrevetne.Text = hotel.BrojCetvorokrevetnih.ToString();
            //numPetokrevetnih.Text = hotel.BrojPetokrevetnih.ToString();
            //cenaJednokrevetnih.Text = hotel.CenaJednokrevetnih.ToString();
            //cenaDvokrevetnih.Text = hotel.CenaDvokrevetnih.ToString();
            //cenaTrokrevetnih.Text = hotel.CenaTrokrevetnih.ToString();
            //cenaCetvorokrevetnih.Text = hotel.CenaCetvorokrevetnih.ToString();
            //cenaPetokrevetnih.Text = hotel.CenaPetokrevetnih.ToString();
            
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listViewHoteli.SelectedItems.Count == 0)
                MessageBox.Show("Selektujte hotel koji zelite da obrisete");
            else
            {
                String nazivHotela = listViewHoteli.SelectedItems[0].SubItems[0].Text;
                dl.ObrisiHotel(nazivHotela);
                listViewHoteli.Items.Remove(listViewHoteli.SelectedItems[0]);
                cmbxGradovi.Text = "";
                txtNazivHotela.Clear();
                txtLokacija.Clear();
                numZvezdice.Value = 1;
                numJednokrevetne.Value = 0;
                numDvokrevetne.Value = 0;
                numTrokrevetne.Value = 0;
                numCetvorokrevetne.Value = 0;
                numPetokrevetnih.Value = 0;
                cenaJednokrevetnih.Text = "0";
                cenaDvokrevetnih.Text = "0";
                cenaTrokrevetnih.Text = "0";
                cenaCetvorokrevetnih.Text = "0";
                cenaPetokrevetnih.Text = "0";
            }
        }

        private void cmbxHoteli_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void cenaJednokrevetnih_TextChanged(object sender, EventArgs e)
        {

        }

        private void cenaPolupansiona_TextChanged(object sender, EventArgs e)
        {

        }

        private void cenaPolupansiona_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cenaPansiona_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbxHoteli_MouseEnter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
                cenaPansiona.Enabled = false;
            else
                cenaPansiona.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                cenaPolupansiona.Enabled = false;
            else
                cenaPolupansiona.Enabled = true;
        }

        private void listViewHoteli_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewHoteli_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Hotel h = dl.VratiHotel(listViewHoteli.SelectedItems[0].SubItems[0].Text);
            List<Soba> sobe = dl.VratiSobeUHotelu(h.NazivHotela);
            List<Pansion> pansioni = dl.VratiPansioneIzHotela(h.NazivHotela);

            HotelISobe hs = new HotelISobe(h,sobe,pansioni);
            hs.ShowDialog();
        }

        public static Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp;";
            if(fd.ShowDialog() == DialogResult.OK)
            {
                txtSlika.Text = fd.FileName;
                pictureBox1.Image = resizeImage(new Bitmap(fd.FileName),297,241);
            }
        }
    }
}
