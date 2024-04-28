using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddestanation", Name = "idx_sellerdestanation_iddestanation")]
    [Index("idseller", Name = "idx_sellerdestanation_idseller")]
    public partial class sellerdestanation
    {
        [Key]
        public int idsellerdestanation { get; set; }
        public int? idseller { get; set; }
        public int? iddestanation { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("iddestanation")]
        [InverseProperty("sellerdestanation")]
        public virtual destanation? iddestanationNavigation { get; set; }
        [ForeignKey("idseller")]
        [InverseProperty("sellerdestanation")]
        public virtual seller? idsellerNavigation { get; set; }
    }
}
