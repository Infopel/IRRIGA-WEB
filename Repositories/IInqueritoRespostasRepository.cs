using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IInqueritoRespostasRepository
    {
        Task<InqueritoRespostum> Create(InqueritoRespostum resposta);
        Task<InqueritoRespostum> SaveResponses(InqueritoRespostum responses);
        Task<ResponsesInquerito> GetResponsesId(ResponsesInquerito responses);
    }
}
