using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IFieldsetsRepository
    {
        IEnumerable<Fieldset> GetFieldsets(Guid IdInquerito, int Step);
    }
}
