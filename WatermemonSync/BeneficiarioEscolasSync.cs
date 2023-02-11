using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record BeneficiarioEscolasSync
    {
        public int Id { get; set; }
        public Guid? BeneficiarioId { get; set; }
        public Guid? EscolaId { get; set; }
        public bool? IsRemoved { get; set; }
        public string RemovedBy { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
    public class BeneficiarioEscolasMapper
    {
        public static BeneficiarioEscolasSync Map(BeneficiarioEscola beneficiarioEscola)
        {
            return new BeneficiarioEscolasSync()
            {
                Id = beneficiarioEscola.Id,
                BeneficiarioId = beneficiarioEscola.IdBeneficiario,
                EscolaId = beneficiarioEscola.IdEscola,
                IsRemoved = beneficiarioEscola.IsRemoved,
                RemovedBy = beneficiarioEscola.RemovedBy,
                RemovedOn = beneficiarioEscola.RemovedOn,
                CreatedOn = beneficiarioEscola.CreatedOn,
                UpdatedOn = beneficiarioEscola.UpdatedOn,
                CreatedBy = beneficiarioEscola.CreatedBy,
                UpdatedBy = beneficiarioEscola.UpdatedBy
            };

        }
    }
}
