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
    public partial class PrevozKompanije : Form
    {
        private DataLayer dl = new DataLayer();
        public PrevozKompanije()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            dl.DodajKompaniju(txtSNaziv.Text);
            listView1.Items.Add(new ListViewItem(new string[] { txtSNaziv.Text }));
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                String naziv = listView1.SelectedItems[0].SubItems[0].Text;
                dl.ObrisiPrevozeUKompaniji(naziv);
                dl.ObrisiKompaniju(naziv);
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Selektujte kompaniju koju zelite da obriste");
            }

            
        }

        private void PrevozKompanije_Load(object sender, EventArgs e)
        {
            List<PrevoznikKompanija> pk = dl.VratiKompanije();

            foreach(PrevoznikKompanija p in pk)
            {
                listView1.Items.Add(new ListViewItem(new string[] { p.NazivKompanije }));
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PrevozForm pf = new PrevozForm(listView1.SelectedItems[0].SubItems[0].Text);
            pf.ShowDialog();
        }
    }
}
