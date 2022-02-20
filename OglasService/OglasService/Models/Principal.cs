using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    /// <summary>
    /// Model autentifikacije
    /// </summary>
    public class Principal
    {
        /// <summary>
        /// Korisniko ime
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Korisnicka lozinka
        /// </summary>
        public string Password { get; set; }
    }
}
