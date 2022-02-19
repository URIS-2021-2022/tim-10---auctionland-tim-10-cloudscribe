using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class ZastupnikCreationDto: IValidatableObject
    {

        //[StringLength(13, MinimumLength=13, ErrorMessage = "Jmbg ne moze imati vise,a ni manje od 13 karaktera.")]
        public string Jmbg { get; set; }

        //[StringLength(9, MinimumLength=9)],ErrorMessage = "Broj pasosa ne moze imati vise, a ni manje od 9 karaktera.")]
        public string BrojPasosa { get; set; }

        [Required(ErrorMessage = "Obavezno uneti naziv drzave")]
        public string NazivDrzave { get; set; }

        [Required(ErrorMessage="Obavezno uneti broj table za licitaciju")]
        public int BrojTable { get; set; }
        public Guid KupacId { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (NazivDrzave != "Srbija"  && Jmbg.Length >= 1)
            {
                yield return new ValidationResult(
                    "Upisite validan broj pasosa.",
                    new[] { "ZastupnikCreationDto" });

            };
            if(NazivDrzave!="Srbija" && BrojPasosa.Length != 9)
            {
                yield return new ValidationResult(
                   "Upisite validan broj pasosa.",
                   new[] { "ZastupnikCreationDto" });
            }
            if (NazivDrzave == "Srbija" && BrojPasosa.Length >= 1)
            {
                yield return new ValidationResult(
                    "Upisite validan jmbg.",
                    new[] { "ZastupnikCreationDto" });

            };
            if (NazivDrzave == "Srbija" && Jmbg.Length != 13)
            {
                yield return new ValidationResult(
                   "Upisite validan jmbg.",
                   new[] { "ZastupnikCreationDto" });
            }
        }
    }
}
