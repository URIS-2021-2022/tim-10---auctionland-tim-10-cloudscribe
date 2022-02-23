using Licitacija.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Entities
{
    public class LicitacijaModel
    {
        /// <summary>
        /// ID licitacije
        /// </summary>
        [Key]
        public Guid licitacijaId { get; set; }
        /// <summary>
        /// Redni broj licitacije
        /// </summary>
        public int brojLicitacije { get; set; }
        /// <summary>
        /// Godina u kojoj je licitacija
        /// </summary>
        public int godinaLicitacije { get; set; }
        /// <summary>
        /// Datum kada je licitacija raspisana
        /// </summary>
        public DateTime datumRaspisivanja { get; set; } //datum licitacije
        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        public int ogranicenje { get; set; }
        
        /// <summary>
        /// Krug licitacije
        /// </summary>
        public int krugLicitacije { get; set; }
        /// <summary>
        /// Rok za prijavu za licitaciju
        /// </summary>
        public DateTime rokZaPrijave { get; set; }

        [ForeignKey("JavnoNadmetanje")]
        public Guid javnoNadmetanjeId { get; set; }
        [NotMapped]
        public virtual JavnaLicitacijaDto javnaLicitacijaDto { get; set; }
        [NotMapped]

        [ForeignKey("Dokument")]
        public Guid  dokumentiId { get; set; }

        [NotMapped]
        public virtual DokumentDto dokumentDto { get; set; }

    }
}
