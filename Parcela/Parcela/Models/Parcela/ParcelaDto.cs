using Parcela.Entities.KatastarskaOpstina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models.Parcela
{
    public class ParcelaDto
    {



        #region Parcela

        public Guid ParcelaId { get; set; }

        public int Povrsina { get; set; }

        public Guid KorisnikId { get; set; }

        public string BrojParcele { get; set; }

        
        public Guid KatastarskaOpstinaId { get; set; }

        public string KatastarskaOpstina { get; set; }

        //public virtual KatastarskaOpstinaEntity KatastarskaOpstina { get; set; }

        public string BrojListaNepokretnosti { get; set; }

        public string Kultura { get; set; }

        public int Klasa { get; set; }

        public string Obradivost { get; set; }

        public Guid ZasticenaZonaId { get; set; }

        public string ZasticenaZona { get; set; }

        public string OblikSvojine { get; set; }

        public string Odvodnjavanje { get; set; }


        #endregion
    }
}
