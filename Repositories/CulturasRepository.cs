using IRRIGA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class CulturasRepository: ICulturasRepository
    {
        private readonly dbIRRIGAContext _context;
        public CulturasRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public async Task<Cultura> Create(Cultura cultura)
        {
            _context.Culturas.Add(cultura);
            await _context.SaveChangesAsync();

            return cultura;
        }

        public IEnumerable<Cultura> GetAll()
        {
            return _context.Culturas
                .Where(c => c.RemovedOn == null)
                .ToList();
        }

        public IEnumerable<TipoCultura> GetAllTipo()
        {
            return _context.TipoCulturas
                .Where(c => c.RemovedOn == null)
                .ToList();
        }
    }
}
