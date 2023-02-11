using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IEscolaMachambasRepository
    {
        Task<EscolaMachamba> Create(EscolaMachamba escola);
        IEnumerable<EscolaMachamba> GetAll();
        Task<EscolaMachamba> GetEscolaBy(Guid id);
    }
}
