using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class KupacUpdateDto : IValidatableObject
    {
        /// <summary>
        /// ID kupca
        /// </summary>
        public Guid KupacId { get; set; }

        /// <summary>
        /// Datum pocetka zabrane
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Datum prestanka zabrane
        /// </summary>
        public DateTime? DatumPrestankaZabrane { get; set; }

        /// <summary>
        /// Duzina trajanja zabrane
        /// </summary>
        public int DuzinaTrajanjaZabrane { get; set; }

        /// <summary>
        /// Da li kupac ima neku zabranu
        /// </summary>

        [Required(ErrorMessage ="Obavezno je uneti da li postoji zabrana")]
        public bool ImaZabranu { get; set; }

        /// <summary>
        /// Ostvarena povrsina 
        /// </summary>
        public int OstvarenaPovrsina { get; set; }

        /// <summary>
        /// Validacija za datum 
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DatumPocetkaZabrane > DatumPrestankaZabrane)
            {
                yield return new ValidationResult(
                    "Nije validan datum",
                    new[] { "KupacCreationDto" });
            }
        }

    }
}
