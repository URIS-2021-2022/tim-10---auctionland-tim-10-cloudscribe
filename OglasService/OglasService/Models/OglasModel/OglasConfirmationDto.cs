using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public Guid javnoNadmetanjeID { get; set; }

        [NotMapped]
        public virtual OglasJavnoNadmetanjeDto javnoNadmetanje { get; set; }
    }
}
