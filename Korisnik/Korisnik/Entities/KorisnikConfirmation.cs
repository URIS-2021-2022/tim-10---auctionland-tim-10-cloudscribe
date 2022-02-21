using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Entities
{
    public class KorisnikConfirmation
    {
        public Guid KorisnikId { get; set; }
     

        public string KorisnikIme { get; set; }
        public string KorisnikPrezime { get; set; }

        
        public string Tip { get; set; }
        public Guid TipId { get; set; }
         public Guid KomisijaId { get; set; }
       



    }
}
