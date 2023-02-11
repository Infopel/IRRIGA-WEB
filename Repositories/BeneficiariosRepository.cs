using IRRIGA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class BeneficiariosRepository:IBeneficiariosRepository
    {
        private readonly dbIRRIGAContext _context;
        public BeneficiariosRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public async Task<Beneficiario> Create(Beneficiario benificiario)
        {
            _context.Beneficiarios.Add(benificiario);
            await _context.SaveChangesAsync();

            return benificiario;
        }
        public IEnumerable<Beneficiario> GetAllBeneficiariosBy(Guid idRegadio)
        {
            return _context.Beneficiarios
                .Where(b => b.IdRegadio == idRegadio && b.RemovedOn == null)
                .ToList();
        }
    }
}
