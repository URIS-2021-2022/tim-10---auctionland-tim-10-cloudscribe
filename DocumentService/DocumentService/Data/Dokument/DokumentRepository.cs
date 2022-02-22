using AutoMapper;
using DocumentService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentService.Data
{
    public class DokumentRepository : IDokumentRepository
    {
        private readonly DokumentContext context;
        private readonly IMapper mapper;
        


        public DokumentRepository(DokumentContext dokumentContext, IMapper mapper)
        {
            this.context = dokumentContext;
            this.mapper = mapper;
        }
        public DokumentConfirmation CreateDokument (Dokument dokument)
        {
            var createdDokument = context.Add(dokument);
            return mapper.Map<DokumentConfirmation>(createdDokument.Entity);
        }

        

        public void DeleteDokument(Guid dokumentid)
        {
            var dokumentDel = GetDokumentEntityById(dokumentid);
            context.Remove(dokumentDel);
        }

       public List<Dokument> GetAllDokuments()
        {
            return context.Dokument.ToList();
        }

        public Dokument GetDokumentEntityById(Guid dokumentid)
        {
            return context.Dokument.FirstOrDefault(e => e.DokumentID == dokumentid);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public DokumentConfirmation UpdateDokument(Dokument dokument)
        {
            throw new NotImplementedException();
        }

        void IDokumentRepository.UpdateDokument(Dokument dokument)
        {
            throw new NotImplementedException();
        }
    }
}
