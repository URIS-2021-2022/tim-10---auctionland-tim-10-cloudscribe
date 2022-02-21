using Licitacija.Entities;
using Licitacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija.Data
{
   public interface ILicitacijaRepository
    {
        LicitacijaModel GetLicitacijaById(Guid licitacijaId);
        List<LicitacijaModel> GetAllLicitacije();
    

        LicitacijaConfirmation CreateLicitacija(LicitacijaModel licitacijaModel);
        void UpdateLicitacija(LicitacijaModel licitacijaModel);
        void DeleteLicitacija(Guid licitacijaId);

        bool SaveChanges();
    }
}
