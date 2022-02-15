using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class OglasUpdateDto
    {
        public Guid OglasId { get; set; }
        public string TekstOglasa { get; set; }
        public Guid SluzbeniListId { get; set; }
    }
}
