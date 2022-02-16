using System;

namespace ZalbaService.Entities
{
    /// <summary>
    /// DTO class which will be used for updating Zalba entity
    /// </summary>
    public class UpdateZalbaDto
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
        /// Date of resolving Zalba
        /// </summary>
        public DateTime DatumResenja { get; set; }

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
        public int TipZalbeId { get; set; }
    }
}
