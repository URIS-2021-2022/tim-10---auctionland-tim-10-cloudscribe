using System;
using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Models
{
    /// <summary>
    /// DTO class which will be used for creation of Zalba entity
    /// </summary>
    public class ZalbaDto
    {
        /// <summary>
        /// Reason why Zalba has been created.
        /// </summary>
        [Required(ErrorMessage ="RazlogZalbe has to be populated.")]
        public string RazlogZalbe { get; set; }
        /// <summary>
        /// Detailed reason why Zalba has been created.
        /// </summary>
        [Required(ErrorMessage = "Obrazlozenje has to be populated.")]
        public string Obrazlozenje { get; set; }
        /// <summary>
        /// Decision document's date
        /// </summary>
        public DateTime DatumResenja { get; set; }
        /// <summary>
        /// Decision document's unique identifier
        /// </summary>
        public string BrojResenja { get; set; }
        /// <summary>
        /// Decision's unique identifier
        /// </summary>
        public string BrojOdluke { get; set; }
        /// <summary>
        /// TipZalbe's foreign key
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage ="TipZalbeId has to be greater than 0.")]
        public int TipZalbeId { get; set; }
    }
}