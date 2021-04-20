using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TuristickaAgencija
{
    public class Grad
    {
        public ObjectId Id { get; set; }
        public String Naziv { get; set; }
        public MongoDBRef Drzava { get; set; }
        public List<MongoDBRef> Hoteli { get; set; }

        public Grad()
        {
            Hoteli = new List<MongoDBRef>();
        }
    }
}
