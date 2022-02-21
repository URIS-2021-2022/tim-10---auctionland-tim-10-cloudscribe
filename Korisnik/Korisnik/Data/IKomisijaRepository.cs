using Korisnik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Data
{
   public interface IKomisijaRepository
    {
        List<Komisija> GetKomisija();

        Komisija GetKomisijaById(Guid komisijaId);


        
        Komisija CreateKomisija(Komisija komisijaModel);

        void DeleteKomisija(Guid komisijaId);
        bool SaveChanges();



    }
}
