using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities.KatastarskaOpstina
{
    public class KatastarskaOpstinaEntity
    {
        [Key]
        public Guid KatastarskaOpstinaId { get; set; }

        public string ImeKatastarskeOpstine { get; set; }
    }
}
