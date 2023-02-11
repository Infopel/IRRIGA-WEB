using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record TipoCulturaSync
    {
        public Guid Id { get; set; }
        public string Designacao { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsRemoved { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string RemovedBy { get; set; }
    }
    public class TipoCulturaMapper
    {
        public static TipoCulturaSync Map(TipoCultura tipoCultura)
        {
            return new TipoCulturaSync()
            {
                Id = tipoCultura.Id,
                Designacao = tipoCultura.Designacao,
                RemovedOn = tipoCultura.RemovedOn,
                CreatedOn = tipoCultura.CreatedOn,
                UpdatedOn = tipoCultura.UpdatedOn,
                IsRemoved = tipoCultura.IsRemoved,
                CreatedBy = tipoCultura.CreatedBy,
                UpdatedBy = tipoCultura.UpdatedBy
            };

        }
    }
}
