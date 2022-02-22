using AutoMapper;
using JavnoNadmetanje.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    public class JavnaLicitacijaRepository : IJavnaLicitacijaRepository
    {
        private readonly JavnoNadmetanjeContext context;
        private readonly IMapper mapper;

        public JavnaLicitacijaRepository(JavnoNadmetanjeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<JavnaLicitacijaEntity> GetJavneLicitacije()
        {
            return context.JavnaLicitacija.Include(p => p.Etapa).Include(e => e.KorakCene).ToList();
        }

        public JavnaLicitacijaEntity GetJavnaLicitacijaById(Guid javnaLicitacijaId)
        {
            return context.JavnaLicitacija.Include(p => p.Etapa).Include(e => e.KorakCene).FirstOrDefault(a => a.javnoNadmetanjeID == javnaLicitacijaId);
        }

        public JavnaLicitacijaConfirmation CreateJavnaLicitacija(JavnaLicitacijaEntity javnaLicitacija)
        {
            var createdEntity = context.Add(javnaLicitacija);
            return mapper.Map<JavnaLicitacijaConfirmation>(createdEntity.Entity);
        }

        public void DeleteJavnaLicitacija(Guid javnaLicitacijaId)
        {
            var javnaLicitacija = GetJavnaLicitacijaById(javnaLicitacijaId);
            context.Remove(javnaLicitacija);
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateJavnaLicitacija(JavnaLicitacijaEntity javnaLicitacija)
        {
            throw new NotSupportedException();
        }
    }
}
