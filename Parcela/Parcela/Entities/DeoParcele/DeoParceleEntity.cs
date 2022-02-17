using Parcela.Entities.Parcela;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities.DeoParcele
{
    public class DeoParceleEntity
    {
        #region DeoParcele
        [Key]
        public Guid DeoParceleId { get; set; }

        public int Povrsina { get; set; }

        public int RedniBroj { get; set; }

        public bool Dodeljena { get; set; }

        [ForeignKey("Parcela")]
        public Guid ParcelaId { get; set; }
        public virtual ParcelaEntity Parcela { get; set; }
        #endregion 
    }
}
