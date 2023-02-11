using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Dtos
{
    public record ResponsesMobileDto
    {
        public string User { get; set; }
        public string FormId { get; set; }
        public string CreatedOn { get; set; }
        public int Version { get; set; }
        public ICollection<Responses> Responses { get; set; }
    }
    public record Responses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string [] Value { get; set; }

    }
}
