using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("ResponsesInquerito")]
    public partial class ResponsesInquerito
    {
        public ResponsesInquerito()
        {
            InqueritoResposta = new HashSet<InqueritoRespostum>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("idInquerito")]
        public Guid? IdInquerito { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("idForMobile")]
        public int? IdForMobile { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("lastStep")]
        public int? LastStep { get; set; }
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
        [Column("idBeneficiario")]
        public Guid? IdBeneficiario { get; set; }
        [Column("idRegadio")]
        public Guid? IdRegadio { get; set; }
        [Column("idEscola")]
        public Guid? IdEscola { get; set; }
        [Column("idResponsesPai")]
        public Guid? IdResponsesPai { get; set; }
        [Column("idInqueritoPai")]
        public Guid? IdInqueritoPai { get; set; }
        [Column("approvedBy")]
        public string ApprovedBy { get; set; }
        [Column("approvedOn", TypeName = "datetime")]
        public DateTime? ApprovedOn { get; set; }

        [ForeignKey(nameof(IdBeneficiario))]
        [InverseProperty(nameof(Beneficiario.ResponsesInqueritos))]
        public virtual Beneficiario IdBeneficiarioNavigation { get; set; }
        [ForeignKey(nameof(IdEscola))]
        [InverseProperty(nameof(EscolaMachamba.ResponsesInqueritos))]
        public virtual EscolaMachamba IdEscolaNavigation { get; set; }
        [ForeignKey(nameof(IdInquerito))]
        [InverseProperty(nameof(Inquerito.ResponsesInqueritos))]
        public virtual Inquerito IdInqueritoNavigation { get; set; }
        [ForeignKey(nameof(IdRegadio))]
        [InverseProperty(nameof(Regadio.ResponsesInqueritos))]
        public virtual Regadio IdRegadioNavigation { get; set; }
        [InverseProperty(nameof(InqueritoRespostum.IdResponsesNavigation))]
        public virtual ICollection<InqueritoRespostum> InqueritoResposta { get; set; }
    }
}
