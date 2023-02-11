using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IInqueritoPerguntasRepository
    {
        IEnumerable<InqueritoPerguntum> GetPerguntasBy(Guid IdInquerito, int Step);
    }
}
