using IRRIGA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class OpcoesPerguntaRepository: IOpcoesPerguntaRepository
    {
        private readonly dbIRRIGAContext _context;
        public OpcoesPerguntaRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public IEnumerable<PerguntaOpcao> GetAllOpcoesBy(int idPergunta)
        {
            try
            {
                return _context.PerguntaOpcaos
                .Where(p => p.IdPergunta == idPergunta && p.IdPerguntaNavigation.RemovedOn == null)
                .Include(p => p.IdPerguntaNavigation)
                .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
