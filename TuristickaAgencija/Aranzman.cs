using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TuristickaAgencija
{
    public class Aranzman
    {
        public ObjectId Id { get; set; }
        public String Sifra { get; set; }
      
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public MongoDBRef TipAranzmana { get; set; }
        public MongoDBRef Kompanija { get; set; }
        public MongoDBRef Hotel { get; set; }
        public int Popust { get; set; }
        public int BrojRata { get; set; }
        public int BrojDana { get; set; }
        public float CenaJednokrevetne { get; set; }
        public float CenaDvokrevetne { get; set; }
        public float CenaTrokrevetne { get; set; }
        public float CenaCetvorokrevetne { get; set; }
        public float CenaPetokrevetne { get; set; }
        public int BrojSlobodnihJednokrevetnih { get; set; }
        public int BrojSlobodnihDvokrevetnih { get; set; }
        public int BrojSlobodnihTrokrevetnih { get; set; }
        public int BrojSlobodnihCetvorokrevetnih { get; set; }
        public int BrojSlobodnihPetokrevetnih { get; set; }

        
    }
    
}
