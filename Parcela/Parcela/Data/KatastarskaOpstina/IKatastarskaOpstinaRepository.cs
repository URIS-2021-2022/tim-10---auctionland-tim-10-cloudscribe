using Parcela.Entities.KatastarskaOpstina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Data.KatastarskaOpstina
{
   public interface IKatastarskaOpstinaRepository
    {
        List<KatastarskaOpstinaEntity> GetKatastarskaOpstina();

        KatastarskaOpstinaEntity GetKatastarskaOpstinaById(Guid KatastarskaOpstinaId);

        KatastarskaOpstinaConfirmation CreateKatastarskaOpstina(KatastarskaOpstinaEntity katastarskaOpstina);
        KatastarskaOpstinaConfirmation UpdateKatastarskaOpstina(KatastarskaOpstinaEntity katastarskaOpstina);

        void DeleteKatastarskaOpstina(Guid KatastarskaOpstinaId);

        bool SaveChanges();

    }
}
