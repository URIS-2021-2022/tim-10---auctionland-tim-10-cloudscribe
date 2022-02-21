using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Entities
{
    public class KorakCeneEntity
    {
        /// <summary>
        /// ID koraka cene
        /// </summary>
        [Key]
        public Guid korakCeneID { get; set; }
        /// <summary>
        /// Oznaka koraka cene
        /// </summary>
        public int brojKoraka { get; set; }
    }
}
