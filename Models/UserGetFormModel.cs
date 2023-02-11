using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Models
{
    public record UserGetFormModel
    {
        public Guid IdUser { get; set; }
        public Guid FormId { get; set; }
        public string Name { get; set; }
    }
}
