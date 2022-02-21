using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities.ZasticenaZona
{
    public class ZasticenaZonaConfirmation
    {
        /// <summary>
        /// ID zaštićene zone
        /// </summary>
        public Guid ZasticenZonaId { get; set; }
        /// <summary>
        /// Broj zaštićene zone
        /// </summary>
        public int BrojZone { get; set; }
    }
}
