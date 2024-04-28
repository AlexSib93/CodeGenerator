using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddestanation", Name = "idx_destanationroute_iddestanation")]
    [Index("idroute", Name = "idx_destanationroute_idroute")]
    public partial class destanationroute
    {
        [Key]
        public int iddestanationroute { get; set; }
        public int iddestanation { get; set; }
        public int idroute { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? plantime { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? planmileage { get; set; }

        [ForeignKey("iddestanation")]
        [InverseProperty("destanationroute")]
        public virtual destanation iddestanationNavigation { get; set; } = null!;
        [ForeignKey("idroute")]
        [InverseProperty("destanationroute")]
        public virtual route idrouteNavigation { get; set; } = null!;
    }
}
