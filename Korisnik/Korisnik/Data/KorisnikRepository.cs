using AutoMapper;
using Korisnik.Entities;
using Korisnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Korisnik.Data
{
    public class KorisnikRepository : IKorisnikRepository
    {
        private readonly KorisnikContext context;
        private readonly IMapper mapper;
        

        public KorisnikRepository(KorisnikContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
       
        public KorisnikConfirmation CreateKorisnik(Korisnikk korisnikModel)
        {
            
            var createdEntity = context.Korisnici.Add(korisnikModel);

            SaveChanges();
            createdEntity.Reference("Tip").Load();
            return mapper.Map<KorisnikConfirmation>(createdEntity.Entity);
          
           
        }


        public void DeleteKorisnik(Guid korisnikID)
        {
            var korisnik = GetKorisnikById(korisnikID);
            context.Korisnici.Remove(korisnik);
           
            SaveChanges();
        }

        public List<Korisnikk> GetKorisnik()
        {
            return context.Korisnici.Include(t=>t.Tip).ToList();
        }

        public Korisnikk GetKorisnikById(Guid korisnikID)
        {
            return context.Korisnici.FirstOrDefault(e => e.KorisnikId == korisnikID);
        }

        
        public List<Korisnikk> GetKorisnikByIdKomisija(Guid komisijaId)
        {
            return context.Korisnici.Where(e => e.KomisijaId == komisijaId).ToList() ;
        }
        public List<Korisnikk> GetKorisnikByImeTipa(string tipKorisnika)
        {
            return context.Korisnici.Include(t => t.Tip).Where(k => k.Tip.TipKorisnika == tipKorisnika).ToList();
        }
    }
}
