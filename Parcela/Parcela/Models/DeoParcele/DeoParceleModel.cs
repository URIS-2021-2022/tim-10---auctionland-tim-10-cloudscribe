using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class DeoParceleModel
    {

        public Guid DeoParceleId { get; set; }

        public Guid ParcelaId { get; set; }

        public int povrsina { get; set; }
    }
}
