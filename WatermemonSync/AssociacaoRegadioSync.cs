using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record AssociacaoRegadioSync
    {
        public int Id { get; set; }
        public Guid? AssociacaoId { get; set; }
        public Guid? RegadioId { get; set; }
        public bool? IsRemoved { get; set; }
        public string RemovedBy { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
    public class AssociacaoRegadioMapper
    {
        public static AssociacaoRegadioSync Map(AssociacaoRegadio associacaoRegadio)
        {
            return new AssociacaoRegadioSync()
            {
                Id = associacaoRegadio.Id,
                AssociacaoId = associacaoRegadio.IdAssociacao,
                RegadioId = associacaoRegadio.IdRegadio,
                IsRemoved = associacaoRegadio.IsRemoved,
                RemovedOn = associacaoRegadio.RemovedOn,
                CreatedOn = associacaoRegadio.CreatedOn,
                UpdatedOn = associacaoRegadio.UpdatedOn,
                UpdatedBy = associacaoRegadio.UpdatedBy,
                CreatedBy = associacaoRegadio.CreatedBy,
                RemovedBy = associacaoRegadio.RemovedBy
            };

        }
    }
}
