using IRRIGA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record DistrictsSync
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinciaId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class DistrictsMapper
    {
        public static DistrictsSync Map(District district)
        {
            return new DistrictsSync()
            {
                Id = district.Id,
                ProvinciaId = district.Id,
                Name = district.Name,
                CreatedOn = district.CreatedOn,
                RemovedOn = district.RemovedOn,
                UpdatedOn = district.UpdatedOn
            };

        }
    }
}
