using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface ICulturasRepository
    {
        Task<Cultura> Create(Cultura cultura);
        IEnumerable<Cultura> GetAll();
        IEnumerable<TipoCultura> GetAllTipo();
        
    }
}
