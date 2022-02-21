using Parcela.Entities.ZasticenaZona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Data.ZasticenaZona
{
    public interface IZasticenaZonaRepository
    {
        List<ZasticenaZonaEntity> GetZasticenaZona();

        ZasticenaZonaEntity GetZasticenaZonaById(Guid ZasticenZonaId);

        ZasticenaZonaConfirmation CreateZasticenaZona(ZasticenaZonaEntity zasticenaZona);
        ZasticenaZonaConfirmation UpdateZasticenaZona(ZasticenaZonaEntity zasticenaZona);

        void DeleteZasticenaZona(Guid ZasticenZonaId);

        bool SaveChanges();


    }
}
