using AutoMapper;
using Korisnik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Data
{
    public class TipRepository : ITipRepository
    {

        private readonly KorisnikContext context;
      
        
        public TipRepository( KorisnikContext context)
        {
            this.context = context;
          
        }
       
       public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
      
       
      

        public List<Tip> GetTip()
        {
            return context.Tipovi.ToList();
        }

        public Tip GetTipById(Guid tipId)
        {
            return context.Tipovi.FirstOrDefault(e => e.TipId == tipId);
        }
    }
}
