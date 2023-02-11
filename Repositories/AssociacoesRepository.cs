using IRRIGA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class AssociacoesRepository:IAssociacoesRespository
    {
        private readonly dbIRRIGAContext _context;
        public AssociacoesRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public async Task<Associacao> Create(Associacao associacao)
        {
            _context.Associacaos.Add(associacao);
            await _context.SaveChangesAsync();

            return associacao;
        }
        public IEnumerable<AssociacaoRegadio> GetAllAssociacaoBy(Guid idRegadio)
        {
            return _context.AssociacaoRegadios
                .Where(a => a.IdRegadio == idRegadio && a.IsRemoved == false)
                .Include(a => a.IdAssociacaoNavigation)
                .Include(a => a.IdRegadioNavigation)
                .ToList();
        }

        public IEnumerable<Associacao> GetAll()
        {
            return _context.Associacaos
                .Where(a => a.RemovedOn == null)
                .ToList();
        }

        public async Task<Associacao> GetAssociacaoGuidIdbBy(int idForMobile)
        {
            try
            {
                return await _context.Associacaos
                  .Where(i => i.IdForMobile == idForMobile && i.RemovedOn == null)
                  .FirstAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Associacao> GetAssociacaoBy(Guid id)
        {
            try
            {
                return await _context.Associacaos
                    .Where(a => a.Id == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<AssociacaoRegadio> GetAllRegadiosBy(Guid idAssocicacao)
        {
            return _context.AssociacaoRegadios
                .Where(a => a.IdAssociacao == idAssocicacao && a.IsRemoved == false)
                .Include(a => a.IdAssociacaoNavigation)
                .Include(a => a.IdRegadioNavigation)
                .ToList();
        }
    }
}
