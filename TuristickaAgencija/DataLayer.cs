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
    public class DataLayer
    {
        #region Admin
        public Admin VratiAdmina(String sifra)
        {

            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Admin>("Admin");
            var query = Query.EQ("SifraAdmin", sifra);
            Admin a = collection.Find(query).FirstOrDefault();
            return a;

        }
        #endregion

        #region Agencija
        public List<Agencija> VratiAgencije()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Agencija>("Agencija");

            List<Agencija> lista = new List<Agencija>();
            foreach (Agencija a in collection.FindAll())
            {
                lista.Add(a);
            }
            return lista;
        }

        public Agencija VratiAgenciju(String sifra)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Agencija>("Agencija");

            var query = (from Agencija in collection.AsQueryable<Agencija>()
                         where Agencija.SifraAgencije == sifra
                         select Agencija).FirstOrDefault();
            return query;

        }
        public void DodajAgenciju(String sifra, String grad, String adresa)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Agencija>("Agencija");
            Agencija agencija = new Agencija { SifraAgencije = sifra, Grad = grad, AdresaAgencije = adresa };
            collection.Insert(agencija);
        }
        public void AzurirajAgenciju(String sifra, String grad, String adresa)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Agencija>("Agencija");
            var query = Query.EQ("SifraAgencije", sifra);
            var update = MongoDB.Driver.Builders.Update.Set("AdresaAgencije",
                BsonValue.Create(adresa));
            collection.Update(query, update);

            var update1 = MongoDB.Driver.Builders.Update.Set("Grad",
                BsonValue.Create(grad));
            collection.Update(query, update1);

        }
        public void ObrisiAgenciju(String sifra)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Agencija>("Agencija");

            var query = Query.EQ("SifraAgencije", sifra);
            collection.Remove(query);

        }
        #endregion
        #region PrevoznikKompanija
        public List<PrevoznikKompanija> VratiKompanije()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanija");

            List<PrevoznikKompanija> lista = new List<PrevoznikKompanija>();
            foreach (PrevoznikKompanija d in collection.FindAll())
            {
                lista.Add(d);
            }
            return lista;
        }

        public PrevoznikKompanija VratiKompanijuPrevoza(String sifra)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionKompanija = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanija");
            var collectionPrevoz = database.GetCollection<Prevoz>("Prevoz");

            Prevoz prevoz = VratiPrevoz(sifra);

            List<PrevoznikKompanija> pk = VratiKompanije();

            foreach (PrevoznikKompanija p in pk)
            {
                foreach (Prevoz pp in VratiPrevozIzKompanije(p.NazivKompanije))
                {
                    if (pp.Id == prevoz.Id)
                        return p;
                }
            }



            return null;
        }
        public PrevoznikKompanija VratiKompaniju(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanija");


            var query = (from PrevoznikKompanija in collection.AsQueryable<PrevoznikKompanija>()
                         where PrevoznikKompanija.NazivKompanije == naziv
                         select PrevoznikKompanija).FirstOrDefault();
            return query;
        }
        public PrevoznikKompanija VratiKompanijuId(ObjectId id)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanija");


            var query = (from PrevoznikKompanija in collection.AsQueryable<PrevoznikKompanija>()
                         where PrevoznikKompanija.Id == id
                         select PrevoznikKompanija).FirstOrDefault();
            return query;
        }
        public void DodajKompaniju(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanija");
            PrevoznikKompanija kompanija = new PrevoznikKompanija { NazivKompanije = naziv };
            collection.Insert(kompanija);
        }

        public void ObrisiKompaniju(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanija");

            var query = Query.EQ("NazivKompanije", naziv);
            collection.Remove(query);

        }

        public void ObrisiPrevozeUKompaniji(String nazivKompanije)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionPrevoz = database.GetCollection<Prevoz>("Prevoz");
            var collectionKompanija = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanija");

            PrevoznikKompanija kompanija = VratiKompaniju(nazivKompanije);
            //List<Grad> gradovi = new List<Grad>();
            var query1 = from Prevoz in collectionPrevoz.AsQueryable<Prevoz>()

                         where Prevoz.Kompanija.Id == kompanija.Id
                         select Prevoz;

            foreach (Prevoz p in query1)
            {
                var query = Query.EQ("Sifra", p.Sifra);
                collectionPrevoz.Remove(query);
            }


        }

        public List<Aranzman> VratiArazmaneIzKompanije(String nazivKompanije)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionKompanija = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanija");
            var collectionAranzman = database.GetCollection<Aranzman>("Aranzman");
            List<Aranzman> lista = new List<Aranzman>();
            PrevoznikKompanija kompanija = VratiKompaniju(nazivKompanije);


            var query = (from Aranzman in collectionAranzman.AsQueryable<Aranzman>()

                         where Aranzman.Kompanija.Id == kompanija.Id
                         select Aranzman);
            foreach (Aranzman g in query)
            {
                lista.Add(g);
            }

            return lista;
        }

        public PrevoznikKompanija VratiKompanijuAranzmana(ObjectId idAranzmana)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionAranzman = database.GetCollection<Aranzman>("Aranzman");
            var collectionKompanija = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanije");

            List<PrevoznikKompanija> pk = VratiKompanije();

            foreach (PrevoznikKompanija p in pk)
            {
                foreach (Aranzman aranzman in VratiArazmaneIzKompanije(p.NazivKompanije))
                {
                    if (aranzman.Id == idAranzmana)
                        return p;
                }
            }

            return null;
        }


        #endregion


        #region Prevoz
        public List<Prevoz> VratiPrevoz()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Prevoz>("Prevoz");

            List<Prevoz> lista = new List<Prevoz>();
            foreach (Prevoz a in collection.FindAll())
            {
                lista.Add(a);
            }
            return lista;
        }

        public List<Prevoz> VratiPrevozeDoGrada(String grad)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Prevoz>("Prevoz");

            var query = (from Prevoz in collection.AsQueryable<Prevoz>()
                         where Prevoz.PrevozDo == grad
                         select Prevoz).ToList<Prevoz>();
            return query;
        }

        public List<Prevoz> VratiPrevozeIzGrada(String grad)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Prevoz>("Prevoz");

            var query = (from Prevoz in collection.AsQueryable<Prevoz>()
                         where Prevoz.PrevozOd == grad
                         select Prevoz).ToList<Prevoz>();
            return query;
        }


        public void DodajPrevoz(String sifra, String tip, String naziv, String prevozOd, String prevozDo, String cena)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Prevoz>("Prevoz");
            var collectionKompanija = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanija");
            Prevoz prevoz = new Prevoz { TipPrevoza = tip, Sifra = sifra, PrevozOd = prevozOd, PrevozDo = prevozDo, Cena = cena };
            PrevoznikKompanija pk = VratiKompaniju(naziv);
            collection.Insert(prevoz);
            pk.Prevozi.Add(new MongoDBRef("Prevoz", prevoz.Id));
            prevoz.Kompanija = new MongoDBRef("PrevoznikKompanija", pk.Id);
            collection.Save(prevoz);
            collectionKompanija.Save(pk);
        }

        public void ObrisiPrevoz(String sifra)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Prevoz>("Prevoz");

            var query = Query.EQ("Sifra", sifra);
            collection.Remove(query);

        }

        public Prevoz vratiPrevozIzKompanijeOdDo(String nazivKompanije, String gradOd, String gradDo)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Prevoz>("Prevoz");
            var collectionKompanija = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanija");

            PrevoznikKompanija pk = VratiKompaniju(nazivKompanije);


            var query = (from Prevoz in collection.AsQueryable<Prevoz>()
                         where Prevoz.PrevozOd == gradOd
                         where Prevoz.PrevozDo == gradDo
                         select Prevoz).FirstOrDefault();

            return query;
        }
        public Prevoz VratiPrevoz(String sifra)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Prevoz>("Prevoz");

            var query = (from Prevoz in collection.AsQueryable<Prevoz>()
                         where Prevoz.Sifra == sifra
                         select Prevoz).FirstOrDefault();
            return query;
        }

        public List<Prevoz> VratiPrevozIzKompanije(String nazivKompanije)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionKompanija = database.GetCollection<PrevoznikKompanija>("PrevoznikKompanija");
            var collectionGrad = database.GetCollection<Prevoz>("Prevoz");
            List<Prevoz> lista = new List<Prevoz>();
            PrevoznikKompanija kompanija = VratiKompaniju(nazivKompanije);


            var query = (from Prevoz in collectionGrad.AsQueryable<Prevoz>()

                         where Prevoz.Kompanija.Id == kompanija.Id
                         select Prevoz);
            foreach (Prevoz g in query)
            {
                lista.Add(g);
            }

            return lista;
        }
        #endregion

        #region TipAranzmana
        public TipAranzmana VratiTipAranzmana(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<TipAranzmana>("TipAranzmana");

            var query = (from TipAranzmana in collection.AsQueryable<TipAranzmana>()
                         where TipAranzmana.Naziv == naziv
                         select TipAranzmana).FirstOrDefault();
            return query;
        }
        public List<TipAranzmana> VratiTipoveAranzmana()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<TipAranzmana>("TipAranzmana");

            List<TipAranzmana> lista = new List<TipAranzmana>();
            foreach (TipAranzmana ta in collection.FindAll())
            {
                lista.Add(ta);
            }
            return lista;
        }
        public void DodajTipAranzmana(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<TipAranzmana>("TipAranzmana");
            TipAranzmana tip = new TipAranzmana { Naziv = naziv };
            collection.Insert(tip);
        }

        public void ObrisiTipAranzmana(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<TipAranzmana>("TipAranzmana");

            var query = Query.EQ("Naziv", naziv);
            collection.Remove(query);

        }

        #endregion
        #region Drzava
        public List<Drzava> VratiDrzave()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Drzava>("Drzava");

            List<Drzava> lista = new List<Drzava>();
            foreach (Drzava d in collection.FindAll())
            {
                lista.Add(d);
            }
            return lista;
        }
        public Drzava VratiDrzavu(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Drzava>("Drzava");


            var query = (from Drzava in collection.AsQueryable<Drzava>()
                         where Drzava.Naziv == naziv
                         select Drzava).FirstOrDefault();
            return query;
        }
        public Drzava VratiDrzavuId(ObjectId id)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Drzava>("Drzava");


            var query = (from Drzava in collection.AsQueryable<Drzava>()
                         where Drzava.Id == id
                         select Drzava).FirstOrDefault();
            return query;
        }
        public void DodajDrzavu(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Drzava>("Drzava");
            Drzava drzava = new Drzava { Naziv = naziv };
            collection.Insert(drzava);
        }

        public void ObrisiDrzavu(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Drzava>("Drzava");

            var query = Query.EQ("Naziv", naziv);
            collection.Remove(query);

        }
        #endregion
        #region Grad
        public Grad VratiGrad(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Grad>("Grad");

            var query = (from Grad in collection.AsQueryable<Grad>()
                         where Grad.Naziv == naziv
                         select Grad).FirstOrDefault();
            return query;
        }
        public List<Grad> VratiGradoveUDrzavi(String nazivDrzave)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionDrzava = database.GetCollection<Drzava>("Drzava");
            var collectionGrad = database.GetCollection<Grad>("Grad");
            List<Grad> lista = new List<Grad>();
            Drzava drzava = VratiDrzavu(nazivDrzave);


            var query = (from Grad in collectionGrad.AsQueryable<Grad>()

                         where Grad.Drzava.Id == drzava.Id
                         select Grad);
            foreach (Grad g in query)
            {
                lista.Add(g);
            }

            return lista;
        }


        public void DodajGrad(String nazivGrada, String nazivDrzave)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionGrad = database.GetCollection<Grad>("Grad");
            var collectionDrzava = database.GetCollection<Drzava>("Drzava");
            Drzava drzava = VratiDrzavu(nazivDrzave);
            Grad grad = new Grad { Naziv = nazivGrada };
            collectionGrad.Insert(grad);
            drzava.Gradovi.Add(new MongoDBRef("Grad", grad.Id));
            grad.Drzava = new MongoDBRef("Drzava", drzava.Id);

            collectionGrad.Save(grad);
            collectionDrzava.Save(drzava);

        }

        public void ObrisiGrad(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionGrad = database.GetCollection<Grad>("Grad");
            var collectionDrzava = database.GetCollection<Drzava>("Drzava");
            Grad gr = VratiGrad(naziv);


            /*Drzava query1 = (from Drzava in collectionDrzava.AsQueryable<Drzava>()

                         where Drzava.Id == gr.Drzava.Id
                         select Drzava).FirstOrDefault();*/


            var query = Query.EQ("Naziv", naziv);
            collectionGrad.Remove(query);
        }
        public void ObrisiGradoveUDrzavi(String nazivDrzave)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionGrad = database.GetCollection<Grad>("Grad");
            var collectionDrzava = database.GetCollection<Drzava>("Drzava");

            Drzava drzava = VratiDrzavu(nazivDrzave);
            //List<Grad> gradovi = new List<Grad>();
            var query1 = from Grad in collectionGrad.AsQueryable<Grad>()

                         where Grad.Drzava.Id == drzava.Id
                         select Grad;

            foreach (Grad grad in query1)
            {
                var query = Query.EQ("Naziv", grad.Naziv);
                collectionGrad.Remove(query);
            }


        }
        public List<Grad> VratiGradove()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Grad>("Grad");

            List<Grad> lista = new List<Grad>();
            foreach (Grad h in collection.FindAll())
            {
                lista.Add(h);
            }
            return lista;
        }

        #endregion

        #region Aranzman
        public Aranzman VratiAranzman(ObjectId id)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Aranzman>("Aranzman");

            var query = (from Aranzman in collection.AsQueryable<Aranzman>()
                         where Aranzman.Id == id
                         select Aranzman).FirstOrDefault();
            return query;
        }
        public Aranzman VratiAranzman(String sifra)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Aranzman>("Aranzman");

            var query = (from Aranzman in collection.AsQueryable<Aranzman>()
                         where Aranzman.Sifra == sifra
                         select Aranzman).FirstOrDefault();
            return query;
        }
        public List<Aranzman> VratiAranzmane()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Aranzman>("Aranzman");

            List<Aranzman> lista = new List<Aranzman>();
            foreach (Aranzman a in collection.FindAll())
            {
                lista.Add(a);
            }
            return lista;
        }

        public List<Aranzman> VratiAranzmanePoTipu(String tip)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionAranzman = database.GetCollection<Aranzman>("Aranzman");
            var collectionTip = database.GetCollection<TipAranzmana>("TipAranzmana");
            List<Aranzman> lista = new List<Aranzman>();
            TipAranzmana ta = VratiTipAranzmana(tip);


            var query = (from Aranzman in collectionAranzman.AsQueryable<Aranzman>()

                         where Aranzman.TipAranzmana.Id == ta.Id
                         select Aranzman);
            foreach (Aranzman a in query)
            {
                lista.Add(a);
            }

            return lista;
        }
        public List<Aranzman> VratiAranzmaneZaHotel(String nazivHotela)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionAranzman = database.GetCollection<Aranzman>("Aranzman");
            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            List<Aranzman> lista = new List<Aranzman>();
            Hotel h = VratiHotel(nazivHotela);


            var query = (from Aranzman in collectionAranzman.AsQueryable<Aranzman>()

                         where Aranzman.Hotel.Id == h.Id
                         select Aranzman);
            foreach (Aranzman a in query)
            {
                lista.Add(a);
            }

            return lista;
        }
        public void DodajAranzman(String sifra, DateTime datumOd, DateTime datumDo, int popust, int brojRata, String nazivTipa, String nazivHotela,
            int brojDana, float cenaJednokrevetne, float cenaDvokrevetne, float cenaTrokrevetne, float cenaCetvorokrevetne,
            float cenaPetokrevetne, String nazivKompanije, int jedan, int dva, int tri, int cetiri, int pet)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionAranzman = database.GetCollection<Aranzman>("Aranzman");
            var collectionTip = database.GetCollection<TipAranzmana>("TipAranzmana");
            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            var collectionKompanija = database.GetCollection<PrevoznikKompanija>("PrevozniKKompanija");

            PrevoznikKompanija kompanija = VratiKompaniju(nazivKompanije);
            TipAranzmana ta = VratiTipAranzmana(nazivTipa);
            Hotel hotel = VratiHotel(nazivHotela);
            Aranzman aranzman = new Aranzman
            {
                Sifra = sifra,
                DatumOd = datumOd,
                DatumDo = datumDo,
                Popust = popust,
                BrojRata = brojRata,
                BrojDana = brojDana,
                CenaJednokrevetne = cenaJednokrevetne,
                CenaDvokrevetne = cenaDvokrevetne,
                CenaTrokrevetne = cenaTrokrevetne,
                CenaCetvorokrevetne = cenaCetvorokrevetne,
                CenaPetokrevetne = cenaPetokrevetne,
                BrojSlobodnihJednokrevetnih = jedan,
                BrojSlobodnihDvokrevetnih = dva,
                BrojSlobodnihTrokrevetnih = tri,
                BrojSlobodnihCetvorokrevetnih = cetiri,
                BrojSlobodnihPetokrevetnih = pet
            };
            collectionAranzman.Insert(aranzman);
            hotel.Aranzmani.Add(new MongoDBRef("Aranzman", aranzman.Id));
            ta.Aranzmani.Add(new MongoDBRef("Aranzman", aranzman.Id));
            aranzman.Hotel = new MongoDBRef("Hotel", hotel.Id);
            aranzman.TipAranzmana = new MongoDBRef("TipAranzmana", ta.Id);
            aranzman.Kompanija = new MongoDBRef("Kompanija", kompanija.Id);
            collectionAranzman.Save(aranzman);
            collectionHotel.Save(hotel);
            collectionTip.Save(ta);
        }

        public void ObrisiAranzman(String sifra)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Aranzman>("Aranzman");

            var query = Query.EQ("Sifra", sifra);
            collection.Remove(query);
        }
        public void AzurirajAranzman(String sifra, DateTime datumOd, DateTime datumDo, int brojRata, int popust)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Aranzman>("Aranzman");
            var query = Query.EQ("Sifra", sifra);
            var update = MongoDB.Driver.Builders.Update.Set("DatumOd",
                BsonValue.Create(datumOd));
            collection.Update(query, update);
            var update1 = MongoDB.Driver.Builders.Update.Set("DatumDo",
                BsonValue.Create(datumDo));
            collection.Update(query, update1);
            var update2 = MongoDB.Driver.Builders.Update.Set("BrojRata",
                BsonValue.Create(brojRata));
            collection.Update(query, update2);
            var update3 = MongoDB.Driver.Builders.Update.Set("Popust",
                BsonValue.Create(popust));
            collection.Update(query, update3);
        }
        public void AzurirajAranzmanSlobodneSobe(String sifra, int slobodneJednokrevetne, int slobodneDvokrevetne, int slobodneTrokrevetne,
            int slobodneCetvorokrevetne, int slobodnePetokrevetne)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Aranzman>("Aranzman");
            var query = Query.EQ("Sifra", sifra);
            var update = MongoDB.Driver.Builders.Update.Set("BrojSlobodnihJednokrevetnih",
                BsonValue.Create(slobodneJednokrevetne));
            collection.Update(query, update);
            var update1 = MongoDB.Driver.Builders.Update.Set("BrojSlobodnihDvokrevetnih",
                BsonValue.Create(slobodneDvokrevetne));
            collection.Update(query, update1);
            var update2 = MongoDB.Driver.Builders.Update.Set("BrojSlobodnihTrokrevetnih",
                BsonValue.Create(slobodneTrokrevetne));
            collection.Update(query, update2);
            var update3 = MongoDB.Driver.Builders.Update.Set("BrojSlobodnihCetvorokrevetnih",
                BsonValue.Create(slobodneCetvorokrevetne));
            collection.Update(query, update3);
            var update4 = MongoDB.Driver.Builders.Update.Set("BrojSlobodnihPetokrevetnih",
                BsonValue.Create(slobodnePetokrevetne));
            collection.Update(query, update4);
        }
        #endregion

        #region Hotel

        public List<Hotel> VratiHotele()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Hotel>("Hotel");

            List<Hotel> lista = new List<Hotel>();
            foreach (Hotel h in collection.FindAll())
            {
                lista.Add(h);
            }
            return lista;
        }

        public void DodajHotel(String naziv, int brojZvezdica,
            int brojJednokrevetnih, float cenaJednokrevetnih,
            int brojDvokrevetnih, float cenaDvokrevetnih,
            int brojTrokrevetnih, float cenaTrokrevetnih,
            int brojCetvorokrevetnih, float cenaCetvorokrevetnih,
            int brojPetokrevetnih, float cenaPetokrevetnih,
            String lokacija, String nazivGrada,
            bool polupansion, float cenaPolupansiona,
            bool punPansion, float cenaPunogPansiona, String putanja)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Hotel>("Hotel");
            var collectionGrad = database.GetCollection<Grad>("Grad)");
            List<Soba> sobe = new List<Soba>();
            List<Pansion> pansioni = new List<Pansion>();
            if (brojJednokrevetnih != 0)
            {
                for (int i = 0; i < brojJednokrevetnih; i++)
                {
                    Soba s = new Soba { BrojKreveta = 1, CenaSobePoDanu = cenaJednokrevetnih };
                    sobe.Add(s);
                }
            }
            if (brojDvokrevetnih != 0)
            {
                for (int i = 0; i < brojDvokrevetnih; i++)
                {
                    Soba s = new Soba { BrojKreveta = 2, CenaSobePoDanu = cenaDvokrevetnih };
                    sobe.Add(s);
                }
            }
            if (brojTrokrevetnih != 0)
            {
                for (int i = 0; i < brojTrokrevetnih; i++)
                {
                    Soba s = new Soba { BrojKreveta = 3, CenaSobePoDanu = cenaTrokrevetnih };
                    sobe.Add(s);
                }
            }
            if (brojCetvorokrevetnih != 0)
            {
                for (int i = 0; i < brojCetvorokrevetnih; i++)
                {
                    Soba s = new Soba { BrojKreveta = 4, CenaSobePoDanu = cenaCetvorokrevetnih };
                    sobe.Add(s);
                }
            }

            if (brojPetokrevetnih != 0)
            {
                for (int i = 0; i < brojPetokrevetnih; i++)
                {
                    Soba s = new Soba { BrojKreveta = 5, CenaSobePoDanu = cenaPetokrevetnih };
                    sobe.Add(s);
                }
            }

            if (polupansion)
                pansioni.Add(new Pansion { TipPansiona = "Polupansion", Cena = cenaPolupansiona });
            if (punPansion)
                pansioni.Add(new Pansion { TipPansiona = "Pun pansion", Cena = cenaPunogPansiona });

            Grad grad = VratiGrad(nazivGrada);
            Hotel hotel = new Hotel
            {
                NazivHotela = naziv,
                BrojZvezdica = brojZvezdica,
                LokacijaUGradu = lokacija,
                PutanjaSlike = putanja
            };
            collection.Insert(hotel);
            grad.Hoteli.Add(new MongoDBRef("Hotel", hotel.Id));
            hotel.Grad = new MongoDBRef("Grad", grad.Id);
            collection.Save(hotel);
            collectionGrad.Save(grad);

            foreach (Soba s in sobe)
            {
                DodajSobu(s.BrojKreveta, s.CenaSobePoDanu, hotel.NazivHotela);
            }
            foreach (Pansion p in pansioni)
            {
                DodajPansion(p.TipPansiona, p.Cena, hotel.NazivHotela);
            }



        }

        public void AzurirajHotel(ObjectId idHotela, String naziv, int brojZvezdica,
           float cenaJednokrevetnih,
           float cenaDvokrevetnih,
           float cenaTrokrevetnih,
           float cenaCetvorokrevetnih,
           float cenaPetokrevetnih, String lokacija, String cenaPunogpansiona, String cenaPolupansiona)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Hotel>("Hotel");
            var collectionPansion = database.GetCollection<Pansion>("Pansion");
            var collectionSoba = database.GetCollection<Soba>("Soba");
            var query = Query.EQ("_id", idHotela);
            var update1 = MongoDB.Driver.Builders.Update.Set("NazivHotela",
                BsonValue.Create(naziv));
            collection.Update(query, update1);
            var update2 = MongoDB.Driver.Builders.Update.Set("BrojZvezdica",
                BsonValue.Create(brojZvezdica));
            collection.Update(query, update2);
            var update3 = MongoDB.Driver.Builders.Update.Set("LokacijaUGradu",
                BsonValue.Create(lokacija));
            collection.Update(query, update3);

            Hotel hotel = VratiHotel(idHotela);
            List<Pansion> listaPansiona = VratiPansioneIzHotela(hotel.NazivHotela);
            if (cenaPolupansiona == "Nema")
            {
                foreach (Pansion p in listaPansiona)
                {
                    if (p.TipPansiona == "Polupansion")
                    {
                        ObrisiPansion(p.Id);

                        /*var query1 = Query.EQ("_id", idHotela);
                        var update = MongoDB.Driver.Builders.Update.Set("Pansioni",
                            BsonValue.Create(hotel.Pansioni));
                        collection.Update(query1, update);*/
                    }
                }
            }
            else
            {
                bool postoji = false;
                foreach (Pansion p in listaPansiona)
                {
                    if (p.TipPansiona == "Polupansion")
                    {
                        postoji = true;
                        var query1 = Query.EQ("_id", p.Id);
                        var update = MongoDB.Driver.Builders.Update.Set("Cena",
                            BsonValue.Create(float.Parse(cenaPolupansiona)));
                        collectionPansion.Update(query1, update);
                    }
                }
                if (!postoji)
                {
                    DodajPansion("Polupansion", float.Parse(cenaPolupansiona), hotel.NazivHotela);
                }
            }

            if (cenaPunogpansiona == "Nema")
            {
                foreach (Pansion p in listaPansiona)
                {
                    if (p.TipPansiona == "Pun pansion")
                    {
                        ObrisiPansion(p.Id);
                        /*var query1 = Query.EQ("_id", idHotela);
                        var update = MongoDB.Driver.Builders.Update.Set("Pansioni",
                            BsonValue.Create(hotel.Pansioni));
                        collection.Update(query1, update);*/
                    }
                }
            }
            else
            {
                bool postoji = false;
                foreach (Pansion p in listaPansiona)
                {
                    if (p.TipPansiona == "Pun pansion")
                    {
                        postoji = true;
                        var query1 = Query.EQ("_id", p.Id);
                        var update = MongoDB.Driver.Builders.Update.Set("Cena",
                            BsonValue.Create(float.Parse(cenaPunogpansiona)));
                        collectionPansion.Update(query1, update);
                    }
                }
                if (!postoji)
                {
                    DodajPansion("Pun pansion", float.Parse(cenaPunogpansiona), hotel.NazivHotela);
                }
            }

            List<Soba> listaSoba = VratiSobeUHotelu(hotel.NazivHotela);
            foreach (Soba s in listaSoba)
            {
                if (s.BrojKreveta == 1)
                {
                    var query1 = Query.EQ("_id", s.Id);
                    var update = MongoDB.Driver.Builders.Update.Set("CenaSobePoDanu",
                        BsonValue.Create(cenaJednokrevetnih));
                    collectionSoba.Update(query1, update);
                }
                else if (s.BrojKreveta == 2)
                {
                    var query1 = Query.EQ("_id", s.Id);
                    var update = MongoDB.Driver.Builders.Update.Set("CenaSobePoDanu",
                        BsonValue.Create(cenaDvokrevetnih));
                    collectionSoba.Update(query1, update);
                }
                else if (s.BrojKreveta == 3)
                {
                    var query1 = Query.EQ("_id", s.Id);
                    var update = MongoDB.Driver.Builders.Update.Set("CenaSobePoDanu",
                        BsonValue.Create(cenaTrokrevetnih));
                    collectionSoba.Update(query1, update);
                }
                else if (s.BrojKreveta == 4)
                {
                    var query1 = Query.EQ("_id", s.Id);
                    var update = MongoDB.Driver.Builders.Update.Set("CenaSobePoDanu",
                        BsonValue.Create(cenaCetvorokrevetnih));
                    collectionSoba.Update(query1, update);
                }
                else if (s.BrojKreveta == 5)
                {
                    var query1 = Query.EQ("_id", s.Id);
                    var update = MongoDB.Driver.Builders.Update.Set("CenaSobePoDanu",
                        BsonValue.Create(cenaPetokrevetnih));
                    collectionSoba.Update(query1, update);
                }
            }

        }

        public Hotel VratiHotel(ObjectId id)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Hotel>("Hotel");
            var query = Query.EQ("_id", id);
            Hotel hotel = collection.FindOne(query);
            return hotel;
        }
        public Hotel VratiHotel(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Hotel>("Hotel");
            var query = Query.EQ("NazivHotela", naziv);
            Hotel hotel = collection.FindOne(query);
            return hotel;
        }
        public List<Hotel> VratiHoteleIzGrada(String nazivGrada)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            var collectionGrad = database.GetCollection<Grad>("Grad");
            List<Hotel> lista = new List<Hotel>();
            Grad grad = VratiGrad(nazivGrada);


            var query = (from Hotel in collectionHotel.AsQueryable<Hotel>()

                         where Hotel.Grad.Id == grad.Id
                         select Hotel);
            foreach (Hotel h in query)
            {
                lista.Add(h);
            }

            return lista;
        }

        public void ObrisiHotel(String naziv)
        {
            Hotel hotel = VratiHotel(naziv);
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Hotel>("Hotel");

            var query = Query.EQ("NazivHotela", naziv);
            collection.Remove(query);

            var collectionSoba = database.GetCollection<Soba>("Soba");
            var query1 = from Soba in collectionSoba.AsQueryable<Soba>()
                         where Soba.Hotel.Id == hotel.Id
                         select Soba;

            foreach (Soba s in query1)
            {
                var query2 = Query.EQ("_id", s.Id);
                collectionSoba.Remove(query2);
            }

            var collectionPansion = database.GetCollection<Pansion>("Pansion");
            var query3 = from Pansion in collectionPansion.AsQueryable<Pansion>()
                         where Pansion.Hotel.Id == hotel.Id
                         select Pansion;

            foreach (Pansion s in query3)
            {
                var query4 = Query.EQ("_id", s.Id);
                collectionPansion.Remove(query4);
            }

        }

        public void AzurirajPutanjuSlike(String putanja, ObjectId idHotela)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Hotel>("Hotel");
            var query = Query.EQ("_id", idHotela);
            var update = MongoDB.Driver.Builders.Update.Set("PutanjaSlike",
                BsonValue.Create(putanja));
            collection.Update(query, update);
        }

        public List<Hotel> VratiHoteleSaOpremom(String nazivOpreme)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            var collectionOprema = database.GetCollection<SpecijalnaOprema>("SpecijalnaOprema");
            List<Hotel> lista = new List<Hotel>();
            List<Hotel> listaZaVracanje = new List<Hotel>();
            lista = VratiHotele();
            SpecijalnaOprema sp = VratiSpecijalnuOpremu(nazivOpreme);

            foreach (Hotel hotel in lista)
            {
                foreach (MongoDBRef h in hotel.SpecijalneOpreme)
                {
                    if (h.Id.Equals(sp.Id))
                    {
                        listaZaVracanje.Add(hotel);
                    }
                }
            }
            return listaZaVracanje;

        }
        #endregion

        #region Sobe

        public Soba VratiNtoKrevetnuSobu(int brojKreveta, String nazivHotela)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            var collectionSoba = database.GetCollection<Soba>("Soba");
            Soba soba = new Soba();
            List<Soba> lista = VratiSobeUHotelu(nazivHotela);
            foreach (Soba s in lista)
            {
                if (s.BrojKreveta == brojKreveta)
                {
                    soba = s;
                    return soba;
                }
            }
            return soba;
        }

        public void DodajSobu(int brojKreveta, float cenaPoDanu, String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionSoba = database.GetCollection<Soba>("Soba");
            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            Hotel hotel = VratiHotel(naziv);
            Soba soba = new Soba { BrojKreveta = brojKreveta, CenaSobePoDanu = cenaPoDanu };
            collectionSoba.Insert(soba);
            hotel.Sobe.Add(new MongoDBRef("Soba", soba.Id));
            soba.Hotel = new MongoDBRef("Hotel", hotel.Id);
            collectionSoba.Save(soba);
            collectionHotel.Save(hotel);
        }

        public Soba VratiSobu(ObjectId idSobe)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Soba>("Soba");

            var query = (from Soba in collection.AsQueryable<Soba>()
                         where Soba.Id == idSobe
                         select Soba).FirstOrDefault();
            return query;
        }
        public List<Soba> VratiSobeUHotelu(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectrionHotel = database.GetCollection<Hotel>("Hotel");
            var collectrionSoba = database.GetCollection<Soba>("Soba");
            List<Soba> sobe = new List<Soba>();
            Hotel hotel = VratiHotel(naziv);

            var query = (from Soba in collectrionSoba.AsQueryable<Soba>()
                         where Soba.Hotel.Id == hotel.Id
                         select Soba);

            foreach (Soba s in query)
            {
                sobe.Add(s);
            }

            return sobe;
        }

        public void ObrisiSobu(ObjectId idSobe)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionSoba = database.GetCollection<Soba>("Soba");
            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            Soba s = VratiSobu(idSobe);


            var query = Query.EQ("_id", idSobe);
            collectionSoba.Remove(query);

        }
        public void ObrisiNtokrevetnu(Hotel hotel, int brojKreveta)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionSoba = database.GetCollection<Soba>("Soba");
            var collectionHotel = database.GetCollection<Hotel>("Hotel");

            List<Soba> listaSoba = VratiSobeUHotelu(hotel.NazivHotela);
            foreach (Soba s in listaSoba)
            {
                if (s.BrojKreveta == brojKreveta)
                {

                    foreach (MongoDBRef mref in hotel.Sobe)
                    {
                        if (mref.Equals(s.Id))
                        {
                            hotel.Sobe.Remove(mref);
                            var query1 = Query.EQ("_id", hotel.Id);
                            var update = MongoDB.Driver.Builders.Update.Set("Sobe",
                                BsonValue.Create(hotel.Sobe));
                            collectionHotel.Update(query1, update);



                        }
                    }
                    var query = Query.EQ("_id", s.Id);
                    collectionSoba.Remove(query);
                    return;
                }
            }



        }
        public void ObrisiSobeUHotelu(String nazivHotela)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionSoba = database.GetCollection<Soba>("Soba");
            var collectionHotel = database.GetCollection<Hotel>("Hotel");

            Hotel hotel = VratiHotel(nazivHotela);
            //List<Grad> gradovi = new List<Grad>();
            var query1 = from Soba in collectionSoba.AsQueryable<Soba>()

                         where Soba.Hotel.Id == hotel.Id
                         select Soba;

            foreach (Soba s in query1)
            {
                var query = Query.EQ("_id", s.Id);
                collectionSoba.Remove(query);
            }


        }
        #endregion

        #region Pansion
        public void DodajPansion(String tipPansiona, float cenaPansiona, String nazivHotela)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionPansion = database.GetCollection<Pansion>("Pansion");
            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            Hotel hotel = VratiHotel(nazivHotela);
            Pansion pansion = new Pansion { TipPansiona = tipPansiona, Cena = cenaPansiona };
            collectionPansion.Insert(pansion);
            hotel.Pansioni.Add(new MongoDBRef("Pansion", pansion.Id));
            pansion.Hotel = new MongoDBRef("Hotel", hotel.Id);
            collectionPansion.Save(pansion);
            collectionHotel.Save(hotel);
        }

        public List<Pansion> VratiPansioneIzHotela(String nazivHotela)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectrionHotel = database.GetCollection<Hotel>("Hotel");
            var collectrionPansion = database.GetCollection<Soba>("Pansion");
            List<Pansion> pansioni = new List<Pansion>();
            Hotel hotel = VratiHotel(nazivHotela);

            var query = (from Pansion in collectrionPansion.AsQueryable<Pansion>()
                         where Pansion.Hotel.Id == hotel.Id
                         select Pansion);

            foreach (Pansion s in query)
            {
                pansioni.Add(s);
            }

            return pansioni;
        }

        public List<Pansion> VratiPansioneIzHotelaId(ObjectId idHotela)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectrionHotel = database.GetCollection<Hotel>("Hotel");
            var collectrionPansion = database.GetCollection<Soba>("Pansion");
            List<Pansion> pansioni = new List<Pansion>();
            Hotel hotel = VratiHotel(idHotela);

            var query = (from Pansion in collectrionPansion.AsQueryable<Pansion>()
                         where Pansion.Hotel.Id == hotel.Id
                         select Pansion);

            foreach (Pansion s in query)
            {
                pansioni.Add(s);
            }

            return pansioni;
        }

        public void ObrisiPansion(ObjectId idPansiona)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Soba>("Pansion");

            var query = Query.EQ("_id", idPansiona);
            collection.Remove(query);

        }

        public void ObrisiPansioneUHotelu(String NazivHotela)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionPansion = database.GetCollection<Pansion>("Pansion");
            var collectionHotel = database.GetCollection<Hotel>("Hotel");

            Hotel hotel = VratiHotel(NazivHotela);

            var query1 = from Pansion in collectionPansion.AsQueryable<Pansion>()

                         where Pansion.Hotel.Id == hotel.Id
                         select Pansion;

            foreach (Pansion p in query1)
            {
                var query = Query.EQ("_id", p.Id);
                collectionPansion.Remove(query);
            }


        }
        #endregion

        #region SpecijalnaOprema
        public SpecijalnaOprema VratiSpecijalnuOpremu(String naziv)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<SpecijalnaOprema>("SpecijalnaOprema");

            var query = (from SpecijalnaOprema in collection.AsQueryable<SpecijalnaOprema>()
                         where SpecijalnaOprema.Naziv == naziv
                         select SpecijalnaOprema).FirstOrDefault();
            return query;
        }
        public List<SpecijalnaOprema> VratiSpecijalneOpreme()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<SpecijalnaOprema>("SpecijalnaOprema");

            List<SpecijalnaOprema> lista = new List<SpecijalnaOprema>();
            foreach (SpecijalnaOprema h in collection.FindAll())
            {
                lista.Add(h);
            }
            return lista;
        }
        public List<SpecijalnaOprema> VratiOpremuUHotelu(Hotel hotel)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            var collectionOprema = database.GetCollection<SpecijalnaOprema>("SpecijalnaOprema");
            List<SpecijalnaOprema> lista = new List<SpecijalnaOprema>();
            List<SpecijalnaOprema> listaZaVracanje = new List<SpecijalnaOprema>();
            lista = VratiSpecijalneOpreme();

            foreach (SpecijalnaOprema so in lista)
            {
                foreach (MongoDBRef h in so.Hoteli)
                {
                    if (h.Id.Equals(hotel.Id))
                    {
                        listaZaVracanje.Add(so);
                    }
                }
            }
            return listaZaVracanje;

        }


        public void DodajNovuSpecijalnuOpremuZaHotel(ObjectId idHotela, String nazivOpreme)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            var collectionOprema = database.GetCollection<SpecijalnaOprema>("SpecijalnaOprema");
            Hotel hotel = VratiHotel(idHotela);
            SpecijalnaOprema oprema = new SpecijalnaOprema { Naziv = nazivOpreme };
            collectionOprema.Insert(oprema);
            hotel.SpecijalneOpreme.Add(new MongoDBRef("SpecijalnaOprema", oprema.Id));
            oprema.Hoteli.Add(new MongoDBRef("Hotel", hotel.Id));

            collectionOprema.Save(oprema);
            collectionHotel.Save(hotel);

        }
        public void DodajSpecijalnuOpremuZaHotel(ObjectId idHotela, String nazivOpreme)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            var collectionOprema = database.GetCollection<SpecijalnaOprema>("SpecijalnaOprema");
            Hotel hotel = VratiHotel(idHotela);
            SpecijalnaOprema oprema = VratiSpecijalnuOpremu(nazivOpreme);
            hotel.SpecijalneOpreme.Add(new MongoDBRef("SpecijalnaOprema", oprema.Id));
            oprema.Hoteli.Add(new MongoDBRef("Hotel", hotel.Id));

            collectionOprema.Save(oprema);
            collectionHotel.Save(hotel);

        }

        public void ObrisiSpecijalnuOpremuIzHotela(Hotel hotel, String nazivOpreme)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionHotel = database.GetCollection<Hotel>("Hotel");
            var collectionOprema = database.GetCollection<SpecijalnaOprema>("SpecijalnaOprema");

            SpecijalnaOprema oprema = VratiSpecijalnuOpremu(nazivOpreme);


            var filter = new BsonDocument("Naziv", oprema.Naziv);
            var update = Builders<SpecijalnaOprema>.Update.PullFilter("Hoteli",
                Builders<Hotel>.Filter.Eq("_id", hotel.Id));

            //collectionOprema.FindOne(filter, update);



        }


        #endregion

        #region Rezervacija

        public void DodajRezervaciju(String ime, String prezime, String brojLicneKarte,
            String sifraAranzmana, float ukupnaCena, int brojRate, String nazivHotela, String tipSobe, String tipPansiona, String nazivKompanije)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collectionRezervacija = database.GetCollection<RezervacijaAranzmana>("RezervacijaAranzmana");

            RezervacijaAranzmana rezervacija = new RezervacijaAranzmana
            {
                Ime = ime,
                Prezime = prezime,
                BrojLicneKarte = brojLicneKarte,
                SifraAranzmana = sifraAranzmana,
                UkupnaCena = ukupnaCena,
                BrojRata = brojRate,
                NazivHotela = nazivHotela,
                TipSobe = tipSobe,
                TipPansiona = tipPansiona,
                Prevoznik = nazivKompanije
            };
            collectionRezervacija.Insert(rezervacija);
            collectionRezervacija.Save(rezervacija);
        }
        public List<RezervacijaAranzmana> VratiRezervacijeKorisnika(String brojLicneKarte)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<RezervacijaAranzmana>("RezervacijaAranzmana");

            var query = (from RezervacijaAranzmana in collection.AsQueryable<RezervacijaAranzmana>()
                         where RezervacijaAranzmana.BrojLicneKarte == brojLicneKarte
                         select RezervacijaAranzmana);
            List<RezervacijaAranzmana> lista = new List<RezervacijaAranzmana>();
            foreach (RezervacijaAranzmana ra in query)
            {
                lista.Add(ra);
            }

            return lista;

        }
        public RezervacijaAranzmana VratiRezervacijuAranzmana(ObjectId id)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<RezervacijaAranzmana>("RezervacijaAranzmana");

            var query = (from RezervacijaAranzmana in collection.AsQueryable<RezervacijaAranzmana>()
                         where RezervacijaAranzmana.Id == id
                         select RezervacijaAranzmana).FirstOrDefault();
            return query;
        }

        public void ObrisiRezervaciju(ObjectId id)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("agencija");

            var collection = database.GetCollection<Grad>("RezervacijaAranzmana");


            var query = Query.EQ("_id", id);
            collection.Remove(query);


        }
        #endregion
    }
}
