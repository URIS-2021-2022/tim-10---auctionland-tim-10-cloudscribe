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


        [ForeignKey("SluzbeniList")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SluzbeniListId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual SluzbeniList SluzbeniList { get; set; }

    }
}
