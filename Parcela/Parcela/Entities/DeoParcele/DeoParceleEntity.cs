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
        /// <summary>
        /// ID dela parcele
        /// </summary>
        [Key]
        public Guid DeoParceleId { get; set; }
        /// <summary>
        /// Površina dela parcele
        /// </summary>
        public int Povrsina { get; set; }
        /// <summary>
        /// Redni broj parcele
        /// </summary>
        public int RedniBroj { get; set; }
        /// <summary>
        /// Da li je parcela dodeljena
        /// </summary>
        public bool Dodeljena { get; set; }
        /// <summary>
        /// ID stranog ključa parcele
        /// </summary>
        [ForeignKey("Parcela")]
        public Guid ParcelaId { get; set; }
        /// <summary>
        /// Entitet Parcele
        /// </summary>
        public virtual ParcelaEntity Parcela { get; set; }
        #endregion 
    }
}
