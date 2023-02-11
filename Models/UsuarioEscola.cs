using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    public partial class UsuarioEscola
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idUsuario")]
        public Guid? IdUsuario { get; set; }
        [Column("idEscola")]
        public Guid? IdEscola { get; set; }
        [Column("isRemoved")]
        public bool? IsRemoved { get; set; }
        [Column("removedBy")]
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("updatedBy")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column("createdBy")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [ForeignKey(nameof(IdEscola))]
        [InverseProperty(nameof(EscolaMachamba.UsuarioEscolas))]
        public virtual EscolaMachamba IdEscolaNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.UsuarioEscolas))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
