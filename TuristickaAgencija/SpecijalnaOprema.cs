using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TuristickaAgencija
{
    public class SpecijalnaOprema
    {
        public ObjectId Id { get; set; }
        public String Naziv { get; set; }
        public List<MongoDBRef> Hoteli { get; set; }

        public SpecijalnaOprema()
        {
            Hoteli = new List<MongoDBRef>();
        }
    }
}
