using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("Regadio")]
    public partial class Regadio
    {
        public Regadio()
        {
            AssociacaoRegadios = new HashSet<AssociacaoRegadio>();
            Beneficiarios = new HashSet<Beneficiario>();
            EscolaRegadios = new HashSet<EscolaRegadio>();
            Inqueritos = new HashSet<Inquerito>();
            ResponsesInqueritos = new HashSet<ResponsesInquerito>();
            UsuarioRegadios = new HashSet<UsuarioRegadio>();
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("codeRegadio")]
        [StringLength(50)]
        public string CodeRegadio { get; set; }
        [Column("localizacao")]
        [StringLength(50)]
        public string Localizacao { get; set; }
        [Column("designacao")]
        [StringLength(50)]
        public string Designacao { get; set; }
        [Column("idForMobile")]
        public int? IdForMobile { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("removedBy")]
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [Column("idAssociacao")]
        public Guid? IdAssociacao { get; set; }
        [Column("idEscola")]
        public Guid? IdEscola { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("isRemoved")]
        public bool? IsRemoved { get; set; }
        [Column("updatedBy")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column("createdBy")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("idProvincia")]
        public int? IdProvincia { get; set; }

        [InverseProperty(nameof(AssociacaoRegadio.IdRegadioNavigation))]
        public virtual ICollection<AssociacaoRegadio> AssociacaoRegadios { get; set; }
        [InverseProperty(nameof(Beneficiario.IdRegadioNavigation))]
        public virtual ICollection<Beneficiario> Beneficiarios { get; set; }
        [InverseProperty(nameof(EscolaRegadio.IdRegadioNavigation))]
        public virtual ICollection<EscolaRegadio> EscolaRegadios { get; set; }
        [InverseProperty(nameof(Inquerito.IdRegadioNavigation))]
        public virtual ICollection<Inquerito> Inqueritos { get; set; }
        [InverseProperty(nameof(ResponsesInquerito.IdRegadioNavigation))]
        public virtual ICollection<ResponsesInquerito> ResponsesInqueritos { get; set; }
        [InverseProperty(nameof(UsuarioRegadio.IdRegadioNavigation))]
        public virtual ICollection<UsuarioRegadio> UsuarioRegadios { get; set; }
        [InverseProperty(nameof(Usuario.IdRegadioNavigation))]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
