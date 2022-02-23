using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Entities
{
    public class JavnaLicitacijaEntity : JavnoNadmetanjeEntity
    {

        /// <summary>
        /// Oznaka javne licitacije
        /// </summary>
        public int brojJavneLicitacije { get; set; }
        // <summary>
        /// Opis javne licitacije
        /// </summary>
        public string opisJavneLicitacije { get; set; }
        // <summary>
        /// ID koraka cene
        /// </summary>
        [ForeignKey("KorakCene")]
        public Guid korakCeneID { get; set; }
        /// <summary>
        /// Korak cene
        /// </summary>
        public virtual KorakCeneEntity KorakCene { get; set; }

    }
}
