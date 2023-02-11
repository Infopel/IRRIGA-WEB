using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record UsuarioAssociacoesSync
    {
        public int Id { get; set; }
        public Guid? UsuarioId { get; set; }
        public Guid? AssociacaoId { get; set; }
        public bool? IsRemoved { get; set; }
        public string RemovedBy { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
    public class UsuarioAssociacoesMapper
    {
        public static UsuarioAssociacoesSync Map(UsuarioAssociaco usuarioAssociaco)
        {
            return new UsuarioAssociacoesSync()
            {
                Id = usuarioAssociaco.Id,
                UsuarioId = usuarioAssociaco.IdUsuario,
                AssociacaoId = usuarioAssociaco.IdAssociacao,
                IsRemoved = usuarioAssociaco.IsRemoved,
                RemovedBy = usuarioAssociaco.RemovedBy,
                RemovedOn = usuarioAssociaco.RemovedOn,
                CreatedOn = usuarioAssociaco.CreatedOn,
                UpdatedOn = usuarioAssociaco.UpdatedOn,
                UpdatedBy = usuarioAssociaco.UpdatedBy,
                CreatedBy = usuarioAssociaco.CreatedBy
            };

        }
    }
}
