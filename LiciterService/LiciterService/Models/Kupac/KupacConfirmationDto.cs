using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class KupacConfirmationDto
    {
        public Guid KupacId { get; set; }
        public string ImeKupca { get; set; }
        public string PrezimeKupca { get; set; }
    }
}
