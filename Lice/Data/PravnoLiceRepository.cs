using AutoMapper;
using Lice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Data
{
    public class PravnoLiceRepository : IPravnoLiceRepository
    {
        private readonly LiceContext context;
        private readonly IMapper mapper;

        public PravnoLiceRepository(LiceContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public PravnoLiceConfirmationEntity CreatePravnoLice(PravnoLiceEntity pravnoLice)
        {
            var createdEntity = context.Add(pravnoLice);
            return mapper.Map<PravnoLiceConfirmationEntity>(createdEntity.Entity);
        }

        public void DeletePravnoLice(Guid liceId)
        {
            var pravnoLice = GetPravnoLiceById(liceId);
            context.Remove(pravnoLice);
        }

        public List<PravnoLiceEntity> GetPravnaLica()
        {
            return context.PravnaLica.ToList();
        }

        public PravnoLiceEntity GetPravnoLiceById(Guid liceId)
        {
            return context.PravnaLica.FirstOrDefault(a => a.liceId == liceId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdatePravnoLice(PravnoLiceEntity pravnoLice)
        {
            
        }
    }
}
