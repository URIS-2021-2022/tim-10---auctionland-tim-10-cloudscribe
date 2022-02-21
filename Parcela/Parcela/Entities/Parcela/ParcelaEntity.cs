using Parcela.Entities.DeoParcele;
using Parcela.Entities.KatastarskaOpstina;
using Parcela.Entities.ZasticenaZona;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities.Parcela
{
    public class ParcelaEntity
    {
        /// <summary>
        /// ID parcele
        /// </summary>
        [Key]
        public Guid ParcelaId { get; set; }

        #region Parcela
        /// <summary>
        /// Površina parcele
        /// </summary>
        public int Povrsina { get; set; }
        /// <summary>
        /// ID korisnika parcele
        /// </summary>
        public Guid KorisnikId { get; set; }
        /// <summary>
        /// Broj parcele
        /// </summary>
        public string BrojParcele { get; set; }
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
        [ForeignKey("ZasticenaZonaEntity")]
        public Guid ZasticenaZonaId { get; set; }
        /// <summary>
        /// Zaštićena zona entitet
        /// </summary>
        public virtual ZasticenaZonaEntity ZasticenaZonaEntity { get; set; }
        /// <summary>
        /// Oblik svojine parcele
        /// </summary>
        public string OblikSvojine { get; set; }
        /// <summary>
        /// ODvodnjavanje parcele
        /// </summary>
        public string Odvodnjavanje { get; set; }
        /// <summary>
        /// ID katastarske opštine
        /// </summary>
        [ForeignKey("KatastarskaOpstinaEntity")]
        public Guid KatastarskaOpstinaId { get; set; }
        /// <summary>
        /// Entitet katastarske opštine
        /// </summary>
        public virtual KatastarskaOpstinaEntity KatastarskaOpstinaEntity { get; set; }
        
        /// <summary>
        /// ID Dela parcele
        /// </summary>
        

        [ForeignKey("DeoParceleEntity")]
        public Guid DeoParceleId { get; set; }

        /// <summary>
        /// Entitet dela parcele
        /// </summary>

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<DeoParceleEntity> DeoParcele { get; set; }

        #endregion
    }
}
