using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("AssociacaoRegadio")]
    public partial class AssociacaoRegadio
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idAssociacao")]
        public Guid? IdAssociacao { get; set; }
        [Column("idRegadio")]
        public Guid? IdRegadio { get; set; }
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
        [InverseProperty(nameof(Associacao.AssociacaoRegadios))]
        public virtual Associacao IdAssociacaoNavigation { get; set; }
        [ForeignKey(nameof(IdRegadio))]
        [InverseProperty(nameof(Regadio.AssociacaoRegadios))]
        public virtual Regadio IdRegadioNavigation { get; set; }
    }
}
