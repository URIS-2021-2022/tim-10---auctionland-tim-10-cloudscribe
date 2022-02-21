using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Models
{
    /// <summary>
    /// DTO class which will be used to resolve a Zalba
    /// </summary>
    public class ResolveZalbaDto
    {
        /// <summary>
        /// Foreign key of Zalba which ought to be resolved.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "ZalbaId has to be greater than 0.")]
        public int ZalbaId{ get; set; }
        /// <summary>
        /// Foreign key of StatusZalbe which will be used to resolve the Zalba.
        /// </summary>
        [Range(2,3,ErrorMessage = "StatusZalbeId cannot be 1 (opened).")]
        public int StatusZalbeId { get; set; }
    }
}