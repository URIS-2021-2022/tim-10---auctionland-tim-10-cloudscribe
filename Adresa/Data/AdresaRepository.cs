using Adresa.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Data
{
    public class AdresaRepository : IAdresaRepository
    {
        private readonly AdresaContext context;
        private readonly IMapper mapper;

        public AdresaRepository(AdresaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public List<AdresaEntity> GetAdrese()
        {
            return context.Adrese.Include(d => d.Drzava).ToList();
        }

        public AdresaEntity GetAdresaById(Guid adresaId)
        {
            return context.Adrese.Include(d => d.Drzava).FirstOrDefault(a => a.AdresaId == adresaId);
        }

        public AdresaConfirmationEntity CreateAdresa(AdresaEntity adresaModel)
        {
            var createdEntity = context.Add(adresaModel);
            return mapper.Map<AdresaConfirmationEntity>(createdEntity.Entity);
        }

        public void DeleteAdresa(Guid adresaId)
        {
            var adresa = GetAdresaById(adresaId);
            context.Remove(adresa);
        }

        public void UpdateAdresa(AdresaEntity adresaModel)
        {
            //nije potrebna implementacija
        }
    }
}
