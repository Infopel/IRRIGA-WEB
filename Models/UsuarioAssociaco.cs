using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    public partial class UsuarioAssociaco
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idUsuario")]
        public Guid? IdUsuario { get; set; }
        [Column("idAssociacao")]
        public Guid? IdAssociacao { get; set; }
        [Column("isRemoved")]
        public bool? IsRemoved { get; set; }
        [Column("removedBy")]
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("updatedBy")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column("createdBy")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [ForeignKey(nameof(IdAssociacao))]
        [InverseProperty(nameof(Associacao.UsuarioAssociacos))]
        public virtual Associacao IdAssociacaoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.UsuarioAssociacos))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
