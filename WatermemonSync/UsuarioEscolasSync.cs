using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record UsuarioEscolasSync
    {
        public int Id { get; set; }
        public Guid? UsuarioId { get; set; }
        public Guid? EscolaId { get; set; }
        public bool? IsRemoved { get; set; }
        public string RemovedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
    public class UsuarioEscolasMapper
    {
        public static UsuarioEscolasSync Map(UsuarioEscola usuarioEscola)
        {
            return new UsuarioEscolasSync()
            {
                Id = usuarioEscola.Id,
                UsuarioId = usuarioEscola.IdUsuario,
                EscolaId = usuarioEscola.IdEscola,
                IsRemoved = usuarioEscola.IsRemoved,
                RemovedBy = usuarioEscola.RemovedBy,
                UpdatedOn = usuarioEscola.UpdatedOn,
                RemovedOn = usuarioEscola.RemovedOn,
                CreatedOn = usuarioEscola.CreatedOn,
                UpdatedBy = usuarioEscola.UpdatedBy,
                CreatedBy = usuarioEscola.CreatedBy
            };

        }
    }
}
