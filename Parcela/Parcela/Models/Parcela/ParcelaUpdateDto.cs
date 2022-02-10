using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models.Parcela
{
    public class ParcelaUpdateDto
    {
        #region Parcela
        [Required]
        public Guid ParcelaId { get; set; }
        [Required]
        public int Povrsina { get; set; }

        [Required]
        public Guid KorisnikId { get; set; }

       
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
