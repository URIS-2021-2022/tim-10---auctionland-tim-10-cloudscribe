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
        public Liciter GetLiciterById(Guid liciterId)
        {
            return context.Liciteri.FirstOrDefault(e => e.LiciterId == liciterId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
