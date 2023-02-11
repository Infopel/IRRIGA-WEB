using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record ResponsesInqueritoSync
    {
        public Guid Id { get; set; }
        public Guid? InqueritoId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? LastStep { get; set; }
        public bool? IsRemoved { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string RemovedBy { get; set; }
        public Guid? BeneficiarioId { get; set; }
        public Guid? RegadioId { get; set; }
        public Guid? EscolaId { get; set; }
        public Guid? ParentResponseId { get; set; }
        public Guid? ParentInqueritoId { get; set; }
    }
    public class ResponsesInqueritoMapper
    {
        public static ResponsesInqueritoSync Map(ResponsesInquerito responsesInquerito)
        {
            return new ResponsesInqueritoSync()
            {
                Id = responsesInquerito.Id,
                InqueritoId = responsesInquerito.IdInquerito,
                CreatedOn = responsesInquerito.CreatedOn,
                RemovedOn = responsesInquerito.RemovedOn,
                UpdatedOn = responsesInquerito.UpdatedOn,
                LastStep = responsesInquerito.LastStep,
                IsRemoved = responsesInquerito.IsRemoved,
                CreatedBy = responsesInquerito.CreatedBy,
                UpdatedBy = responsesInquerito.UpdatedBy,
                BeneficiarioId = responsesInquerito.IdBeneficiario,
                RegadioId = responsesInquerito.IdRegadio,
                EscolaId = responsesInquerito.IdEscola,
                ParentInqueritoId = responsesInquerito.IdInqueritoPai,
                ParentResponseId = responsesInquerito.IdResponsesPai
            };

        }
    }
}
