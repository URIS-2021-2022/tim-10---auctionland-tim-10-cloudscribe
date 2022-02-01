using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Data
{
    public class LiciterRepository : ILiciterRepository
    {
        public static List<Liciter> Liciteri { get; set; } = new List<Liciter>();

        public LiciterRepository()
        {
            FillData();
        }

        private void FillData()
        {
            Liciteri.AddRange(new List<Liciter>
            {
                new Liciter{
                LiciterId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                },
            new Liciter{
                LiciterId=Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
            } }); 
        }

        public Liciter GetLiciterById(Guid liciterId)
        {
            return Liciteri.FirstOrDefault(e => e.LiciterId == liciterId);
        }

        public bool SaveChanges()
        {
            return true;
        }
    }
}
