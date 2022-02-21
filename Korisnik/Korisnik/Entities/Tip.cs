using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Entities
{
    public class Tip
    {
        /// <summary>
        /// ID Tipa
        /// </summary>
        public Guid TipId { get; set; }
        /// <summary>
        /// Ime tipa
        /// </summary>
        public string TipKorisnika { get; set; }

    }
}
