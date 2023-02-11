using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IBeneficiariosRepository
    {
        Task<Beneficiario> Create(Beneficiario benificiario);
        IEnumerable<Beneficiario> GetAllBeneficiariosBy(Guid idRegadio);
    }
}
