using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record UsuariosSync
    {
        public Guid Id { get; set; }
        public string AspNetUserId { get; set; }
        public Guid? InqueritoId { get; set; }
        public Guid? RegadioId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public string RemovedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsRemoved { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
    public class UsuariosMapper
    {
        public static UsuariosSync Map(Usuario usuario)
        {
            return new UsuariosSync()
            {
                Id = usuario.Id,
                AspNetUserId = usuario.IdAspNetUser,
                InqueritoId = usuario.IdInquerito,
                RegadioId = usuario.IdRegadio,
                IsActive = usuario.IsActive,
                CreatedOn = usuario.CreatedOn,
                RemovedOn = usuario.RemovedOn,
                RemovedBy = usuario.RemovedBy,
                UpdatedOn = usuario.UpdatedOn,
                CreatedBy = usuario.CreatedBy,
                UpdatedBy = usuario.UpdatedBy,
                IsRemoved = usuario.IsRemoved
            };

        }
    }
}
