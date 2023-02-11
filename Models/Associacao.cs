using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("Associacao")]
    public partial class Associacao
    {
        public Associacao()
        {
            AssociacaoRegadios = new HashSet<AssociacaoRegadio>();
            Beneficiarios = new HashSet<Beneficiario>();
            UsuarioAssociacos = new HashSet<UsuarioAssociaco>();
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("designacao")]
        [StringLength(50)]
        public string Designacao { get; set; }
        [Column("idRegadio")]
        public Guid? IdRegadio { get; set; }
        [Column("numMulheres")]
        public int? NumMulheres { get; set; }
        [Column("numHomens")]
        public int? NumHomens { get; set; }
        [Column("idForMobile")]
        public int? IdForMobile { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("removedBy")]
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("isRemoved")]
        public bool? IsRemoved { get; set; }
        [Column("updatedBy")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column("createdBy")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [InverseProperty(nameof(AssociacaoRegadio.IdAssociacaoNavigation))]
        public virtual ICollection<AssociacaoRegadio> AssociacaoRegadios { get; set; }
        [InverseProperty(nameof(Beneficiario.IdAssociacaoNavigation))]
        public virtual ICollection<Beneficiario> Beneficiarios { get; set; }
        [InverseProperty(nameof(UsuarioAssociaco.IdAssociacaoNavigation))]
        public virtual ICollection<UsuarioAssociaco> UsuarioAssociacos { get; set; }
        [InverseProperty(nameof(Usuario.IdAssociacaoNavigation))]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
