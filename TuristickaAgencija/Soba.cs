using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TuristickaAgencija
{
    public class Soba
    {
        public ObjectId Id;
        public int BrojKreveta { get; set; }
        public float CenaSobePoDanu { get; set; }

        public MongoDBRef Hotel { get; set; }
    }
}
