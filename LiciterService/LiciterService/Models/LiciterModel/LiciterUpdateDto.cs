using LiciterService.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class LiciterUpdateDto 
    {
        public Guid LiciterId { get; set; }
        public Guid KupacId { get; set; }
        public Guid ZastupnikId { get; set; }

        /*[Required(ErrorMessage = "Obavezno je uneti ime")]
        public string ImeLicitera { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti prezime")]
        public string PrezimeLicitera { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ImeLicitera == PrezimeLicitera)
            {
                yield return new ValidationResult(
                    "Liciter ne može da ima isto ime i prezime",
                    new[] { "LiciterCreationDto" });
            }
        }*/
    }
}
