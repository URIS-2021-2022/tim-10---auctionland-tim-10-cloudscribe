using Parcela.Entities.DeoParcele;
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

        /// <summary>
        /// ID Parcele
        /// </summary>

        public Guid ParcelaId { get; set; }

        /// <summary>
        /// Površina parcele
        /// </summary>
        public int Povrsina { get; set; }

        /// <summary>
        /// ID Korisnika
        /// </summary>
        public Guid KorisnikId { get; set; }

        /// <summary>
        /// Broj Parcele
        /// </summary>
        public string BrojParcele { get; set; }

        /// <summary>
        /// ID Katastarske Opštine
        /// </summary>
        public Guid KatastarskaOpstinaId { get; set; }

        /// <summary>
        /// Ime Katastarske Opštine
        /// </summary>
        public string KatastarskaOpstina { get; set; }

        //public virtual KatastarskaOpstinaEntity KatastarskaOpstina { get; set; }
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
        /// Ime Zaštićene zone
        /// </summary>
        public string ZasticenaZona { get; set; }
        /// <summary>
        /// Oblik svojine parcele
        /// </summary>
        public string OblikSvojine { get; set; }
        /// <summary>
        /// Odvodnjavanje parcele
        /// </summary>
        public string Odvodnjavanje { get; set; }

        /// <summary>
        /// Delovi parcele
        /// </summary>
        public virtual List<DeoParceleEntity> DeoParcele { get; set; }

        #endregion
    }
}
