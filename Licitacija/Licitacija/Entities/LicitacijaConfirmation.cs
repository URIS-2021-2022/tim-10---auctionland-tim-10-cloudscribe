using Licitacija.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Entities
{
    public class LicitacijaConfirmation
    {
        /// <summary>
        /// ID licitacije
        /// </summary>
        public Guid licitacijaId { get; set; }
        /// <summary>
        /// Broj licitacije
        /// </summary>
        public int brojLicitacije { get; set; }
        /// <summary>
        /// Godina licitacije
        /// </summary>
        public int godinaLicitacije { get; set; }
        /// <summary>
        /// Datum raspisivanja licitacije
        /// </summary>
        public DateTime datumRaspisivanja { get; set; }
        /// <summary>
        /// ID javnog nadmetanja
        /// </summary>
        public Guid javnoNadmetanjeId { get; set; }
        [NotMapped]
        public virtual JavnaLicitacijaDto javnaLicitacijaDto { get; set; }

        public Guid dokumentiId { get; set; }

        [NotMapped]
        public virtual DokumentDto dokumentDto { get; set; }
    }
}
