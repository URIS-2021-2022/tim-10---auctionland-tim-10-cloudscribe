using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class OglasUpdateDto
    {
        /// <summary>
        /// ID oglasa
        /// </summary>
        public Guid OglasId { get; set; }

        /// <summary>
        /// Tekst oglasa
        /// </summary>
        public string TekstOglasa { get; set; }

        /// <summary>
        /// ID sluzbeni list
        /// </summary>
        public Guid SluzbeniListId { get; set; }
    }
}
