using LiciterService.Entities;
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
                    DatumPocetkaZabrane=DateTime.Parse("2020-11-15T09:00:00"),
                    DatumPrestankaZabrane=DateTime.Parse("2021-11-15T09:00:00"),
                    DuzinaTrajanjaZabrane=365,
                    ImaZabranu=true,
                    OstvarenaPovrsina=1500000,
                },
                new Kupac
                {
                    KupacId=Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523029"),
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
            /return Kupci;
        }
        public Kupac GetKupacById(Guid kupacId)
        {
            return Kupci.FirstOrDefault(e => e.KupacId == kupacId);
        }
        public Kupac CreateKupac(Kupac kupac)
        {
            kupac.KupacId = Guid.NewGuid();
            Kupci.Add(kupac);
            var kup = GetKupacById(kupac.KupacId);

            return new Kupac
            {
                KupacId = kup.KupacId,
                DatumPocetkaZabrane = kup.DatumPocetkaZabrane,
                DatumPrestankaZabrane = kup.DatumPrestankaZabrane,
                ImaZabranu = kup.ImaZabranu,
                OstvarenaPovrsina = kup.OstvarenaPovrsina,
                DuzinaTrajanjaZabrane = kup.DuzinaTrajanjaZabrane

            };
        }

        public void DeleteKupac(Guid kupacId)
        {
            Kupci.Remove(Kupci.FirstOrDefault(e => e.KupacId == kupacId));
        }
        public void UpdateKupac(Kupac kupac)
        {
            var kup = GetKupacById(kupac.KupacId);

            kup.KupacId = kupac.KupacId;
            kup.DatumPocetkaZabrane = kupac.DatumPocetkaZabrane;
            kup.DatumPrestankaZabrane = kupac.DatumPrestankaZabrane;
            kup.ImaZabranu = kupac.ImaZabranu;
            kup.OstvarenaPovrsina = kupac.OstvarenaPovrsina;
            kup.DuzinaTrajanjaZabrane = kupac.DuzinaTrajanjaZabrane;


        }
        public bool SaveChanges()
        {
            return true;
        }
        
    }
}
