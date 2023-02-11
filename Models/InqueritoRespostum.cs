using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    public partial class InqueritoRespostum
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("idInquerito")]
        public Guid? IdInquerito { get; set; }
        [Column("idPergunta")]
        public int? IdPergunta { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("code")]
        [StringLength(50)]
        public string Code { get; set; }
        [Column("tipo")]
        public int? Tipo { get; set; }
        [Column("idResponses")]
        public Guid? IdResponses { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("idFieldsets")]
        public int? IdFieldsets { get; set; }
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
        [Column("approvedBy")]
        public string ApprovedBy { get; set; }
        [Column("approvedOn", TypeName = "datetime")]
        public DateTime? ApprovedOn { get; set; }

        [ForeignKey(nameof(IdFieldsets))]
        [InverseProperty(nameof(Fieldset.InqueritoResposta))]
        public virtual Fieldset IdFieldsetsNavigation { get; set; }
        [ForeignKey(nameof(IdInquerito))]
        [InverseProperty(nameof(Inquerito.InqueritoResposta))]
        public virtual Inquerito IdInqueritoNavigation { get; set; }
        [ForeignKey(nameof(IdPergunta))]
        [InverseProperty(nameof(InqueritoPerguntum.InqueritoResposta))]
        public virtual InqueritoPerguntum IdPerguntaNavigation { get; set; }
        [ForeignKey(nameof(IdResponses))]
        [InverseProperty(nameof(ResponsesInquerito.InqueritoResposta))]
        public virtual ResponsesInquerito IdResponsesNavigation { get; set; }
    }
}
