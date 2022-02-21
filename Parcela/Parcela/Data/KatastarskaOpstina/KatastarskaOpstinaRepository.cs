using AutoMapper;
using Parcela.Entities;
using Parcela.Entities.KatastarskaOpstina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Data.KatastarskaOpstina
{
    public class KatastarskaOpstinaRepository : IKatastarskaOpstinaRepository
    {
        private readonly ParcelaContext context;
        private readonly IMapper mapper;
        public KatastarskaOpstinaRepository(ParcelaContext koContext, IMapper mapper)
        {
            this.context = koContext;
            this.mapper = mapper;
        }

        public KatastarskaOpstinaConfirmation CreateKatastarskaOpstina(KatastarskaOpstinaEntity katastarskaOpstina)
        {
            var opstina = context.Add(katastarskaOpstina);
            return mapper.Map<KatastarskaOpstinaConfirmation>(opstina.Entity);
        }

        public void DeleteKatastarskaOpstina(Guid KatastarskaOpstinaId)
        {
            var opstina = GetKatastarskaOpstinaById(KatastarskaOpstinaId);
            context.Remove(opstina);
        }

        public List<KatastarskaOpstinaEntity> GetKatastarskaOpstina()
        {
            return context.KatastarskaOpstina.ToList();
        }

        public KatastarskaOpstinaEntity GetKatastarskaOpstinaById(Guid KatastarskaOpstinaId)
        {
            return context.KatastarskaOpstina.FirstOrDefault(e => e.KatastarskaOpstinaId == KatastarskaOpstinaId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public KatastarskaOpstinaConfirmation UpdateKatastarskaOpstina(KatastarskaOpstinaEntity katastarskaOpstina)
        {
            throw new NotImplementedException();
        }
    }
}
