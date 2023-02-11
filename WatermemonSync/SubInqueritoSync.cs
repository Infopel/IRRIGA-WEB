using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record SubInqueritoSync
    {
        public int Id { get; set; }
        public Guid? InqueritoId { get; set; }
        public Guid? SubInqueritoId { get; set; }
        public bool? IsRemoved { get; set; }
        public string RemovedBy { get; set; }
        public int? InqueritoOrder { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
    public class SubInqueritoMapper
    {
        public static SubInqueritoSync Map(SubInquerito subInquerito)
        {
            return new SubInqueritoSync()
            {
                Id = subInquerito.Id,
                InqueritoId = subInquerito.IdInquerito,
                SubInqueritoId = subInquerito.IdSubInquerito,
                IsRemoved = subInquerito.IsRemoved,
                RemovedBy = subInquerito.RemovedBy,
                InqueritoOrder = subInquerito.OrderInquerito,
                CreatedOn = subInquerito.CreatedOn,
                RemovedOn = subInquerito.RemovedOn,
                UpdatedOn = subInquerito.UpdatedOn,
                CreatedBy = subInquerito.CreatedBy,
                UpdatedBy =  subInquerito.UpdatedBy

            };

        }
    }
}
