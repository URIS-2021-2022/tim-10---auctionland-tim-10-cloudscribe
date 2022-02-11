using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models.DeoParcele
{
    public class DeoParceleCreationDto
    {
        #region DeoParcele
        

        public Guid ParcelaId { get; set; }

        public int Povrsina { get; set; }

        public int RedniBroj { get; set; }

        public bool Dodeljena { get; set; }
        #endregion 
    }
}
