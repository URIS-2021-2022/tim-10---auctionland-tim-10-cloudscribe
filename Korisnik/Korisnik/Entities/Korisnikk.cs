using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Entities
{
    public class Korisnikk
    {
        #region Korisnik

        [Key]
        public Guid KorisnikId { get; set; }
        public string KorisnikIme { get; set; }
        public string KorisnikPrezime { get; set; }
        public string KorisnikKorisnickoIme { get; set; }
        public string KorisnikLozinka { get; set; }
       
        public Guid TipId { get; set; }

        [ForeignKey("TipId")]
        public Tip Tip { get; set; }

        [ForeignKey("KomisijaId")]
        public Nullable<Guid> KomisijaId { get; set; }
        public string Salt { get; set; }

        #endregion
    }
}
