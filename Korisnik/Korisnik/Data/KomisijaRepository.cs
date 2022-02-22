using AutoMapper;
using Korisnik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Data
{
    public class KomisijaRepository : IKomisijaRepository
    {
        private readonly KorisnikContext context;
        private readonly IMapper mapper;
      

        public KomisijaRepository(KorisnikContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
        
        public Komisija CreateKomisija(Komisija komisijaModel)
        {
            var createEntity = context.Komisije.Add(komisijaModel);
            SaveChanges();
            return mapper.Map<Komisija>(createEntity.Entity);

        }

        public void DeleteKomisija(Guid komisijaId)
        {
            var komisija = GetKomisijaById(komisijaId);
            context.Komisije.Remove(komisija);
        }

        public List<Komisija> GetKomisija()
        {
            return context.Komisije.ToList();
        }

     
        public Komisija GetKomisijaById(Guid komisijaId)
        {
            return context.Komisije.FirstOrDefault(e => e.KomisijaId == komisijaId);
        }

        

    }
}
