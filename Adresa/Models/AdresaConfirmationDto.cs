using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Models
{
    public class AdresaConfirmationDto
    {
        /// <summary>
        /// ID adrese
        /// </summary>
        public Guid AdresaId { get; set; }

        /// <summary>
        /// Ulica i broj adrese
        /// </summary>
        public string UlicaBroj { get; set; }

        public string Mesto { get; set; }

        public int PostanskiBroj { get; set; }

        //public string NazivDrzave { get; set; }

    }
}
