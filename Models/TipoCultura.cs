using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("TipoCultura")]
    public partial class TipoCultura
    {
        public TipoCultura()
        {
            Culturas = new HashSet<Cultura>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("designacao")]
        [StringLength(50)]
        public string Designacao { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
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
        [Column("removedBy")]
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [Column("isPrincipal")]
        public bool? IsPrincipal { get; set; }

        [InverseProperty(nameof(Cultura.IdTipoCulturaNavigation))]
        public virtual ICollection<Cultura> Culturas { get; set; }
    }
}
