using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddestanation", Name = "idx_destanationseller_iddestanation")]
    [Index("idseller", Name = "idx_destanationseller_idseller")]
    public partial class destanationseller
    {
        [Key]
        public int iddestanationseller { get; set; }
        public int? iddestanation { get; set; }
        public int? idseller { get; set; }
        public short? numpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("iddestanation")]
        [InverseProperty("destanationseller")]
        public virtual destanation? iddestanationNavigation { get; set; }
        [ForeignKey("idseller")]
        [InverseProperty("destanationseller")]
        public virtual seller? idsellerNavigation { get; set; }
    }
}
