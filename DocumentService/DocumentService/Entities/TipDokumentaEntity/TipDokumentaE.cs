using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Entities.TipDokumentaEntity
{
    public class TipDokumentaE
    {
        [Key]
        public Guid TipDokumentaID { get; set; }
        public string TipDokumenta { get; set; }
        public string StatusDokumenta { get; set; }
    }
}
