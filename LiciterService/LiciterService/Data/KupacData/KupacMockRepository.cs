using LiciterService.Entities;
using LiciterService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Data
{
    public class KupacMockRepository: IKupacRepository
    {
        public static List<Kupac> Kupci { get; set; } = new List<Kupac>();

        public KupacMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            Kupci.AddRange(new List<Kupac>
            {
                new Kupac
                {
                    KupacId=Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a36"),
                    ImeKupca="Maksim",
                    PrezimeKupca="Gorki",
                    DatumPocetkaZabrane=DateTime.Parse("2020-11-15T09:00:00"),
                    DatumPrestankaZabrane=DateTime.Parse("2021-11-15T09:00:00"),
                    DuzinaTrajanjaZabrane=365,
                    ImaZabranu=true,
                    OstvarenaPovrsina=1500000,
                },
                new Kupac
                {
                    KupacId=Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523029"),
                    ImeKupca="Dzejn",
                    PrezimeKupca="Ostin",
                    DatumPocetkaZabrane=DateTime.Parse("2021-12-15T09:00:00"),
                    DatumPrestankaZabrane=DateTime.Parse("2022-5-15T09:00:00"),
                    DuzinaTrajanjaZabrane=365,
                    ImaZabranu=true,
                    OstvarenaPovrsina=15500,
                }
            });
        }
        public List<Kupac> GetKupci()
        {
            return Kupci;
        }
        public Kupac GetKupacById(Guid kupacId)
        {
            return Kupci.FirstOrDefault(e => e.KupacId == kupacId);
        }
        public KupacConfirmation CreateKupac(Kupac kupac)
        {
            kupac.KupacId = Guid.NewGuid();
            Kupci.Add(kupac);
            Kupac kup = GetKupacById(kupac.KupacId);

            return new KupacConfirmation
            {
                KupacId = kup.KupacId,
                //ImaZabranu = kup.ImaZabranu,
                ImeKupca=kup.ImeKupca,
                PrezimeKupca=kup.PrezimeKupca

            };
        }

        public void DeleteKupac(Guid kupacId)
        {
            Kupci.Remove(Kupci.FirstOrDefault(e => e.KupacId == kupacId));
        }
        public KupacConfirmation UpdateKupac(Kupac kupac)
        {
            var kup = GetKupacById(kupac.KupacId);

            kup.KupacId = kupac.KupacId;
            kup.DatumPocetkaZabrane = kupac.DatumPocetkaZabrane;
            kup.DatumPrestankaZabrane = kupac.DatumPrestankaZabrane;
            kup.ImaZabranu = kupac.ImaZabranu;
            kup.OstvarenaPovrsina = kupac.OstvarenaPovrsina;
            kup.DuzinaTrajanjaZabrane = kupac.DuzinaTrajanjaZabrane;

            return new KupacConfirmation
            {
                KupacId = kup.KupacId,
                //ImaZabranu = kup.ImaZabranu,
                ImeKupca = kup.ImeKupca,
                PrezimeKupca = kup.PrezimeKupca
            };

        }
        public bool SaveChanges()
        {
            return true;
        }

       
    }
}
