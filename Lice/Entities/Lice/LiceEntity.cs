using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Entities
{
    public class LiceEntity
    {
        /// <summary>
        /// ID Lica
        /// </summary>
        [Key]
        public Guid liceId { get; set; }

        /// <summary>
        /// Prvi broj telefona lica
        /// </summary>
        public int brojTelefona1 { get; set; }

        /// <summary>
        /// Drugi broj telefona lica
        /// </summary>
        public int brojTelefona2 { get; set; }

        /// <summary>
        /// Email adresa lica
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Broj racuna lica
        /// </summary>
        public string brojRacuna { get; set; }

        
    }
}
