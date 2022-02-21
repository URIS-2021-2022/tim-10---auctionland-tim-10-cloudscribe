using DocumentService.Entities.TipDokumentaEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Data.TipDokumenta
{
   public interface ITipDokumentaRepository
    {
        List<TipDokumentaE> GetAllTip();
        public TipDokumentaE GetTipByID(Guid tipID);
        TipDokumentaConfirmation CreateTipDokumenta(TipDokumentaE tip);
        TipDokumentaE UpdateTipDokumenta(TipDokumentaE tip);
        void DeleteTipDokumenta(Guid tipID);
        bool SaveChanges();
    }
}
