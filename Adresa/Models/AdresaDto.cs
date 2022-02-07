using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Models
{
    /// <summary>
    /// Model adrese
    /// </summary>
    public class AdresaDto
    {
        /// <summary>
        /// Ulica i broj adrese
        /// </summary>
        public string UlicaBroj { get; set; }
        
        /// <summary>
        /// Mesto adrese
        /// </summary>
        public string Mesto { get; set; }

        /// <summary>
        /// Poštanski broj adrese
        /// </summary>
        public int PostanskiBroj { get; set; } 

        /// <summary>
        /// ID države
        /// </summary>
        public Guid DrzavaId { get; set; }

        /// <summary>
        /// Naziv države
        /// </summary>
        public string NazivDrzave { get; set; }

    }
}
