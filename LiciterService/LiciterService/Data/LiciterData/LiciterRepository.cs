using AutoMapper;
using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Data.LiciterData
{
    public class LiciterRepository : ILiciterRepository
    {
        private readonly LiciterContext context;
        private readonly IMapper mapper;

        public LiciterRepository(LiciterContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public LiciterConfirmation CreateLiciter(Liciter liciter)
        {
            var createdEntity = context.Add(liciter);
            return mapper.Map<LiciterConfirmation>(createdEntity.Entity);
        }

        public void DeleteLiciter(Guid liciterId)
        {
            var liciter = GetLiciterById(liciterId);
            context.Remove(liciter);
        }

        public Liciter GetLiciterById(Guid liciterId)
        {
            return context.Liciteri.FirstOrDefault(e => e.LiciterId == liciterId);
        }

        public List<Liciter> GetLiciteri()
        {
            return context.Liciteri.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateLiciter(Liciter liciter)
        {
            throw new NotImplementedException();
        }
    }
}
