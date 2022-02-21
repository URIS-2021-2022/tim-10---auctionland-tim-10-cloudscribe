using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class KupacCreationDto: IValidatableObject
    {

        /// <summary>
        /// Datum pocetka zabrane
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Datum prestanka zabrane
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? DatumPrestankaZabrane { get; set; }

        /// <summary>
        /// Duzina trajanja zabrane
        /// </summary>
        public int DuzinaTrajanjaZabrane { get; set; }

        /// <summary>
        /// Da li kupac ima neku zabranu
        /// </summary>

        [Required(ErrorMessage = "Obavezno je uneti da li postoji zabrana")]
        public bool ImaZabranu { get; set; }

        /// <summary>
        /// Ostvarena povrsina
        /// </summary>
        public int OstvarenaPovrsina { get; set; }

        /// <summary>
        /// ID zastupnika
        /// </summary>
        public Guid ZastupnikId { get; set; }

        /// <summary>
        /// Validacija u slucaju da je unesen datum veci od datuma zabrane
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DatumPocetkaZabrane>DatumPrestankaZabrane)
            {
                yield return new ValidationResult(
                    "Nije validan datum",
                    new[] { "KupacCreationDto" });
            }
        }
    }
}
