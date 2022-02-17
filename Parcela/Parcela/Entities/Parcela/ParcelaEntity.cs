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

        [Key]
        public Guid ParcelaId { get; set; }

        #region Parcela

        public int Povrsina { get; set; }

        public Guid KorisnikId { get; set; }

        public string BrojParcele { get; set; }

        public string BrojListaNepokretnosti { get; set; }

        public string Kultura { get; set; }

        public int Klasa { get; set; }

        public string Obradivost { get; set; }

        [ForeignKey("ZasticenaZonaEntity")]
        public Guid ZasticenaZonaId { get; set; }
        public virtual ZasticenaZonaEntity ZasticenaZonaEntity { get; set; }

        public string OblikSvojine { get; set; }

        public string Odvodnjavanje { get; set; }

        [ForeignKey("KatastarskaOpstinaEntity")]
        public Guid KatastarskaOpstinaId { get; set; }

        public virtual KatastarskaOpstinaEntity KatastarskaOpstinaEntity { get; set; }

        public virtual List<DeoParceleEntity> DeloviParcele { get; set; }

        #endregion
    }
}
