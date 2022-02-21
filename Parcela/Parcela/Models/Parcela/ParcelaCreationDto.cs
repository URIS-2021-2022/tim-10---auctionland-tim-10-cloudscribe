using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcela.Models.Parcela
{
    public class ParcelaCreationDto : IValidatableObject
    {


        #region Parcela

        /// <summary>
        /// Površina parcele
        /// </summary>
        [Required]
        public int Povrsina { get; set; }
        /// <summary>
        /// ID korisnika
        /// </summary>
        [Required]
        public Guid KorisnikId { get; set; }
        /// <summary>
        /// Broj parcele
        /// </summary>
        [Required]
        public string BrojParcele { get; set; }
        /// <summary>
        /// ID katastarske opštine
        /// </summary>
        [Required]
        public Guid KatastarskaOpstinaId { get; set; }

        /// <summary>
        /// Broj lista nepokretnosti
        /// </summary>
        public string BrojListaNepokretnosti { get; set; }

        /// <summary>
        /// Kultura parcele
        /// </summary>
        public string Kultura { get; set; }

        /// <summary>
        /// Klasa parcele
        /// </summary>
        public int Klasa { get; set; }

        /// <summary>
        /// Obradivost parcele
        /// </summary>
        public string Obradivost { get; set; }

        /// <summary>
        /// ID Zaštićene zone
        /// </summary>
        public Guid ZasticenaZonaId { get; set; }

        /// <summary>
        /// Oblik svojine parcele
        /// </summary>
        public string OblikSvojine { get; set; }

        /// <summary>
        /// Odvodnjavanje parcele
        /// </summary>
        public string Odvodnjavanje { get; set; }

        /// <summary>
        /// ID dela parcele
        /// </summary>
        public Guid DeoParceleId { get; set; }


        
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
