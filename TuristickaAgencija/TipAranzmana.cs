using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace TuristickaAgencija
{
    public class TipAranzmana
    {
        public ObjectId Id { get; set; }
        public String Naziv { get; set; }
        public List<MongoDBRef> Aranzmani { get; set; }

        public TipAranzmana()
        {
            Aranzmani = new List<MongoDBRef>();
        }
    }
}
