using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioAssociacos = new HashSet<UsuarioAssociaco>();
            UsuarioEscolas = new HashSet<UsuarioEscola>();
            UsuarioInqueritos = new HashSet<UsuarioInquerito>();
            UsuarioRegadios = new HashSet<UsuarioRegadio>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("idAspNetUser")]
        [StringLength(450)]
        public string IdAspNetUser { get; set; }
        [Column("idInquerito")]
        public Guid? IdInquerito { get; set; }
        [Column("stepInquerito")]
        public int? StepInquerito { get; set; }
        [Column("idRegadio")]
        public Guid? IdRegadio { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("removedBy")]
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [Column("idForMobile")]
        public int? IdForMobile { get; set; }
        [Column("idAssociacao")]
        public Guid? IdAssociacao { get; set; }
        [Column("idEscola")]
        public Guid? IdEscola { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("updatedBy")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column("createdBy")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("isRemoved")]
        public bool? IsRemoved { get; set; }

        [ForeignKey(nameof(IdAssociacao))]
        [InverseProperty(nameof(Associacao.Usuarios))]
        public virtual Associacao IdAssociacaoNavigation { get; set; }
        [ForeignKey(nameof(IdRegadio))]
        [InverseProperty(nameof(Regadio.Usuarios))]
        public virtual Regadio IdRegadioNavigation { get; set; }
        [InverseProperty(nameof(UsuarioAssociaco.IdUsuarioNavigation))]
        public virtual ICollection<UsuarioAssociaco> UsuarioAssociacos { get; set; }
        [InverseProperty(nameof(UsuarioEscola.IdUsuarioNavigation))]
        public virtual ICollection<UsuarioEscola> UsuarioEscolas { get; set; }
        [InverseProperty(nameof(UsuarioInquerito.IdUsuarioNavigation))]
        public virtual ICollection<UsuarioInquerito> UsuarioInqueritos { get; set; }
        [InverseProperty(nameof(UsuarioRegadio.IdUsuarioNavigation))]
        public virtual ICollection<UsuarioRegadio> UsuarioRegadios { get; set; }
    }
}
