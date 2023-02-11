using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IRegadiosRepository
    {
        IEnumerable<Regadio> GetAll();
        IEnumerable<Regadio> GetAllRegadiosBy(Guid idAssociacao);
        IEnumerable<Regadio> GetRegadiosBy(int idProvincia);
        Task<Regadio> GetRegadioBy(Guid id);
        Task<Regadio> GetRegadioGuidIdBy(int  idForMobile);
    }
}
