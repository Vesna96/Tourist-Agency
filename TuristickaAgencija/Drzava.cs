using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TuristickaAgencija
{
    public class Drzava
    {
        public ObjectId Id { get; set; }
        public String Naziv { get; set; }
        public List<MongoDBRef> Gradovi { get; set; }
       

        public Drzava()
        {
           Gradovi = new List<MongoDBRef>();
            
        }
    }
}
