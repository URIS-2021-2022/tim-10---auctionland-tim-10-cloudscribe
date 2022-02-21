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
        /// <summary>
        /// ID katastarske opštine
        /// </summary>
        [Key]
        public Guid KatastarskaOpstinaId { get; set; }
        /// <summary>
        /// Ime katastarske opštine
        /// </summary>
        [Required]
        public string ImeKatastarskeOpstine { get; set; }
        /// <summary>
        /// Lista parcela u opštini
        /// </summary>
        public virtual List<ParcelaEntity> parcelaEntity { get; set; }

    }
}
