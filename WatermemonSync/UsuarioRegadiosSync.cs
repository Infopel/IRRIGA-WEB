using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record UsuarioRegadiosSync
    {
        public int Id { get; set; }
        public Guid? UsuarioId { get; set; }
        public Guid? RegadioId { get; set; }
        public bool? IsRemoved { get; set; }
        public string RemovedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }


    public class UsuarioRegadiosMapper
    {
        public static UsuarioRegadiosSync Map(UsuarioRegadio usuarioRegadio)
        {
            return new UsuarioRegadiosSync()
            {
                Id = usuarioRegadio.Id,
                UsuarioId = usuarioRegadio.IdUsuario,
                RegadioId = usuarioRegadio.IdRegadio,
                IsRemoved = usuarioRegadio.IsRemoved,
                RemovedBy = usuarioRegadio.RemovedBy,
                CreatedOn = usuarioRegadio.CreatedOn,
                RemovedOn = usuarioRegadio.RemovedOn,
                UpdatedOn = usuarioRegadio.UpdatedOn,
                UpdatedBy = usuarioRegadio.UpdatedBy,
                CreatedBy = usuarioRegadio.CreatedBy
            };

        }
    }
}
