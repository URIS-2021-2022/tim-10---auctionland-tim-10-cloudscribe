using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Entities.Prioritet
{
    public class PrioritetEntity
    {
        /// <summary>
        /// ID prioriteta
        /// </summary>
        [Key]
        public Guid prioritetId { get; set; }

        /// <summary>
        /// Opis prioriteta
        /// </summary>
        public string opisPrioriteta { get; set; }

    }
}
