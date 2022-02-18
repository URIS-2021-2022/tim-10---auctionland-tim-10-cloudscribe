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
       /* private void FillData()
        {
            Korisnici.AddRange(new List<Korisnikk>
            {
                new Korisnikk
                {
                    KorisnikId= Guid.Parse("850da794-6460-424d-bd01-731e2f54a8c8"),
                    KorisnikIme= "Teodora",
                    KorisnikPrezime= "Jovanovic",
                    KorisnikKorisnickoIme="teajovanovic92",
                    KorisnikLozinka= "pera",
                    TipId = Guid.Parse("4c62ec6a-3857-4ca1-93a3-00736de02e7a"),
                    KomisijaId= Guid.Parse("e1ffc834-7f0c-4c52-9697-805b41aef182")
                }

            });
        }
       */
        public KorisnikConfirmation CreateKorisnik(Korisnikk korisnikModel)
        {
            
            var createdEntity = context.Korisnici.Add(korisnikModel);

            SaveChanges();
            createdEntity.Reference("Tip").Load();
            return mapper.Map<KorisnikConfirmation>(createdEntity.Entity);
           /* Korisnici.Add(korisnikModel);
           /*Korisnikk korisnik = GetKorisnikById(korisnikModel.KorisnikId);

               /* return new KorisnikConfirmation
                {
                    KorisnikId = korisnik.KorisnikId,
                    KorisnikIme = korisnik.KorisnikIme,
                    KorisnikPrezime = korisnik.KorisnikPrezime,
                    TipId= korisnik.TipId,
                    KomisijaId= korisnik.KomisijaId,
                };
               */
           
        }


        public void DeleteKorisnik(Guid korisnikID)
        {
            var korisnik = GetKorisnikById(korisnikID);
            context.Korisnici.Remove(korisnik);
            //Korisnici.Remove(Korisnici.FirstOrDefault(e => e.KorisnikId == korisnikID));
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
