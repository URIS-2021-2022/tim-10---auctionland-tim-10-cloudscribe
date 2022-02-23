using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class LiciterConfirmation
    {
        /// <summary>
        /// ID licitera
        /// </summary>
        public Guid LiciterId { get; set; }

        /// <summary>
        /// Ime licitera
        /// </summary>
        public string ImeLicitera { get; set; }

        /// <summary>
        /// Prezime licitera
        /// </summary>
        public string PrezimeLicitera { get; set; }

        public Guid liceId { get; set; }

        public Kupac Kupac { get; set; }
        public Zastupnik Zastupnik { get; set; }
    }
}
