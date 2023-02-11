using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record InqueritoRespostaSync
    {
        public Guid Id { get; set; }
        public Guid? InqueritoId { get; set; }
        public int? PerguntaId { get; set; }
        public string Descricao { get; set; }
        public string Code { get; set; }
        public int? Tipo { get; set; }
        public Guid? ResponseId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? FieldsetId { get; set; }
        public bool? IsRemoved { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string RemovedBy { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
    }

    public class InqueritoRespostaMapper
    {
        public static InqueritoRespostaSync Map(InqueritoRespostum inqueritoRespostum)
        {
            return new InqueritoRespostaSync()
            {
                Id = inqueritoRespostum.Id,
                InqueritoId = inqueritoRespostum.IdInquerito,
                PerguntaId = inqueritoRespostum.IdPergunta,
                Descricao = inqueritoRespostum.Descricao,
                Code = inqueritoRespostum.Code,
                Tipo = inqueritoRespostum.Tipo,
                ResponseId = inqueritoRespostum.IdResponses,
                CreatedOn = inqueritoRespostum.CreatedOn,
                RemovedOn = inqueritoRespostum.RemovedOn,
                UpdatedOn = inqueritoRespostum.UpdatedOn,
                FieldsetId = inqueritoRespostum.IdFieldsets,
                IsRemoved = inqueritoRespostum.IsRemoved,
                CreatedBy = inqueritoRespostum.CreatedBy,
                UpdatedBy = inqueritoRespostum.UpdatedBy,
                ApprovedBy = inqueritoRespostum.ApprovedBy,
                ApprovedOn = inqueritoRespostum.ApprovedOn
            };

        }
    }
}
