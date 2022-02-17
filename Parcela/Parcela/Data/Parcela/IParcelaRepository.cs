using Parcela.Entities.Parcela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Data.Parcela
{
    public interface IParcelaRepository
    {
        List<Entities.Parcela.ParcelaEntity> GetParcela();

        Entities.Parcela.ParcelaEntity GetParcelaById(Guid parcelaId);

        ParcelaConfirmation CreateParcela(Entities.Parcela.ParcelaEntity parcela);

        ParcelaConfirmation UpdateParcela(Entities.Parcela.ParcelaEntity parcela);

        void DeleteParcela(Guid parcelaId);

        bool SaveChanges();

    }
}
