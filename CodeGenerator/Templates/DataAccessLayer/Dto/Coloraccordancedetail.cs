using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcoloraccordance", Name = "idx_coloraccordancedetail_idcoloraccordance")]
    [Index("idcolordest", Name = "idx_coloraccordancedetail_idcolordest")]
    [Index("idcolorsource", Name = "idx_coloraccordancedetail_idcolorsource")]
    [Index("idcolorsource2", Name = "idx_coloraccordancedetail_idcolorsource2")]
    public partial class coloraccordancedetail
    {
        [Key]
        public int idcoloraccordancedetail { get; set; }
        public int idcoloraccordance { get; set; }
        public int? idcolorsource { get; set; }
        public int? idcolordest { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcolorsource2 { get; set; }

        [ForeignKey("idcoloraccordance")]
        [InverseProperty("coloraccordancedetail")]
        public virtual coloraccordance idcoloraccordanceNavigation { get; set; } = null!;
        [ForeignKey("idcolordest")]
        [InverseProperty("coloraccordancedetailidcolordestNavigation")]
        public virtual color? idcolordestNavigation { get; set; }
        [ForeignKey("idcolorsource2")]
        [InverseProperty("coloraccordancedetailidcolorsource2Navigation")]
        public virtual color? idcolorsource2Navigation { get; set; }
        [ForeignKey("idcolorsource")]
        [InverseProperty("coloraccordancedetailidcolorsourceNavigation")]
        public virtual color? idcolorsourceNavigation { get; set; }
    }
}
