using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ZalbaService.Entities
{
    /// <summary>
    /// Entity class for TipZalbe
    /// </summary>
    public partial class TipZalbe
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public TipZalbe()
        {
            Zalba = new HashSet<Zalba>();
        }
        /// <summary>
        /// Foreign key
        /// </summary>
        public int TipZalbeId { get; set; }
        /// <summary>
        /// Type of zalba
        /// </summary>
        public string TipZalbe1 { get; set; }
        /// <summary>
        /// List of zalba's which are connected to this entity
        /// </summary>
        public virtual ICollection<Zalba> Zalba { get; set; }
    }
}
