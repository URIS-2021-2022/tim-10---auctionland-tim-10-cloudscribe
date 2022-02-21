using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Parcela.Entities;
using Parcela.Entities.Parcela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Data.Parcela
{
    public class ParcelaRepository : IParcelaRepository
    {

        private readonly ParcelaContext context;
        private readonly IMapper mapper;

        public ParcelaRepository(ParcelaContext parcelaContext, IMapper mapper)
        {
            this.context = parcelaContext;
            this.mapper = mapper;

        }


        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }


        public ParcelaConfirmation CreateParcela(ParcelaEntity parcela)
        {
            var createdParcela = context.Add(parcela);
            return mapper.Map<ParcelaConfirmation>(createdParcela.Entity);
        }

        public void DeleteParcela(Guid parcelaId)
        {
            var parcelaDeletion = GetParcelaById(parcelaId);
            context.Remove(parcelaDeletion);
        }

        public List<ParcelaEntity> GetParcela()
        {
            return context.Parcela.Include( p => p.KatastarskaOpstinaEntity).Include(s => s.ZasticenaZonaEntity).ToList();

            /*
            return (from e in context.Parcela
                    where string.IsNullOrEmpty(brojParcele) || e.BrojParcele == brojParcele &&
                          string.IsNullOrEmpty(katastarskaOpstina) || e.KatastarskaOpstina == katastarskaOpstina
                    select e).ToList(); */
        }

        public ParcelaEntity GetParcelaById(Guid parcelaId)
        {
            return context.Parcela.FirstOrDefault(e => e.ParcelaId == parcelaId);
        }

        public ParcelaConfirmation UpdateParcela(ParcelaEntity parcela)
        {
            throw new NotImplementedException();
        }
    }
}
