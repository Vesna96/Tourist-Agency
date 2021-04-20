using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TuristickaAgencija
{
    public class Agencija
    {
        public ObjectId Id { get; set; }
        public String SifraAgencije { get; set; }
        public String AdresaAgencije { get; set; }

        public String Grad { get; set; }
        
    }
}
