using AutoMapper;
using JavnoNadmetanje.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    public class JzopRepository : IJzopRepository
    {
        private readonly JavnoNadmetanjeContext context;
        private readonly IMapper mapper;

        public JzopRepository(JavnoNadmetanjeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<JzopEntity> GetJZOP()
        {
            return context.JZOP.Include(p => p.Etapa).ToList();
        }

        public JzopEntity GetJZOPById(Guid javnoNadmetanjeId)
        {
            return context.JZOP.Include(p => p.Etapa).FirstOrDefault(a => a.javnoNadmetanjeID == javnoNadmetanjeId);
        }
        public JzopConfirmation CreateJZOP(JzopEntity JZOP)
        {
            var createdEntity = context.Add(JZOP);
            return mapper.Map<JzopConfirmation>(createdEntity.Entity);
        }

        public void DeleteJZOP(Guid javnoNadmetanjeId)
        {
            var jzop = GetJZOPById(javnoNadmetanjeId);
            context.Remove(jzop);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateJZOP(JzopEntity JZOP)
        {
            throw new NotSupportedException();
        }
    }
}
