using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TuristickaAgencija
{
    public class Admin
    {
        public ObjectId Id { get; set; }
        public String SifraAdmin { get; set; }
        public String ImeAdmin { get; set; }
        public String PrezimeAdmin { get; set; }
    }
}
