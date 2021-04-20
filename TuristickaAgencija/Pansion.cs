using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TuristickaAgencija
{
    public class Pansion
    {
        public ObjectId Id { get; set; }
        public String TipPansiona { get; set; }
        public float Cena { get; set; }

        public MongoDBRef Hotel { get; set; }
    }
}
