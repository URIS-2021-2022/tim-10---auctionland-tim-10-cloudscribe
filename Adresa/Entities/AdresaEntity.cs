using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Entities
{
    public class AdresaEntity
    {
        /// <summary>
        /// ID adrese
        /// </summary>
        [Key]
        public Guid AdresaId { get; set; }

        /// <summary>
        /// Ulica adrese
        /// </summary>
        public string Ulica { get; set; }

        /// <summary>
        /// Broj adrese
        /// </summary>
        public string Broj { get; set; }

        /// <summary>
        /// Mesto adrese
        /// </summary>
        public string Mesto { get; set; }

        /// <summary>
        /// Poštanski broj adrese
        /// </summary>
        public int PostanskiBroj { get; set; }

        /// <summary>
        /// ID države
        /// </summary>
        [ForeignKey("Drzava")]
        public Guid DrzavaId { get; set; }

        /// <summary>
        /// Drzava
        /// </summary>
        public virtual DrzavaEntity Drzava { get; set; }
    }
}
