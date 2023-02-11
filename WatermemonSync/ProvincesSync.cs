
using IRRIGA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record ProvincesSync
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }

    public class ProvinciasMapper
    {
        public static ProvincesSync Map(Province provincias)
        {
            return new ProvincesSync()
            {
                Id = provincias.Id,
                Name = provincias.Name,
                CreatedOn = provincias.CreatedOn,
                RemovedOn = provincias.RemovedOn,
                UpdatedOn = provincias.UpdatedOn
            };

        }
    }
}
