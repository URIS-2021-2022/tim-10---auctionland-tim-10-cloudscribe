using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class ZasticenZonaConfirmationDto
    {


        /// <summary>
        /// ID Zaštićene zone
        /// </summary>
        public Guid ZasticenZonaId { get; set; }
        /// <summary>
        /// Broj zone
        /// </summary>
        public int BrojZone { get; set; }
    }
}
