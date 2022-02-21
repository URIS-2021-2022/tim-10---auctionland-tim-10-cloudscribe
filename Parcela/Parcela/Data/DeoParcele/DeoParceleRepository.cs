using AutoMapper;
using Parcela.Entities;
using Parcela.Entities.DeoParcele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Data.DeoParcele
{
    public class DeoParceleRepository : IDeoParceleRepository
    {

        private readonly ParcelaContext context;
        private readonly IMapper mapper;

        public DeoParceleRepository(ParcelaContext deoContext, IMapper mapper)
        {
            this.context = deoContext;
            this.mapper = mapper;
        }

        public DeoParceleConfirmation CreateDeoParcele(DeoParceleEntity deoParcele)
        {
            var createdDeoParcele = context.Add(deoParcele);
            
            return mapper.Map<DeoParceleConfirmation>(createdDeoParcele.Entity);
        }

        public void DeleteDeoParcele(Guid deoParceleId)
        {
            var deoParceleDeletion = GetDeoParceleById(deoParceleId);
            context.Remove(deoParceleDeletion);
        }

        public List<DeoParceleEntity> GetDeoParcele()
        {
            return context.DeoParceleEntity.ToList();
        }

        public DeoParceleEntity GetDeoParceleById(Guid deoParceleId)
        {
            return context.DeoParceleEntity.FirstOrDefault(e => e.DeoParceleId == deoParceleId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public DeoParceleConfirmation updateDeoParcele(DeoParceleEntity deoParcele)
        {
            throw new NotImplementedException();
        }
    }
}
