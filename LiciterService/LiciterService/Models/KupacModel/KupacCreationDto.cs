using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class KupacCreationDto: IValidatableObject
    {
        [DataType(DataType.Date)]
        public DateTime? DatumPocetkaZabrane { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DatumPrestankaZabrane { get; set; }
        public int DuzinaTrajanjaZabrane { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti da li postoji zabrana")]
        public bool ImaZabranu { get; set; }
        public int OstvarenaPovrsina { get; set; }

       //Validacija u slucaju da je unesen datum veci od datuma zabrane
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
