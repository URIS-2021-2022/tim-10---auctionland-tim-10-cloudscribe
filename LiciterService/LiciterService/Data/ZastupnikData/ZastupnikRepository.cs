using AutoMapper;
using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Data
{
    public class ZastupnikRepository : IZastupnikRepository

    {
        private readonly LiciterContext context;
        private readonly IMapper mapper;

        public ZastupnikRepository(LiciterContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ZastupnikConfirmation CreateZastupnik(Zastupnik zastupnik)
        {
            var createdEntity = context.Add(zastupnik);
            return mapper.Map<ZastupnikConfirmation>(createdEntity.Entity);
        }

        public void DeleteZastupnik(Guid zastupnikId)
        {
            var zastupnik = GetZastupnikById(zastupnikId);
            context.Remove(zastupnik);
        }

        public List<Zastupnik> GetZastupnici()
        {
            return context.Zastupnici.ToList();
        }

        public Zastupnik GetZastupnikById(Guid zastupnikId)
        {
            return context.Zastupnici.FirstOrDefault(e => e.ZastupnikId == zastupnikId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public ZastupnikConfirmation UpdateZastupnik(Zastupnik zastupnik)
        {
            throw new NotImplementedException();
        }

    }
}
