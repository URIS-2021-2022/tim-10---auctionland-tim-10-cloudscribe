using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    [Serializable]
    public class LiceException : Exception
    {
        public LiceException(string message) : base(message)
        {

        }
    }
}
