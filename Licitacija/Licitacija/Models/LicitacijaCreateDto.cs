using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Models
{
    public class LicitacijaCreateDto
    {
        /// <summary>
        /// Redni broj licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj licitacije.")]
        public int brojLicitacije { get; set; }
        /// <summary>
        /// Godina u kojoj je licitacija
        /// </summary>
         [Required(ErrorMessage = "Obavezno je uneti godinu licitacije.")]
        public int godinaLicitacije { get; set; }
        /// <summary>
        /// Datum kada je licitacija raspisana
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum raspisivanja licitacije.")]
        public DateTime datumRaspisivanja { get; set; } //datum licitacije
        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        public int ogranicenje { get; set; }

        /// <summary>
        /// Krug licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti krug licitacije.")]
        public int krugLicitacije { get; set; }
        /// <summary>
        /// Rok za prijavu za licitaciju
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum roka za prijave licitacije.")]
        public DateTime rokZaPrijave { get; set; }
        /// <summary>
        /// Javno nadmetanje
        /// </summary>
        public Guid javnoNadmetanjeId { get; set; }
        // <summary>
        /// Javna licitacija
        /// </summary>
        [NotMapped]
        public virtual JavnaLicitacijaDto javnaLicitacijaDto { get; set; }
        // <summary>
        /// Id Dokumenata
        /// </summary>
        public Guid dokumentId { get; set; }
        // <summary>
        /// Dokumenti
        /// </summary>
        [NotMapped]
        public virtual DokumentDto dokumentDto { get; set; }

    }
}
