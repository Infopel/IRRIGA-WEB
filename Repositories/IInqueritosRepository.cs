using IRRIGA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IInqueritosRepository
    {
        IEnumerable<SubInquerito> GetInqueritoBy(Guid Id);
        IEnumerable<Inquerito> GetAll();
        Task<IEnumerable<Inquerito>> GetInquerito(Guid IdInquerito);
        Task<Inquerito> GetInqueritoTaskBy(String inqueritoNome);
        Task<Inquerito> GetInqueritoUserBy(Guid idInquerito);
    }
}
