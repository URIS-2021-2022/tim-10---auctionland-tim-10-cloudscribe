using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class ZastupnikConfirmationDto
    {
        public Guid ZastupnikId { get; set; }
        public string ImeZastupnika { get; set; }
        public string PrezimeZastupnika { get; set; }
    }
}
