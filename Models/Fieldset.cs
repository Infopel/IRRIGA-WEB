using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    public partial class Fieldset
    {
        public Fieldset()
        {
            InqueritoPergunta = new HashSet<InqueritoPerguntum>();
            InqueritoResposta = new HashSet<InqueritoRespostum>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("label")]
        public string Label { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("idInquerito")]
        public Guid? IdInquerito { get; set; }
        [Column("fieldsetsOrder")]
        public int? FieldsetsOrder { get; set; }
        [Column("idPergunta")]
        public int? IdPergunta { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
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
        [Column("caracteristicasComponente")]
        public string CaracteristicasComponente { get; set; }
        [Column("isMobile")]
        public bool? IsMobile { get; set; }

        [ForeignKey(nameof(IdInquerito))]
        [InverseProperty(nameof(Inquerito.Fieldsets))]
        public virtual Inquerito IdInqueritoNavigation { get; set; }
        [InverseProperty(nameof(InqueritoPerguntum.IdFieldsetNavigation))]
        public virtual ICollection<InqueritoPerguntum> InqueritoPergunta { get; set; }
        [InverseProperty(nameof(InqueritoRespostum.IdFieldsetsNavigation))]
        public virtual ICollection<InqueritoRespostum> InqueritoResposta { get; set; }
    }
}
