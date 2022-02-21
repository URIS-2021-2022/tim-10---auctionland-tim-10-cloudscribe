using Parcela.Entities.DeoParcele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Data.DeoParcele
{
    public interface IDeoParceleRepository
    {
        List<DeoParceleEntity> GetDeoParcele();
        DeoParceleEntity GetDeoParceleById(Guid deoParceleId);
        DeoParceleConfirmation CreateDeoParcele(DeoParceleEntity deoParcele);
        DeoParceleConfirmation updateDeoParcele(DeoParceleEntity deoParcele);

        void DeleteDeoParcele(Guid deoParceleId);

        bool SaveChanges();
    }
}
