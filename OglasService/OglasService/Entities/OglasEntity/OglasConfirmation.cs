using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Entities
{
    public class OglasConfirmation
    {
        /// <summary>
        /// ID oglas
        /// </summary>
        public Guid OglasId { get; set; }

        /// <summary>
        /// Tekst oglasa
        /// </summary>
        public string TekstOglasa { get; set; }
    }
}
