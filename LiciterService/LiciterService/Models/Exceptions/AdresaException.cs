using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    [Serializable]
    public class AdresaException:Exception
    {
        public AdresaException(string message) : base(message)
        {

        }
    }
}
