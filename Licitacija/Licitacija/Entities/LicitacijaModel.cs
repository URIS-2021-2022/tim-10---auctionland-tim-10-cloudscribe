using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Entities
{
    public class LicitacijaModel
    {
        /// <summary>
        /// ID licitacije
        /// </summary>
        [Key]
        public Guid licitacijaId { get; set; }
        /// <summary>
        /// Redni broj licitacije
        /// </summary>
        public int brojLicitacije { get; set; }
        /// <summary>
        /// Godina u kojoj je licitacija
        /// </summary>
        public int godinaLicitacije { get; set; }
        /// <summary>
        /// Datum kada je licitacija raspisana
        /// </summary>
        public DateTime datumRaspisivanja { get; set; } //datum licitacije
        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        public int ogranicenje { get; set; }
        /// <summary>
        /// Dokument
        /// </summary>
     
        //  public string[] dokumentacijaFizickaLica { get; set; } // niz vrednosti 
        // public string[] dokumentacijaPravnaLica { get; set; }
        /// <summary>
        /// Krug licitacije
        /// </summary>
        public int krugLicitacije { get; set; }
        /// <summary>
        /// Rok za prijavu za licitaciju
        /// </summary>
        public DateTime rokZaPrijave { get; set; }
        /// <summary>
        /// Javno nadmetanje
        /// </summary>

        //  public string[] javnoNadmetanje { get; set; } //niz vrednosti 
    }
}
