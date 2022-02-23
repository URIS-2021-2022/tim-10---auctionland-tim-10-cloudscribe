using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasService.Models
{
    public class OglasJavnoNadmetanjeDto
    {
        public Guid javnoNadmetanjeID { get; set; }
        public DateTime datum { get; set; }
     
        public DateTime vremePocetka { get; set; }
       
        public DateTime vremeKraja { get; set; }
    }
}
