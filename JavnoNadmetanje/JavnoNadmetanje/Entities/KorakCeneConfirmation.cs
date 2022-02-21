using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Entities
{
    public class KorakCeneConfirmation
    {
        /// <summary>
        /// ID koraka cene
        /// </summary>
        public Guid korakCeneID { get; set; }
        /// <summary>
        /// Oznaka koraka cene
        /// </summary>
        public int brojKoraka { get; set; }
    }
}
