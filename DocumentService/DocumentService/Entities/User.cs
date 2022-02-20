using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Entities
{
    public class User
    {
        /// <summary>
        /// Id korisnika
        /// </summary>
        public Guid KorisnikId { get; set; }

        /// <summary>
        /// Ime korisnika
        /// </summary>
        public string KorisnikIme { get; set; }

        /// <summary>
        /// Prezime korisnika
        /// </summary>
        public string KorisnikPrezime { get; set; }

        /// <summary>
        /// Korisničko ime
        /// </summary>
        public string KorisnikKorisnickoIme { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// Hash-ovana šifra korisnika
        /// </summary>
        public string KorisnikLozinka { get; set; }

        /// <summary>
        /// Salt
        /// </summary>
        public string Salt { get; set; }
    }
}
