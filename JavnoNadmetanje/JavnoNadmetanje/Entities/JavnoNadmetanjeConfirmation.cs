using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Entities
{
    public class JavnoNadmetanjeConfirmation
    {

        /// <summary>
        /// ID javnog nadmetanja
        /// </summary>
        public Guid javnoNadmetanjeID { get; set; }
        /// <summary>
        /// Datum javnog nadmetanja
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
        /// Status javnog nadmetanja
        /// </summary>

        public string status { get; set; }

        /// <summary>
        /// ID adrese
        /// </summary>

        public Guid adresaId { get; set; }
        /// <summary>
        /// Adresa 
        /// </summary>
        [NotMapped]
        public virtual AdresaDto adresaDto { get; set; }
        /// <summary>
        /// ID parcele
        /// </summary>
        /// 
        public Guid parcelaId { get; set; }
        /// <summary>
        /// Parcela
        /// </summary>
        [NotMapped]
        public virtual ParcelaDto parcelaDto { get; set; }
        /// <summary>
        /// ID licitera
        /// </summary>

        public Guid liciterId { get; set; }
        /// <summary>
        /// Liciter
        /// </summary>
        [NotMapped]
        public virtual LiciterDto liciterDto { get; set; }
    }
}
