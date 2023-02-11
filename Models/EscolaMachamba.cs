using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("EscolaMachamba")]
    public partial class EscolaMachamba
    {
        public EscolaMachamba()
        {
            BeneficiarioEscolas = new HashSet<BeneficiarioEscola>();
            EscolaRegadios = new HashSet<EscolaRegadio>();
            ResponsesInqueritos = new HashSet<ResponsesInquerito>();
            UsuarioEscolas = new HashSet<UsuarioEscola>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("designacao")]
        [StringLength(50)]
        public string Designacao { get; set; }
        [Column("numHomens")]
        public int? NumHomens { get; set; }
        [Column("numMulheres")]
        public int? NumMulheres { get; set; }
        [Column("metodologia")]
        [StringLength(50)]
        public string Metodologia { get; set; }
        [Column("areaEscola", TypeName = "decimal(18, 2)")]
        public decimal? AreaEscola { get; set; }
        [Column("localizacao")]
        [StringLength(50)]
        public string Localizacao { get; set; }
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

        [InverseProperty(nameof(BeneficiarioEscola.IdEscolaNavigation))]
        public virtual ICollection<BeneficiarioEscola> BeneficiarioEscolas { get; set; }
        [InverseProperty(nameof(EscolaRegadio.IdEscolaNavigation))]
        public virtual ICollection<EscolaRegadio> EscolaRegadios { get; set; }
        [InverseProperty(nameof(ResponsesInquerito.IdEscolaNavigation))]
        public virtual ICollection<ResponsesInquerito> ResponsesInqueritos { get; set; }
        [InverseProperty(nameof(UsuarioEscola.IdEscolaNavigation))]
        public virtual ICollection<UsuarioEscola> UsuarioEscolas { get; set; }
    }
}
