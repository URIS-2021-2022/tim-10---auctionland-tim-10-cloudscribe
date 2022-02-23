using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class JavnoNadmetanjeException : Exception
    {
        public JavnoNadmetanjeException(string message) : base(message)
        {

        }
    }
}
