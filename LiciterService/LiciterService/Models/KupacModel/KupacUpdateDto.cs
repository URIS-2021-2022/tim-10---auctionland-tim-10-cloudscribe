using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class KupacUpdateDto : IValidatableObject
    {
        public Guid KupacId { get; set; }
        public DateTime? DatumPocetkaZabrane { get; set; }
        public DateTime? DatumPrestankaZabrane { get; set; }
        public int DuzinaTrajanjaZabrane { get; set; }

        [Required(ErrorMessage ="Obavezno je uneti da li postoji zabrana")]
        public bool ImaZabranu { get; set; }
        public int OstvarenaPovrsina { get; set; }

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
