using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Dtos
{
    public record BeneficiariosMobileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdRegadio { get; set; }
        public bool IsActive { get; set; }
    }
}
