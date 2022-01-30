using Adresa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Data
{
    public interface IAdresaRepository
    {
        List<AdresaModel> GetAdrese();

        AdresaModel GetAdresaById(Guid adresaId);

        AdresaModel CreateAdresa(AdresaModel adresaModel);

        AdresaModel UpdateAdresa(AdresaModel adresaModel);

        void DeleteAdresa(Guid adresaId);

    }
}
