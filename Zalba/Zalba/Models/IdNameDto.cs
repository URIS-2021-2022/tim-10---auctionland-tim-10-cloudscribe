using ZalbaService.Entities;

namespace ZalbaService.Models
{
    /// <summary>
    /// DTO class which will be used to represent certain entities as dropdown items.
    /// </summary>
    public class IdNameDto
    {
        /// <summary>
        /// ID of a certian entity.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of a certain entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Constructor which takes a TipZalbe object and 
        ///  maps it to a IdNameDropdownItem object.
        /// </summary>
        /// <param name="tipZalbe">TipZalbe entity object.</param>
        public IdNameDto(TipZalbe tipZalbe)
        {
            Id = tipZalbe.TipZalbeId;
            Name = tipZalbe.TipZalbe1;
        }

        /// <summary>
        ///  Constructor which takes a StatusZalbe object and 
        ///  maps it to a IdNameDropdownItem object.
        /// </summary>
        /// <param name="statusZalbe">StatusZalbe entity object.</param>
        public IdNameDto(StatusZalbe statusZalbe)
        {
            Id = statusZalbe.StatusZalbeId;
            Name = statusZalbe.StatusZalbe1;
        }
    }
}
