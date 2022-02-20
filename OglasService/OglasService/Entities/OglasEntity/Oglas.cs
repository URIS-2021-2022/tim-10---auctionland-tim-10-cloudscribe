using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Entities
{
    public class Oglas
    {
        [Key]
        public Guid OglasId { get; set; }

        public string TekstOglasa { get; set; }

       // [ForeignKey("SluzbeniList")]
        public Guid SluzbeniListId { get; set; }
       // public virtual SluzbeniList SluzbeniList { get; set; }

    }
}
