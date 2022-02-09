using Adresa.Entities;
using Adresa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Data
{
    public interface IAdresaRepository
    {
        List<AdresaEntity> GetAdrese();

        AdresaEntity GetAdresaById(Guid adresaId);

        AdresaConfirmationEntity CreateAdresa(AdresaEntity adresaModel);

        void UpdateAdresa(AdresaEntity adresaModel);

        void DeleteAdresa(Guid adresaId);

        bool SaveChanges();

    }
}
