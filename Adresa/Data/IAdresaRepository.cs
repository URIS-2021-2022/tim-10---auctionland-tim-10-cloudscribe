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

        AdresaConfirmation CreateAdresa(AdresaModel adresaModel);

        AdresaConfirmation UpdateAdresa(AdresaModel adresaModel);

        void DeleteAdresa(Guid adresaId);

    }
}
