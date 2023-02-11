using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record EscolaRegadiosSync
    {
        public int Id { get; set; }
        public Guid? EscolaId { get; set; }
        public Guid? RegadioId { get; set; }
        public bool? IsRemoved { get; set; }
        public string RemovedBy { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
    public class EscolaRegadiosMapper
    {
        public static EscolaRegadiosSync Map(EscolaRegadio escolaRegadio)
        {
            return new EscolaRegadiosSync()
            {
                Id = escolaRegadio.Id,
                EscolaId = escolaRegadio.IdEscola,
                RegadioId = escolaRegadio.IdRegadio,
                IsRemoved = escolaRegadio.IsRemoved,
                RemovedBy = escolaRegadio.RemovedBy,
                RemovedOn = escolaRegadio.RemovedOn,
                CreatedOn = escolaRegadio.CreatedOn,
                UpdatedOn = escolaRegadio.UpdatedOn,
                UpdatedBy = escolaRegadio.UpdatedBy
            };

        }
    }
}
