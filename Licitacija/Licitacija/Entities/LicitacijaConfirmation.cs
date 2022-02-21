using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Entities
{
    public class LicitacijaConfirmation
    {
        public Guid licitacijaId { get; set; }
        public int brojLicitacije { get; set; }
        public int godinaLicitacije { get; set; }
        public DateTime datumRaspisivanja { get; set; }
    }
}
