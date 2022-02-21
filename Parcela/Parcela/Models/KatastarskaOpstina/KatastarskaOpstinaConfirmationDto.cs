using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models.KatastarskaOpstina
{
    public class KatastarskaOpstinaConfirmationDto
    {
        /// <summary>
        /// Katastarska Opština ID
        /// </summary>
        public Guid KatastarskaOpstinaId { get; set; }
        /// <summary>
        /// Ime Katastarske Opštine
        /// </summary>
        public string ImeKatastarskeOpstine { get; set; }
    }
}
