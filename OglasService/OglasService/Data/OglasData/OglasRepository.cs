using AutoMapper;
using OglasService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Data
{
    public class OglasRepository : IOglasRepository
    {
        private readonly IMapper mapper;
        private readonly OglasContext context;

        public OglasRepository(IMapper mapper,OglasContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public OglasConfirmation CreateOglas(Oglas oglas)
        {
           var createdEntity=context.Add(oglas);
            return mapper.Map<OglasConfirmation>(createdEntity.Entity);
        }

        public void DeleteOglas(Guid oglasId)
        {
            var oglas=GetOglasById(oglasId);
            context.Remove(oglas);
        }

        public Oglas GetOglasById(Guid oglasId)
        {
            return context.Oglasi.FirstOrDefault(e => e.OglasId == oglasId);
        }

        public List<Oglas> GetOglasi()
        {
            return context.Oglasi.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateOglas(Oglas oglas)
        {
            throw new NotImplementedException();
        }
    }
}
