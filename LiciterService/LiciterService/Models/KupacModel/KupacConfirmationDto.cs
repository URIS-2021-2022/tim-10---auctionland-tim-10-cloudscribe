using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class KupacConfirmationDto
    {
        public Guid KupacId { get; set; }

        public DateTime? DatumPocetkaZabrane { get; set; }

        public DateTime? DatumPrestankaZabrane { get; set; }

    }
}
