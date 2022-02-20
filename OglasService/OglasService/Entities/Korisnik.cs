using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Entities
{
    public class Korisnik
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Ime korisnika
        /// </summary>
        public string ImeKorisnika { get; set; }

        /// <summary>
        /// Prezime korisnika
        /// </summary>
        public string PrezimeKorisnika { get; set; }

        /// <summary>
        /// Korisničko ime
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email korisnika
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Hash-ovana šifra korisnika
        /// </summary>
        public string Lozinka { get; set; }

        /// <summary>
        /// Salt
        /// </summary>
        public string Salt { get; set; }
    }
}
