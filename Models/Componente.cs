using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("Componente")]
    public partial class Componente
    {
        public Componente()
        {
            InqueritoPergunta = new HashSet<InqueritoPerguntum>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("designacao")]
        [StringLength(50)]
        public string Designacao { get; set; }
        [Column("caracteristicas")]
        public string Caracteristicas { get; set; }
        [Column("validacao")]
        public string Validacao { get; set; }

        [InverseProperty(nameof(InqueritoPerguntum.IdComponenteNavigation))]
        public virtual ICollection<InqueritoPerguntum> InqueritoPergunta { get; set; }
    }
}
