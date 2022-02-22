using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Models
{
    public class KorisnikDokumentDto
    {
        public Guid TipId { get; set; }
        /// <summary>
        /// Ime tipa
        /// </summary>
        public string TipKorisnika { get; set; }

    }
}
