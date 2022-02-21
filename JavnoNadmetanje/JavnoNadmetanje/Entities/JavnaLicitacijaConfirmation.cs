﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Entities
{
    public class JavnaLicitacijaConfirmation
    {
        /// <summary>
        /// ID javne licitacije
        /// </summary>
        public Guid javnoNadmetanjeID { get; set; }
        /// <summary>
        /// ID javnog nadmetanja
        /// </summary>
        public DateTime datum { get; set; }
        /// <summary>
        /// Vreme pocetka javnog nadmetanja
        /// </summary>
        public DateTime vremePocetka { get; set; }
        /// <summary>
        /// Vreme zavrsetka javnog nadmetanja
        /// </summary>
        public DateTime vremeKraja { get; set; }
        /// <summary>
        /// Pocetna cena na javnom nadmetanju
        /// </summary>
        public int pocetnaCena { get; set; }
        /// <summary>
        /// Izuzeto iz javnog nadmetanja
        /// </summary>
        public int tip { get; set; }
        /// <summary>
        /// Izlicitirana cena na javnom nadmetanju
        /// </summary>
        public int izlicitiranaCena { get; set; }
        //  public string najboljiPonudjac { get; set; } //kupac

        //public string adresaOdrzavanjaNadmetanja // adresa
        /// <summary>
        /// Katastarska opstina vezana za javno nadmetanje
        /// </summary>
        public string katastarskaOpstina { get; set; }
        /// <summary>
        /// Period zakupa u javnom nadmetanju
        /// </summary>
        public int periodZakupa { get; set; }
        //public string prijavljeniKupci { get; set; } //kupac
        //public string licitanti { get; set; } //ovlasceno lice
        /// <summary>
        /// Broj ucesnika u javnom nadmetanju
        /// </summary>

        public string status { get; set; }
        /// <summary>
        /// Etapa ID
        /// </summary>

        public Guid etapaID { get; set; }
        /// <summary>
        /// Oznaka javne licitacije
        /// </summary>
        public int brojJavneLicitacije { get; set; }

        public Guid korakCeneID { get; set; }
    }
}
