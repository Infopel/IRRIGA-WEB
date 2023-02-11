using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record EscolaMachambaSync
    {
        public Guid Id { get; set; }
        public string Designacao { get; set; }
        public int? NumHomens { get; set; }
        public int? NumMulheres { get; set; }
        public string Metodologia { get; set; }
        public decimal? AreaEscola { get; set; }
        public string Localizacao { get; set; }
        public DateTime? RemovedOn { get; set; }
        public string RemovedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsRemoved { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }

    public class EscolaMachambaMapper
    {
        public static EscolaMachambaSync Map(EscolaMachamba escolaMachamba)
        {
            return new EscolaMachambaSync()
            {
                Id = escolaMachamba.Id,
                Designacao = escolaMachamba.Designacao,
                NumHomens = escolaMachamba.NumHomens,
                NumMulheres = escolaMachamba.NumMulheres,
                Metodologia = escolaMachamba.Metodologia,
                AreaEscola = escolaMachamba.AreaEscola,
                Localizacao = escolaMachamba.Localizacao,
                RemovedOn = escolaMachamba.RemovedOn,
                RemovedBy = escolaMachamba.RemovedBy,
                CreatedOn = escolaMachamba.CreatedOn,
                UpdatedOn = escolaMachamba.UpdatedOn,
                IsRemoved = escolaMachamba.IsRemoved,
                CreatedBy = escolaMachamba.CreatedBy,
                UpdatedBy = escolaMachamba.UpdatedBy
            };

        }
    }
}
