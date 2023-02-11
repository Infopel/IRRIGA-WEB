using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IOpcoesPerguntaRepository
    {
        IEnumerable<PerguntaOpcao> GetAllOpcoesBy(int idPergunta);
    }
}
