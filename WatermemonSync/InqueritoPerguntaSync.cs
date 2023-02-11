using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record InqueritoPerguntaSync
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Guid? InqueritoId { get; set; }
        public string ValidacaoComponente { get; set; }
        public string CaracteristicasComponente { get; set; }
        public int? QuestionOrder { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string RemovedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? FieldsetId { get; set; }
        public Guid? FormId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsRemoved { get; set; }
        public string CreatedBy { get; set; }
    }
    public class InqueritoPerguntaMapper
    {
        public static InqueritoPerguntaSync Map(InqueritoPerguntum inqueritoPerguntum)
        {
            return new InqueritoPerguntaSync()
            {
                Id = inqueritoPerguntum.Id,
                Descricao = inqueritoPerguntum.Descricao,
                InqueritoId = inqueritoPerguntum.IdInquerito,
                ValidacaoComponente = inqueritoPerguntum.ValidacaoComponente,
                CaracteristicasComponente = inqueritoPerguntum.CaracteristicasComponente,
                QuestionOrder = inqueritoPerguntum.QuestionOrder,
                RemovedOn = inqueritoPerguntum.RemovedOn,
                UpdatedOn = inqueritoPerguntum.UpdateOn,
                RemovedBy = inqueritoPerguntum.RemovedBy,
                UpdatedBy = inqueritoPerguntum.UpdatedBy,
                FieldsetId = inqueritoPerguntum.IdFieldset,
                FormId = inqueritoPerguntum.IdForm,
                CreatedOn = inqueritoPerguntum.CreatedOn,
                CreatedBy = inqueritoPerguntum.CreatedBy,
                IsRemoved = inqueritoPerguntum.IsRemoved
            };

        }
    }
}
