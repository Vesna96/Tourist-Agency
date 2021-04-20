using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TuristickaAgencija
{
    public class Prevoz
    {
        public ObjectId Id { get; set; }
        public String Sifra { get; set; }
        public String TipPrevoza { get; set; }
        public String PrevozOd { get; set; }
        public String PrevozDo { get; set; }
        public String Cena { get; set; }

        public MongoDBRef Kompanija { get; set; }
    }
}
