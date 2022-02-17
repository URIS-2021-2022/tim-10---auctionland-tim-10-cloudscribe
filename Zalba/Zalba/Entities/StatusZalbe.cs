using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ZalbaService.Entities
{
    /// <summary>
    /// Entity class for StatusZalbe
    /// </summary>
    public partial class StatusZalbe
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public StatusZalbe()
        {
            Zalba = new HashSet<Zalba>();
        }

        /// <summary>
        /// Foreign key
        /// </summary>
        public int StatusZalbeId { get; set; }

        /// <summary>
        /// Status of zalba
        /// </summary>
        public string StatusZalbe1 { get; set; }

        /// <summary>
        /// List of zalba's which are connected to this entity
        /// </summary>
        public virtual ICollection<Zalba> Zalba { get; set; }
    }
}
