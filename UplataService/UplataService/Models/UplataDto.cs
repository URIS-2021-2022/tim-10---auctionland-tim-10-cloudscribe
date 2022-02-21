using System;
using UplataService.Entities;

namespace UplataService.Models
{
    /// <summary>
    /// DTO class which will be used for creation of Uplata entity
    /// </summary>
    public class UplataDto
    {
        /// <summary>
        /// Constructor which takes Uplata entity and maps it to UplataDto  
        /// </summary>
        public UplataDto(Uplata x)
        {
            UplataId = x.UplataId;
            BrojRacuna = x.BrojRacuna;
            PozivNaBroj = x.PozivNaBroj;
            Iznos = x.Iznos;
            SvrhaUplate = x.SvrhaUplate;
            Datum = x.Datum;
        }

        /// <summary>
        /// Id of uplata    
        /// </summary>
        public int UplataId { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        public string BrojRacuna { get; set; }

        /// <summary>
        /// Reference number
        /// </summary>
        public string PozivNaBroj { get; set; }

        /// <summary>
        /// Amount of Uplata
        /// </summary>
        public decimal? Iznos { get; set; }

        /// <summary>
        /// Purpose of Uplata
        /// </summary>
        public string SvrhaUplate { get; set; }

        /// <summary>
        /// Date of Uplata
        /// </summary>
        public DateTime? Datum { get; set; }
    }
}
