using IRRIGA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class ProvincesRepository: IProvincesRepository
    {
        private readonly dbIRRIGAContext _context;
        public ProvincesRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public IEnumerable<Province> GetAll()
        {
            return _context.Provinces
                .Where(c => c.RemovedOn == null)
                .ToList();  
        }

        public IEnumerable<District> GetDistrictsBy(int idProvincia)
        {
            return _context.Districts
                    .Where(c => c.RemovedOn == null && c.IdProvincia == idProvincia)
                    .ToList();
        }
    }
}
