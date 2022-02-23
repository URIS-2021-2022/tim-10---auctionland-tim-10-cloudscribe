using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class OglasCreationDto
    {
        /// <summary>
        /// Tekst oglasa
        /// </summary>
        public string TekstOglasa { get; set; }

        /// <summary>
        /// ID sluzbeni list
        /// </summary>
        public Guid SluzbeniListId { get; set; }

        public Guid javnoNadmetanjeID { get; set; }

        public virtual OglasJavnoNadmetanjeDto javnoNadmetanje { get; set; }
    }
}
