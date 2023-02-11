using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("LogApp")]
    public partial class LogApp
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idUser")]
        public string IdUser { get; set; }
        [Column("local")]
        public string Local { get; set; }
        [Column("acao")]
        public string Acao { get; set; }
        [Column("idInquerito")]
        public Guid? IdInquerito { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
    }
}
