using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    public partial class UsuarioInquerito
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idUsuario")]
        public Guid? IdUsuario { get; set; }
        [Column("idInquerito")]
        public Guid? IdInquerito { get; set; }
        [Column("isRemoved")]
        public bool? IsRemoved { get; set; }
        [Column("removedBy")]
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("updatedBy")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column("createdBy")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [ForeignKey(nameof(IdInquerito))]
        [InverseProperty(nameof(Inquerito.UsuarioInqueritos))]
        public virtual Inquerito IdInqueritoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.UsuarioInqueritos))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
