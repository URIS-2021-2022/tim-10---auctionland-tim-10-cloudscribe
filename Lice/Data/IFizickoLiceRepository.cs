using Lice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lice.Data
{
    public interface IFizickoLiceRepository
    {
        List<FizickoLiceEntity> GetFizickaLica();

        FizickoLiceEntity GetFizickoLiceById(Guid liceId);

        FizickoLiceConfirmationEntity CreateFizickoLice(FizickoLiceEntity fizickoLice);

        void UpdateFizickoLice(FizickoLiceEntity fizickoLice);

        void DeleteFizickoLice(Guid liceId);

        bool SaveChanges();
    }
}
