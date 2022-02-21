using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Models
{
    public class JZOPCreateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti datum.")]
        public DateTime datum { get; set; }
        /// <summary>
        /// Vreme pocetka javnog nadmetanja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti vreme pocetka.")]
        public DateTime vremePocetka { get; set; }
        /// <summary>
        /// Vreme zavrsetka javnog nadmetanja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti vreme kraja.")]
        public DateTime vremeKraja { get; set; }
        /// <summary>
        /// Pocetna cena na javnom nadmetanju
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti pocetnu cenu.")]
        public int pocetnaCena { get; set; }
        /// <summary>
        /// Izuzeto iz javnog nadmetanja
        /// </summary>
        public bool izuzeto { get; set; }
        /// <summary>
        /// Tip javnog nadmetanja
        /// </summary>
        public int tip { get; set; }
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
        /// Period zakupa u javnom nadmetanju
        /// </summary>
        public int periodZakupa { get; set; }
        //public string prijavljeniKupci { get; set; } //kupac
        //public string licitanti { get; set; } //ovlasceno lice
        /// <summary>
        /// Broj ucesnika u javnom nadmetanju
        /// </summary>
        public int brojUcesnika { get; set; }
        /// <summary>
        /// Definisana dopuna depozita u javnom nadmetanju
        /// </summary>
        public int dopunaDepozita { get; set; }
        /// <summary>
        /// Krug javnog nadmetanja
        /// </summary>
        public int krug { get; set; }
        /// <summary>
        /// Status javnog nadmetanja
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Oznaka javne licitacije
        /// </summary>
        public int brojJZOP { get; set; }
        // <summary>
        /// Opis javne licitacije
        /// </summary>
        public string opisJZOP { get; set; }
        /// <summary>
        /// Etapa ID
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID etape.")]
        public Guid etapaID { get; set; }
    }
}
