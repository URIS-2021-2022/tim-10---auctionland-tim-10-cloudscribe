using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Entities
{
    public class LiciterConfirmation
    {
        public Guid LiciterId { get; set; }
        public string ImeLicitera { get; set; }
        public string PrezimeLicitera { get; set; }
    }
}
