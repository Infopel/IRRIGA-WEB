using IRRIGA.Data;
using IRRIGA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class InqueritosRepository: IInqueritosRepository
    {
        private readonly dbIRRIGAContext _context;
        public InqueritosRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public IEnumerable<Inquerito> GetAll()
        {
            return _context.Inqueritos
                .Where(i => i.IdInqueritoPai == null && i.RemovedOn == null)
                .ToList();
        }

        public async Task<IEnumerable<Inquerito>> GetInquerito(Guid IdInquerito)
        {
            return await _context.Inqueritos
                .Where(i => i.Id == IdInquerito)
                .Include(i => i.Fieldsets)
                    .ThenInclude(i => i.InqueritoPergunta)
                .Include(i => i.InqueritoPergunta)
                    .ThenInclude(i => i.IdComponenteNavigation)
                .ToListAsync();
        }

        public IEnumerable<SubInquerito> GetInqueritoBy(Guid Id)
        {
            return _context.SubInqueritos
                .Where(i => i.IdInquerito == Id && i.IsRemoved == false && i.IdSubInqueritoNavigation.RemovedOn == null)
                .OrderBy(i => i.OrderInquerito)
                .Include( i => i.IdSubInqueritoNavigation)
                .ThenInclude(i => i.Fieldsets)
                    .ThenInclude(i => i.InqueritoPergunta)
                    .ThenInclude(i => i.IdComponenteNavigation)
                .ToList();
        }

        public async Task<Inquerito> GetInqueritoTaskBy(string inqueritoNome)
        {
            try
            {
                return await _context.Inqueritos
                  .Where(i => i.Designacao == inqueritoNome && i.RemovedOn == null)
                  .FirstAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Inquerito> GetInqueritoUserBy(Guid idInquerito)
        {
            return await _context.Inqueritos
               .Where(i => i.Id == idInquerito && i.RemovedOn == null)
               .FirstAsync();
        }
    }
}
