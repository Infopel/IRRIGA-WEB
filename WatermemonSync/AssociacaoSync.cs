using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record AssociacaoSync
    {
        public Guid Id { get; set; }
        public string Designacao { get; set; }
        public Guid? RegadioId { get; set; }
        public int? NumMulheres { get; set; }
        public int? NumHomens { get; set; }
        public DateTime? RemovedOn { get; set; }
        public string RemovedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsRemoved { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
    public class AssociacaoMapper
    {
        public static AssociacaoSync Map(Associacao associacao)
        {
            return new AssociacaoSync()
            {
                Id = associacao.Id,
                Designacao = associacao.Designacao,
                RegadioId = associacao.IdRegadio,
                NumMulheres = associacao.NumMulheres,
                NumHomens = associacao.NumHomens,
                RemovedOn = associacao.RemovedOn,
                RemovedBy = associacao.RemovedBy,
                CreatedOn = associacao.CreatedOn,
                UpdatedOn = associacao.UpdatedOn,
                UpdatedBy = associacao.UpdatedBy,
                CreatedBy = associacao.CreatedBy,
                IsRemoved = associacao.IsRemoved
            };

        }
    }
}
