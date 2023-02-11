using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IAssociacoesRespository
    {
        Task<Associacao> Create(Associacao associacao);
        Task<Associacao> GetAssociacaoGuidIdbBy(int idForMobile);
        Task<Associacao> GetAssociacaoBy(Guid id);
        IEnumerable<AssociacaoRegadio> GetAllAssociacaoBy(Guid idRegadio);
        IEnumerable<AssociacaoRegadio> GetAllRegadiosBy(Guid idAssocicacao);
        IEnumerable<Associacao> GetAll();
    }

}
