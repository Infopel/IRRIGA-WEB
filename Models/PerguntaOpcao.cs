using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("PerguntaOpcao")]
    public partial class PerguntaOpcao
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idPergunta")]
        public int? IdPergunta { get; set; }
        [Column("descricao")]
        [StringLength(50)]
        public string Descricao { get; set; }
        [Column("idPaiOpcao")]
        public int? IdPaiOpcao { get; set; }
        [Column("idPaiPergunta")]
        public int? IdPaiPergunta { get; set; }
        [Column("isOpcao")]
        public bool? IsOpcao { get; set; }
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

        [ForeignKey(nameof(IdPergunta))]
        [InverseProperty(nameof(InqueritoPerguntum.PerguntaOpcaos))]
        public virtual InqueritoPerguntum IdPerguntaNavigation { get; set; }
    }
}
