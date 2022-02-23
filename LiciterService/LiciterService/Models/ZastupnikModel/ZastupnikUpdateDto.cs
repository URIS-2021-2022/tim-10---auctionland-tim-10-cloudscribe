using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class ZastupnikUpdateDto
    {
        /// <summary>
        /// ID zastupnika
        /// </summary>
        public Guid ZastupnikId { get; set; }

        /// <summary>
        /// JMBG
        /// </summary>
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Jmbg ne moze imati vise,a ni manje od 13 karaktera.")]
        public string Jmbg { get; set; }

        /// <summary>
        /// Broj pasosa
        /// </summary>
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Broj pasosa ne moze imati vise, a ni manje od 9 karaktera.")]
        public string BrojPasosa { get; set; }

        /// <summary>
        /// Naziv drzave
        /// </summary>
        [Required(ErrorMessage = "Obavezno uneti naziv drzave")]
        public string NazivDrzave { get; set; }

        /// <summary>
        /// Broj table za licitiranje
        /// </summary>
        [Required(ErrorMessage = "Obavezno uneti broj table za licitaciju")]
        public int BrojTable { get; set; }

        public Guid AdresaId { get; set; }

        [NotMapped]
        public AdresaZastupnikDto Adresa { get; set; }
        /// <summary>
        /// ID kupca
        /// </summary>
        public Guid KupacId { get; set; }



    }
}

