using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
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

        /*/// <summary>
        /// ID države
        /// </summary>
        public Guid DrzavaId { get; set; }*/

        /// <summary>
        /// Naziv države adrese
        /// </summary>
        public string NazivDrzave { get; set; }

    }
}
