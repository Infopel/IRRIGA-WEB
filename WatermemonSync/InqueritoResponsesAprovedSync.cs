using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record InqueritoResponsesAprovedSync
    {
        public Guid Id { get; set; }
        public Guid? InqueritoId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastStep { get; set; }
        public string CreatedBy { get; set; }
        public Guid? BeneficiarioId { get; set; }
        public Guid? RegadioId { get; set; }
        public Guid? EscolaId { get; set; }
        public Guid? ParentResponseId { get; set; }
        public Guid? ParentInqueritoId { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
    }
    public class InqueritoResponsesAprovedMapper
    {
        public static InqueritoResponsesAprovedSync Map(ResponsesInquerito responsesInquerito)
        {
            return new InqueritoResponsesAprovedSync()
            {
                Id = responsesInquerito.Id,
                InqueritoId = responsesInquerito.IdInquerito,
                CreatedOn = responsesInquerito.CreatedOn,
                LastStep = responsesInquerito.LastStep,
                CreatedBy = responsesInquerito.CreatedBy,
                BeneficiarioId = responsesInquerito.IdBeneficiario,
                RegadioId = responsesInquerito.IdRegadio,
                EscolaId = responsesInquerito.IdEscola,
                ParentInqueritoId = responsesInquerito.IdInqueritoPai,
                ParentResponseId = responsesInquerito.IdResponsesPai,
                ApprovedBy = responsesInquerito.ApprovedBy,
                ApprovedOn = responsesInquerito.ApprovedOn
            };

        }
    }
}
