using OglasService.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class OglasDto
    {
        public Guid OglasId { get; set; }
        public string TekstOglasa { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid SluzbeniListId { get; set; }
        public virtual SluzbeniList SluzbeniList { get; set; }
        
    }
}
