using IRRIGA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class RegadiosRepository: IRegadiosRepository
    {
        private readonly dbIRRIGAContext _context;
        public RegadiosRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public IEnumerable<Regadio> GetAll()
        {
            return _context.Regadios
                .Where(i => i.RemovedOn == null)
                .ToList();
        }

        public IEnumerable<Regadio> GetAllRegadiosBy(Guid idAssociacao)
        {
             return _context.Regadios
            .Where(i => i.RemovedOn == null && i.IdAssociacao == idAssociacao)
            .ToList();
        }

        public async Task<Regadio> GetRegadioBy(Guid id)
        {
            try
            {
                return await _context.Regadios
                    .Where(r => r.Id == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Regadio> GetRegadioGuidIdBy(int idForMobile)
        {
            try
            {
                return await _context.Regadios
                    .Where(r => r.IdForMobile == idForMobile)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Regadio> GetRegadiosBy(int idProvincia)
        {
            return _context.Regadios
           .Where(i => i.RemovedOn == null && i.IdProvincia == idProvincia)
           .ToList();
        }
    }
}
