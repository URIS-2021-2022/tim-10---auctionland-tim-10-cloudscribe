using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Entities
{
    public class FizickoLiceConfirmationEntity
    {
            /// <summary>
            /// ID lica
            /// </summary>
            public Guid liceId { get; set; }

            /// <summary>
            /// Prvi broj telefona lica
            /// </summary>
            public string brojTelefona1 { get; set; }

            /// <summary>
            /// Drugi broj telefona lica
            /// </summary>
            public string brojTelefona2 { get; set; }

            /// <summary>
            /// Email adresa lica
            /// </summary>
            public string email { get; set; }

            /// <summary>
            /// Broj racuna lica
            /// </summary>
            public string brojRacuna { get; set; }

            /// <summary>
            /// Opis prioriteta lica
            /// </summary>
            public string opisPrioriteta { get; set; }

            /// <summary>
            /// Ime fizickog lica
            /// </summary>
            public string ime { get; set; }

            /// <summary>
            /// Prezime fizickog lica
            /// </summary>
            /// 
            public string prezime { get; set; }
        }
}
