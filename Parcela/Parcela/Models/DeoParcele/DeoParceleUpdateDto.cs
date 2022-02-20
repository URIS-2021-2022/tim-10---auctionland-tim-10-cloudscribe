using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models.DeoParcele
{
    public class DeoParceleUpdateDto
    {
        #region DeoParcele
        /// <summary>
        /// ID dela parcele
        /// </summary>
        public Guid DeoParceleId { get; set; }
        /// <summary>
        /// ID parcele
        /// </summary>
        public Guid ParcelaId { get; set; }
        /// <summary>
        /// Površina dela parcele
        /// </summary>
        public int Povrsina { get; set; }
        /// <summary>
        /// Redni broj
        /// </summary>
        public int RedniBroj { get; set; }
        /// <summary>
        /// Da li je dodeljen deo parcele
        /// </summary>
        public bool Dodeljena { get; set; }
        #endregion 
    }
}
