using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcarmarking", Name = "idx_carmarkingroute_idcarmarking")]
    [Index("idroute", Name = "idx_carmarkingroute_idroute")]
    public partial class carmarkingroute
    {
        [Key]
        public int idcarmarkingroute { get; set; }
        public int idcarmarking { get; set; }
        public int idroute { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? numpos { get; set; }

        [ForeignKey("idcarmarking")]
        [InverseProperty("carmarkingroute")]
        public virtual carmarking idcarmarkingNavigation { get; set; } = null!;
        [ForeignKey("idroute")]
        [InverseProperty("carmarkingroute")]
        public virtual route idrouteNavigation { get; set; } = null!;
    }
}
