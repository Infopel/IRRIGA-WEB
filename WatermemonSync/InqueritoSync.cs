using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record InqueritoSync
    {
        public Guid Id { get; set; }
        public string Designacao { get; set; }
        public string Descricao { get; set; }
        public Guid? ParentInqueritoId { get; set; }
        public int? Versao { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string RemovedBy { get; set; }
        public DateTime? RemovedOn { get; set; }
        public bool? IsPrincipal { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? RegadioId { get; set; }

    }
    public class InqueritoMapper
    {
        public static InqueritoSync Map(Inquerito inquerito)
        {
            return new InqueritoSync()
            {
                Id = inquerito.Id,
                Descricao = inquerito.Descricao,
                Designacao = inquerito.Designacao,
                ParentInqueritoId = inquerito.IdInqueritoPai,
                Versao = inquerito.Versao,
                CreatedBy = inquerito.CreatedBy,
                UpdatedBy = inquerito.UpdatedBy,
                CreatedOn = inquerito.CreatedOn,
                UpdatedOn = inquerito.UpdatedOn,
                RemovedBy = inquerito.RemovedBy,
                RemovedOn = inquerito.RemovedOn,
                IsPrincipal = inquerito.IsPrincipal,
                RegadioId = inquerito.IdRegadio
            };

        }
    }
}
