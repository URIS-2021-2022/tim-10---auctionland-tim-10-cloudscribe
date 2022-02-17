using Parcela.Entities.Parcela;
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

        [Required]
        public string ImeKatastarskeOpstine { get; set; }

        public virtual List<ParcelaEntity> parcelaEntity { get; set; }

    }
}
