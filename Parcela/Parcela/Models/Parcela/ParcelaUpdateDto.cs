using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models.Parcela
{
    public class ParcelaUpdateDto : IValidatableObject
    {
        #region Parcela
        [Required]
        public Guid ParcelaId { get; set; }
        [Required]
        public int Povrsina { get; set; }

        [Required]
        public Guid KorisnikId { get; set; }

       
        public string BrojParcele { get; set; }


        public Guid KatastarskaOpstinaId { get; set; }


        public string BrojListaNepokretnosti { get; set; }

       
        public string Kultura { get; set; }

       
        public int Klasa { get; set; }

        
        public string Obradivost { get; set; }


        public Guid ZasticenaZonaId { get; set; }


        public string OblikSvojine { get; set; }

        public string Odvodnjavanje { get; set; }





        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Kultura != "Njive" && Kultura != "Vrtovi" && Kultura != "Vinogradi" && Kultura != "Livade" && Kultura != "Pasnjaci" && Kultura != "Sume" && Kultura != "Mocvare")
            {
                yield return new ValidationResult(
                    "Unesite ispravnu kulturu",
                    new[] { "ParcelaCreationDto" });
            }


            if (Obradivost != "Obradivo" && Obradivost != "Ostalo")
            {
                yield return new ValidationResult(
                    "Unesite ispravnu obradivost",
                    new[] { "ParcelaCreationDto" });
            }


            if (OblikSvojine != "Privatna" && OblikSvojine != "Drzavna" && OblikSvojine != "Drustvena" && OblikSvojine != "Mesovita" && OblikSvojine != "Drugi oblici" && OblikSvojine != "Zadruzna")
            {
                yield return new ValidationResult(
                    "Unesite ispravan oblik svojine",
                    new[] { "ParcelaCreationDto" });
            }

            if (Klasa != 1 && Klasa != 2 && Klasa != 3 && Klasa != 4 && Klasa != 5 && Klasa != 6 && Klasa != 7 && Klasa != 8)
            {
                yield return new ValidationResult(
                    "Unesite ispravnu klasu",
                    new[] { "ParcelaCreationDto" });
            }



        }

        #endregion
    }
}
