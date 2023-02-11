using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("MobileSync")]
    public partial class MobileSync
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("syncOn", TypeName = "datetime")]
        public DateTime? SyncOn { get; set; }
        [Column("syncedBy")]
        [StringLength(50)]
        public string SyncedBy { get; set; }
        [Column("deviceIMEI")]
        [StringLength(50)]
        public string DeviceImei { get; set; }
        [StringLength(50)]
        public string Tipo { get; set; }
    }
}
