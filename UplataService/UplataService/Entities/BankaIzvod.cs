// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UplataService.Entities
{
    /// <summary>
    /// Entity class for BankaIzvod
    /// </summary>
    public partial class BankaIzvod
    {
        /// <summary>
        /// Id of bank statement
        /// </summary>
        public int IzvodId { get; set; }

        /// <summary>
        /// public ID 
        /// </summary>
        public string JMBG { get; set; }

        /// <summary>
        /// Foreign key
        /// </summary>
        public string maticniBroj { get; set; }

        /// <summary>
        /// Foreign key
        /// </summary>
        public int? BankaUplataId { get; set; }

        /// <summary>
        /// BankaUplata which is connected to BankaIzvod entity
        /// </summary>
        public virtual BankaUplata BankaUplata { get; set; }
    }
}
