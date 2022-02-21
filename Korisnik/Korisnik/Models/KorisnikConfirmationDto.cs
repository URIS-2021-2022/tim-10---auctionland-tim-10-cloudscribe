using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Models
{
    public class KorisnikConfirmationDto
    {
        public Guid KorisnikId { get; set; }
        public string KorisnikIme { get; set; }
        public string KorisnikPrezime { get; set; }
        public Guid KomisijaId { get; set; }
        public string Tip { get; set; }

    }
}
