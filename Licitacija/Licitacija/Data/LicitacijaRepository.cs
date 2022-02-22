using AutoMapper;
using Licitacija.Entities;
using Licitacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Data
{
    public class LicitacijaRepository : ILicitacijaRepository
    {
        private readonly LicitacijaContext context;
        private readonly IMapper mapper;

        public LicitacijaRepository(LicitacijaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public List<LicitacijaModel> GetAllLicitacije()
        {
            return context.Licitacija.ToList();
        }

        public LicitacijaModel GetLicitacijaById(Guid licitacijaId)
        {
            return context.Licitacija.FirstOrDefault(e => e.licitacijaId == licitacijaId);
        }

        public LicitacijaConfirmation CreateLicitacija(LicitacijaModel licitacijaModel)
        {
            var createdEntity = context.Add(licitacijaModel);
            return mapper.Map<LicitacijaConfirmation>(createdEntity.Entity);
        }

        public void UpdateLicitacija(LicitacijaModel licitacijaModel)
        {
            //Nije potrebna implementacija jer EF core prati entitet koji smo izvukli iz baze
            //i kada promenimo taj objekat i odradimo SaveChanges sve izmene će biti perzistirane

        }

        public void DeleteLicitacija(Guid licitacijaId)
        {
            var licitacija = GetLicitacijaById(licitacijaId);
            context.Remove(licitacija);
        }


    }
}
