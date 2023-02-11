using IRRIGA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class FieldsetsRepository: IFieldsetsRepository
    {
        private readonly dbIRRIGAContext _context;
        public FieldsetsRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public IEnumerable<Fieldset> GetFieldsets(Guid IdInquerito, int Step)
        {
            return _context.Fieldsets
                .Where(f => f.IdInquerito == IdInquerito && f.Id == Step)
                .Include(i => i.InqueritoPergunta)
                    .ThenInclude(i => i.IdComponenteNavigation)
                .ToList();
        }
    }
}
