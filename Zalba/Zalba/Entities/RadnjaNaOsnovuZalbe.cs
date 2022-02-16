using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ZalbaService.Entities
{
    /// <summary>
    /// Entity class for RadnjaNaOsnovuZalbe
    /// </summary>
    public partial class RadnjaNaOsnovuZalbe
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public RadnjaNaOsnovuZalbe()
        {
            Zalba = new HashSet<Zalba>();
        }
        /// <summary>
        /// Foreign key
        /// </summary>

        public int RadnjaNaOsnovuZalbeId { get; set; }
        /// <summary>
        /// Action to be taken after zalba is resolved
        /// </summary>
        public string RadnjaNaOsnovuZalbe1 { get; set; }
        /// <summary>
        /// List of zalba's which are connected to this entity
        /// </summary>
        public virtual ICollection<Zalba> Zalba { get; set; }
    }
}
