using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcela.Models.Parcela
{
    public class ParcelaCreationDto
    {


        #region Parcela

        
        [Required]
        public int Povrsina { get; set; }

        [Required]
        public Guid KorisnikId { get; set; }

        [Required]
        public string BrojParcele { get; set; }

        
        public string KatastarskaOpstina { get; set; }

        
        public string BrojListaNepokretnosti { get; set; }

        
        public string Kultura { get; set; }

       
        public string Klasa { get; set; }

        
        public string Obradivost { get; set; }

        
        public string ZasticenaZona { get; set; }

       
        public string OblikSvojine { get; set; }

      
        public string Odvodnjavanje { get; set; }

      
        public string KulturaStvarnoStanje { get; set; }

      
        public string KlasaStvarnoStanje { get; set; }


        public string OBradivostStvarnoStanje { get; set; }


        public string ZasticenZonaStvarnoStanje { get; set; }


        public string OdvodnjavanjeStvarnoStanje { get; set; }

        #endregion
    }
}
