using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuristickaAgencija
{
    public class RezervacijaAranzmana
    {
        public ObjectId Id { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String BrojLicneKarte { get; set; }
        public String NazivHotela { get; set; }
        public String SifraAranzmana { get; set; }
        public String TipSobe { get; set; }
        public String TipPansiona { get; set; }
        public String Prevoznik { get; set; }
        public float UkupnaCena { get; set; }
        public int BrojRata { get; set; }
        

    }
}
