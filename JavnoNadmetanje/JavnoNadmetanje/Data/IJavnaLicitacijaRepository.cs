using JavnoNadmetanje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanje.Data
{
    public interface IJavnaLicitacijaRepository
    {
        List<JavnaLicitacijaEntity> GetJavneLicitacije();

        JavnaLicitacijaEntity GetJavnaLicitacijaById(Guid javnaLicitacijaId);

        JavnaLicitacijaConfirmation CreateJavnaLicitacija(JavnaLicitacijaEntity javnaLicitacija);

        void UpdateJavnaLicitacija(JavnaLicitacijaEntity javnaLicitacija);

        void DeleteJavnaLicitacija(Guid javnaLicitacijaId);

        bool SaveChanges();
    }
}
