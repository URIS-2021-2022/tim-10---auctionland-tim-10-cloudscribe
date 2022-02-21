using OglasService.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class OglasDto
    {
        /// <summary>
        /// ID oglasa
        /// </summary>
        public Guid OglasId { get; set; }

        /// <summary>
        /// Tekst oglasa
        /// </summary>
        public string TekstOglasa { get; set; }
        public virtual SluzbeniList SluzbeniList { get; set; }
        
    }
}
