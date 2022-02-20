using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Models
{
    //Predstavlja model za autentifikaciju
    public class Principal
    {
        public string KorisnickoIme { get; set; }

        public string Password { get; set; }
    }
}
