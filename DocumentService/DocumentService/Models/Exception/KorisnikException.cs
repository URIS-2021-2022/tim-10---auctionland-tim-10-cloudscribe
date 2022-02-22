using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Models
{
    public class KorisnikException : Exception
    {
        public KorisnikException(string message) : base(message)
        {

        }
    }
}
