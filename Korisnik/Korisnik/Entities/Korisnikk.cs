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
        /// <summary>
        /// ID korisnika
        /// </summary>
        [Key]
        public Guid KorisnikId { get; set; }
        /// <summary>
        /// ime korisnika
        /// </summary>
        public string KorisnikIme { get; set; }
        /// <summary>
        /// prezime korisnika
        /// </summary>
        public string KorisnikPrezime { get; set; }
        /// <summary>
        /// korisnicko ime
        /// </summary>
        public string KorisnikKorisnickoIme { get; set; }
        /// <summary>
        /// lozinka korisnika
        /// </summary>
        public string KorisnikLozinka { get; set; }
        /// <summary>
        /// ID tipa korisnika
        /// </summary>
        public Guid TipId { get; set; }

        [ForeignKey("TipId")]
        public Tip Tip { get; set; }

        /// <summary>
        /// ID komisije 
        /// </summary>
        [ForeignKey("KomisijaId")]
        public Nullable<Guid> KomisijaId { get; set; }
        public string Salt { get; set; }

        #endregion
    }
}
