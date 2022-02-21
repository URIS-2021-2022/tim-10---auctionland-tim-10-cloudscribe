using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Models
{
    public class KorisnikCreationDto
    {
        #region Korisnik
      
        public string KorisnikIme { get; set; }
        public string KorisnikPrezime { get; set; }
        public string KorisnikKorisnickoIme { get; set; }
        public string KorisnikLozinka { get; set; }
        public Guid TipId { get; set; }
        public Guid KomisijaId { get; set; }

        #endregion
    }
}
    

