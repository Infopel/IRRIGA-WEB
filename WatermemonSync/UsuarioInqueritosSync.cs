using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record UsuarioInqueritosSync
    {
        public int Id { get; set; }
        public Guid? UsuarioId { get; set; }
        public Guid? InqueritoId { get; set; }
        public bool? IsRemoved { get; set; }
        public string RemovedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }


    public class UsuarioInqueritosMapper
    {
        public static UsuarioInqueritosSync Map(UsuarioInquerito usuarioInquerito)
        {
            return new UsuarioInqueritosSync()
            {
                Id = usuarioInquerito.Id,
                UsuarioId = usuarioInquerito.IdUsuario,
                InqueritoId = usuarioInquerito.IdInquerito,
                IsRemoved = usuarioInquerito.IsRemoved,
                RemovedBy = usuarioInquerito.RemovedBy,
                CreatedOn = usuarioInquerito.CreatedOn,
                RemovedOn = usuarioInquerito.RemovedOn,
                UpdatedOn = usuarioInquerito.UpdatedOn,
                UpdatedBy = usuarioInquerito.UpdatedBy,
                CreatedBy = usuarioInquerito.CreatedBy
            };

        }
    }
}
