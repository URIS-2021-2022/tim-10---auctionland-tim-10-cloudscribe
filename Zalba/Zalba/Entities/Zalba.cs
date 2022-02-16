using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ZalbaService.Entities
{
    /// <summary>
    /// Entity class for Zalba
    /// </summary>
    public partial class Zalba
    {
        /// <summary>
        /// Id of Zalba
        /// </summary>
        public int ZalbaId { get; set; }
        /// <summary>
        /// Reason why Zalba is created
        /// </summary>
        public string RazlogZalbe { get; set; }
        /// <summary>
        /// Detailed reason why Zalba is created
        /// </summary>
        public string Obrazlozenje { get; set; }   
        /// <summary>
        /// Date of creating Zalba
        /// </summary>
        public DateTime? DatumPodnosenja { get; set; }
        /// <summary>
        /// Date of resolving Zalba
        /// </summary>
        public DateTime? DatumResenja { get; set; }
        /// <summary>
        /// Decision's document unique identifier
        /// </summary>
        public string BrojResenja { get; set; }
        /// <summary>
        /// Decision's unique identifier
        /// </summary>
        public string BrojOdluke { get; set; }
        /// <summary>
        /// TipZalbe's foreign key
        /// </summary>
        public int? TipZalbeId { get; set; }
        /// <summary>
        /// StatusZalbe's foreign key
        /// </summary>
        public int? StatusZalbeId { get; set; }
        /// <summary>
        /// RadnjaNaOsnovuZalbe's foreign key
        /// </summary>
        public int? RadnjaNaOsnovuZalbeId { get; set; }
        /// <summary>
        /// RadnjaNaOsnovuZalbe's connected entity
        /// </summary>
        public virtual RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe { get; set; }
        /// <summary>
        /// StatusZalbe's connected entity
        /// </summary>
        public virtual StatusZalbe StatusZalbe { get; set; }
        /// <summary>
        /// TipZalbe's connected entity
        /// </summary>
        public virtual TipZalbe TipZalbe { get; set; }
    }
}
