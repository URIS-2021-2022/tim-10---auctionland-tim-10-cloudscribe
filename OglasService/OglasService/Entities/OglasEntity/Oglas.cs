using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Entities
{
    public class Oglas
    {
        public Guid OglasId { get; set; }

        public string TekstOglasa { get; set; }

        [ForeignKey("sluzbeniListId")]
        public Guid SluzbeniListId { get; set; }

    }
}
