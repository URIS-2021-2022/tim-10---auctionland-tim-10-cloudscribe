using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities.ZasticenaZona
{
    public class ZasticenaZonaEntity
    {
        [Key]
        public Guid ZasticenZonaId { get; set; }

        public int BrojZone { get; set; }
    }
}
