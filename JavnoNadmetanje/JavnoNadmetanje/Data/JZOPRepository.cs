using AutoMapper;
using JavnoNadmetanje.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    public class JZOPRepository : IJZOPRepository
    {
        private readonly JavnoNadmetanjeContext context;
        private readonly IMapper mapper;

        public JZOPRepository(JavnoNadmetanjeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<JZOPEntity> GetJZOP()
        {
            return context.JZOP.Include(p => p.Etapa).ToList();
        }

        public JZOPEntity GetJZOPById(Guid javnoNadmetanjeId)
        {
            return context.JZOP.Include(p => p.Etapa).FirstOrDefault(a => a.javnoNadmetanjeID == javnoNadmetanjeId);
        }
        public JZOPConfirmation CreateJZOP(JZOPEntity jzop)
        {
            var createdEntity = context.Add(jzop);
            return mapper.Map<JZOPConfirmation>(createdEntity.Entity);
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

        public void UpdateJZOP(JZOPEntity jzop)
        {

        }
    }
}
