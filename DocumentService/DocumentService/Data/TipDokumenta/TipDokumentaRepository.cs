using AutoMapper;
using DocumentService.Entities;
using DocumentService.Entities.TipDokumentaEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Data.TipDokumenta
{
    public class TipDokumentaRepository : ITipDokumentaRepository
    {
        private readonly DokumentContext context;
        private readonly IMapper mapper;



        public TipDokumentaRepository(DokumentContext tipContext, IMapper mapper)
        {
            this.context = tipContext;
            this.mapper = mapper;
        }
        public TipDokumentaConfirmation CreateTipDokumenta(TipDokumentaE tip)
        {
            var createdTip = context.Add(tip);
            return mapper.Map<TipDokumentaConfirmation>(createdTip.Entity);
        }

        internal static object GetAllTip()
        {
            throw new NotImplementedException();
        }

        public void DeleteTipDokumenta(Guid tipID)
        {
            var tipDel = GetTipByID(tipID);
            context.Remove(tipDel);
        }  


        public TipDokumentaE GetTipByID(Guid tipID)
        {
            return context.tipDokumenta.FirstOrDefault(e => e.TipDokumentaID == tipID);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }


         List<TipDokumentaE> ITipDokumentaRepository.GetAllTip()
        {
            return context.tipDokumenta.ToList();
        }

        public TipDokumentaE UpdateTipDokumenta(TipDokumentaE tip)
        {
            throw new NotImplementedException();
        }
    }
}
