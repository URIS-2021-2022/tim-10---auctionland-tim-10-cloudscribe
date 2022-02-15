using AutoMapper;
using OglasService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Data
{
    public class SluzbeniListRepository : ISluzbeniListRepository
    {
        private readonly IMapper mapper;
        private readonly OglasContext context;

        public SluzbeniListRepository(IMapper mapper, OglasContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public SluzbeniListConfirmation CreateSluzbeniList(SluzbeniList sluzbeniList)
        {
            var createdEntity = context.Add(sluzbeniList);
            return mapper.Map<SluzbeniListConfirmation>(createdEntity.Entity);
        }

        public void DeleteSluzbeniList(Guid sluzbeniListId)
        {
            var sluzbeniList = GetSluzbeniListById(sluzbeniListId);
            context.Remove(sluzbeniList);
        }

        public SluzbeniList GetSluzbeniListById(Guid sluzbeniListId)
        {
            return context.SluzbeniListovi.FirstOrDefault(e => e.SluzbeniListId == sluzbeniListId);
        }

        public List<SluzbeniList> GetSluzbeniListovi()
        {
            return context.SluzbeniListovi.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateSluzbeniList(SluzbeniList sluzbeniList)
        {
            throw new NotImplementedException();
        }
    }
}
