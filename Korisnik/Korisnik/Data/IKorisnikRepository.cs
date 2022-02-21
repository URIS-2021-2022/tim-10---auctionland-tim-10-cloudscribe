using Korisnik.Entities;
using Korisnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Data
{
    public interface IKorisnikRepository
    {

        List<Korisnikk> GetKorisnik();

        Korisnikk GetKorisnikById(Guid korisnikID);

        KorisnikConfirmation CreateKorisnik(Korisnikk korisnikModel);

        

        void DeleteKorisnik(Guid korisnikID);
        List<Korisnikk> GetKorisnikByIdKomisija(Guid komisijaId);

        List<Korisnikk> GetKorisnikByImeTipa(string tipKorisnika);

        bool SaveChanges();

    }
}
