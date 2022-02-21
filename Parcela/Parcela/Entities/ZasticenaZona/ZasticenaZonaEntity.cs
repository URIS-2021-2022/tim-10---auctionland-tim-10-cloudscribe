using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities.ZasticenaZona
{
    public class ZasticenaZonaEntity
    {
        /// <summary>
        /// ID zaštićene zone
        /// </summary>
        [Key]
        public Guid ZasticenZonaId { get; set; }
        /// <summary>
        /// Broj zaštićene zone
        /// </summary>
        public int BrojZone { get; set; }
    }
}
