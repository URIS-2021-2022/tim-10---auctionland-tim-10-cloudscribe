using LiciterService.Entities;
using LiciterService.Entities.ZastupnikEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Data
{
    public class ZastupnikMockRepository : IZastupnikRepository
    {
        public static List<Zastupnik> Zastupnici { get; set; } = new List<Zastupnik>();
        public ZastupnikMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            Zastupnici.AddRange(new List<Zastupnik>
            {
                new Zastupnik
                {
                    ZastupnikId=Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a66"),
                    ImeZastupnika="Novak",
                    PrezimeZastupnika="Djokovic",
                    Jmbg=163588962,
                    Adresa="Beogradska 25",
                    NazivDrzave="Srbija",
                    BrojTable=255
                },
                new Zastupnik
                {
                    ZastupnikId=Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a52"),
                    ImeZastupnika="Petar",
                    PrezimeZastupnika="Petrovic",
                    Jmbg=58966345,
                    Adresa="Narodnog Fronta 13",
                    NazivDrzave="Srbija",
                    BrojTable=365
                }
            });
        }

        public ZastupnikConfirmation CreateZastupnik(Zastupnik zastupnik)
        {
            zastupnik.ZastupnikId = Guid.NewGuid();
            Zastupnici.Add(zastupnik);
            Zastupnik ovlascenoLice = GetZastupnikById(zastupnik.ZastupnikId);

            return new ZastupnikConfirmation
            {
                ZastupnikId = ovlascenoLice.ZastupnikId,
                PrezimeZastupnika = ovlascenoLice.PrezimeZastupnika,
                ImeZastupnika = ovlascenoLice.ImeZastupnika
            };
        }

        public void DeleteZastupnik(Guid zastupnikId)
        {
            Zastupnici.Remove(Zastupnici.FirstOrDefault(e => e.ZastupnikId == zastupnikId));
        }

        public List<Zastupnik> GetZastupnici()
        {
            return Zastupnici;
        }

        public Zastupnik GetZastupnikById(Guid zastupnikId)
        {
            return Zastupnici.FirstOrDefault(e => e.ZastupnikId == zastupnikId);
        }

        public bool SaveChanges()
        {
            return true;
        }

        public ZastupnikConfirmation UpdateZastupnik(Zastupnik zastupnik)
        {
            var ovlascenoLice = GetZastupnikById(zastupnik.ZastupnikId);
            ovlascenoLice.ZastupnikId = zastupnik.ZastupnikId;
            ovlascenoLice.ImeZastupnika = zastupnik.ImeZastupnika;
            ovlascenoLice.PrezimeZastupnika = zastupnik.PrezimeZastupnika;
            ovlascenoLice.Jmbg = zastupnik.Jmbg;
            ovlascenoLice.Adresa = zastupnik.Adresa;
            ovlascenoLice.BrojTable = zastupnik.BrojTable;
            ovlascenoLice.NazivDrzave = zastupnik.NazivDrzave;

            return new ZastupnikConfirmation
            {
                ZastupnikId = ovlascenoLice.ZastupnikId,
                ImeZastupnika = ovlascenoLice.ImeZastupnika,
                PrezimeZastupnika = ovlascenoLice.PrezimeZastupnika
            };
        }
    }
}
