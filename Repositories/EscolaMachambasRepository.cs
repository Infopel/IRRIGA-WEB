using IRRIGA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class EscolaMachambasRepository:IEscolaMachambasRepository
    {
        private readonly dbIRRIGAContext _context;
        public EscolaMachambasRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public async Task<EscolaMachamba> Create(EscolaMachamba escola)
        {
            _context.EscolaMachambas.Add(escola);
            await _context.SaveChangesAsync();

            return escola;
        }
        public IEnumerable<EscolaMachamba> GetAll()
        {
            return _context.EscolaMachambas
                .Where(a => a.RemovedOn == null)
                .ToList();
        }

        public async Task<EscolaMachamba> GetEscolaBy(Guid id)
        {
            try
            {
                return await _context.EscolaMachambas
                    .Where(e => e.Id == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
