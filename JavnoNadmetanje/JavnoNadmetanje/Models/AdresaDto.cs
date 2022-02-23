using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Models
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

    }
}
