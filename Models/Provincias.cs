using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Models
{
    public record Provincias
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public List<Districts> Districts { get; set; }
    }
    public record Districts
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public record Provincia
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Districts> Districts { get; set; }
    }
}
