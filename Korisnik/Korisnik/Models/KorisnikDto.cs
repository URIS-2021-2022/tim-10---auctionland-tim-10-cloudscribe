using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Models
{
    public class KorisnikDto
    {
        #region Korisnik
        public Guid KorisnikId { get; set; }
        public string KorisnikIme { get; set; }
        public string KorisnikPrezime { get; set; }

        public string Tip { get; set; }

        public Guid TipId { get; set; }
        public Guid KomisijaId { get; set; }

        #endregion
    }
}
