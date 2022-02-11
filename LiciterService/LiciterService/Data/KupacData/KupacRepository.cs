using AutoMapper;
using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Data.KupacData
{
    public class KupacRepository : IKupacRepository
    {
        private readonly LiciterContext context;
        private readonly IMapper mapper;

        public KupacRepository(LiciterContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public KupacConfirmation CreateKupac(Kupac kupac)
        {
            var createdEntity = context.Add(kupac);
            return mapper.Map<KupacConfirmation>(createdEntity.Entity);
        }

        public void DeleteKupac(Guid kupacId)
        {
            var kup = GetKupacById(kupacId);
            context.Remove(kup);
        }

        public Kupac GetKupacById(Guid kupacId)
        {
            return context.Kupci.FirstOrDefault(e => e.KupacId == kupacId);
        }

        public List<Kupac> GetKupci()
        {
            return context.Kupci.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void  UpdateKupac(Kupac kupac)
        {
            //nije potrebno izvrsiti implementaciju
        }
    }
}
