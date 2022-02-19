using DocumentService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Data
{
    public interface IDokumentRepository
    {
        List<Dokument> GetAllDokuments();
        public Dokument GetDokumentEntityById(Guid dokumentid);
        DokumentConfirmation CreateDokument(Dokument dokument);
        void UpdateDokument(Dokument dokument);
        void DeleteDokument(Guid dokumentid);
        bool SaveChanges();



    }
}
