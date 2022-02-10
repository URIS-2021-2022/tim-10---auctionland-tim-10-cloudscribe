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

        public string parcelaOpstine { get; set; }

        public string BrojListaNepokretnosti { get; set; }

        public string Kultura { get; set; }

        public string Klasa { get; set; }

        public string Obradivost { get; set; }

        public string ZasticenaZona { get; set; }

        public string OblikSvojine { get; set; }

        public string Odvodnjavanje { get; set; }

        public string StvarnoStanje { get; set; }

        #endregion
    }
}
