using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Models
{
    public class JavnaLicitacijaDto
    {
        /// <summary>
        /// ID javne licitacije
        /// </summary>

        public Guid javnoNadmetanjeId { get; set; }
        public DateTime datum { get; set; }
        /// <summary>
        /// Vreme pocetka javnog nadmetanja
        /// </summary>
        public DateTime vremePocetka { get; set; }
        /// <summary>
        /// Vreme zavrsetka javnog nadmetanja
        /// </summary>
        public DateTime vremeKraja { get; set; }
        /// <summary>
        /// Pocetna cena na javnom nadmetanju
        /// </summary>
        public int pocetnaCena { get; set; }
        /// <summary>
        /// Izlicitirana cena na javnom nadmetanju
        /// </summary>
        public int izlicitiranaCena { get; set; }
        //  public string najboljiPonudjac { get; set; } //kupac

        //public string adresaOdrzavanjaNadmetanja // adresa
        /// <summary>
        /// Katastarska opstina vezana za javno nadmetanje
        /// </summary>
        public string katastarskaOpstina { get; set; }

        /// <summary>
        /// Krug javnog nadmetanja
        /// </summary>
        public int krug { get; set; }
        /// <summary>
        /// Status javnog nadmetanja
        /// </summary>
        public string status { get; set; }

        // <summary>
        /// Opis javne licitacije
        /// </summary>
        public string opisJavneLicitacije { get; set; }
    }
}
