using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("Inquerito")]
    public partial class Inquerito
    {
        public Inquerito()
        {
            Fieldsets = new HashSet<Fieldset>();
            InqueritoPergunta = new HashSet<InqueritoPerguntum>();
            InqueritoResposta = new HashSet<InqueritoRespostum>();
            ResponsesInqueritos = new HashSet<ResponsesInquerito>();
            SubInqueritoIdInqueritoNavigations = new HashSet<SubInquerito>();
            SubInqueritoIdSubInqueritoNavigations = new HashSet<SubInquerito>();
            UsuarioInqueritos = new HashSet<UsuarioInquerito>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("designacao")]
        [StringLength(50)]
        public string Designacao { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("idInqueritoPai")]
        public Guid? IdInqueritoPai { get; set; }
        [Column("versao")]
        public int? Versao { get; set; }
        [Column("createdBy")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("updatedBy")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("removedBy")]
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("isMobile")]
        public bool? IsMobile { get; set; }
        [Column("isPublished")]
        public bool? IsPublished { get; set; }
        [Column("publishedOn", TypeName = "datetime")]
        public DateTime? PublishedOn { get; set; }
        [Column("status")]
        public bool? Status { get; set; }
        [Column("step")]
        public int? Step { get; set; }
        [Column("isPrincipal")]
        public bool? IsPrincipal { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("idRegadio")]
        public Guid? IdRegadio { get; set; }

        [ForeignKey(nameof(IdRegadio))]
        [InverseProperty(nameof(Regadio.Inqueritos))]
        public virtual Regadio IdRegadioNavigation { get; set; }
        [InverseProperty(nameof(Fieldset.IdInqueritoNavigation))]
        public virtual ICollection<Fieldset> Fieldsets { get; set; }
        [InverseProperty(nameof(InqueritoPerguntum.IdInqueritoNavigation))]
        public virtual ICollection<InqueritoPerguntum> InqueritoPergunta { get; set; }
        [InverseProperty(nameof(InqueritoRespostum.IdInqueritoNavigation))]
        public virtual ICollection<InqueritoRespostum> InqueritoResposta { get; set; }
        [InverseProperty(nameof(ResponsesInquerito.IdInqueritoNavigation))]
        public virtual ICollection<ResponsesInquerito> ResponsesInqueritos { get; set; }
        [InverseProperty(nameof(SubInquerito.IdInqueritoNavigation))]
        public virtual ICollection<SubInquerito> SubInqueritoIdInqueritoNavigations { get; set; }
        [InverseProperty(nameof(SubInquerito.IdSubInqueritoNavigation))]
        public virtual ICollection<SubInquerito> SubInqueritoIdSubInqueritoNavigations { get; set; }
        [InverseProperty(nameof(UsuarioInquerito.IdInqueritoNavigation))]
        public virtual ICollection<UsuarioInquerito> UsuarioInqueritos { get; set; }
    }
}
