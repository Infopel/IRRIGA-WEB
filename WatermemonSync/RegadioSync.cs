using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record RegadioSync
    {
        public Guid Id { get; set; }
        public string CodeRegadio { get; set; }
        public string Localizacao { get; set; }
        public string Designacao { get; set; }
        public DateTime? RemovedOn { get; set; }
        public string RemovedBy { get; set; }
        public Guid? AssociacaoId { get; set; }
        public Guid? EscolaId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsRemoved { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public int? ProvinciaId { get; set; }
    }
    public class RegadioMapper
    {
        public static RegadioSync Map(Regadio regadio)
        {
            return new RegadioSync()
            {
                Id = regadio.Id,
                CodeRegadio = regadio.CodeRegadio,
                Localizacao = regadio.Localizacao,
                Designacao = regadio.Designacao,
                RemovedOn = regadio.RemovedOn,
                RemovedBy = regadio.RemovedBy,
                AssociacaoId = regadio.IdAssociacao,
                EscolaId = regadio.IdEscola,
                UpdatedOn = regadio.UpdatedOn,
                CreatedOn = regadio.CreatedOn,
                CreatedBy = regadio.CreatedBy,
                ProvinciaId = regadio.IdProvincia
            };

        }
    }
}
