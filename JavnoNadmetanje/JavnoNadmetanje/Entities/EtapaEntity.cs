using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Entities
{
    public class EtapaEntity
    {
        /// <summary>
        /// ID etape
        /// </summary>
        [Key]
        public Guid etapaID { get; set; }
        /// <summary>
        /// Broj etape koja se izvodi
        /// </summary>
        public int brojEtape { get; set; }
    }
}
