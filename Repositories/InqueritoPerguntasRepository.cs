using IRRIGA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class InqueritoPerguntasRepository: IInqueritoPerguntasRepository
    {
        private readonly dbIRRIGAContext _context;
        public InqueritoPerguntasRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public IEnumerable<InqueritoPerguntum> GetPerguntasBy(Guid IdInquerito, int Step)
        {
            try { 
                return _context.InqueritoPergunta
                    .Where(f => f.IdInquerito == IdInquerito && f.IdFieldset == Step)
                        .Include(i => i.IdComponenteNavigation)
                        .Include(i => i.PerguntaOpcaos)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
}
    }
}
