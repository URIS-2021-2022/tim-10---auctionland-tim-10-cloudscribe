using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Models
{
    public class LicitacijaUpdateDto
    {
        /// <summary>
        /// ID licitacije
        /// </summary>
        public Guid licitacijaId { get; set; }
        // <summary>
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
