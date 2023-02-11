using IRRIGA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class ResponsesInqueritoRepository:IResponsesInqueritoRepository
    {
        private readonly dbIRRIGAContext _context;
        public ResponsesInqueritoRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public async Task<ResponsesInquerito> Create(ResponsesInquerito responses)
        {
            _context.ResponsesInqueritos.Add(responses);
            await _context.SaveChangesAsync();

            return responses;
        }

        public IEnumerable<ResponsesInquerito> GetAll()
        {
            return _context.ResponsesInqueritos
                    .ToList();
        }

        public async Task<ResponsesInquerito> GetLastResponse()
        {
            try
            {
                return await _context.ResponsesInqueritos
                    .OrderByDescending(r => r.IdForMobile)
                    .FirstAsync();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<ResponsesInquerito> GetResponse(string formId)
        {
            return _context.ResponsesInqueritos
                .Where(r => r.IdInquerito == Guid.Parse(formId))
                .Include(r => r.InqueritoResposta)
                    .ThenInclude(r => r.IdPerguntaNavigation)
                .ToList();
        }
    }
}
