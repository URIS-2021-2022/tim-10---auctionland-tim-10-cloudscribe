using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class OglasConfirmationDto
    {
        /// <summary>
        /// ID oglasa
        /// </summary>
        public Guid OglasId { get; set; }

        /// <summary>
        /// Tekst oglasa
        /// </summary>
        public string TekstOglasa { get; set; }
    }
}
