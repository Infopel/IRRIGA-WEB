using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IResponsesInqueritoRepository
    {
        Task<ResponsesInquerito> Create(ResponsesInquerito responses);
        IEnumerable<ResponsesInquerito> GetResponse (string formId);
        IEnumerable<ResponsesInquerito> GetAll ();
        Task<ResponsesInquerito> GetLastResponse();

    }
}
