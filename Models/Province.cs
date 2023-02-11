using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    public partial class Province
    {
        public Province()
        {
            Districts = new HashSet<District>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        [InverseProperty(nameof(District.IdProvinciaNavigation))]
        public virtual ICollection<District> Districts { get; set; }
    }
}
