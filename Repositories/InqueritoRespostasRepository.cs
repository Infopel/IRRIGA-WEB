using IRRIGA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class InqueritoRespostasRepository : IInqueritoRespostasRepository
    {
        private readonly dbIRRIGAContext _context;
        public InqueritoRespostasRepository(dbIRRIGAContext context)
        {
            _context = context;
        }
        public async Task<InqueritoRespostum> Create(InqueritoRespostum resposta)
        {
            _context.InqueritoResposta.Add(resposta);
            await _context.SaveChangesAsync();

            return resposta;
        }
        public async Task<ResponsesInquerito> GetResponsesId(ResponsesInquerito responses)
        {
            _context.ResponsesInqueritos.Add(responses);
            await _context.SaveChangesAsync();

            return responses;
        }

        public async Task<InqueritoRespostum> SaveResponses(InqueritoRespostum responses)
        {
            _context.InqueritoResposta.Add(responses);
            await _context.SaveChangesAsync();

            return responses;
        }
    }
}
