using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("Cultura")]
    public partial class Cultura
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("designacao")]
        public string Designacao { get; set; }
        [Column("areaCultivada", TypeName = "decimal(18, 0)")]
        public decimal? AreaCultivada { get; set; }
        [Column("redimento", TypeName = "decimal(18, 0)")]
        public decimal? Redimento { get; set; }
        [Column("idTipoCultura")]
        public Guid? IdTipoCultura { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
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
        [Column("removedBy")]
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [Column("isPrincipal")]
        public bool? IsPrincipal { get; set; }

        [ForeignKey(nameof(IdTipoCultura))]
        [InverseProperty(nameof(TipoCultura.Culturas))]
        public virtual TipoCultura IdTipoCulturaNavigation { get; set; }
    }
}
