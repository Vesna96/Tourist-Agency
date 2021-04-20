using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TuristickaAgencija
{
    public class Hotel
    {
        public ObjectId Id { get; set; }
        public String NazivHotela { get; set; }
        public String LokacijaUGradu { get; set; }
        public int BrojZvezdica { get; set; }

        public MongoDBRef Grad { get; set; }
        public List<MongoDBRef> Sobe {get; set; }
        public List<MongoDBRef> Pansioni { get; set; }
        public List<MongoDBRef> SpecijalneOpreme { get; set; }
        public List<MongoDBRef> Aranzmani { get; set; }

        public String PutanjaSlike { get; set; }

        public Hotel()
        {
            Sobe = new List<MongoDBRef>();
            Pansioni = new List<MongoDBRef>();
            SpecijalneOpreme = new List<MongoDBRef>();
            Aranzmani = new List<MongoDBRef>();
        }


        
    }
}
