using AutoMapper;
using Parcela.Entities;
using Parcela.Entities.ZasticenaZona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Data.ZasticenaZona
{
    public class ZasticenaZonaRepository : IZasticenaZonaRepository
    {

        private readonly ParcelaContext context;
        private readonly IMapper mapper;

        public ZasticenaZonaRepository(ParcelaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ZasticenaZonaConfirmation CreateZasticenaZona(ZasticenaZonaEntity zasticenaZona)
        {
            var createdZasticenaZona = context.Add(zasticenaZona);
            return mapper.Map<ZasticenaZonaConfirmation>(createdZasticenaZona.Entity);
        }

        public void DeleteZasticenaZona(Guid ZasticenZonaId)
        {
            var zasticenaZonaDeletion = GetZasticenaZonaById(ZasticenZonaId);
            context.Remove(zasticenaZonaDeletion);
        }

        public List<ZasticenaZonaEntity> GetZasticenaZona()
        {
            return context.ZasticenaZona.ToList();
        }

        public ZasticenaZonaEntity GetZasticenaZonaById(Guid ZasticenZonaId)
        {
            return context.ZasticenaZona.FirstOrDefault(e => e.ZasticenZonaId == ZasticenZonaId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public ZasticenaZonaConfirmation UpdateZasticenaZona(ZasticenaZonaEntity zasticenaZona)
        {
            throw new NotImplementedException();
        }
    }
}
