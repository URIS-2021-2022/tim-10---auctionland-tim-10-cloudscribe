using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Entities
{
    public class EtapaConfirmation
    {
        /// <summary>
        /// ID etape
        /// </summary>
        public Guid etapaID { get; set; }
        /// <summary>
        /// Broj etape koja se izvodi
        /// </summary>
        public int brojEtape { get; set; }
    }
}
