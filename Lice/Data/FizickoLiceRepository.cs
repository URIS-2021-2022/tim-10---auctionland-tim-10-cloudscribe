using AutoMapper;
using Lice.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Data
{
    public class FizickoLiceRepository : IFizickoLiceRepository
    {
        private readonly LiceContext context;
        private readonly IMapper mapper;

        public FizickoLiceRepository(LiceContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public FizickoLiceConfirmationEntity CreateFizickoLice(FizickoLiceEntity fizickoLice)
        {
            var createdEntity = context.Add(fizickoLice);
            return mapper.Map<FizickoLiceConfirmationEntity>(createdEntity.Entity);
        }

        public void DeleteFizickoLice(Guid liceId)
        {
            var fizickoLice = GetFizickoLiceById(liceId);
            context.Remove(fizickoLice);
        }

        public List<FizickoLiceEntity> GetFizickaLica()
        {
            return context.FizickaLica.Include(p => p.Prioritet).ToList();
        }

        public FizickoLiceEntity GetFizickoLiceById(Guid liceId)
        {
            return context.FizickaLica.FirstOrDefault(a => a.liceId == liceId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateFizickoLice(FizickoLiceEntity fizickoLice)
        {
            
        }
    }
}
