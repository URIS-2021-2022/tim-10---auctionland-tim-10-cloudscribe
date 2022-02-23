using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Models
{
    public class LicitacijaConfirmationDto
    {
        /// <summary>
        /// ID licitacije
        /// </summary>
        public Guid licitacijaId { get; set; }
        /// <summary>
        /// Redni broj licitacije
        /// </summary>
        public int brojLicitacije { get; set; }
        /// <summary>
        /// Godina u kojoj se vrsi licitacije
        /// </summary>
        public int godinaLicitacije { get; set; }
        public DateTime datumRaspisivanja { get; set; }
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
