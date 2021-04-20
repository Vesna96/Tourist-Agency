using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;


namespace TuristickaAgencija
{
    public class PrevoznikKompanija
    {
        public ObjectId Id { get; set; }
        public String NazivKompanije { get; set; }

        public List<MongoDBRef> Prevozi { get; set; }

        public PrevoznikKompanija()
        {
            Prevozi = new List<MongoDBRef>();
        }
    }
}
