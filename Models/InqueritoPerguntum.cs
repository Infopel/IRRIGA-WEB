using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    public partial class InqueritoPerguntum
    {
        public InqueritoPerguntum()
        {
            InqueritoResposta = new HashSet<InqueritoRespostum>();
            PerguntaOpcaos = new HashSet<PerguntaOpcao>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("idInquerito")]
        public Guid? IdInquerito { get; set; }
        [Column("idComponente")]
        public int? IdComponente { get; set; }
        [Column("validacaoComponente")]
        public string ValidacaoComponente { get; set; }
        [Column("caracteristicasComponente")]
        public string CaracteristicasComponente { get; set; }
        [Column("questionOrder")]
        public int? QuestionOrder { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("updateOn", TypeName = "datetime")]
        public DateTime? UpdateOn { get; set; }
        [Column("removedBy")]
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [Column("updatedBy")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column("idFieldset")]
        public int? IdFieldset { get; set; }
        [Column("idForm")]
        public Guid? IdForm { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("isRemoved")]
        public bool? IsRemoved { get; set; }
        [Column("createdBy")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("isMobile")]
        public bool? IsMobile { get; set; }

        [ForeignKey(nameof(IdComponente))]
        [InverseProperty(nameof(Componente.InqueritoPergunta))]
        public virtual Componente IdComponenteNavigation { get; set; }
        [ForeignKey(nameof(IdFieldset))]
        [InverseProperty(nameof(Fieldset.InqueritoPergunta))]
        public virtual Fieldset IdFieldsetNavigation { get; set; }
        [ForeignKey(nameof(IdInquerito))]
        [InverseProperty(nameof(Inquerito.InqueritoPergunta))]
        public virtual Inquerito IdInqueritoNavigation { get; set; }
        [InverseProperty(nameof(InqueritoRespostum.IdPerguntaNavigation))]
        public virtual ICollection<InqueritoRespostum> InqueritoResposta { get; set; }
        [InverseProperty(nameof(PerguntaOpcao.IdPerguntaNavigation))]
        public virtual ICollection<PerguntaOpcao> PerguntaOpcaos { get; set; }
    }
}
