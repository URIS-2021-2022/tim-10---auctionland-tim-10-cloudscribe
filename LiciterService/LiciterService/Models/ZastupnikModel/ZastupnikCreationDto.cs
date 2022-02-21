using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiciterService.Models
{
    public class ZastupnikCreationDto: IValidatableObject
    {

        /// <summary>
        /// Jmbg zastupnika
        /// </summary>
        public string Jmbg { get; set; }

        /// <summary>
        /// Broj pasosa zastupnika
        /// </summary>
        public string BrojPasosa { get; set; }

        /// <summary>
        /// Naziv drzave odakle je zastupnik
        /// </summary>
        [Required(ErrorMessage = "Obavezno uneti naziv drzave")]
        public string NazivDrzave { get; set; }

        /// <summary>
        /// Broj table za licitiranje
        /// </summary>
        [Required(ErrorMessage="Obavezno uneti broj table za licitaciju")]
        public int BrojTable { get; set; }

        /// <summary>
        /// ID kupca
        /// </summary>
        public Guid KupacId { get; set; }

        /// <summary>
        /// Validacija ukoliko je liciter iz Srbije upisuje samo jmbg, a ukoliko je strani drzavljanin u tom slucaju upisuje broj pasosa
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
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
