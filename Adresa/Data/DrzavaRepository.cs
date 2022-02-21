using Adresa.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Data
{
    public class DrzavaRepository : IDrzavaRepository
    {
        private readonly AdresaContext context;

        public DrzavaRepository(AdresaContext context)
        {
            this.context = context;
        }

        public DrzavaEntity GetDrzavaById(Guid drzavaId)
        {
            return context.Drzave.FirstOrDefault(d => d.DrzavaId == drzavaId);
        }

        public List<DrzavaEntity> GetDrzave()
        {
            return context.Drzave.ToList();
        }


    }
}
