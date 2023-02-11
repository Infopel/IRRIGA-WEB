using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IProvincesRepository
    {
        IEnumerable<Province> GetAll();
        IEnumerable<District> GetDistrictsBy( int idProvincia);
    }
}
