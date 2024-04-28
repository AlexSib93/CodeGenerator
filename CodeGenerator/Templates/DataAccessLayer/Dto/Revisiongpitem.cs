using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_revisiongpitem_idpeople")]
    [Index("idrevisiongp", Name = "idx_revisiongpitem_idrevisiongp")]
    [Index("idrotoxhouse", Name = "idx_revisiongpitem_idrotoxhouse")]
    public partial class revisiongpitem
    {
        [Key]
        public int idrevisiongpitem { get; set; }
        public int idrevisiongp { get; set; }
        public int? idrotoxhouse { get; set; }
        public int? state { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcheck { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("revisiongpitem")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idrevisiongp")]
        [InverseProperty("revisiongpitem")]
        public virtual revisiongp idrevisiongpNavigation { get; set; } = null!;
        [ForeignKey("idrotoxhouse")]
        [InverseProperty("revisiongpitem")]
        public virtual rotoxhouse? idrotoxhouseNavigation { get; set; }
    }
}
