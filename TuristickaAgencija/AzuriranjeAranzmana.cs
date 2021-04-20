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
    public partial class AzuriranjeAranzmana : Form
    {
        DataLayer dl = new DataLayer();
        public String sifra;
        public AzuriranjeAranzmana()
        {
            InitializeComponent();

        }
        public AzuriranjeAranzmana(String s)
        {
            sifra = s;
            InitializeComponent();
        }

        public void PopuniPodatke()
        {
            Aranzman aranzman = dl.VratiAranzman(sifra);
            txtSifra.Text = sifra;
            dtpDatumOd.Value = aranzman.DatumOd;
            dtpDatumDo.Value = aranzman.DatumDo;
            numRate.Value = aranzman.BrojRata;
            numPopust.Value = aranzman.Popust;
            if (aranzman.CenaJednokrevetne != 0)
                label7.Text = "Cena jednokrevetne sobe: " + aranzman.CenaJednokrevetne;
            else
                label7.Text = "Hotel nema jednokrevetne sobe";
            if (aranzman.CenaDvokrevetne != 0)
                label8.Text = "Cena dvokrevetne sobe: " + aranzman.CenaDvokrevetne;
            else
                label8.Text = "Hotel nema dvokrevetne sobe";
            if (aranzman.CenaTrokrevetne != 0)
                label9.Text = "Cena trokrevetne sobe: " + aranzman.CenaTrokrevetne;
            else
                label9.Text = "Hotel nema trokrevetne sobe";
            if (aranzman.CenaCetvorokrevetne != 0)
                label10.Text = "Cena cetvorokrevetne sobe: " + aranzman.CenaCetvorokrevetne;
            else
                label10.Text = "Hotel nema cetvorokrevetne sobe";
            if (aranzman.CenaPetokrevetne != 0)
                label11.Text = "Cena petokrevetne sobe: " + aranzman.CenaPetokrevetne;
            else
                label11.Text = "Hotel nema petokrevetne sobe";

        }
        private void AzuriranjeAranzmana_Load(object sender, EventArgs e)
        {
            this.PopuniPodatke();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            DateTime datumOd = dtpDatumOd.Value;
            DateTime datumDo = dtpDatumDo.Value;
            int brojRata = (int)numRate.Value;
            int popust = (int)numPopust.Value;
            dl.AzurirajAranzman(sifra, datumOd, datumDo, brojRata, popust);
            
            this.Close();

        }

        
    }
}
