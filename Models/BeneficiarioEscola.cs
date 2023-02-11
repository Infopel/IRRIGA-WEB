using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    public partial class BeneficiarioEscola
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idBeneficiario")]
        public Guid? IdBeneficiario { get; set; }
        [Column("idEscola")]
        public Guid? IdEscola { get; set; }
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

        [ForeignKey(nameof(IdBeneficiario))]
        [InverseProperty(nameof(Beneficiario.BeneficiarioEscolas))]
        public virtual Beneficiario IdBeneficiarioNavigation { get; set; }
        [ForeignKey(nameof(IdEscola))]
        [InverseProperty(nameof(EscolaMachamba.BeneficiarioEscolas))]
        public virtual EscolaMachamba IdEscolaNavigation { get; set; }
    }
}
