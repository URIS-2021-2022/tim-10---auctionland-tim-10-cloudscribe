using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Models
{
    public class JavnaLicitacijaDto
    {
        /// <summary>
        /// ID javne licitacije
        /// </summary>
        public Guid javnoNadmetanjeID { get; set; }
        /// <summary>
        /// Datum javne licitacije
        /// </summary>
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

        /// <summary>
        /// Katastarska opstina vezana za javno nadmetanje
        /// </summary>
        public string katastarskaOpstina { get; set; }
        /// <summary>
        /// Period zakupa u javnom nadmetanju
        /// </summary>
        public int periodZakupa { get; set; }

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
        public int brojJavneLicitacije { get; set; }
        // <summary>
        /// Opis javne licitacije
        /// </summary>
        public string opisJavneLicitacije { get; set; }
        /// <summary>
        /// ID koraka cene
        /// </summary>
        public Guid korakCeneID { get; set; }
        /// <summary>
        /// ID adrese
        /// </summary>
        [ForeignKey("Adresa")]
        public Guid adresaId { get; set; }
        /// <summary>
        /// Adresa 
        /// </summary>
        [NotMapped]
        public virtual AdresaDto adresaDto { get; set; }
        /// <summary>
        /// ID parcele
        /// </summary>

        [ForeignKey("Parcela")]
        public Guid parcelaId { get; set; }
        /// <summary>
        /// Parcela
        /// </summary>
        [NotMapped]
        public virtual ParcelaDto parcelaDto { get; set; }
        /// <summary>
        /// ID licitera
        /// </summary>
        [ForeignKey("Liciter")]
        public Guid liciterId { get; set; }
        /// <summary>
        /// Liciter
        /// </summary>
        [NotMapped]
        public virtual LiciterDto liciterDto { get; set; }
    }
}
