using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record CulturaSync
    {
        public Guid Id { get; set; }
        public string Designacao { get; set; }
        public decimal? AreaCultivada { get; set; }
        public decimal? Redimento { get; set; }
        public Guid? TipoCulturaId { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsRemoved { get; set; }
        public string RemovedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsPrincipal { get; set; }
    }
    public class CulturaMapper
    {
        public static CulturaSync Map(Cultura cultura)
        {
            return new CulturaSync()
            {
                Id = cultura.Id,
                Designacao = cultura.Designacao,
                AreaCultivada = cultura.AreaCultivada,
                Redimento = cultura.Redimento,
                TipoCulturaId = cultura.IdTipoCultura,
                RemovedOn = cultura.RemovedOn,
                UpdatedOn = cultura.UpdatedOn,
                CreatedOn = cultura.CreatedOn,
                CreatedBy = cultura.CreatedBy,
                IsRemoved = cultura.IsRemoved,
                UpdatedBy = cultura.UpdatedBy,
                IsPrincipal = cultura.IsPrincipal
            };

        }
    }
}
